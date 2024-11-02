using System;
using System.Collections.Generic;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DAL.Data;

public partial class KoiVeterinaryServiceCenter : DbContext
{
    public KoiVeterinaryServiceCenter()
    {
    }

    public KoiVeterinaryServiceCenter(DbContextOptions<KoiVeterinaryServiceCenter> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AnimalProfile> AnimalProfiles { get; set; }

    public virtual DbSet<AnimalType> AnimalTypes { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<BookingDetail> BookingDetails { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Faq> Faqs { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<PoolProfile> PoolProfiles { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<PostCategory> PostCategories { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<ServiceDeliveryMethod> ServiceDeliveryMethods { get; set; }

    public virtual DbSet<SlotTable> SlotTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(GetConnectionString());
    private string GetConnectionString()
    {
        IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true).Build();
        return configuration["ConnectionStrings:DefaultConnectionString"];
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__Account__349DA586C039EECD");

            entity.ToTable("Account");

            entity.HasIndex(e => e.PhoneNumber, "UQ__Account__85FB4E3864BFBCC0").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Account__A9D10534541A1E0D").IsUnique();

            entity.Property(e => e.AccountId)
                .HasMaxLength(30)
                .HasColumnName("AccountID");
            entity.Property(e => e.Avatar).HasMaxLength(500);
            entity.Property(e => e.Email).HasMaxLength(30);
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(10);
            entity.Property(e => e.RoleId)
                .HasMaxLength(20)
                .HasColumnName("RoleID");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Role).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Account__RoleID__3B75D760");
        });

        modelBuilder.Entity<AnimalProfile>(entity =>
        {
            entity.HasKey(e => e.AnimalProfileId).HasName("PK__AnimalPr__EDA85571C377A9AC");

            entity.ToTable("AnimalProfile");

            entity.Property(e => e.AnimalProfileId)
                .HasMaxLength(20)
                .HasColumnName("AnimalProfileID");
            entity.Property(e => e.BookingDetailId)
                .HasMaxLength(20)
                .HasColumnName("BookingDetailID");
            entity.Property(e => e.Color).HasMaxLength(20);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Picture).HasMaxLength(500);
            entity.Property(e => e.TypeId)
                .HasMaxLength(20)
                .HasColumnName("TypeID");

            entity.HasOne(d => d.BookingDetail).WithMany(p => p.AnimalProfiles)
                .HasForeignKey(d => d.BookingDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AnimalPro__Booki__5EBF139D");

            entity.HasOne(d => d.Type).WithMany(p => p.AnimalProfiles)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AnimalPro__TypeI__5DCAEF64");
        });

        modelBuilder.Entity<AnimalType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PK__AnimalTy__516F03953CAC5927");

            entity.ToTable("AnimalType");

            entity.Property(e => e.TypeId)
                .HasMaxLength(20)
                .HasColumnName("TypeID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__Booking__73951ACDF4336B2F");

            entity.ToTable("Booking");

            entity.Property(e => e.BookingId)
                .HasMaxLength(20)
                .HasColumnName("BookingID");
            entity.Property(e => e.BookingAddress).HasMaxLength(200);
            entity.Property(e => e.BookingDate).HasColumnType("datetime");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(20)
                .HasColumnName("CustomerID");
            entity.Property(e => e.Deposit).HasColumnType("money");
            entity.Property(e => e.DistanceCost).HasColumnType("money");
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(20)
                .HasColumnName("EmployeeID");
            entity.Property(e => e.ExpiredDate).HasColumnType("datetime");
            entity.Property(e => e.FeedbackId)
                .HasMaxLength(20)
                .HasColumnName("FeedbackID");
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
            entity.Property(e => e.PaymentStatus).HasMaxLength(50);
            entity.Property(e => e.ScheduleId)
                .HasMaxLength(20)
                .HasColumnName("ScheduleID");
            entity.Property(e => e.ServiceDeliveryMethodId)
                .HasMaxLength(20)
                .HasColumnName("ServiceDeliveryMethodID");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TotalServiceCost).HasColumnType("money");
            entity.Property(e => e.Vat).HasColumnName("VAT");

            entity.HasOne(d => d.Customer).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Booking__Custome__5165187F");

            entity.HasOne(d => d.Employee).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__Booking__Employe__52593CB8");

            entity.HasOne(d => d.Feedback).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.FeedbackId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Booking__Feedbac__5441852A");

            entity.HasOne(d => d.Schedule).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.ScheduleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Booking__Schedul__5535A963");

            entity.HasOne(d => d.ServiceDeliveryMethod).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.ServiceDeliveryMethodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Booking__Service__534D60F1");
        });

