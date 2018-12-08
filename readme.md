# WebApiExamples

These projects were created with a Visual Studio 2017 Community Edition 
This solution is a reference implementation for [my blogpost regarding route constraints](https://samanthaneilen.github.io/2018/10/09/using-route-constraints.html "my blogpost regarding route constraints").
This solution is a reference implementation for [my blogpost regarding Swagger/OpenApi/Swashbuckle constraints](https://samanthaneilen.github.io/2018/12/08/Using-and-extending-swagger.json-for-API-documentation.html "my blogpost regarding Swagger/OpenApi/Swashbuckle constraints").


## Framework.WebApiExample

#### Routing

This .NET Framework (4.7.2) web application contains code showing the route constraint possibilities. 

The HomeController is an MVC controller containing 2 methods accepting an email parameter. One method is decorated with the a route attribute. The other has a route configured in de App_Start/RouteConfig.cs file.
Both routes have a Email constraint on the email input parameter. The route constraint binding is setup in the App_Start/RouteConfig.cs file. The implementation of the route constraint can be found in the Custom/EmailRouteConstraint.cs file.

The RoutingApiController is an WebApi 2.0 controller containing several methods demonstrating the default route constraints provided by the default constraint resolver. There is also a method with an Email route constraint. The route constraint mapping can be found in App_Start/WebApiConfig.cs and the implementation for the route constraint can be found in the Custom/EmailHttpRouteConstraint.cs file.

Note that the routing bindings and route constraint implementations for a MVC controller and WebApi controller differ in namespaces, configuration and implementation.

#### Swagger/OpenApi with Swashbuckle

This .NET Framework (4.7.2) web application contains code showing how to configure and customize a Swagger UI.

The App_Start\SwaggerConfig.cs contains all relevant configuration. This file was created by adding the Swashbuckle NuGet package to the project. Swashbuckle will only generate methods in the Swagger.json file for API controller. MVC controller methods will not appear.

The document and operation filter implementations are located in the Custom\Swagger folder. 

The XML comments file output is configured in the Project Properties in the Build tab. The warnings, that not all methods are decorated with XML comments, are also suppressed in the Build tab. A method in the RoutingApiController.cs was decorated with XML comments to generate the contents for the XML comments file.

The RoutingApiController.cs file contains a method GetCustomResponseType. This method was decorated with the ResponseType to list the output JSON model in the SwaggerUI page for that method.


## .NETCore.WebApiExample

#### Routing

This .NET Core (2.1) web application contains code showing the route constraint possibilities. 

The HomeController is an controller containing a method accepting an email parameter. The Email route constraint binding is setup in the Startup.cs file. The implementation of the route constraint can be found in the MiddleWare/EmailRouteConstraint.cs file.

The RoutingApiController is an WebApi controller containing several methods demonstrating the default route constraints provided by the default constraint resolver. There is also a method with an Email route constraint. The route constraint mapping can be found in Startup.cs and the implementation for the route constraint can be found in the MiddleWare /EmailRouteConstraint.cs file.

In ..NET Core MVC and WebApi controllers share the same base class and setup in the Startup.cs file so you no longer have to provide separate implementations and mappings.

#### Swagger/OpenApi with Swashbuckle

This .NET Core (2.1) web application contains code showing how to configure and customize a Swagger UI.

The StartUp.cs contains all relevant configuration and requires the Swashbuckle NuGet package to be installed. The document and operation filter implementations are located in the MiddleWare\Swagger folder. 

The XML comments file output is configured in the Project Properties in the Build tab. The XML comments output location was customized to a variable path directly in the csproj file of the project. The warnings, that not all methods are decorated with XML comments, are also suppressed in the Build tab. A method in the HomeController.cs was decorated with XML comments to generate the contents for the XML comments file.

The HomeController.cs file contains a method GetCustomResponseType. This method was decorated with the ProducesResponseType to list the output JSON model in the SwaggerUI page for that method.

## Utilities

This .NET Standard (2.0) class library contains a simple IsEmail extension method used by the EmailRouteConstraint implementations in the web projects. 

## IntegrationTests

This .NET Core (2.1) test project constains several tests to show which routes are found and not found in both the .NETCore.WebApiExample and Framework.WebApiExample websites.

## Microsoft Docs reference links for routing

- [Creating an ..NET Framework MVC route constraint](https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/controllers-and-routing/creating-a-route-constraint-cs "Creating an ..NET Framework MVC route constraint")
- [Creating an ..NET Framework WebApi 2.0 route constraint](https://docs.microsoft.com/en-us/aspnet/web-api/overview/web-api-routing-and-actions/attribute-routing-in-web-api-2#route-constraints "Creating an ..NET Framework WebApi 2.0 route constraint")
- [..NET Core 2.1 route constraint reference](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/routing?view=aspnetcore-2.1#route-constraint-reference "..NET Core 2.1 route constraint reference")


## Reference links for Swagger/OpenApi implementation
- [Swashbuckle github project and documentation](https://github.com/domaindrivendev/Swashbuckle "Swashbuckle github project and documentation"){:target="_blank"}
- [Swashbuckle. AspNetCore github project and documentation](https://github.com/domaindrivendev/Swashbuckle.AspNetCore  "Swashbuckle.AspNetCore github project and documentation"){:target="_blank"}
- [Microsoft docs Swagger page for .NET Core](https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger "Microsoft docs Swagger page for .NET Core "){:target="_blank"}
