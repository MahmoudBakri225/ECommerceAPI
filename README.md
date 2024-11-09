# ECommerce API
This ECommerce API provides endpoints to manage various resources such as Accounts, Categories, Contacts, and Products. It allows clients to perform CRUD operations following RESTful principles.

## Features
- **User Authentication**: Register, login, and logout endpoints to manage user accounts securely.
- **Product Management**: Create, update, delete, and retrieve products with search functionality.
- **Category Managemen**t: Organize products into categories with category-specific retrieval.
- **Contact Management**: Allow users to submit contact messages that can be managed by admins.



### Base URL
bash
Copy code
http://localhost:7291/api
#### Endpoints
- **Account**
- POST /Account/registration - Register a new user account.
- POST /Account/login - Login for existing users.
- POST /Account/logout - Logout from the account.
- **Category**
- GET /Category - Retrieve all categories.
- POST /Category - Create a new category.
- GET /Category/{id} - Retrieve a category by ID.
- PUT /Category/{id} - Update an existing category by ID.
- DELETE /Category/{id} - Delete a category by ID.
- GET /Category/{id}/products - Retrieve products within a specific category.
- **ContactUs**
- GET /ContactUs - Retrieve all contact messages.
- POST /ContactUs - Submit a new contact message.
- GET /ContactUs/{id} - Retrieve a contact message by ID.
- PUT /ContactUs/{id} - Update an existing contact message by ID.
- DELETE /ContactUs/{id} - Delete a contact message by ID.
- **Product**
- GET /Product - Retrieve all products.
- POST /Product - Add a new product.
- DELETE /Product - Delete all products.
- GET /Product/{id} - Retrieve a product by ID.
- PUT /Product/{id} - Update an existing product by ID.
- GET /Product/search - Search for products.
##### Getting Started
Clone the repository:

bash
Copy code
git clone https://github.com/yourusername/ECommerceAPI.git
Install dependencies and configure your development environment as per the project setup.

Run the application and navigate to http://localhost:7291/swagger to explore and test the API endpoints.

##### Technologies Used
- **ASP.NET Core - Web API framework**
- **Entity Framework Core - ORM for data management**

