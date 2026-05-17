[![FOSSA Status](https://app.fossa.io/api/projects/git%2Bgithub.com%2Fshanselman%2FSmallestDotNet.svg?type=shield)](https://app.fossa.io/projects/git%2Bgithub.com%2Fshanselman%2FSmallestDotNet?ref=badge_shield)

SmallestDotNet
==============

SmallestDotNet - [SmallestDotNet.com](https://smallestdotnet.com) is a single page site that does one thing. It tells you the smallest, easiest download you'd need to get the .NET Framework on your system. 

It currently recommends .NET Framework 4.8.1 for machines that need the latest .NET Framework runtime. For new development, use modern .NET instead.

The code sucks. I did it in an hour and I'm sad.

Thanks to Calin Balauru for his help. Anything good here is him. All the bad is me.

## Current production app

Production now runs from `SmallestDotNetModern`, an ASP.NET Core app targeting .NET 10. The original Web Forms project is still in the repository for reference, but the live site is the Linux App Service app:

- Azure subscription: `Scott's Main Azure Account (MSDN)`
- Resource group: `HanselmanDotComLinux`
- App Service app: `smallestdotnet-linux`
- App Service plan: `HanselmanLinux`
- Runtime: `DOTNETCORE|10.0`
- Hostnames: `smallestdotnet.com`, `smallestdotnet-linux.azurewebsites.net`
- TLS: Azure App Service managed certificate bound with SNI
- DNS: hosted at DNSimple, not Azure DNS

There is not currently a GitHub/Git deployment wired up for the Azure app. The app's deployment source is `None`; the production deployment was done manually with a prebuilt zip package and App Service zip deploy.

## Project layout

- `SmallestDotNetModern` - production ASP.NET Core/.NET 10 app. It preserves the original public routes, including `/`, `/VersionCheck.ashx`, `/javascript.ashx`, `/javascriptdom.ashx`, and the old `/smallestdotnet/...` redirects.
- `SmallestDotNetModernLib` - SDK-style .NET 10 wrapper that links the original detection source files.
- `SmallestDotNetLib` - original .NET Framework detection and output logic. Keep framework release keys and download URLs current here.
- `SmallestDotNet` - original ASP.NET Web Forms app, kept for history/reference.
- `CheckForDotNet45` - helper executable that reads the .NET Framework registry release key and returns to the website.
- `SmallestTest` - legacy MSTest coverage for the detection and JavaScript output behavior.

## Framework data maintenance

The site intentionally focuses on .NET Framework, not modern .NET. New application development should use current .NET, but this site exists for people who need to run or detect .NET Framework.

When Microsoft adds or documents new .NET Framework release keys, update:

- `Constants.ReleaseVersions` for checker release-key detection.
- `Constants.DotNet`, download URLs, and download sizes if the latest recommended .NET Framework runtime changes.
- `CLRVersions.Versions` if `/javascriptdom.ashx` should advertise additional downloadable framework versions.
- `SmallestTest` expectations for release keys and JavaScript payloads.

## Manual deployment

Build and publish the modern app from the repository root:

```powershell
Remove-Item -Recurse -Force .\artifacts -ErrorAction SilentlyContinue
dotnet publish .\SmallestDotNetModern\SmallestDotNetModern.csproj -c Release -o .\artifacts\SmallestDotNetModern-publish
Compress-Archive -Path .\artifacts\SmallestDotNetModern-publish\* -DestinationPath .\artifacts\SmallestDotNetModern.zip -Force
```

Deploy the zip to Azure App Service:

```powershell
az account set --subscription "Scott's Main Azure Account (MSDN)"

$sub = az account show --query id -o tsv
$rg = "HanselmanDotComLinux"
$app = "smallestdotnet-linux"
$siteId = "/subscriptions/$sub/resourceGroups/$rg/providers/Microsoft.Web/sites/$app"

az resource update --ids "$siteId/basicPublishingCredentialsPolicies/scm" --set properties.allow=true

try {
    [xml]$profiles = az webapp deployment list-publishing-profiles -g $rg -n $app --xml
    $profile = @($profiles.publishData.publishProfile | Where-Object { $_.publishMethod -eq "ZipDeploy" })[0]
    $pair = "$($profile.userName):$($profile.userPWD)"
    $headers = @{ Authorization = "Basic " + [Convert]::ToBase64String([Text.Encoding]::ASCII.GetBytes($pair)) }

    Invoke-WebRequest `
        -Uri "https://$app.scm.azurewebsites.net/api/zipdeploy" `
        -Headers $headers `
        -Method Post `
        -InFile .\artifacts\SmallestDotNetModern.zip `
        -ContentType "application/zip" `
        -UseBasicParsing

    az webapp restart -g $rg -n $app
}
finally {
    az resource update --ids "$siteId/basicPublishingCredentialsPolicies/scm" --set properties.allow=false
}
```

Validate the public endpoints after deploy:

```powershell
Invoke-WebRequest https://smallestdotnet.com/
Invoke-WebRequest https://smallestdotnet.com/?releaseKey=528040
Invoke-WebRequest https://smallestdotnet.com/?realversion=4.8
Invoke-WebRequest https://smallestdotnet.com/VersionCheck.ashx?userAgent=Mozilla%2F5.0
Invoke-WebRequest https://smallestdotnet.com/javascript.ashx
Invoke-WebRequest https://smallestdotnet.com/javascriptdom.ashx
```

If deployment is automated later, prefer GitHub Actions with OIDC or an Azure publish profile stored as a repository secret. Until then, keep SCM basic publishing disabled except during the short zip deploy window.


## License
[![FOSSA Status](https://app.fossa.io/api/projects/git%2Bgithub.com%2Fshanselman%2FSmallestDotNet.svg?type=large)](https://app.fossa.io/projects/git%2Bgithub.com%2Fshanselman%2FSmallestDotNet?ref=badge_large)
