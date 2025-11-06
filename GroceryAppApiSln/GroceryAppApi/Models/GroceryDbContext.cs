using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GroceryAppApi.Models;

public partial class GroceryDbContext : DbContext
{
    public GroceryDbContext()
    {
    }

    public GroceryDbContext(DbContextOptions<GroceryDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<InventoryTransaction> InventoryTransactions { get; set; }

    public virtual DbSet<LoginAudit> LoginAudits { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Purchase> Purchases { get; set; }

    public virtual DbSet<PurchaseItem> PurchaseItems { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<SalesItem> SalesItems { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vendor> Vendors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=REXA\\SQLEXPRESS;Database=GroceryDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__23CAF1D879B68789");

            entity.Property(e => e.CategoryId).HasColumnName("categoryId");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("categoryName");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.CustomerId).HasColumnName("customerId");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lastName");
            entity.Property(e => e.Phone)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.RegisteredAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Registered_At");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__C134C9C1850F474D");

            entity.Property(e => e.EmployeeId).HasColumnName("employeeId");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_At");
            entity.Property(e => e.DateOfBirth).HasColumnName("dateOfBirth");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.EmployeeStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Active")
                .HasColumnName("employeeStatus");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("firstName");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.HireDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("hireDate");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lastName");
            entity.Property(e => e.Phone)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("phone");
            entity.Property(e => e.Position)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("position");
            entity.Property(e => e.Salary)
                .HasDefaultValue(0.00m)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("salary");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany(p => p.Employees)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Employees__userI__236943A5");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("PK__Images__336E9B55E83C7E32");

            entity.Property(e => e.ImageId).HasColumnName("imageId");
            entity.Property(e => e.CustomerId).HasColumnName("customerId");
            entity.Property(e => e.ImagePath)
                .IsUnicode(false)
                .HasColumnName("imagePath");
            entity.Property(e => e.ImageType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("Customer")
                .HasColumnName("imageType");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.UploadedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("uploadedAt");
            entity.Property(e => e.UploadedBy).HasColumnName("uploadedBy");
            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.VerdorId).HasColumnName("verdorId");

            entity.HasOne(d => d.Customer).WithMany(p => p.Images)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Images__customer__1DB06A4F");

            entity.HasOne(d => d.Product).WithMany(p => p.Images)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Images__productI__1AD3FDA4");

            entity.HasOne(d => d.UploadedByNavigation).WithMany(p => p.ImageUploadedByNavigations)
                .HasForeignKey(d => d.UploadedBy)
                .HasConstraintName("FK__Images__uploaded__208CD6FA");

            entity.HasOne(d => d.User).WithMany(p => p.ImageUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Images__userId__1BC821DD");

            entity.HasOne(d => d.Verdor).WithMany(p => p.Images)
                .HasForeignKey(d => d.VerdorId)
                .HasConstraintName("FK__Images__verdorId__1CBC4616");
        });

        modelBuilder.Entity<InventoryTransaction>(entity =>
        {
            entity.HasKey(e => e.InventoryTransactionId).HasName("PK__Inventor__EC86BDB1E58D2AEB");

            entity.ToTable("InventoryTransaction");

            entity.Property(e => e.InventoryTransactionId).HasColumnName("inventoryTransactionId");
            entity.Property(e => e.ChangeType)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValue("purchase")
                .HasColumnName("changeType");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.QuantityChange)
                .HasDefaultValueSql("('0')")
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("quantityChange");
            entity.Property(e => e.ReferenceId).HasColumnName("referenceId");
            entity.Property(e => e.Remarks)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("remarks");
            entity.Property(e => e.TransactionDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("transactionDate");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Product).WithMany(p => p.InventoryTransactions)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Inventory__produ__7C4F7684");

            entity.HasOne(d => d.User).WithMany(p => p.InventoryTransactions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Inventory__userI__7E37BEF6");
        });

        modelBuilder.Entity<LoginAudit>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__LoginAud__7839F64DAC321995");

            entity.ToTable("LoginAudit");

            entity.Property(e => e.LogId).HasColumnName("logId");
            entity.Property(e => e.IpAddress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ip_address");
            entity.Property(e => e.LoginTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("login_time");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany(p => p.LoginAudits)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LoginAudi__userI__02FC7413");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__2D10D16A2D76EF08");

            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.CategoryId).HasColumnName("categoryId");
            entity.Property(e => e.CostPrice)
                .HasDefaultValueSql("('0')")
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("costPrice");
            entity.Property(e => e.ExpiryDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("expiryDate");
            entity.Property(e => e.IsAvailable)
                .HasDefaultValueSql("('1')")
                .HasColumnName("isAvailable");
            entity.Property(e => e.ProductName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("productName");
            entity.Property(e => e.SellingPrice)
                .HasDefaultValueSql("('0')")
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("sellingPrice");
            entity.Property(e => e.StockQuantity)
                .HasDefaultValueSql("('0')")
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("stockQuantity");
            entity.Property(e => e.Unit)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("Kg")
                .HasColumnName("unit");
            entity.Property(e => e.VendorId).HasColumnName("vendorId");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Products__catego__4E88ABD4");

            entity.HasOne(d => d.Vendor).WithMany(p => p.Products)
                .HasForeignKey(d => d.VendorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Products__vendor__4F7CD00D");
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.HasKey(e => e.PurchaseId).HasName("PK__Purchase__0261226C31386936");

            entity.Property(e => e.PurchaseId).HasColumnName("purchaseId");
            entity.Property(e => e.PurchaseDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("purchaseDate");
            entity.Property(e => e.Remarks)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("remarks");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("totalAmount");
            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.VendorId).HasColumnName("vendorId");

            entity.HasOne(d => d.User).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Purchases__userI__628FA481");

            entity.HasOne(d => d.Vendor).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.VendorId)
                .HasConstraintName("FK__Purchases__vendo__619B8048");
        });

        modelBuilder.Entity<PurchaseItem>(entity =>
        {
            entity.HasKey(e => e.PurchaseItemId).HasName("PK__Purchase__817E5EC573D641C4");

            entity.Property(e => e.PurchaseItemId).HasColumnName("purchaseItemId");
            entity.Property(e => e.CostPrice)
                .HasDefaultValueSql("('0.00')")
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("costPrice");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.PurchaseId).HasColumnName("purchaseId");
            entity.Property(e => e.Quantity)
                .HasDefaultValueSql("('0')")
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("quantity");
            entity.Property(e => e.TotalPrice)
                .HasDefaultValueSql("('0.00')")
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("totalPrice");

            entity.HasOne(d => d.Product).WithMany(p => p.PurchaseItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__PurchaseI__produ__6754599E");

            entity.HasOne(d => d.Purchase).WithMany(p => p.PurchaseItems)
                .HasForeignKey(d => d.PurchaseId)
                .HasConstraintName("FK__PurchaseI__purch__66603565");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.SaleId).HasName("PK__Sales__FAE8F4F5A628CD9C");

            entity.Property(e => e.SaleId).HasColumnName("saleId");
            entity.Property(e => e.CustomerId).HasColumnName("customerId");
            entity.Property(e => e.PaymentAmount)
                .HasDefaultValueSql("('0')")
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("paymentAmount");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Cash")
                .HasColumnName("paymentMethod");
            entity.Property(e => e.Remarks)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("remarks");
            entity.Property(e => e.SaleDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("saleDate");
            entity.Property(e => e.TotalAmount)
                .HasDefaultValueSql("('0')")
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("totalAmount");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Customer).WithMany(p => p.Sales)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Sales__customerI__6D0D32F4");

            entity.HasOne(d => d.User).WithMany(p => p.Sales)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Sales__userId__6E01572D");
        });

