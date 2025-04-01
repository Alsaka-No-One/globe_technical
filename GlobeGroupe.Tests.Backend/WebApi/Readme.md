# WebApi Project

This project is a recruitment candidate exercise project. It implements a RESTful API using ASP.NET Core Web API.

Entity Framework's context, `ApplicationDbContext`, is available through dependency injection to store and retrieve data using an InMemory database.

If you're not familiar with Entity Framework, you can use your ORM of choice. However, please note that Globe Groupe exclusively uses Dapper and Entity Framework

## Endpoints

### Missions
- **Get all missions**: Retrieve a list of all missions, with optional filters for id, name, date (after, before), country, intervention point name, and whether it includes a promoter.
- **Get mission by id**: Retrieve details of a specific mission by their id.
- **Create a new mission**: Add a new mission to the system.
- **Delete a mission**: Remove a mission from the system. (Note: You cannot delete a past mission if a promoter is assigned to it.)

For a junior developer, at least 1 read endpoint and 1 write endpoint should be implemented.

## Assessment Criteria

The assessment criteria for this project will be based on the following:
- Correctness and completeness of the implemented endpoints.
- Code quality and adherence to best practices.
- Proper use of ASP.NET Core Web API features.
- Handling of edge cases and error conditions.
- Documentation and readability of the code.

## Testing

All endpoints should be testable with the provided HTTP file located at `WebApi/GlobeGroupe.Tests.WebApi/GlobeGroupe.Tests.WebApi.http`.
