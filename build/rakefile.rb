require 'albacore'
require 'fileutils'

@solutions = []
@unit_tests = []
@acceptance_tests = []
@service_specs = []
@custom_specs = []
@assembly_info = ''
@assembly_company_name = ''
@assembly_description = ''
@config = {
	:xunit_executable => '../tools/xunit/xunit.console.clr4.exe',
	:artifact_folder => 'artifacts',
	:nuget => {
		:specs_folder => 'nuget/specs',
		:package_folder => 'nuget/packages',
		:prefix => '',
		:executable => '../tools/nuget/nuget.exe',
	},
	:octupus => {
  		:server => 'http://dev.octopus/api',
  		:apiKey => 'API-ONI3VWBDTIWUFPOJOJIOMOC7AZA'
 	}
}

# CONFIG #
Albacore.configure do |config|
	config.msbuild.targets = [:clean, :build]
	config.msbuild.properties = {
									:configuration => :Release,
									:documentationFile => "bin/iBroker.Api.XML",
									:nowarn => 1591
								}
	config.msbuild.verbosity = "minimal"

	config.xunit.command = @config[:xunit_executable]
end

class Include
	def initialize(pattern, to)
		self.pattern = pattern
		self.to = to
	end

	attr_accessor :pattern, :to

	def to_s
		"Include: Pattern: #{pattern}, To: #{to}"
	end
end

class Dependency
	def initialize(id, version)
		self.id = id
		self.version = version
	end

	attr_accessor :id, :version

	def to_s
		"Dependency: Id: #{id}, Version: #{version}"
	end
end

class SingleBuildConfig
	def initialize(name, folder, author, deploy, description, version, deployment_project)
		self.name = name
		self.folder = folder
		self.author = author
		self.deploy = deploy
		self.description = description
		self.deployment_project = deployment_project
		self.version = version
		self.includes = []
		self.dependencies = []		
	end

	attr_accessor :name, :folder, :author, :deploy, :description, :includes, :dependencies, :version, :deployment_project

	def to_s
		"Name: #{name},\nFolder: #{folder},\nAuthor: #{author},\nDeploy: #{deploy},\nDescription: #{description},\nDeploymentProject: #{deployment_project}"
	end
end

class BuildConfig
	def initialize
		@configs = Array.new
	end

	def Configs
		@configs
	end
end

# VERSIONING #
def get_version

  if ENV['BUILD_NUMBER'].nil?
	'0.0.0.1'
  else
	"#{ENV['BUILD_NUMBER']}"
  end
end

def custom_build
	custom_build_file = File.join("build.xml")

	return File.exists?(custom_build_file)
end

namespace :environment do
	task :default => ['specs', 'artifact_folder'] do
	end

	task :artifact_folder do
		puts "Removing and adding #{@config[:artifact_folder]}"
		if !File.directory?(@config[:artifact_folder])
			FileUtils.mkdir_p @config[:artifact_folder]
		end
		Dir.glob(File.join(Dir.pwd, @config[:artifact_folder], "/*.*")).each { |f| File.delete f }
	end

	task :specs do
		puts "Removing and adding #{@config[:nuget][:specs_folder]}"
		if !File.directory?(@config[:nuget][:specs_folder])
			FileUtils.mkdir_p @config[:nuget][:specs_folder]
		end
		Dir.glob(File.join(Dir.pwd, @config[:nuget][:specs_folder], "/*.*")).each { |f| File.delete f }


		puts "Removing and adding #{@config[:nuget][:package_folder]}"
		if !File.directory?(@config[:nuget][:package_folder])
			FileUtils.mkdir_p @config[:nuget][:package_folder]
		end
		Dir.glob(File.join(Dir.pwd, @config[:nuget][:package_folder], "/*.*")).each { |f| File.delete f }
	end
end

# BUILD #
namespace :build do
	task :default => ['convention:before_build', 'versioning:default', :build_solutions] do
	end

	task :build_solutions do
		puts "Found #{@solutions.length} solutions to build"
		@solutions.each do |solution|
			puts "Building #{solution}"
			msb = MSBuild.new
			msb.solution = solution
			msb.execute
		end
	end
end

