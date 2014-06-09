# Refresh Modules
Remove-Module ToolBox.Builds -ErrorAction SilentlyContinue
Import-Module ToolBox.Builds


Update-Database `
	$OctopusParameters["billingConnectionString"] `
	$OctopusParameters["MigratorPath"] `
	$OctopusParameters["MigrationAssemblyPath"]