        modelBuilder.Entity<BookingDetail>(entity =>
        {
            entity.HasKey(e => e.BookingDetailId).HasName("PK__BookingD__8136D47A5C74F9FD");

            entity.ToTable("BookingDetail");

            entity.Property(e => e.BookingDetailId)
                .HasMaxLength(20)
                .HasColumnName("BookingDetailID");
            entity.Property(e => e.BookingId)
                .HasMaxLength(20)
                .HasColumnName("BookingID");
            entity.Property(e => e.ServiceId)
                .HasMaxLength(20)
                .HasColumnName("ServiceID");
            entity.Property(e => e.UnitPrice).HasColumnType("money");

            entity.HasOne(d => d.Booking).WithMany(p => p.BookingDetails)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BookingDe__Booki__59FA5E80");

            entity.HasOne(d => d.Service).WithMany(p => p.BookingDetails)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BookingDe__Servi__5AEE82B9");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B864197CF7");

            entity.ToTable("Customer");

            entity.Property(e => e.CustomerId)
                .HasMaxLength(20)
                .HasColumnName("CustomerID");
            entity.Property(e => e.AccountId)
                .HasMaxLength(30)
                .HasColumnName("AccountID");
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.Firstname).HasMaxLength(20);
            entity.Property(e => e.Lastname).HasMaxLength(20);
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Account).WithMany(p => p.Customers)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__Customer__Accoun__3E52440B");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04FF14C07FE65");

            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeId)
                .HasMaxLength(20)
                .HasColumnName("EmployeeID");
            entity.Property(e => e.AccountId)
                .HasMaxLength(30)
                .HasColumnName("AccountID");
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.Firstname).HasMaxLength(20);
            entity.Property(e => e.Lastname).HasMaxLength(20);
            entity.Property(e => e.RoleId)
                .HasMaxLength(20)
                .HasColumnName("RoleID");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Account).WithMany(p => p.Employees)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__Employee__Accoun__412EB0B6");

            entity.HasOne(d => d.Role).WithMany(p => p.Employees)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Employee__RoleID__4222D4EF");
        });

        modelBuilder.Entity<Faq>(entity =>
        {
            entity.HasKey(e => e.FaqId).HasName("PK__FAQ__9C741C237DE20E44");

            entity.ToTable("FAQ");

            entity.Property(e => e.FaqId)
                .HasMaxLength(20)
                .HasColumnName("FaqID");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Feedback__6A4BEDF6DCFF89E0");

            entity.ToTable("Feedback");

            entity.Property(e => e.FeedbackId)
                .HasMaxLength(20)
                .HasColumnName("FeedbackID");
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<PoolProfile>(entity =>
        {
            entity.HasKey(e => e.PoolProfileId).HasName("PK__PoolProf__F170E0F64A412574");

            entity.ToTable("PoolProfile");

            entity.Property(e => e.PoolProfileId)
                .HasMaxLength(20)
                .HasColumnName("PoolProfileID");
            entity.Property(e => e.BookingDetailId)
                .HasMaxLength(20)
                .HasColumnName("BookingDetailID");
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.Picture).HasMaxLength(500);

            entity.HasOne(d => d.BookingDetail).WithMany(p => p.PoolProfiles)
                .HasForeignKey(d => d.BookingDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PoolProfi__Booki__619B8048");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.PostId).HasName("PK__Post__AA126038231DC23D");

            entity.ToTable("Post");

            entity.Property(e => e.PostId)
                .HasMaxLength(20)
                .HasColumnName("PostID");
            entity.Property(e => e.PostCategoryId)
                .HasMaxLength(20)
                .HasColumnName("PostCategoryID");

            entity.HasOne(d => d.PostCategory).WithMany(p => p.Posts)
                .HasForeignKey(d => d.PostCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Post__PostCatego__68487DD7");
        });

        modelBuilder.Entity<PostCategory>(entity =>
        {
            entity.HasKey(e => e.PostCategoryId).HasName("PK__PostCate__FE61E3698B042B78");

            entity.ToTable("PostCategory");

            entity.Property(e => e.PostCategoryId)
                .HasMaxLength(20)
                .HasColumnName("PostCategoryID");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE3AF4A2BF0D");

            entity.ToTable("Role");

            entity.Property(e => e.RoleId)
                .HasMaxLength(20)
                .HasColumnName("RoleID");
            entity.Property(e => e.Rolename).HasMaxLength(100);
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleId).HasName("PK__Schedule__9C8A5B6956B8E0AD");

            entity.ToTable("Schedule");

            entity.Property(e => e.ScheduleId)
                .HasMaxLength(20)
                .HasColumnName("ScheduleID");
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(20)
                .HasColumnName("EmployeeID");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Employee).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Schedule__Employ__4BAC3F29");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PK__Service__C51BB0EA161FAB91");

            entity.ToTable("Service");

            entity.Property(e => e.ServiceId)
                .HasMaxLength(20)
                .HasColumnName("ServiceID");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.ServiceDeliveryMethodId)
                .HasMaxLength(20)
                .HasColumnName("ServiceDeliveryMethodID");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.ServiceDeliveryMethod).WithMany(p => p.Services)
                .HasForeignKey(d => d.ServiceDeliveryMethodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Service__Service__46E78A0C");
        });

        modelBuilder.Entity<ServiceDeliveryMethod>(entity =>
        {
            entity.HasKey(e => e.ServiceDeliveryMethodId).HasName("PK__ServiceD__63B5D2A694F751BD");

            entity.ToTable("ServiceDeliveryMethod");

            entity.Property(e => e.ServiceDeliveryMethodId)
                .HasMaxLength(20)
                .HasColumnName("ServiceDeliveryMethodID");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<SlotTable>(entity =>
        {
            entity.HasKey(e => e.SlotTableId).HasName("PK__SlotTabl__823D6BCAA97D9BD1");

            entity.ToTable("SlotTable");

            entity.Property(e => e.SlotTableId)
                .HasMaxLength(20)
                .HasColumnName("SlotTableID");
            entity.Property(e => e.ScheduleId)
                .HasMaxLength(20)
                .HasColumnName("ScheduleID");

            entity.HasOne(d => d.Schedule).WithMany(p => p.SlotTables)
                .HasForeignKey(d => d.ScheduleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SlotTable__Sched__4E88ABD4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
