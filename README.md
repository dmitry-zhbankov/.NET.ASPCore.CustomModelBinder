# Custom Model Binder
## Short Description
Example of custom model binders for ASP.NET Core MVC application.
## Topics
* ASP.NET Core
* WebApi apps
* Routing
* Model Binding
* Testing and Debugging
## Requirements
* If not specified, feel free to choose between .NET Core and .NET Framework technology, but the first one is prefered.
* Remember about code style and naming conventions.
* Hosting application with IIS is welcome but not required.
* Using of the 3rd party libraries that ease the task implementation directly is prohibited.
* Create custom model binder that allows to accept the requests like https://localhost:44310/api/location?coord=1,2,3.
* The action should return the Point object with corresponding x, y, z coordinates filled from the request.
* The Action result should be in json format.
* Create a Person model with some arbitrary properties, including identifier as following public Guid Id {get;set;}
* Create another custom model binder that allows to accept the requests like https://localhost:44310/api/person/stQlYvnRqU6wvoevbgfLaw where stQlYvnRqU6wvoevbgfLaw is a base-64 encoded person identifier.
* The Action result should return json with the Person object with decoded identifier property.
