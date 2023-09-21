# .NET web api backend for Dashboard starter

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
<a href="https://github.com/j1032w/dashboard-starter" target="_blank"><img src="https://visitor-badge.laobi.icu/badge?page_id=j1032w/das-webapi-.NET"></a>
[![](https://www.paypalobjects.com/en_US/i/btn/btn_donate_SM.gif)](https://www.paypal.com/donate/?hosted_button_id=29ZE3URD5V9Q8)

## Features

- Built on .NET 7.0, Oracle 19c and MS SQL Server 2022
- Follows [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html) Principles
- Repository Pattern with [Dapper](https://github.com/DapperLib/Dapper) 
- Integration with [Swagger](https://github.com/domaindrivendev/Swashbuckle.AspNetCore), [Serilog](https://serilog.net/), [AutoMapper](https://automapper.org/), [Newton Json(Json.NET)](https://www.newtonsoft.com/json), [Dapper](https://dapperlib.github.io/Dapper/)
- Unit tests with [xUnit](https://xunit.net/) and [Moq](https://github.com/moq/moq)

## Getting Started
To create schema and seed data in Oracle 19c and above:
- You may run the SQL scripts in the `database\oracle-19c` folder, as privileged user with rights to create another user (SYSTEM, ADMIN, etc.) \
  dashboard_schema_create.sql \
  dashboard_create.sql \
  dashboard_populate.sql
- Or you may import the `dashboard.dmp` file in the `database` folder with the below command:
``` 
impdp userid=username/password@//server-ip:1521/service-name DIRECTORY=orcl_dump   DUMPFILE=dashboard.dmp FULL=Y
```
To remove the schema
- You may run the SQL `dashboard_schema_drop.sql` in the `database` folder.
- Or you may drop the schema with the below command:
```
DROP USER DASHBOARD CASCADE
```

![Demo](documentations/screen-residential-property-api.png)
<br/>  
<br/>


## Design
![Demo](documentations/design-uml.png)




