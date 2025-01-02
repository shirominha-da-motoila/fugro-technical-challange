# Fugro Technical Challenge

## Setup
1. Clone the repository:
`git clone https://github.com/shirominha-da-motoila/fugro-technical-challange.git`

3. At the project root, restore the required dependencies:
`dotnet restore`

4. Build the project:
`dotnet build`

5. Run the application:
`dotnet run --project AppHost`

6. Follow the URL in the console to access the AppHost hub.

## Challange Walkthrought and Decisions
### Tech-Stack
In this challange, I focused on having a great time with it. Given the freedom to choose the technology stack, I ended up with two different options:

1. .NET Core + Next.JS in a monorepo with NX;
2. .NET Core + .NET Blazor with Aspire;

#### The NX approach
I spent some time trying to configure a .NET + Next.js project with NX, but the results didn’t meet my expectations. 
After a few hours, I decided to take a different approach.

#### The Aspire approach
My curiosity about using .NET Aspire in a project led me to try it in this challenge. I was impressed with how easy it is to start a new project from a template and set up the entire environment to begin writing code.

### Project Architecture
TThe base architecture was the one generated from the template:

- AppHost orchestrates the solution.
- ApiService centralizes the backend logic.
- Web centralizes the frontend logic.
- Tests are well described.
- ServicesDefaults handles the observability services.

With this structure in place, I began writing the code.

### Tests
The API development was focused on unit tests using xUnit.

### Problem Solving
The main idea here was to use geometry to get to the results. I took some time to revisit some math equations and study how they could fit into this challenge.
I decided follow these steps:
- Calculate the distance between the point and each segment, then get the minimum distance;
- Calculate the Offset and Station;
