

# IMDb Top Actors Scraper API

This project is a RESTful API developed in C# .NET Core for managing an actor database, sourced from IMDb. The API provides endpoints for retrieving, adding, updating, and deleting actor information, with data preloaded from a web-scraping operation. The scraping is done using the HTMLAgilityPack library.

## Features

- Scrapes top actor data from IMDb.
- In-memory database for storing actor data.
- RESTful API with endpoints for managing actor data.
- Supports filtering, pagination, and data validation.
- Extensible to support multiple data providers (e.g., IMDb, Rotten Tomatoes).

## Technologies Used

- C# .NET Core
- HTMLAgilityPack
- In-Memory Database
- RESTful API

## Endpoints

### Get All Actors

Retrieve a list of all actors, with optional filters and pagination.

```http
GET /api/actors
```

**Query Parameters:**

- `name` (optional): Filter by actor's name.
- `rank` (optional): Filter by rank range (e.g., `rank=1-10`).
- `page` (optional): Page number for pagination.
- `pageSize` (optional): Number of items per page.

**Response:**

```json
[
  {
    "id": 1,
    "name": "Actor Name"
  },
  ...
]
```

### Get Actor Details

Retrieve details for a specific actor.

```http
GET /api/actors/{id}
```

**Response:**

```json
{
  "id": 1,
  "name": "Actor Name",
  "rank": 1,
  "bio": "Actor biography..."
}
```

### Add a New Actor

Add a new actor to the database.

```http
POST /api/actors
```

**Request Body:**

```json
{
  "name": "New Actor",
  "rank": 10,
  "bio": "Biography of the new actor."
}
```

**Response:**

```json
{
  "id": 2,
  "name": "New Actor",
  "rank": 10,
  "bio": "Biography of the new actor."
}
```

### Update Actor Details

Update details of an existing actor.

```http
PUT /api/actors/{id}
```

**Request Body:**

```json
{
  "name": "Updated Actor",
  "rank": 5,
  "bio": "Updated biography."
}
```

**Response:**

```json
{
  "id": 1,
  "name": "Updated Actor",
  "rank": 5,
  "bio": "Updated biography."
}
```

### Delete an Actor

Delete an actor from the database.

```http
DELETE /api/actors/{id}
```

**Response:**

```json
{
  "message": "Actor deleted successfully."
}
```

## Setup Instructions

1. **Clone the Repository:**

   ```bash
   git clone <your-repository-url>
   cd <repository-directory>
   ```

2. **Install Dependencies:**

   Ensure you have .NET Core SDK installed. Then restore the dependencies:

   ```bash
   dotnet restore
   ```

3. **Run the Application:**

   ```bash
   dotnet run
   ```

   The API will be available at `http://localhost:5000`.

4. **Run Tests:**

   To run the included unit tests, use the following command:

   ```bash
   dotnet test
   ```

## Error Handling

The API includes comprehensive error handling and validation. Common errors include:

- **400 Bad Request:** Invalid input or missing required fields.
- **404 Not Found:** Actor not found.
- **500 Internal Server Error:** General server error.

## Extensibility

The project is designed to support multiple data providers. The `ProviderFactory` can be extended to add new providers such as Rotten Tomatoes.

## License

This project is licensed under the MIT License.

## Contact

For any questions or issues, please contact [porusheli@gmail.com](mailto:porusheli@gmail.com).

## Repository

The project's GitHub repository is available [here](https://github.com/eliyahuPorush/splitit-movie-actors-api).

