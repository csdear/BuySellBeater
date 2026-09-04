# Buy Sell Beater

**beater (noun, informal):** An old or worn-out car, especially one that is inexpensive and used mainly as a basic means of transportation.
**Example:** “He drives an old beater to work so he doesn’t have to worry about damaging his new car.”

A full-stack sample application for browsing vehicle makes and models. The project combines an ASP.NET Core Web API with an Angular frontend and uses SQL Server + Entity Framework Core for persistence.

## Tech stack

- Backend: .NET 10 / ASP.NET Core Web API
- Frontend: Angular 19
- Database: SQL Server
- ORM: Entity Framework Core

## Project structure

- `BuySellBeater.api/` – ASP.NET Core backend and EF Core data access
- `BuySellBeater.Client/` – Angular client application
- `start-dev.ps1` – helper script to launch both apps on Windows

## Features

- API endpoint to fetch makes and their related models
- Angular client to display the vehicle catalog
- CORS configured between the frontend and backend
- EF Core migrations for database setup

## Prerequisites

Before running the app, make sure you have:

- .NET 10 SDK
- Node.js 20+ and npm
- Angular CLI (`npm install -g @angular/cli`)
- SQL Server instance available locally or on a reachable machine

## Configuration

The API reads its connection string from `BuySellBeater.api/appsettings.json`.

Update the `BuySellBeaterDatabase` value to point to your SQL Server instance:

```json
"ConnectionStrings": {
  "BuySellBeaterDatabase": "Server=YOUR_SERVER;Database=BuySellBeaterDb;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True"
}
```

You can also set this in `appsettings.Development.json` for local development.

## Run the application

The app is ready to run directly. On first startup, it will automatically create and migrate the database for you.

### Option 1: Start both apps manually

1. Restore .NET dependencies:

```bash
dotnet restore
```

2. Start the API:

```bash
cd BuySellBeater.api
dotnet run
```

3. In a second terminal, install frontend dependencies and run the client:

```bash
cd BuySellBeater.Client
npm install
npm start
```

The Angular app runs at `http://localhost:4200` and the API runs at `http://localhost:5000` or the port configured by ASP.NET.

### Option 2: Use the Windows helper script

From the repository root:

```powershell
./start-dev.ps1
```

This script opens two separate PowerShell windows for the API and Angular client.

## API endpoints

The backend exposes vehicle data through:

- `GET /api/makes`

Example response:

```json
[
  {
    "id": 1,
    "name": "Ford",
    "models": [
      { "id": 1, "name": "Mustang" }
    ]
  }
]
```

## Database setup and migration commands

The application is configured to automatically create and migrate the database on first start. If you want to manage migrations manually, these are the common commands.

### .NET CLI commands

```bash
# Apply all migrations (creates DB + seeds)
dotnet ef database update

# See pending migrations
dotnet ef migrations list

# Reset the database
dotnet ef database drop
dotnet ef database update
```

### Visual Studio / Package Manager Console commands

```powershell
Update-Database

# If you need to see pending migrations first:
Get-Migration

# To reset the database (delete and recreate):
# First, remove all migrations applied
Remove-Database

# Then recreate
Update-Database
```

## Notes

- The frontend uses CORS to allow requests from `http://localhost:4200`.
- The project is a sample starter and can be extended with filtering, search, inventory management, and authentication.