# TESTING #
namespace :testing do
	task :unit => ['convention:after_build', :unit_tests]
	task :acceptance => ['convention:after_build', :update_config, :acceptance_tests]

	task :unit_tests do
		puts "Found #{@unit_tests.length} unit test assemblies to run"
		@unit_tests.each do |assembly|
			puts "Running unit tests in #{assembly}"
			xunit = XUnitTestRunner.new
			xunit.assembly = assembly
			xunit.execute
		end
	end

	task :acceptance_tests do
		puts "Found #{@acceptance_tests.length} acceptance test assemblies to run"
		@acceptance_tests.each do |assembly|
			puts "Running acceptance tests in #{assembly}"
			xunit = XUnitTestRunner.new
			xunit.assembly = assembly
			xunit.execute
		end
	end

	task :update_config do
		@acceptance_tests.each do |assembly|
			current_folder = Dir.pwd
			base_folder = File.dirname(assembly)
			configuration_folder = File.join(base_folder, "Configuration")

			if File.directory?(configuration_folder)
				Dir.chdir configuration_folder
				puts "Found a configuration folder at #{configuration_folder}"

				Dir.glob("*.config") do |f|
					puts "Found file #{f}"

					environment, *config_name = f.split(".")
					if environment.downcase.index("development")
						File.rename f, config_name.join('.')
						FileUtils.cp config_name.join('.'), '..\\'
					end
				end
				Dir.chdir current_folder
			end
		end
	end
end

# PACKAGE #
namespace :package do
	task :default => [:specs, :pack, :zip] do
	end

	task :specs => ['convention:spec_generation'] do
		@settings.Configs.each do |c|

			output_file = "#{c.name}.#{get_version()}.nuspec"
			nuspec_file = File.join(Dir.pwd, @config[:nuget][:specs_folder], output_file)

			nuspec = Nuspec.new
			nuspec.id = c.name
			nuspec.version = c.version
			nuspec.authors = c.author
			nuspec.description = c.description
			nuspec.title = c.name
			nuspec.output_file = nuspec_file

			c.includes.each do |i|
				nuspec.file i.pattern, i.to
			end

			c.dependencies.each do |d|
				nuspec.dependency d.id, d.version == nil ? "" : d.version
			end

			puts "Creating spec file at #{nuspec_file} for #{c.folder}"
			nuspec.execute
		end
	end

	task :pack do
		puts "#{@settings.Configs.length} nuspec definitions to pack"

		build_folder = Dir.pwd
		package_folder = File.join(Dir.pwd, @config[:nuget][:package_folder])

		@settings.Configs.each do |c|
			folder = "../#{c.folder}"
			spec_file = "#{c.name}.#{get_version()}.nuspec"
			spec_file_location = File.join(Dir.pwd, @config[:nuget][:specs_folder], spec_file)
			base_path = File.join(folder, 'bin/release')

			if !File.exists?(base_path)
				base_path = folder
			end
			puts "Packing '#{spec_file_location}' in '#{base_path}' with output directory '#{package_folder}'"

			nuget_parameters = "pack #{spec_file_location} -OutputDirectory #{package_folder} -BasePath #{base_path} -Version #{get_version()} -Properties Configuration=Release"
			cmd = Exec.new
			cmd.command = @config[:nuget][:executable]
			cmd.parameters = nuget_parameters
			cmd.execute
		end
	end

	task :zip do
		puts "#{(@settings.Configs).length} apps to zip found"

		@settings.Configs.each do |c|
			folder = "../#{c.folder}"
			spec_file = "#{c.name}.#{get_version()}.nuspec"
			spec_file_location = File.join(Dir.pwd, @config[:nuget][:specs_folder], spec_file)
			base_path = File.join(folder, 'bin/release')

			if !File.exists?(base_path)
				base_path = folder
			end
			puts "Zipping '#{folder}' as '#{c.name}.zip' to '#{@config[:artifact_folder]}'"

			zip = ZipDirectory.new

			if File.directory?(@config[:artifact_folder])
				zip.directories_to_zip = folder
				zip.output_file = "#{c.name}.zip"
				zip.output_path = @config[:artifact_folder]
				zip.execute
			end

			zip = nil
		end
	end
end

# DEPLOY #
namespace :deploy do
	task :default do
		@settings.Configs.each do |c|
			if c.deploy
				puts "Deploying #{c.folder} to project #{c.folder} with version number #{get_version}"
				cmd = Exec.new
				cmd.command = '../tools/octopus/Octo.exe'
				cmd.parameters = 'create-release --force --waitfordeployment --deployto=TeamCity --version=' + get_version() + ' --server=' + @config[:octupus][:server] + ' --project=' + c.deployment_project + ' --apiKey=' + @config[:octupus][:apiKey]
				cmd.execute
			end
		end
	end

	task :to_test => ['convention:spec_generation', 'deploy:deploy_to_test'] do
	end

	task :deploy_to_test do
		@settings.Configs.each do |c|
			if c.deploy
				puts "Deploying #{c.folder} to project #{c.folder} with version number #{get_version}"
				cmd = Exec.new
				cmd.command = '../tools/octopus/Octo.exe'
				cmd.parameters = 'create-release --force --waitfordeployment --deployto=Test --version=' + get_version() + ' --server=' + @config[:octupus][:server] + ' --project=' + c.folder + ' --apiKey=' + @config[:octupus][:apiKey]
				cmd.execute
			end
		end
	end
