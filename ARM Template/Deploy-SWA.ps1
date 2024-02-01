#Requires -Version 3.0

Param(
    [string] [Parameter(Mandatory=$true)] $ResourceGroupLocation,
    [string] [Parameter(Mandatory=$true)] $ResourceGroupName = "swa-resume-rg",
    [string] [Parameter(Mandatory=$true)] $StaticWebAppName,
    [string] [Parameter(Mandatory=$true)] $StorageAccountName,
    [string] [Parameter(Mandatory=$true)] $StorageContainerName = $ResourceGroupName.ToLowerInvariant() + '-content',
    [string] $TemplateFile = 'azuredeploy.json',
    [string] $TemplateParametersFile = 'azuredeploy.parameters.json'
    [switch] $ValidateOnly
)

function Write-ColorOutput($ForegroundColor){
    $fc = $host.UI.RawUI.ForegroundColor
    $host.UI.RawUI.ForegroundColor = $ForegroundColor
    if ($args) {
        Write-Output $args
    }
    else {
        $input | Write-Output
    }
    $host.UI.RawUI.ForegroundColor = $fc
}

#$gh_login = Read-Host -Prompt "Login with Github (Y/n): ";
$gh_login = "n";
if($gh_login.ToLower() -eq 'y'){
    ## MUST HAVE GITHUB CLI INSTALLED ##
    $ghstat = gh auth login;
    Write-Host $ghstat;
    $Github_User = gh api /user | ConvertFrom-Json;
    $Github_Username = $Github_User.name;
    Write-Host "Username: " -join $Github_User.name;
    $Github_Repository_Name = Read-Host -Prompt "Enter a new Github Repository Name: ";
    $ghstat = gh repo create $Github_Repository_Name --private -p "https://github.com/staticwebdev/vanilla-basic.git";

    $Github_Token = gh auth token; #Token Not Useful Auth Token does not have permission

    ##Maybe work on getting Github to give us a repository token another time
}else{
    $Github_Username = Read-Host -Prompt "Enter your Github Username: ";
    $Github_Repository_Name = Read-Host -Prompt "Enter a new Github Repository Name: ";
    Write-ColorOutput Green "Navigate to https://github.com/settings/tokens to generate a Personal Access Token";
    Write-ColorOutput Yellow "This token with allow the Azure to clone the repository and setup the Github Actions for the SWA"
    $Github_Token = Read-Host -Prompt "Enter your Github Access Token: ";
}



$OptionalParameters = New-Object -TypeName Hashtable
$OptionalParameters.Add("StaticSiteName", $StaticWebAppName)
$OptionalParameters.Add("StorageAccountName", $StorageAccountName)
$OptionalParameters.Add("StorageContainerName", $StorageContainerName)
$OptionalParameters.Add("location", $ResourceGroupLocation)
$OptionalParameters.Add("githubUsername", $Github_Username)
$OptionalParameters.Add("githubRepositoryname", $Github_Repository_Name)
$OptionalParameters.Add("githubRepositoryToken", $Github_Token)

try {
    [Microsoft.Azure.Common.Authentication.AzureSession]::ClientFactory.AddUserAgent("VSAzureTools-$UI$($host.name)".replace(' ','_'), '3.0.0')
} catch { }

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 3
function Format-ValidationOutput {
    param ($ValidationOutput, [int] $Depth = 0)
    Set-StrictMode -Off
    return @($ValidationOutput | Where-Object { $_ -ne $null } | ForEach-Object { @('  ' * $Depth + ': ' + $_.Message) + @(Format-ValidationOutput @($_.Details) ($Depth + 1)) })
}

$TemplateFile = [System.IO.Path]::GetFullPath([System.IO.Path]::Combine($PSScriptRoot, $TemplateFile))
$TemplateParametersFile = [System.IO.Path]::GetFullPath([System.IO.Path]::Combine($PSScriptRoot, $TemplateParametersFile))

# Create the resource group only when it doesn't already exist
if ((Get-AzResourceGroup -Name $ResourceGroupName -Location $ResourceGroupLocation -Verbose -ErrorAction SilentlyContinue) -eq $null) {
    New-AzResourceGroup -Name $ResourceGroupName -Location $ResourceGroupLocation -Verbose -Force -ErrorAction Stop
}

if ($ValidateOnly) {
    $ErrorMessages = Format-ValidationOutput (
        Test-AzResourceGroupDeployment -ResourceGroupName $ResourceGroupName `
        -TemplateParameterObject $OptionalParameters `
        -TemplateFile $TemplateFile)
    if ($ErrorMessages) {
        Write-Output '', 'Validation returned the following errors:', @($ErrorMessages), '', 'Template is invalid.'
    }
}else{
    $ErrorMessages = Format-ValidationOutput (
        Test-AzResourceGroupDeployment -ResourceGroupName $ResourceGroupName `
        -TemplateParameterObject $OptionalParameters `
        -TemplateFile $TemplateFile)
    if ($ErrorMessages) {
        Write-Output '', 'Validation returned the following errors:', @($ErrorMessages), '', 'Template is invalid.'
    }
    else {
        Write-Output '', 'Template is valid.'
        New-AzResourceGroupDeployment -Name ((Get-ChildItem $TemplateFile).BaseName + '-' + ((Get-Date).ToUniversalTime()).ToString('MMdd-HHmm')) `
                                            -ResourceGroupName $ResourceGroupName `
                                            -TemplateFile $TemplateFile `
                                            -TemplateParameterObject $OptionalParameters `
                                            -Force -Verbose `
                                            -ErrorVariable ErrorMessages
        if ($ErrorMessages) {
            Write-Output '', 'Template deployment returned the following errors:', @(@($ErrorMessages) | ForEach-Object { $_.Exception.Message.TrimEnd("`r`n") })
        }
        $swa = Get-AzStaticWebApp -name $Static_Web_App_Name -resourcegroupname $ResourceGroupName; 
        Write-Output $swa; 
        $hostname = $swa.DefaultHostname; 
        Write-ColorOutput Green '',"Navigate to your new Static Web App:  https://${hostname}";
        Write-ColorOutput Yellow "Hostnames are randomly generated. Consider a custom domain name.";
        Write-ColorOutput Yellow "See https://learn.microsoft.com/en-us/azure/static-web-apps/custom-domain for more details."

    }
}