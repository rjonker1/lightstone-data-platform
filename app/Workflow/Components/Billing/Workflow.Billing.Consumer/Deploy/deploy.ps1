# Refresh Modules
Remove-Module ToolBox.Builds -ErrorAction SilentlyContinue
Import-Module ToolBox.Builds


$service = get-service $OctopusParameters["ServiceName"] -ErrorAction SilentlyContinue 

if ($service –ne $null){
    "Already installed on this server";
} 
else {
        Write-Host $OctopusParameters["ServiceName"];
}