end

# CONVENTIONS #
namespace :convention do
	task :before_build => [:solutions, :assembly_info] do

	end

	task :after_build => [:tests, :spec_generation] do
	end

	task :assembly_info do
		@assembly_info = Dir.glob("../**/AssemblyInfo.cs")[0]
		puts "Found an AssemblyInfo.cs file at '#{@assembly_info}'"
	end

	task :spec_generation do

		@settings = BuildConfig.new

		build_config = File.join("build.xml")

		xml = File.read(build_config)
		doc, package_folders = REXML::Document.new(xml), []
		doc.elements.each('build/nugets/nuget') do |p|

			@current = SingleBuildConfig.new(
				p.get_elements("name")[0].text,
				p.get_elements("folder")[0].text,
				p.get_elements("author")[0].text,
				p.attributes["deploy"] == nil ? false : p.attributes["deploy"] == "true" ? true : false,
				p.get_elements("description")[0].text,
				get_version(),
				p.get_elements("deploymentProject")[0] == nil ? "" : p.get_elements("deploymentProject")[0].text)

			p.get_elements('includes/*').each do |e|
				@current.includes << Include.new(e.attributes["pattern"], e.attributes["to"])
			end

			p.get_elements('dependencies/*').each do |e|
				@current.dependencies << Dependency.new(e.attributes["id"], e.attributes["version"])
			end

			#@custom_specs << "../app/#{folder_name}"
			@settings.Configs << @current
		end

		puts "BUILD CONFIG"
		counter = 1
		@settings.Configs.each do |c|
			puts "Item #{counter} "
			puts "#{c}"
			c.includes.each do |i|
				puts "#{i}"
			end
			c.dependencies.each do |d|
				puts "#{d}"
			end
			counter = counter + 1
		end
	end

	task :tests do
		@unit_tests = []
		@acceptance_tests = []

		potential_tests = Dir.glob("../**/*.Tests.dll")
		puts "Found #{potential_tests.length} test assemblies"

		potential_tests.each do |test_assembly|
			puts "Potential test assembly '#{test_assembly}'"
			if test_assembly.downcase.index("libs") == nil && # ignore lib tests
				test_assembly.downcase.index("bin/release") != nil # only release build tests

				@unit_tests << test_assembly unless test_assembly.downcase.index("acceptance") != nil || test_assembly.downcase.index("infrastructure") != nil

				@acceptance_tests << test_assembly if test_assembly.downcase.index("acceptance") != nil || test_assembly.downcase.index("infrastructure") != nil
			else
				puts "Ignoring #{test_assembly} as a test assembly."
			end
		end

		puts "#{@unit_tests.length} unit test assemblies have been found."
		puts "#{@acceptance_tests.length} acceptance test assemblies have been found."
	end

	task :solutions do
		Dir.glob('../**/*.sln').each do |solution_file|
			if solution_file.index("libs") == nil
				@solutions << solution_file
			else
				puts "Ignoring #{solution_file} as a solution file to build"
			end
		end

		puts "#{@solutions.length} solutions found"
	end
end

namespace :versioning do
	task :default => [:assemblyinfo] do
	end

	task :assemblyinfo do
		if @assembly_info == nil
			puts "Could not find an assemblyinfo.cs file"
		else
			puts "Updating #{@assembly_info} with the latest version"
			File.open(@assembly_info, 'r') do |file|
				file.readlines.each do | line |
					if line.downcase.index("assemblycompany") != nil
						@assembly_company_name = /([""'])(?:(?=(\\?))\2.)*?\1/.match(line).to_s.gsub( /\A"/m, "" ).gsub( /"\Z/m, "" )
					end
					if line.downcase.index("assemblydescription") != nil
						@assembly_description = /([""'])(?:(?=(\\?))\2.)*?\1/.match(line).to_s.gsub( /\A"/m, "" ).gsub( /"\Z/m, "" )
					end
				end
			end

			asm = AssemblyInfo.new
			asm.version = get_version()
			asm.output_file = @assembly_info
			asm.company_name = @assembly_company_name
			asm.description = @assembly_description
			asm.execute
		end
	end
end

task :team_city => [
	'environment:default',
	'build:default',
	'testing:unit',
	'package:default'
	] do
end

task :test => ['convention:spec_generation']

task :acceptance_tests => ['testing:acceptance'] do end

task :default => [
	'environment:default',
	'build:default',
	#'testing:unit',
	'package:default'
	] do
end

task :deploy => ['convention:spec_generation', 'deploy:default'] do end
