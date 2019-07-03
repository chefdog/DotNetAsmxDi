# 1. DotNetAsmxDi
Dependency injection with autofac in asp.net webforms and webservices

## 2. Introduction

Using autofac to inject Serilog and custom services into asmx and aspx based classes.
The issue with DI and asp.net webforms is that injection in constructors does not work.

## 3. Examples
Dependency injection is setup in the Global.asax. I have registered two instances; serilog and a custom service.
Serilog needs some extra configuration, that is also handled in the Global.asax.

### 3.1. ASPX
Default.aspx is the implemented example. This implemtation is pretty straightforward. 
Each service that is needed in the aspx class, is exposed through property get&set.
Autofac takes care of the injection in the properties.

The result of calling the custom business service is displayed in a asp.net literal.

### 3.2. ASMX
LoggingWebService.asmx is the implemented example.
Implementation within an asmx is a little bit different. The process of injection into properties is not done through an automatic process.
There is need for a little bit extra code, that is done in the constrcutor.

## 4. Serilog
Serilog is configured to use the rolling file sink. The log files are saved in the App_Data folder.
There is one file for serilog and one for the application. The serilog file is used when something goes wrong with Serilog itself.
The application log file is the standard file for the application info, warning, exceptions etc.


## 5. What is next?
Moving the serilog setup in a custom service class.
Moving the autofac integration from asmx to a base class.
Adding UnitTests

#### References
https://autofaccn.readthedocs.io/en/latest/integration/webforms.html#tips-and-tricks

https://www.codeproject.com/Articles/310677/ASP-NET-Web-Services-Dependency-Injection-using-Un

https://autofaccn.readthedocs.io/en/latest/integration/webforms.html#dependency-injection-via-base-page-class


