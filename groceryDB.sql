use GroceryDB
GO
Create Table Users
(userId int primary key identity(1,1) NOT NULL,
userName varchar(50) NOT NULL,
firstName varchar(50) NOT NULL,
lastName varchar(50)  ,
Email varchar(100) NOT NULL,
userRole varchar(50) NOT NULL DEFAULT 'Admin',
userStatus varchar(10) Not null DEFAULT 'Active',
created_At DateTime DEFAULT GetDate()
);
Go 

alter Table Users
add Password varchar(255) Not nULL; 

GO

Create Table Customers
( customerId int NOT NULL identity(1,1) primary key ,
firstName varchar(50) Not NULL,
lastName varchar(50),
Email varchar(50),
Phone char(11) NOT NULL,
Address Varchar(100) null,
Registered_At DateTime Default GetDate()
);
GO

Create Table Vendors
(
vendorId int primary Key identity(1,1) Not null,
CompanyName Varchar(50) Not NULL,
ContactPersonFirstName varchar(50) Not NUll,
ContactPersonLastName varchar(50),
Phone char(11) Not Null,
Email Varchar(255),
Address Varchar(100) Not Null,
created_At DateTime DEFAULT GetDate()
);
GO
Create Table Categories
(
categoryId int primary Key identity(1,1) NOt NUll,
categoryName varchar(100) Not Null,
Description varchar(100)
);
GO
Create Table Products
(
productId int identity(1,1) primary key Not NUll,
productName varchar(100) not null,
categoryId  int Not null References Categories(categoryId),
vendorId  int Not null References Vendors(vendorId),
costPrice Decimal (18,2) Not null Default '0',
unit varchar(10) default 'Kg',
sellingPrice Decimal(18,2) default '0',
stockQuantity Decimal(10,2) default '0',
expiryDate Date Default GETDATE(),
isAvailable bit Default '1'
)
Create Table Purchases
(
purchaseId int primary key identity(1,1) not null,
vendorId int references Vendors(vendorId),
userId int references Users(userId),
purchaseDate Date not null DEFAULT GETDATE(),
totalAmount decimal(18,2) ,
remarks varchar(100) 
);
Create Table PurchaseItems
(purchaseItemId int primary key identity(1,1) not null,
purchaseId int references Purchases(purchaseId),
productId int references Products(productId),
quantity Decimal(10,2) Default '0',
costPrice Decimal(18,2) not null Default'0.00',
totalPrice Decimal(18,2) not null Default '0.00'
)

Create Table Sales
(
saleId int primary Key identity(1,1) not null,
customerId int references Customers(customerId),
userId int references Users(userId),
saleDate Date Default GetDate(),
totalAmount Decimal(18,2) not null Default '0',
paymentAmount Decimal (18,2) not null Default '0',
paymentMethod varchar(20) Default 'Cash',
remarks varchar(100) null

)
Create Table SalesItem
( 
salesItemId int primary key identity (1,1) not null,
saleId int references Sales(saleId),
productId int references Products (productId),
Quantity Decimal (18,2) not null default '0.00',
sellingPrice Decimal(18,2) not null default '0.00',
discount Decimal(10,2) null default '0',
totalPrice Decimal(18,2) not null default '0.00'
)

Create Table InventoryTransaction
(inventoryTransactionId int primary key not null identity (1,1),
productId int references Products(productId),
changeType varchar(30) default 'purchase',
userId int references Users(userId),
quantityChange decimal (18,2) not null Default '0',
transactionDate Date default GetDate(),
referenceId int ,
remarks varchar(100) 
)
Create Table LoginAudit
(
logId int primary key not null identity(1,1),
userId int references Users(userId) not null,
login_time Date default getDate(),
ip_address varchar(100) 
)

















--For Correcting Database Diagram compatibility level 

--USE GroceryDB;
--GO

--EXECUTE sp_dbcmptlevel 'GroceryDB', 110;