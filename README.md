# Fugro Technical Challange

## Setup
1. Clone the repository:
`git clone https://github.com/shirominha-da-motoila/fugro-technical-challange.git`

3. At the project root, restore the required dependencies:
`dotnet restore`

4. Build the project:
`dotnet build`

5. Run the application:
`dotnet run --project AppHost`

## Challange Walkthrought and Decisions
### Tech-Stack
In this challange, I've focused on having a great time with it. Due to the freedom to choose the technology stack, I ended up with two different ones:

1. .NET Core + Next.JS in a monorepo with NX;
2. .NET Core + .NET Blazor with Aspire;

#### The NX approach
I spent some time trying to configure a .NET + Next.js project with NX, but the results didn’t meet my expectations. 
After a few hours, I decided to take a different path.

#### The Aspire approach
TThe curiosity I had about using .NET Aspire in a project was enough for me to try it in this challenge. I was impressed with how easy it is to start a new project from a template and set up the entire environment to begin writing code.

### Project Architecture
TThe base architecture was the one generated from the template:

- AppHost orchestrates the solution.
- ApiService centralizes the backend logic.
- Web centralizes the frontend logic.
- Tests are well described.
- ServicesDefaults handles the observability services.

With this structure in place, I started writing code.

### Tests
The API development was focused on unit tests using xUnit.

### Problem Solving
The main idea here was to use geometry to get to the results. I've took some time to revisit some math equations and studied how they could fit in this challange.
I've decided follow this steps:
- Calculate the distance between the point and every segment and get the minimum one;
- Calculate the Offset and Station
