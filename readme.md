# WebApiExamples

These projects were created with a Visual Studio 2017 Community Edition 
This solution is a reference implementation for [my blogpost regarding route constraints](https://samanthaneilen.github.io/2018/10/09/using-route-constraints-for-input-validation-and-improved-security.html "blogpost regarding route constraints"){:target="_blank"}.


## Framework.WebApiExample

This Net Framework (4.7.2) web application contains code showing the route constraint possibilities. 

The HomeController is an MVC controller containing 2 methods accepting an email parameter. One method is decorated with the a route attribute. The other has a route configured in de App_Start/RouteConfig.cs file.
Both routes have a Email constraint on the email input parameter. The route constraint binding is setup in the App_Start/RouteConfig.cs file. The implementation of the route constraint can be found in the Custom/EmailRouteConstraint.cs file.

The RoutingApiController is an WebApi 2.0 controller containing several methods demonstrating the default route constraints provided by the default constraint resolver. There is also a method with an Email route constraint. The route constraint mapping can be found in App_Start/WebApiConfig.cs and the implementation for the route constraint can be found in the Custom/EmailHttpRouteConstraint.cs file.

Note that the routing bindings and route constraint implementations for a MVC controller and WebApi controller differ in namespaces, configuration and implementation.

## NetCore.WebApiExample

This Net Core (2.1) web application contains code showing the route constraint possibilities. 

The HomeController is an controller containing a method accepting an email parameter. The Email route constraint binding is setup in the Startup.cs file. The implementation of the route constraint can be found in the MiddleWare/EmailRouteConstraint.cs file.

The RoutingApiController is an WebApi controller containing several methods demonstrating the default route constraints provided by the default constraint resolver. There is also a method with an Email route constraint. The route constraint mapping can be found in Startup.cs and the implementation for the route constraint can be found in the MiddleWare /EmailRouteConstraint.cs file.

In .Net Core MVC and WebApi controllers share the same base class and setup in the Startup.cs file so you no longer have to provide separate implementations and mappings.

## Utilities

This Net Standard (2.0) class library contains a simple IsEmail extension method used by the EmailRouteConstraint implementations in the web projects. 

## IntegrationTests

This Net Core (2.1) test project constains several tests to show which routes are found and not found in both the NetCore.WebApiExample and Framework.WebApiExample websites.

## Microsoft Docs reference links

- [Creating an .Net Framework MVC route constraint](https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/controllers-and-routing/creating-a-route-constraint-cs "Creating an .Net Framework MVC route constraint"){:target="_blank"}.
- [Creating an .Net Framework WebApi 2.0 route constraint](https://docs.microsoft.com/en-us/aspnet/web-api/overview/web-api-routing-and-actions/attribute-routing-in-web-api-2#route-constraints "Creating an .Net Framework WebApi 2.0 route constraint"){:target="_blank"}.
- [.Net Core 2.1 route constraint reference](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/routing?view=aspnetcore-2.1#route-constraint-reference ".Net Core 2.1 route constraint reference"){:target="_blank"}.