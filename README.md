### AFS - Diego

## Overview
This is a complete sample project that uses the following technologies
* AspNet Core
* AspNet Mvc
* Entity Framework Core
* AutoMapper
* AngularJs
* Typescript
* Materialize
* NuGet
* Npm
* Bower + some plugins
* SASS

## Pre-Requirements
* [npm](https://nodejs.org/en/) for javascript dependencies
* [bower](https://bower.io/) for client-side dependencies
* [.NET Core](https://www.microsoft.com/net/core#windows) for the .NET core framework

## Instructions to Run

* Clone repository ```git clone https://github.com/iberodev/Afs.git ```
* ```cd Afs```
* ```dotnet restore``` to retrieve NuGet dependencies 
* ```cd src/Afs.Diego.Web``` to go to the main project
* ```npm install``` to install npm dependencies such as bower, gulp and plugins
* ```bower install``` to install bower dependencies such as angular, jquery, materialize and restangular
* ```gulp compile``` to run the gulp tasks that compile scss to css and typescript files to javascript
* ```dotnet run``` to run the application on Kestrel. Go to http://localhost:5000