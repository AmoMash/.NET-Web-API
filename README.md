# CMPG-323-Project-2-34204792
This project is designed to manage telemetry data using a .NET Web API connected to a SQL Server database.

## Where are the porject files
- They are in the master branch

## How to Use the Report
- The report can be accessed via the API endpoints described below

## Authentication

- The endpoints do not have authentication

## API Endpoints
- `GET /api/telemetry` - Retrieve all telemetry entries.
- `GET /api/telemetry/{id}` - Retrieve a telemetry entry by ID.
- `POST /api/telemetry` - Create a new telemetry entry.
- `PATCH /api/telemetry/{id}` - Update an existing telemetry entry.
- `DELETE /api/telemetry/{id}` - Delete a telemetry entry.
- `GET /api/telemetry/getsavings` - Retrieve savings by project or client.

## Error Handling

- **401 Unauthorized**: Returned if the request lacks valid authentication.
- **404 Not Found**: Returned if the specified resource is not found.
- **500 Internal Server Error**: Returned for unexpected server errors.
