<!--
 * @Author: G.F
 * @Date: 2024-09-11 21:32:22
 * @LastEditTime: 2024-09-30 22:43:06
 * @LastEditors: your name
 * @Description: 
 * @FilePath: /dotnet/DotnetAPI/readme.md
-->
dotnet new webapi -n DotnetAPI
dotnet add package dapper
dotnet add package automapper
dotnet add package Microsoft.Data.SQLClient

run: dotnet run
dotnet watch run
http://localhost:5121/weatherforecast
http://localhost:5121/swagger/index.html