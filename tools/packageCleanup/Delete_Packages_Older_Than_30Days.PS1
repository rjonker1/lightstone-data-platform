#----- define parameters -----#
#----- get current date ----#
$Now = Get-Date
#----- define amount of days ----#
$Days = "30"
#----- define folder where files are located ----#
$TargetFolder = "D:\Development\Packages"
#----- define extension ----#
$packagesToDelete = 
"*Lightstone.DataPlatform.Api.*", 
"*Lightstone.DataPlatform.UserManagement.Api.*", 
"*Lightstone.DataPlatform.PackageBuilder.Api.*", 
"*Lightstone.DataPlatform.PackageBuilder.Web.UI.*", 
"*Lightstone.DataPlatform.Billing.Api.*", 
"*Lightstone.DataPlatform.Billing.Api.Dtos.*",
"*Lightstone.DataPlatform.Billing.Api.Connector.*",
"*Lightstone.DataPlatform.Lace.Domain.Core.*",
"*Lightstone.DataPlatform.Lace.Domain.Core.Entities.*",
"*Lightstone.DataPlatform.Lace.Domain.Core.Requests.*",
"*Lightstone.DataPlatform.Lace.Shared.Monitoring.Messages.*",
"*Lightstone.DataPlatform.Lace.Domain.Infrastructure.EntryPoint.*",
"*Lightstone.DataPlatform.Shared.*",
"*Lightstone.Dataplatform.Shared.BuildingBlocks*",
"*Lightstone.Dataplatform.Shared.BuildingBlocks.Api*",
"*Lightstone.Dataplatform.Workflow*",
"*Lightstone.DataPlatform.Workflow.BuildingBlocks*",
"*Lightstone.DataPlatform.Workflow.RabbitMQ*",
"*Lightstone.Dataplatform.PackageBuilder.Domain.Entities*",
"*Lightstone.Dataplatform.PackageBuilder.TestObjects*",
"*Lightstone.Dataplatform.PackageBuilder.TestObjects*",
"*Lightstone.DataPlatform.EventTracking.Domain.Persistence*",
"*Lightstone.DataPlatform.Lace.Domain.Core*"

#----- define LastWriteTime parameter based on $Days ---#
$LastWrite = $Now.AddDays(-$Days)
 
#----- get files based on lastwrite filter and specified folder ---#
 
foreach ($packageToDelete in $packagesToDelete)
{
    $packageToKeep = Get-Childitem $TargetFolder -Include $packageToDelete -Recurse | sort LastWriteTime | select -last 1
    $Files = Get-Childitem $TargetFolder -Include $packageToDelete -Recurse | Where {$_.LastWriteTime -le "$LastWrite" -and $_.name -ne $packageToKeep.Name}

    foreach ($File in $Files)
    {
        if ($File -ne $NULL)
            {
            write-host "Deleting File $File" -ForegroundColor "DarkRed"
            Remove-Item $File.FullName | out-null
            }
        else
            {
            Write-Host "No more files to delete!" -foregroundcolor "Green"
            }
    }
}


