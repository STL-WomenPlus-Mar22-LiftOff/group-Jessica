# Household Manager

## Description
Household Manager Web Application using C# and ASP.NET Core 6 via MVC created with the intent for 5 entry-level programmers to practice building an application from scratch utilizing Agile development and version-control via branching in GitHub.

Household Manager allows individuals that live in a multi-person unit to collect, organize, and assign all chores and assignments involved in keeping up with home organization and cleanliness efficiently and fairly.

## Contributors
- [**Alli**](https://github.com/alliology934)
- [**Erica**](https://github.com/ejohnson1124)
- [**Michele**](https://github.com/mmrichmond6)
- [**Roxanna**](https://github.com/narhiril)
- [**Spencer**](https://github.com/wilsons6561)

## Features
- Manipulation of database content through CRUD operations.
- Authentication and authorization via Identity framework.
- Clear and efficient method for choosing icons by jQuery implementation and icon API utilization.
- Modern UI through intentional usage of Bootstrap 5, Sass, and theme selection feature.
- Informative and useful display of data through sortable and pageable tables powered by Syncfusion UI components.
- Basic ability to send SMS message utilizing Twilio.

## Technology Stack
- **Language:** C#
- **Framework:** .NET 6.0
- **Template Engine:** ASP.NET Core MVC
- **Database Engine:** SQL Express
- **Other Libraries or Components:**
  - Entity Framework
  - Bootstrap 5
  - Sass
  - Syncfusion
  - Identity
  - Icon API
  - Font Awesome
  - Twilio API
  - ngrok

## Instructions
1. Fork this repository
2. Clone your forked repository
3. Ensure Microsoft SQL Express is installed on your local machine.
4. Through the Package Manager console type "update-database" to initialize and migrate the seeded database with its tables to SQL Express.
5. Run the application to see if it builds and runs correctly
6. Log-in with either the pre-seeded admin or user to visit their authorized pages.
7. Celebrate that you made it here and enjoy working with this block of code!

## Bonus!
- Should you wish to learn more about SMS messaging, head to [**Twilio**](https://www.twilio.com/docs/sms/quickstart/csharp-dotnet-core) to learn more about how to set up basic SMS messages. This will walk you through the steps to set up an account and allow Twilio to access your web application.
- You will then need to open the Package Manager console and type "install-package twilio" to add access to the Twilio API and helper libraries.
- Additionally, should you want the capability of sending and receiving messages, you will need a tunneling API like [**ngrok**](https://ngrok.com/).
