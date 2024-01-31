# Build your own low-cost ddns with .NET and Azure

> Build your own low-cost ddns and forget about depending on third-party solutions.
<br/>


#### Table of Contents
[Requirements](#requirements)<br/>
[Architecture](#architecture)<br/>
[Deploy to Azure](#deploy-to-azure)<br/>
[Compile and publish the web API](#compile-and-publish-the-web-api)<br/>
[Compile and run the Winforms app](#compile-and-run-the-winforms-app)<br/>

## Requirements
- Visual Studio with Web and Windows Forms features installed.
- .NET SDK 8.0
- A free trial Azure account or an account with a valid credit card linked to it.
Keep in mind that all the resources deployed to your account will be free, except the DNS zone, which have a cost of less than $1 per month.

## Architecture

## Deploy to Azure

First step is to deploy the necessary infrastructure in our Azure account. Click this button and let the magic happen:
<br/>

[![Deploy to Azure](https://aka.ms/deploytoazurebutton)](https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2Foscarsolerfollana%2FBuild-your-own-low-cost-ddns-with-.NET-and-Azure%2Fmain%2Ftemplate.json)

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

## Compile and run the Winforms app

(Under construction)
