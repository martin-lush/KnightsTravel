# KnightsTravel
Represents the travel of a knight around a chess board using Backtracking strategy.

##Rules
- The knight can only move in the normal way and cannot travel through a square it has already been on.
- If the knight reaches the end of its travel but has not passed through every possible space on the chess board it must backtrack its moves until it finds the route that passes through them all.

### Developer Setup
#### Requirements
- Install [.NET Core 5 SDK](https://www.microsoft.com/net/download)
- Install [Visual Studio 2019](https://www.visualstudio.com/downloads)

##### Alternatives (caveat emptor)
- [Visual Studio Code](https://code.visualstudio.com/download)

#### Setup
- Clone this repository
- Open solution in Visual Studio

##### Testing the solution

Solution was created to work with dotnet test.

- run `dotnet restore`
- run `dotnet test`

or

- Run all tests within Text Explorer window

### TODO List
Comments are placed throughout the code base, however here's a quick rundown:
- Implement Dependency Injection or Decorator Pattern (for logging & output to other than Console)
- Add Application Insights (for performance metrics)
- SpecFlow / Specification tests so full end to end journey can be done
- Stress Tests to be considered (not currently within scope of required, 8x8 chess board was the only requirement)
- Optimisation of memory footprint (using 32 bit where as could move down to 8 bit)
- Multi-threaded processing (currently running as Single-Threaded apartment)
