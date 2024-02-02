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

### Clone, Build, Run, and Deploy

Prerequisites:

- [Visual Studio](https://visualstudio.microsoft.com/downloads/)
- [Azure Functions Visual Studio Extension](https://marketplace.visualstudio.com/items?itemName=VisualStudioWebandAzureTools.AzureFunctionsandWebJobsTools)
- [Azurite](https://learn.microsoft.com/en-us/azure/storage/common/storage-use-azurite?tabs=visual-studio%2Cblob-storage) (Commonly Installed with Visual Studio)

1. Clone the repository

```bash	
	git clone https://github.com/deathmarine/swa-resume-template.git
```

2. Open the solution in Visual Studio
	- Due to the structure of the Program.cs in the Frontend project, opening the solution in Visual Studio will allow it to run locally as multiple projects.
	- Changes can be made to the application.
	
3. Build the Application
	- Build the solution in Visual Studio selecting Build -> Build Solution
	
4. Start Azurite in a seperate window (Visual Studio has a known issue with starting Azurite with multiple projects)
	
```bash
	azurite.cmd --skipApiVersionCheck --location .vstools/azurite/
```

5. Ensure Multiple Startup Projects are selected from Projects -> Configure Startup Projects
	- Select the Frontend and Backend projects to start

6. Start the Applications
	- The Order should be to start the API first

7. Deploy the Application
	- The application can be deployed to Azure using the Azure Functions Visual Studio Extension
	- Right click the ARM Template project and select Deploy
	- Follow the prompts to deploy (Ensure that you have a Github Access Token)

8. Once deployed, retrieve the new Github Repository URL and add the new repository as a remote to the local repository
	- This will allow you to push changes to the deployed site

```bash
	git remote add github <new-github-repo-url>
	git pull github master --allow-unrelated-histories
```

Commit and/or stash any changes, merge the repos, and push to the new remote repository *github*.

```bash
	git push github master
```

Congratulations! You have deployed the application to Azure.
You can now make changes to the site and have them automatically deployed via Github Actions.

Alternatively you can create a branch repository.
This will allow you to merge locally and push to master or create pull requests and merge on github.

### Updates
	
To receive updates to the Application, you can pull from the original repository and push to the new repository.
You may have to resolve any conflicts that arise.
```bash
	git pull origin master
	git push github master
```

## Features

This project is a complete Static Web App Solution which allows you to deploy a Blazor WebAssembly Resume Template and Static Web Site to Azure.
Using this allow you to display your resume and portfolio in a modern and interactive way. 

The project was derived from a college request to provide a quick easy and modern method to allow potential employers to quick review a candidates resume and portfolio.
Additionally this application would reduce the need to print and carry around physical copies of a resume and portfolio.

A few features of the application include:
- QR Codes
	- QR Codes can be displayed from the site to quickly access documents and to share the site.
- Documents
	- Plain text, Word, and PDF documents can be displayed and downloaded from the site.
- JSON Resume Payload
	- The site is dynamically generated from a JSON Resume Payload. This payload can be easily updated and changed to reflect the users resume.
- Github Actions
	- Deployments are quick and changes are automatically applied to the SWA.
- Low / No Cost
	- Static Web Apps are a cost effective solution that can provide a site hosted on the cloud in minutes.
	- Adding a custom domain name, securing the API for writing to storage, and many other features can be added.
- Simple Cloud Archecture
	- The Static Web App is the Application and the API are bundled in the same Azure resource
	- The Application Json files, documents, and image files are hosted in a Storage Account Blob Container.
- Easily Update and Manipulate
	- Changes to the application code can be pushed via Github
	- Changes to the Json files, documents, and image files can be uploaded using the Azure portal, Storage Explorer, Az CLI, Az Powershell, or even written by other applications.
- Deploys in Minutes
	- Following the directions above and the services can be deployed in minutes.
	- Writing the resume and updating the documents... results may vary.
	- Uploading the files to Azure can be performed in seconds.

[Azure Static Web Apps](https://docs.microsoft.com/azure/static-web-apps/overview) allows you to easily build [Blazor](https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor) apps in minutes. 
Use the [Blazor quickstart](https://docs.microsoft.com/azure/static-web-apps/getting-started?tabs=blazor) to build and customize a new static site.