        modelBuilder.Entity<SalesItem>(entity =>
        {
            entity.HasKey(e => e.SalesItemId).HasName("PK__SalesIte__4204D278B02467FA");

            entity.ToTable("SalesItem");

            entity.Property(e => e.SalesItemId).HasColumnName("salesItemId");
            entity.Property(e => e.Discount)
                .HasDefaultValueSql("('0')")
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("discount");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.Quantity)
                .HasDefaultValueSql("('0.00')")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SaleId).HasColumnName("saleId");
            entity.Property(e => e.SellingPrice)
                .HasDefaultValueSql("('0.00')")
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("sellingPrice");
            entity.Property(e => e.TotalPrice)
                .HasDefaultValueSql("('0.00')")
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("totalPrice");

            entity.HasOne(d => d.Product).WithMany(p => p.SalesItems)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__SalesItem__produ__75A278F5");

            entity.HasOne(d => d.Sale).WithMany(p => p.SalesItems)
                .HasForeignKey(d => d.SaleId)
                .HasConstraintName("FK__SalesItem__saleI__74AE54BC");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__CB9A1CFFD3BBA0F4");

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_At");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lastName");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("userName");
            entity.Property(e => e.UserRole)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("Admin")
                .HasColumnName("userRole");
            entity.Property(e => e.UserStatus)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("Active")
                .HasColumnName("userStatus");
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.HasKey(e => e.VendorId).HasName("PK__Vendors__EC65C4C3D8780821");

            entity.Property(e => e.VendorId).HasColumnName("vendorId");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ContactPersonFirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ContactPersonLastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_At");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
