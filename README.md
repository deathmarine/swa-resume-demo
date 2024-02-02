# Resume Static Web Site and Template
## A Blazor WebAssembly Resume Template and Static Web Site

This project is a complete Static Web App Solution which allows you to deploy a Blazor WebAssembly Resume Template and Static Web Site to Azure.



## Getting Started

### Quick Start

1. To get started, you need to generate a Access Token from your [GitHub Account](https://github.com/settings/tokens)

2. Click *Generate new token* (classic) and select the following scopes:

- repo
- workflow
- admin:repo_hook
- user
- read:user
- write:packages
- read:packages
- delete:packages
- admin:org_hook
- admin:org
- admin:gpg_key

Copy the token and save it somewhere safe. You will need it later. 
After the deployment the token can be revoked.

3. Click the *Deploy to Azure* button below. This will open the Azure Portal and start the deployment process.

[![Deploy to Azure](https://aka.ms/deploytoazurebutton)](https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2Fdeathmarine%2Fswa-resume-template%2Fmaster%2FARM%2520Template%2Fazuredeploy.json)

4. Fill in the fields and provide the Github Access Key generated and click Review + Create. 

Once the deployment is complete, you will be able to access your site at the URL from the SWA resource.
Additionally, this repository will be cloned to your GitHub account and you will be able to make changes to the site and the site will update via Github Actions.
Finally, you will be able to revoke the token you generated earlier.

### Clone, Build, and Deploy

[Azure Static Web Apps](https://docs.microsoft.com/azure/static-web-apps/overview) allows you to easily build [Blazor](https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor) apps in minutes. 
Use the [Blazor quickstart](https://docs.microsoft.com/azure/static-web-apps/getting-started?tabs=blazor) to build and customize a new static site.

