# _Eau Claire's Salon_

#### _AAn MVC web application to help Claire manage her employees (stylists) and their clients; 18-October-2019_

#### By _**Mike McShane**_

## Description

_An MVC web application to help Claire manage her employees (stylists) and their clients._

## Specifications

| Behavior | Input | Output|
|:------|:---------:|:------:|
| It lets Claire add her stylists to the database. | "Pierre" | Stylist: Pierre |
| It lets Claire view details for each stylist | Stylist: Pierre | "Pierre's Client List:" |
| It lets Claire add clients to her stylists | Client: Sally | "Name: Sally" "Age: 39" "Stylist: Pierre" |
| It lets Sally edit/delete clients and stylists | Delete Pierre | "Pierre has been removed from the database"

## Setup/Installation Requirements_

* Open MySQLWorkbench
* CREATE DATABASE mike_mcshane
* CREATE TABLE stylists (stylistid serial PRIMARY KEY AUTO_INCREMENT, name VARCHAR(255));
* CREATE TABLE clients (clientid serial PRIMARY KEY AUTO_INCREMENT, name VARCHAR(255), age INT, number, VARCHAR(255), stylistid INT);
* _Clone this repository from https://github.com/mmcshane10/Eau-Claire-s-Salon.git
* _Navigate to the root directory_
* _Use "dotnet run" command in console to generate localhost site._

## Known Bugs

_Search function does not currently return found clients_

## Support and contact details

mmcshane10@gmail.com

## Technologies Used

_HTML, CSS, C#, .NET, MySQL_

### License

*open source*

Copyright (c) 2019 **_Mike McShane_**
