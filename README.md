# CMPG-323-Project-2-34204792
This project is designed to manage telemetry data using a .NET Web API connected to a SQL Server database.

## How to Use the Report
- The report can be accessed via the API endpoints described below.
- Ensure you have the necessary credentials and access rights to use the API.

## Authentication

To access protected endpoints, you need to authenticate using JWT. Obtain a token by making a GET request to the authentication endpoint.

**GET** `/api/authenticate`

- **Description**: Authenticate and obtain a JWT token.
- **Request Body**:
  ```json
  {
    "username": "your_username",
    "password": "your_password"
  }

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
