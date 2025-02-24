Zakaria Kara - Walker Advertising Code Challenge

# Requirements
 - .Net 8.0
 - Dotnet CLI

# Running application
 - From the root of the project, run the following commands:
  * dotnet build
  * cd ClientApp
  * npm install (dotnet build should have already built the frontend as well as the backend)
  * cd ../
  * dotnet run

# Using the application
 - Data should be initialized by using Postman or a similar tool to seed the data that goes into the data table
 - An example POST request to localhost:5000/api/Lead should be made with a body that looks something like:
  > {
        "id": "0f8fad5b-d9cb-469f-a165-708677289501",
        "name": "test",
        "phoneNumber": 1,
        "zipCode": 1,
        "emailConsent": true,
        "emailAddress": null
    }
 - Once the data is seeded, navigating to https://localhost:5001 will render a table showing the data from the previous POST request