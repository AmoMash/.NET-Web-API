# CMPG-323-Project-2-34204792
This project is designed to manage telemetry data using a .NET Web API connected to a SQL Server database.

## How to Use the Report
- The report can be accessed via the API endpoints described below.
- Ensure you have the necessary credentials and access rights to use the API.

## API Endpoints
- `GET /api/telemetry` - Retrieve all telemetry entries.
- `GET /api/telemetry/{id}` - Retrieve a telemetry entry by ID.
- `POST /api/telemetry` - Create a new telemetry entry.
- `PATCH /api/telemetry/{id}` - Update an existing telemetry entry.
- `DELETE /api/telemetry/{id}` - Delete a telemetry entry.
- `GET /api/telemetry/getsavings` - Retrieve savings by project or client.
