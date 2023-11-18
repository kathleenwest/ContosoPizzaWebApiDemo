# ContosoPizza
A simple web api demo with swagger documentation, unit tests, and patch.

TBA - In progress

I will present this demo project.

Topics/YouTube Video
## Project Overview
## Architecture
## Web Api CRUD
## Web Api Patch
## Error/Handling Display
## Swagger Documentation

This tutorial and demo project will show you how to add, set up, configure, and verify Swagger documentation to your developer WebApi project. The final results are in this code repo. 

Swashbuckle and Swagger are two popular tools used for generating developer documentation for web APIs. Swashbuckle is a package that can be added to an ASP.NET Core web API project to integrate the Swagger UI. It has three main components: Swashbuckle.AspNetCore.Swagger, which is a Swagger object model and middleware to expose SwaggerDocument objects as JSON endpoints; Swashbuckle.AspNetCore.SwaggerGen, which is a Swagger generator that builds SwaggerDocument objects directly from your routes, controllers, and models; and Swashbuckle.AspNetCore.SwaggerUI, which is an embedded version of the Swagger UI tool. It interprets Swagger JSON to build a rich, customizable experience for describing the web API functionality. Swagger (OpenAPI) is a language-agnostic specification for describing REST APIs. It allows both computers and humans to understand the capabilities of a REST API without direct access to the source code. Its main goals are to minimize the amount of work needed to connect decoupled services. ¹³⁴

[![Watch the tutorial and demo video](/images/SwaggerDocumentationTutorialTitle.jpg)](https://www.youtube.com/watch?v=23VY2JxWEAA "Swagger Documentation Tutorial and Demo")

## Client Tester

This tutorial and demo project will show how to set up, configure, and code a simple HttpClient for the Contoso Pizza Web Api project.

In this YouTube video, we will learn how to create a simple console application project that connects to a Web Api and tests it. The video includes a short demo of the project running and outputting results from the api. We will obtain the OpenApi file by first running our WebApi locally to show the Swagger UI. The JSON file for our Web Api can be downloaded and saved to our project directory. There is another video in the playlist series that shows how to set up and configure Swagger Documentation. The next step is to add a new console application project to our solution. This will be the HttpClient application to connect to our Web Api. Next, we will add an OpenApi Service Reference from the Swagger UI JSON file we previously saved. Visual Studio will auto-generate the client code class needed to interact with the Contoso Pizza Web Api. We will take a look at the auto-generated code class. The constructor needs both a HttpClient object instance and the base url of the running web api. If you run your web api locally, you can find that from the Debug launch profile. Finally, we can code our project to create a HttpClient and proxy service reference to the Contoso UI Pizza Web Api and try to retrieve some pizzas. Make sure the web api application is already running locally before running the HttpClient console application.

[![Watch the tutorial and demo video](/images/HttpClientTitle.jpg)](https://www.youtube.com/watch?v=bpcxD_PZ5cU "HttpClient for Web Api Tutorial and Demo")

## Unit Testing

This tutorial and demo project will show how to set up, configure, and code simple unit tests for a WebApi project.

In this video, we will discuss how to write simple unit tests for a web API with CRUD controller operations. We will be using xUnit and FakeItEasy packages to write the tests. We will cover the basics of unit testing, including how to set up the test project, how to write tests for each CRUD operation, and how to use xUnit and FakeItEasy to create mocks and stubs. We will also discuss best practices for writing unit tests, such as keeping tests independent and ensuring that they are easy to read and maintain.

[![Watch the tutorial and demo video](/images/UnitTestsTitle.jpg)](https://www.youtube.com/watch?v=EIn-eRWm8AM "Simple Unit Tests Tutorial and Demo")

## References
Although tutorials, videos, and documentation were referenced, this project is creatively my own code and style to demo my technical expertise and contribute to the collective tech knowledge on GitHub. I have listed some of the sources where I drew some code examples and knowledge. 

[Beginner's Series to: Web APIs](https://learn.microsoft.com/en-us/shows/beginners-series-to-web-apis/)

[Microsoft Learn - Create a web API with ASP.NET Core controllers](https://learn.microsoft.com/en-us/training/modules/build-web-api-aspnet-core/)

## Bing Chat References for Summary

Source: Conversation with Bing, 11/10/2023
(1) Get started with Swashbuckle and ASP.NET Core. https://learn.microsoft.com/en-us/asp....
(2) ASP.NET Core web API documentation with Swagger / OpenAPI. https://learn.microsoft.com/en-us/asp....
(3) What is Swagger, Swashbuckle and Swashbuckle UI. https://stackoverflow.com/questions/4....
(4) Improve the developer experience of an API with Swagger documentation .... https://learn.microsoft.com/en-us/tra....
[ASP.NET Core Documentation on GitHub](https://github.com/dotnet/AspNetCore.Docs)

[JsonPatch in ASP.NET Core web API](https://learn.microsoft.com/en-us/aspnet/core/web-api/jsonpatch?view=aspnetcore-7.0&WT.mc_id=beginwebapis-c9-cephilli)


