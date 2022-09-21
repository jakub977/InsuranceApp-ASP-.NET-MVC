# InsuranceApp-ASP-.NET-MVC

## Title
Dynamic web application for insurance and client registration.

## Descripton
This project of responsive web application for the insurance company will let user save all neccessary information about client, 
their insurance, and possible insured events to the database.
Any user can register as a basic user and login with their profile information.
User of the basic authorization can create profile with their personal information, add new insurance to their profile, 
and add and edit their insured events. They are unable to edit or delete their profile, and insurance as well as delete their insured events.
User with the Admin authorization has a full controll over user profiles and can create, edit, and delete all information about client as well 
as their insurance and filed insured events.
Information are stored in the SQL database.
The application is fully responsive.

## IDE requirements
Visual Studio Community 2022

## Installation and setup
1. Download source code from "Code" section, extract all the files and open the application in Visual Studio Community. 
2. For database set up, open "Package manager console" under "Tools" => "NuGet package manager".
3. Insert "Add-Migration" command to create migration of the database and then insert "Update-Database" to create corresponding 
database for the project.
4. Run the application.
