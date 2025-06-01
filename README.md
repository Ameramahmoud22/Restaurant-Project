# Restaurant-Project

A RESTful API for managing a restaurant system, built with **.NET 8** and **C# 12**.  
This project demonstrates clean architecture with dependency injection (DI), controllers, services, interfaces, models, middleware, and Entity Framework Core for data access.

---

## Features

- Manage menu items (CRUD)
- Manage customer orders
- Clean separation of concerns (Controllers, Services, Interfaces, Models)
- Global exception handling middleware
- API documentation and testing via Swagger UI
- Uses Entity Framework Core with SQL Server

---

## Folder Structure
```
├── Controllers/ 
│   ├── MenuController.cs         # API endpoints for menu items 
│   └── OrderController.cs        # API endpoints for orders 
│ 
├── Interfaces/ 
│   ├── IMenuService.cs           # Interface for menu service 
│   └── IOrderService.cs          # Interface for order service 
│ 
├── Models/ 
│   ├── Customer.cs               # Customer entity 
│   ├── MenuItem.cs               # Menu item entity 
│   ├── Order.cs                  # Order entity 
│   └── OrderItem.cs              # Order item entity 
│ 
├── Services/ 
│   └── Services/ 
│       ├── MenuService.cs        # Business logic for menu items 
│       └── OrderService.cs       # Business logic for orders 
│ 
├── Infrastructure/ 
│   └── Data/ 
│       └── RestaurantDbContext.cs # Entity Framework Core DbContext 
│ 
├── API/ 
│   └── Middleware/ 
│       └── ExceptionMiddleware.cs # Global exception handling 
│ 
├── Properties/ 
│   └── launchSettings.json       # Project launch profiles 
│ 
├── Program.cs                    # Application entry point and configuration 
├── RestaurantSystem.csproj       # Project file and dependencies 
└── README.md                     # Project documentation
```


---

## Technologies & Libraries Used

- **.NET 8 / C# 12**
- **Entity Framework Core 8** (with SQL Server)
- **Swashbuckle.AspNetCore** (Swagger/OpenAPI for API docs)
- **ASP.NET Core Web API**
- **Dependency Injection** for services and DbContext

---

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- SQL Server (localdb or full instance)

### Setup

1. **Clone the repository**
2. **Configure the connection string**  
   Create `appsettings.json` and set your SQL Server connection string.
3. **Apply database migrations**
  ```
  dotnet ef database update
  ```
4. **Run the project**
   ```
	dotnet run
	```
or use Visual Studio's Run/Debug button.

5. **Open Swagger UI**  
   The API documentation and test interface will be available at:  
	```
	http://localhost:<port>/swagger
	```


---

## API Endpoints

- `GET /api/menu` - List all menu items
- `GET /api/menu/{id}` - Get menu item by ID
- `POST /api/menu` - Add a new menu item
- `POST /api/order` - Create a new order
- `GET /api/order/{id}` - Get order by ID

All endpoints and models are documented and testable via Swagger UI.

---

## Error Handling

- Global exception handling is provided by custom middleware (`ExceptionMiddleware.cs`).

---

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

---

## License

This project is licensed under the MIT License.

