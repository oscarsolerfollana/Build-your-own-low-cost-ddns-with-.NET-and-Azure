# Build your own low-cost ddns with .NET and Azure

> Build your own low-cost ddns and forget about depending on third-party solutions.
<br/>


#### Table of Contents

[Requirements](#requirements)<br/>
[Architecture](#architecture)<br/>
[Deploy to Azure](#deploy-to-azure)<br/>
[Configure your domain name](#configure-your-domain-name)<br/>
[Compile and publish the web API](#compile-and-publish-the-web-api)<br/>
[Compile and run the Winforms app](#compile-and-run-the-winforms-app)<br/>
[Debugging](#debugging)<br/>
<br/>

## Requirements

- Visual Studio with Web and Windows Forms features installed.
- .NET SDK 8.0.
- Azure CLI.
- A domain name of your own.
- A free trial Azure account or an account with a valid credit card linked to it.
Keep in mind that all the resources deployed to your account will be free, except the DNS zone, which have a cost of less than $1 per month.
<br/>

## Architecture

### Components

![alt text](https://github.com/oscarsolerfollana/Build-your-own-low-cost-ddns-with-.NET-and-Azure/blob/main/readmeContent/components.png?raw=true)
- Azure Web App
- Azure Public DNS Zone
- Azure Key Vault
- Domain name
<br/>

### Dataflow

![alt text](https://github.com/oscarsolerfollana/Build-your-own-low-cost-ddns-with-.NET-and-Azure/blob/main/readmeContent/dataflow.png?raw=true)
1. Desktop application periodically sends a request to web API to check whether the domain is up to date.
2. Web API requests the password to Key Vault.
3. Web API compares the password.
4. Web API checks if IP has changed, and if so, it updates the DNS servers.
5. New IP propagates to your domain name.
6. Whenever the user requests his/her domain name, it will point to the updated IP.
<br/><br/>

## Deploy to Azure

First step is to deploy the necessary infrastructure in our Azure account. Click this button and let the magic happen:
<br/>

[![Deploy to Azure](https://aka.ms/deploytoazurebutton)](https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2Foscarsolerfollana%2FBuild-your-own-low-cost-ddns-with-.NET-and-Azure%2Fmain%2Ftemplate.json)
<br/><br/>

## Configure your domain name

For Azure to be able to manage the DNS, it is necessary to update the domain's servers to Azure's servers.
<br/><br/>
![alt text](https://github.com/oscarsolerfollana/Build-your-own-low-cost-ddns-with-.NET-and-Azure/blob/main/readmeContent/ddns_servers.png?raw=true)
<br/><br/>

## Compile and publish the web API

When you open the solution with Visual Studio, you will need to configure the publish settings.
Access to your Azure account, click on the new web app service that has been created. In the main screen, download the publish profile.
<br/><br/>
![alt text](https://github.com/oscarsolerfollana/Build-your-own-low-cost-ddns-with-.NET-and-Azure/blob/main/readmeContent/download_profile.png?raw=true)

Then, in Visual Studio, click on Publish on the API project and import the publish profile.
<br/><br/>
![alt text](https://github.com/oscarsolerfollana/Build-your-own-low-cost-ddns-with-.NET-and-Azure/blob/main/readmeContent/publish.png?raw=true)
![alt text](https://github.com/oscarsolerfollana/Build-your-own-low-cost-ddns-with-.NET-and-Azure/blob/main/readmeContent/import_profile.png?raw=true)

Now, publish to Azure.
<br/><br/>

## Compile and run the Winforms app

Ir order to publish the Winforms app, you need to follow the same steps than before, but changing the target to a folder.
The first time you run the app, you must configure the following parameters in the configuration form:
URL: it must be the url given when Azure Web App is deployed, and it can be checked in the web app services' main page.
<br/><br/>
![alt text](https://github.com/oscarsolerfollana/Build-your-own-low-cost-ddns-with-.NET-and-Azure/blob/main/readmeContent/url.png?raw=true)
<br/><br/>

## Debugging

If you want to debug the app, you shall need to modify the environment variables **keyVaultName**, **resourceGroupName** and **domainName** as you wish.
On the other hand, you shall be able to use your Azure resources locally, as the **DefaultAzureCredential** method will use your Azure CLI login credentials.
<br/><br/>
![alt text](https://github.com/oscarsolerfollana/Build-your-own-low-cost-ddns-with-.NET-and-Azure/blob/main/readmeContent/environment_variables.png?raw=true)
