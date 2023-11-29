# Contoso Pizza Web Api Demo and Tutorial
A simple web api demo with swagger documentation, custom error handling, unit tests, JsonPatch, and a HttpClient tester. Features tutorial-style YouTube videos for some topics.  

<!-- vscode-markdown-toc -->
* 1. [Project Overview](#ProjectOverview)
* 2. [Architecture](#Architecture)
* 3. [Web Api CRUD](#WebApiCRUD)
	* 3.1. [Create (C) - Post](#CreateC-Post)
	* 3.2. [Read (R)](#ReadR)
		* 3.2.1. [Get](#Get)
		* 3.2.2. [Get By Id](#GetById)
	* 3.3. [Update (U)](#UpdateU)
		* 3.3.1. [Put](#Put)
		* 3.3.2. [Patch](#Patch)
	* 3.4. [Delete (D)](#DeleteD)
* 4. [Web Api JsonPatch](#WebApiJsonPatch)
	* 4.1. [Tutorial](#Tutorial)
	* 4.2. [Documentation](#Documentation)
* 5. [Custom Error Handling and Display](#CustomErrorHandlingandDisplay)
* 6. [Swagger Documentation](#SwaggerDocumentation)
* 7. [Client Tester](#ClientTester)
* 8. [Unit Testing](#UnitTesting)
* 9. [References](#References)
* 10. [Bing Chat References for Summary](#BingChatReferencesforSummary)

<!-- vscode-markdown-toc-config
	numbering=true
	autoSave=true
	/vscode-markdown-toc-config -->
<!-- /vscode-markdown-toc -->

##  1. <a name='ProjectOverview'></a>Project Overview

The objective of this GitHub project is to demo a simple CRUD web api application with additional tutorials (including YouTube videos) and references including Swagger, unit testing, JsonPatch, custom error handling and display, client testers, etc. 

##  2. <a name='Architecture'></a>Architecture
The visual studio solution has three projects: ContosoPizza (Web Api), ContosoPizza.Tests (Unit Tests), and WebApiClient (a simple HttpClient console app)

![Solution Summary](/images/Architecture/SolutionSummary.jpg)

The controller, model, and service classes with their member summary of the ContosoPizza Web Api project are shown below. 

![Solution Summary](/images/Architecture/SolutionExplorer.jpg)

##  3. <a name='WebApiCRUD'></a>Web Api CRUD
This is a simple web api that follows the standard CRUD (create, read, update, and delete) pattern. Demo images of the api operations are shown below by category.

###  3.1. <a name='CreateC-Post'></a>Create (C) - Post
![Create Pizza](/images/CRUDDemo/Post.jpg)
###  3.2. <a name='ReadR'></a>Read (R)
####  3.2.1. <a name='Get'></a>Get 
![Get Pizza](/images/CRUDDemo/GetAll.jpg)
####  3.2.2. <a name='GetById'></a>Get By Id
![Get Pizza By Id](/images/CRUDDemo/GetById.jpg)
###  3.3. <a name='UpdateU'></a>Update (U)
####  3.3.1. <a name='Put'></a>Put
![Put Pizza](/images/CRUDDemo/Put.jpg)
####  3.3.2. <a name='Patch'></a>Patch
![Patch Pizza](/images/CRUDDemo/Patch.jpg)
###  3.4. <a name='DeleteD'></a>Delete (D)
![Create Pizza](/images/CRUDDemo/Delete.jpg)
##  4. <a name='WebApiJsonPatch'></a>Web Api JsonPatch

Here are some screen captures showing the web api JsonPatch demo. 

1. Get Existing Pizza
![Get Existing Pizza](/images/JsonPatch/Step1GetExistingPizza.jpg)
2. PATCH Replace Pizza Name
![PATCH Replace Pizza Name](/images/JsonPatch/Step2PatchReplaceName.jpg)

Here is the code reference.
```
[
  {
    "value": "ModifiedPizza",
    "path": "/name",
    "op": "replace"
  }
]
```

4. Get Existing Pizza - Verify PATCH Replace Operation
![Get Existing Pizza - Verify PATCH Replace Operationa](/images/JsonPatch/Step3GetExistingPizzaVerifyPatchOperation.jpg)

###  4.1. <a name='Tutorial'></a>Tutorial

This is a great tutorial reference video if you would like to learn more about setup, installing, and using JsonPatch for your Web Api project.

[Updating data with JsonPatch | Beginner's Series to Web APIs](https://learn.microsoft.com/en-us/shows/beginners-series-to-web-apis/updating-data-with-jsonpatch-13-of-18--beginners-series-to-web-apis)

###  4.2. <a name='Documentation'></a>Documentation

[JsonPatch in ASP.NET Core web API](https://learn.microsoft.com/en-us/aspnet/core/web-api/jsonpatch?view=aspnetcore-7.0&WT.mc_id=beginwebapis-c9-cephilli)

##  5. <a name='CustomErrorHandlingandDisplay'></a>Custom Error Handling and Display

This tutorial and demo project will show how to set up, configure, and code a simple custom error handler for the Contoso Pizza Web Api project.

Developers should plan for unhandled errors in code. The Contoso Pizza Web API project demonstrates how to do this. In the demo, an endpoint is created that always throws an unhandled exception. The project has a custom error controller that handles and logs the exceptions before returning a standard Problem model object to the user. The error controller is specified in the Program configuration to route to a custom error controller when not running in a development environment. The development environment is specified under the Debug launch profile settings, with the default value being Production unless otherwise specified. 

To see the differences in the error display between development and production, first run the API in development mode. Test the endpoint that always triggers an unhandled exception. In the Swagger UI, you can see the response and exception details. The browser window has a separate and elegant developer view of the error results. 

To run the API in production mode, remove the environment variable or manually set the value to Production. Since Swagger UI does not run in production mode, you will need to test the API endpoint manually with a URL. The final result for the user is a general error with an identifier. A user would create a trouble ticket with this information. The company could then complete detailed troubleshooting matching the error identifier to more detailed internal logging.

[![Watch the tutorial and demo video](/images/CustomErrorHandlingTitle.jpg)](https://www.youtube.com/watch?v=1bSpwN5EHyI "Custom Error Handling Tutorial and Demo")

##  6. <a name='SwaggerDocumentation'></a>Swagger Documentation

This tutorial and demo project will show you how to add, set up, configure, and verify Swagger documentation to your developer WebApi project. The final results are in this code repo. 

Swashbuckle and Swagger are two popular tools used for generating developer documentation for web APIs. Swashbuckle is a package that can be added to an ASP.NET Core web API project to integrate the Swagger UI. It has three main components: Swashbuckle.AspNetCore.Swagger, which is a Swagger object model and middleware to expose SwaggerDocument objects as JSON endpoints; Swashbuckle.AspNetCore.SwaggerGen, which is a Swagger generator that builds SwaggerDocument objects directly from your routes, controllers, and models; and Swashbuckle.AspNetCore.SwaggerUI, which is an embedded version of the Swagger UI tool. It interprets Swagger JSON to build a rich, customizable experience for describing the web API functionality. Swagger (OpenAPI) is a language-agnostic specification for describing REST APIs. It allows both computers and humans to understand the capabilities of a REST API without direct access to the source code. Its main goals are to minimize the amount of work needed to connect decoupled services. ¹³⁴

[![Watch the tutorial and demo video](/images/SwaggerDocumentationTutorialTitle.jpg)](https://www.youtube.com/watch?v=23VY2JxWEAA "Swagger Documentation Tutorial and Demo")

##  7. <a name='ClientTester'></a>Client Tester

This tutorial and demo project will show how to set up, configure, and code a simple HttpClient for the Contoso Pizza Web Api project.

In this YouTube video, we will learn how to create a simple console application project that connects to a Web Api and tests it. The video includes a short demo of the project running and outputting results from the api. We will obtain the OpenApi file by first running our WebApi locally to show the Swagger UI. The JSON file for our Web Api can be downloaded and saved to our project directory. There is another video in the playlist series that shows how to set up and configure Swagger Documentation. The next step is to add a new console application project to our solution. This will be the HttpClient application to connect to our Web Api. Next, we will add an OpenApi Service Reference from the Swagger UI JSON file we previously saved. Visual Studio will auto-generate the client code class needed to interact with the Contoso Pizza Web Api. We will take a look at the auto-generated code class. The constructor needs both a HttpClient object instance and the base url of the running web api. If you run your web api locally, you can find that from the Debug launch profile. Finally, we can code our project to create a HttpClient and proxy service reference to the Contoso UI Pizza Web Api and try to retrieve some pizzas. Make sure the web api application is already running locally before running the HttpClient console application.

[![Watch the tutorial and demo video](/images/HttpClientTitle.jpg)](https://www.youtube.com/watch?v=bpcxD_PZ5cU "HttpClient for Web Api Tutorial and Demo")

##  8. <a name='UnitTesting'></a>Unit Testing

This tutorial and demo project will show how to set up, configure, and code simple unit tests for a WebApi project.

In this video, we will discuss how to write simple unit tests for a web API with CRUD controller operations. We will be using xUnit and FakeItEasy packages to write the tests. We will cover the basics of unit testing, including how to set up the test project, how to write tests for each CRUD operation, and how to use xUnit and FakeItEasy to create mocks and stubs. We will also discuss best practices for writing unit tests, such as keeping tests independent and ensuring that they are easy to read and maintain.

[![Watch the tutorial and demo video](/images/UnitTestsTitle.jpg)](https://www.youtube.com/watch?v=EIn-eRWm8AM "Simple Unit Tests Tutorial and Demo")

##  9. <a name='References'></a>References
Although tutorials, videos, and documentation were referenced, this project is creatively my own code and style to demo my technical expertise and contribute to the collective tech knowledge on GitHub. I have listed some of the sources where I drew some code examples and knowledge. 

[Beginner's Series to: Web APIs](https://learn.microsoft.com/en-us/shows/beginners-series-to-web-apis/)

[Microsoft Learn - Create a web API with ASP.NET Core controllers](https://learn.microsoft.com/en-us/training/modules/build-web-api-aspnet-core/)

##  10. <a name='BingChatReferencesforSummary'></a>Bing Chat References for Summary

Source: Conversation with Bing, 11/10/2023
(1) Get started with Swashbuckle and ASP.NET Core. https://learn.microsoft.com/en-us/asp....
(2) ASP.NET Core web API documentation with Swagger / OpenAPI. https://learn.microsoft.com/en-us/asp....
(3) What is Swagger, Swashbuckle and Swashbuckle UI. https://stackoverflow.com/questions/4....
(4) Improve the developer experience of an API with Swagger documentation .... https://learn.microsoft.com/en-us/tra....
[ASP.NET Core Documentation on GitHub](https://github.com/dotnet/AspNetCore.Docs)

[JsonPatch in ASP.NET Core web API](https://learn.microsoft.com/en-us/aspnet/core/web-api/jsonpatch?view=aspnetcore-7.0&WT.mc_id=beginwebapis-c9-cephilli)


