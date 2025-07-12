# Book.Api
***
Book.Api is a basic backend server API application for managing book publications.
It provides simple CRUD operations (GET, POST, UPDATE, DELETE) for handling books.
This project uses Mapper and Swashbuckle extensions.
## Features
---
* Create, read, update, and delete books
* RESTful API endpoints
* C# implementation
* Mapper for object mapping
* Swashbuckle for API documentation (Swagger)
## Getting Started
---
1. Clone the repository
```bash
  git clone https://github.com/JaromirIhln/Book.Api.git
```
### 2. Install dependencies
---
 * .NET SDK (9.0 +)
### 3. Run the aplication
---
   ```bash
   dotnet run
   ```
   or `F5` on VisualStudio
### 4. Access Swagger UI
---
 *  * Navigate to <https://localhost:7219/swagger> (open page /index.html))
    (or your configured port) to explore the API.
## API Endpoits
---
  * `GET /api/books` - Retrieve all books
  * `GET /api/books/{id}` - Retrieve a book by ID
  * `POST /api/books` - Add a new book
  * `PUT /api/books/{id}` - Update an existing book
  * `DELETE /api/books/{id}` - Delete a book
## License
---
This project is open source and available under the ([MIT License](https://opensource.org/licenses/MIT)).
