INSERT INTO Customers (Name, Email, Phone) VALUES ('John Doe', 'john.doe@example.com', '555-0101');
INSERT INTO Customers (Name, Email, Phone) VALUES ('Jane Smith', 'jane.smith@example.com', '555-0102');

INSERT INTO MenuItems (Name, Description, Price, Category) VALUES ('Cheeseburger', 'Beef patty with cheese', 9.99, 'Main');
INSERT INTO MenuItems (Name, Description, Price, Category) VALUES ('Caesar Salad', 'Fresh romaine with dressing', 6.99, 'Salad');
INSERT INTO MenuItems (Name, Description, Price, Category) VALUES ('Fries', 'Crispy potato fries', 3.99, 'Side');

INSERT INTO Orders (CustomerId, OrderDate, TotalAmount) VALUES (1, '2025-06-01 18:00:00', 23.97);
INSERT INTO Orders (CustomerId, OrderDate, TotalAmount) VALUES (2, '2025-06-01 19:00:00', 13.98);

INSERT INTO OrderItems (OrderId, MenuItemId, Quantity, UnitPrice) VALUES (1, 1, 2, 9.99);
INSERT INTO OrderItems (OrderId, MenuItemId, Quantity, UnitPrice) VALUES (1, 3, 1, 3.99);
INSERT INTO OrderItems (OrderId, MenuItemId, Quantity, UnitPrice) VALUES (2, 2, 2, 6.99);

INSERT INTO Customers (Name, Email, Phone)
VALUES ('John Doe', 'john.doe@example.com', '555-0101');

INSERT INTO MenuItems (Name, Description, Price, Category)
VALUES 
    ('Cheeseburger', 'Beef patty with cheese', 9.99, 'Main'),
    ('Caesar Salad', 'Fresh romaine with dressing', 6.99, 'Salad'),
    ('Fries', 'Crispy potato fries', 3.99, 'Side');

	SELECT * FROM Customers; -- Should show Id = 1
SELECT * FROM MenuItems; -- Should show Id = 1, 2, 3