#========================================================================
# This file will only run locally on pre/post build events from the IDE #
#        NOTE: If this project does not require a deployment, 
#         the tentacle obviously does not have to be invoked
#========================================================================

# You can pass any params to this file from the IDE (see macro's)
param([string]$isVisualStudio, [string]$targetDir)

if ($isVisualStudio -eq $true)
{
	# Refresh Modules
	Remove-Module ToolBox.Builds -ErrorAction SilentlyContinue
	Import-Module ToolBox.Builds

	# Set Working Directory to current script path
	Push-Location (Split-Path $MyInvocation.MyCommand.Path -Parent)

	# Helper to read the App/Web config file (optional)
	Read-Configuration (Resolve-Path "..\App.config")

	# The path to the tentacle in the tools folder (required)
	$tentacle = Resolve-Path "..\..\..\..\..\..\tools\octopus\tentacle\tentacle.exe"

	# The script to execute to simulate deployment (required)
	$script = Resolve-Path "deploy.ps1"

	$migrator = Resolve-Path "..\..\..\..\..\..\tools\migrator\migrate.exe"
	$assembly = Resolve-Path "$targetDir\Workflow.Billing.Database.dll"

	#========================================================================#
	#    The Octopus Tentacle will invoke the specified deploy script        #
	#      It will use any parameters passed as "Octopus Variables"          #
	#     These will generally be the same as in the Octopus Project         #
	#========================================================================#

	Invoke-Tentacle $tentacle $script `
	@{
		billingConnectionString = $connectionStrings["workflow/billing/database"]
		DatabaseUpgrade = $true
		MigratorPath = $migrator
		MigrationAssemblyPath = $assembly
	}
}
else
{
	Write-Host "[BUILD] Skipping PostBuild Event - Not inside Visual Studio"
}