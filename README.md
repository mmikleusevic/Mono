Summary: develop a minimalistic application of your choice by following the technologies and concepts mentioned above and the requirements defined below.

Requirements

Create a database with the following elements
  VehicleMake (Id,Name,Abrv) e.g. BMW,Ford,Volkswagen,
  VehicleModel (Id,MakeId,Name,Abrv) e.g. 128,325,X5 (BWM), 
Create the solution (back-end) with the following projects and elements
  Project.Service
    EF models for above database tables
    VehicleService class - CRUD for Make and Model (Sorting, Filtering & Paging) 
      *This is where you should report with a first code review
  Project.MVC 
    Make administration view (CRUD with Sorting, Filtering & Paging)
    Model administration view (CRUD with Sorting, Filtering & Paging)
    Filtering by Make

    
Implementation details 

async/await should be enforced in all layers (async all the way)
all classes should be abstracted (have interfaces so that they can be unit tested)
IoC (Inversion of Control) and DI (Dependency Injection) should be enforced in all layers (constructor injection preferable) 
  Ninject DI container should be used (https://github.com/ninject/ninject/wiki)
Mapping should be done by using AutoMapper (http://automapper.org/)
EF 6, Core or above with Code First approach (EF Power Tools can be used) should be used  
MVC project
  return view models rather than EF database models
  return proper HTTP status codes
