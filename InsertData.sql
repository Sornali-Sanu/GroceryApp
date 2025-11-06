INSERT INTO Users (userName, firstName, lastName, Email, userRole, userStatus, Password)
VALUES
('admin1', 'Rahim', 'Uddin', 'rahim.admin@example.com', 'Admin', 'Active', 'Admin@123'),
('seller1', 'Karim', 'Ali', 'karim.seller@example.com', 'Seller', 'Active', 'Seller@123'),
('cashier1', 'Jamil', 'Hasan', 'jamil.cashier@example.com', 'Cashier', 'Active', 'Cashier@123');

INSERT INTO Customers (firstName, lastName, Email, Phone, Address)
VALUES
('Sadia', 'Akter', 'sadia@example.com', '01711112222', 'Mirpur, Dhaka'),
('Rafiq', 'Islam', 'rafiq@example.com', '01833334444', 'Banani, Dhaka'),
('Mitu', 'Rahman', 'mitu@example.com', '01655556666', 'Uttara, Dhaka');


INSERT INTO Vendors (CompanyName, ContactPersonFirstName, ContactPersonLastName, Phone, Email, Address)
VALUES
('FreshFoods Ltd', 'Nasir', 'Hossain', '01710001111', 'nasir@freshfoods.com', 'Tejgaon, Dhaka'),
('AgroMart', 'Faruk', 'Ahmed', '01820002222', 'faruk@agromart.com', 'Gazipur'),
('DailyNeeds Co', 'Tania', 'Begum', '01930003333', 'tania@dailyneeds.com', 'Savar');

INSERT INTO Categories (categoryName, Description)
VALUES
('Beverages', 'Soft drinks, water, juices'),
('Snacks', 'Chips, biscuits, and nuts'),
('Groceries', 'Rice, lentils, oil');
  

INSERT INTO Products (productName, categoryId, vendorId, costPrice, sellingPrice, stockQuantity, expiryDate)
VALUES
('Coca-Cola 1L', 1, 1, 50.00, 65.00, 200, '2026-05-01'),
('Potato Chips', 2, 2, 30.00, 45.00, 150, '2025-08-01'),
('Premium Rice 5kg', 3, 3, 400.00, 500.00, 100, '2026-01-01');


INSERT INTO Purchases (vendorId, userId, totalAmount, remarks)
VALUES
(1, 1, 10000.00, 'Initial stock purchase'),
(2, 2, 7000.00, 'Snacks purchase'),
(3, 1, 20000.00, 'Grocery bulk purchase');

INSERT INTO PurchaseItems (purchaseId, productId, quantity, costPrice, totalPrice)
VALUES
(1, 1, 200, 50.00, 10000.00),
(2, 2, 150, 30.00, 4500.00),
(3, 3, 100, 400.00, 40000.00);


INSERT INTO Sales (customerId, userId, totalAmount, paymentAmount, paymentMethod, remarks)
VALUES
(1, 3, 650.00, 650.00, 'Cash', 'Beverage purchase'),
(2, 3, 450.00, 450.00, 'Cash', 'Snacks purchase'),
(3, 2, 1500.00, 1500.00, 'Card', 'Grocery purchase');

INSERT INTO SalesItem (saleId, productId, Quantity, sellingPrice, discount, totalPrice)
VALUES
(1, 1, 10, 65.00, 0, 650.00),
(2, 2, 10, 45.00, 0, 450.00),
(3, 3, 3, 500.00, 0, 1500.00);


INSERT INTO InventoryTransaction (productId, changeType, userId, quantityChange, referenceId, remarks)
VALUES
(1, 'purchase', 1, 200, 1, 'Initial stock'),
(2, 'purchase', 2, 150, 2, 'Stock added'),
(3, 'purchase', 1, 100, 3, 'Bulk purchase');


INSERT INTO LoginAudit (userId, ip_address)
VALUES
(1, '192.168.1.5'),
(2, '192.168.1.6'),
(3, '192.168.1.7');

INSERT INTO Images (productId, userId, imageType, imagePath, uploadedBy)
VALUES
(1, 1, 'Product', '/images/products/cocacola.jpg', 1),
(2, 2, 'Product', '/images/products/chips.jpg', 2),
(3, 3, 'Product', '/images/products/rice.jpg', 1);

INSERT INTO Employees (userId, firstName, lastName, gender, dateOfBirth, phone, email, address, position, salary)
VALUES
(1, 'Rahim', 'Uddin', 'Male', '1990-03-12', '01711112222', 'rahim.admin@example.com', 'Mirpur, Dhaka', 'Manager', 50000.00),
(2, 'Karim', 'Ali', 'Male', '1995-06-10', '01833334444', 'karim.seller@example.com', 'Banani, Dhaka', 'Sales Executive', 30000.00),
(3, 'Jamil', 'Hasan', 'Male', '1998-02-20', '01655556666', 'jamil.cashier@example.com', 'Uttara, Dhaka', 'Cashier', 25000.00);






