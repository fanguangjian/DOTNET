<!--
 * @Author: G.F
 * @Date: 2024-09-11 21:32:22
 * @LastEditTime: 2024-11-26 23:16:22
 * @LastEditors: your name
 * @Description: 
 * @FilePath: /dotnet/DotnetAPI/readme.md
-->
dotnet new webapi -n DotnetAPI
dotnet add package dapper
dotnet add package automapper
dotnet add package Microsoft.Data.SQLClient

dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Relational
dotnet add package Microsoft.EntityFrameworkCore.SqlServer



run: dotnet run
dotnet watch run
http://localhost:5121/weatherforecast
http://localhost:5121/swagger/index.html