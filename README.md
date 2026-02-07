# Family Tree Application

A .NET 10 solution with three projects that displays a family tree website.

## Projects

1. **FamilyTree.Database** - Class library containing hardcoded family data
2. **FamilyTree.Api** - Web API that exposes family member endpoints
3. **FamilyTree.BlazorApp** - Blazor Server application that displays the family tree

## Features

- Family tree spanning 5 generations (from Great Great Grandparents to Children)
- 15 family members with names, birth dates, and relationships
- Beautiful, responsive UI with cards for each family member
- Shows age calculation and parent-child relationships
- Color-coded generations with hover effects

## Running the Application

### Prerequisites
- .NET 10 SDK installed

### Option 1: Using Visual Studio

1. Open `FamilyTree.sln` in Visual Studio
2. Right-click on the solution in Solution Explorer
3. Select **"Set Startup Projects..."** or **"Configure Startup Projects..."**
4. Choose **"Multiple startup projects"**
5. Set both **FamilyTree.Api** and **FamilyTree.BlazorApp** to **"Start"**
6. Click OK and press F5 to run

### Option 2: Using Command Line (Manual)

1. **Start the API** (in one terminal):
   ```bash
   cd FamilyTree.Api
   dotnet run
   ```
   The API will start at https://localhost:7001

2. **Start the Blazor App** (in another terminal):
   ```bash
   cd FamilyTree.BlazorApp
   dotnet run
   ```
   The Blazor app will start (check console for port, typically https://localhost:5001)

3. **Open your browser** and navigate to the Blazor app URL

### Option 3: Using a Single Command

Run this from the solution root directory:
```bash
start cmd /k "cd FamilyTree.Api && dotnet run" && start cmd /k "cd FamilyTree.BlazorApp && dotnet run"
```

**Important:** Both the API and Blazor app must be running for the application to work correctly!

## API Endpoints

- `GET /api/family` - Returns all family members in a flat list
- `GET /api/family/tree` - Returns family members organized as a tree structure

## Family Members

The Thompson family includes:
- **Generation 0**: William & Margaret Thompson (Great Great Grandparents)
- **Generation 1**: Robert & Helen Thompson (Great Grandparents)
- **Generation 2**: James, Sarah & Michael Thompson (Grandparents)
- **Generation 3**: David, Emily & Christopher Thompson (Parents)
- **Generation 4**: Oliver, Emma, Sophia, Lucas & Ava Thompson (Children)

## Technology Stack

- .NET 10
- ASP.NET Core Web API
- Blazor Server with Interactive Server rendering
- C# 13
- CSS for styling

## Notes

- All data is currently hardcoded in `FamilyDataStore.cs`
- CORS is enabled on the API to allow requests from the Blazor app
- The application uses HTTPS by default
