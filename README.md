# LIMS33
Abp Demo

- ABP Framework version:4.4.3
- User Interface: Razor Pages
- database provider: EF Core(Oracle)
- Tiered: Not Tiered

ConnectionString for Oracle:
```c#
"ConnectionStrings": {
    "Default": "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.10.7)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=LIMS08)));User Id=system;Password=123456;"
  },
 ```
  
  - database :LIMS08
  
If you run this project ,you should create a oracle user **ym**, then grant permissions to **ym**. 
```
create user ym identified by 123456;
grant connect, dba to ym;
```


