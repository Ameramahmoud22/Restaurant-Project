# Restaurant-Project

A RESTful API for managing a restaurant system, built with **.NET 8** and **C# 12**.  
This project demonstrates clean architecture with dependency injection (DI), controllers, services, interfaces, models, middleware, and Entity Framework Core for data access.

---

## Features

- Full CRUD for menu items, orders, and customers
- Customers can view their own orders
- Menu enhancements: categories, images, availability, search/filter
- Table reservation system (reserve/cancel, check table availability)
- Order status tracking (Pending, In Progress, Completed, Cancelled)
- Update/cancel orders
- Clean separation of concerns (Controllers, Services, Interfaces, Models)
- Global exception handling middleware
- API documentation and testing via Swagger UI
- Uses Entity Framework Core with SQL Server

---

## Folder Structure
```
├── Controllers/ 
│   ├── MenuController.cs           # API endpoints for menu items 
│   ├── OrderController.cs          # API endpoints for orders 
│   ├── CustomerController.cs       # API endpoints for customers 
│   └── ReservationController.cs    # API endpoints for table reservations 
│ 
├── Interfaces/ 
│   ├── IMenuService.cs             # Interface for menu service 
│   ├── IOrderService.cs            # Interface for order service 
│   ├── ICustomerService.cs         # Interface for customer service 
│   └── IReservationService.cs      # Interface for reservation service 
│ 
├── Models/ 
│   ├── Customer.cs                 # Customer entity 
│   ├── MenuItem.cs                 # Menu item entity (with category, image, availability) 
│   ├── Order.cs                    # Order entity (with status) 
│   ├── OrderItem.cs                # Order item entity 
│   ├── Table.cs                    # Table entity 
│   ├── Reservation.cs              # Reservation entity 
│   └── OrderStatus.cs              # Enum for order status 
│ 
├── Services/  
│   ├── MenuService.cs          # Business logic for menu items 
│   ├── OrderService.cs         # Business logic for orders 
│   ├── CustomerService.cs      # Business logic for customers 
│   └── ReservationService.cs   # Business logic for reservations 
│	
├── Data/ 
│   └── RestaurantDbContext.cs  # Entity Framework Core DbContext 
│ 
├──Middleware/ 
│   └── ExceptionMiddleware.cs  # Global exception handling 
│ 
├── Properties/ 
│   └── launchSettings.json         # Project launch profiles 
│ 
├── Program.cs                      # Application entry point and configuration 
│ 
├── RestaurantSystem.csproj         # Project file and dependencies 
│ 
└── README.md                       # Project documentation
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

| HTTP Method | Endpoint                                 | Description                                 |
|-------------|------------------------------------------|---------------------------------------------|
| **Menu**    |                                          |                                             |
| GET         | `/api/menu`                              | List all menu items (with search/filter)     |
| GET         | `/api/menu/{id}`                         | Get menu item by ID                         |
| POST        | `/api/menu`                              | Add a new menu item                         |
| PUT         | `/api/menu/{id}`                         | Update a menu item                          |
| DELETE      | `/api/menu/{id}`                         | Delete a menu item                          |
|             |                                          |                                             |
| **Order**   |                                          |                                             |
| GET         | `/api/order`                             | List all orders                             |
| GET         | `/api/order/{id}`                        | Get order by ID                             |
| POST        | `/api/order`                             | Create a new order                          |
| PUT         | `/api/order/{id}`                        | Update an order                             |
| PATCH       | `/api/order/{id}/status`                 | Update order status                         |
| DELETE      | `/api/order/{id}`                        | Cancel an order                             |
|             |                                          |                                             |
| **Customer**|                                          |                                             |
| GET         | `/api/customer`                          | List all customers                          |
| GET         | `/api/customer/{id}`                     | Get customer by ID                          |
| POST        | `/api/customer`                          | Add a new customer                          |
| PUT         | `/api/customer/{id}`                     | Update a customer                           |
| DELETE      | `/api/customer/{id}`                     | Delete a customer                           |
| GET         | `/api/customer/{id}/orders`              | Get all orders for a customer               |
|             |                                          |                                             |
| **Reservation** |                                      |                                             |
| POST        | `/api/reservation`                       | Reserve a table                             |
| GET         | `/api/reservation/customer/{customerId}` | Get reservations for a customer             |
| GET         | `/api/reservation/available`             | Get available tables for a time/party size  |
| DELETE      | `/api/reservation/{id}`                  | Cancel a reservation                        |

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