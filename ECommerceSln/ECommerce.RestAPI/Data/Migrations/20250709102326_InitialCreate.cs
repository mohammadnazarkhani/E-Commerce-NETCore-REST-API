using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce.RestAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    NationalCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuditableEntityBase",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditableEntityBase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentDepartments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentDepartments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShipmentDepartments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendors_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ProvinceId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ShipmentDepartmentId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_ShipmentDepartments_ShipmentDepartmentId",
                        column: x => x.ShipmentDepartmentId,
                        principalTable: "ShipmentDepartments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    StockQuantity = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    VendorId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAddresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Street = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Alley = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    BuildingNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Floor = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    UnitNumber = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    PostalCode = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    OwnerName = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    CostumerEmail = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CityId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAddresses_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAddresses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Method = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    CartId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    VendorId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Quest = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Answer = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Questions_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Comment = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    RatingScore = table.Column<byte>(type: "smallint", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { new Guid("342d1965-53bd-487f-a15e-3a49d3dc34ee"), new DateTime(2025, 7, 9, 13, 53, 25, 302, DateTimeKind.Local).AddTicks(9772), "Books" },
                    { new Guid("35b0c6e7-54f2-49eb-98e4-c836b246f939"), new DateTime(2025, 7, 9, 13, 53, 25, 302, DateTimeKind.Local).AddTicks(9797), "Sports & Outdoors" },
                    { new Guid("36769f20-cbfe-4a1a-845a-51202a83e5be"), new DateTime(2025, 7, 9, 13, 53, 25, 302, DateTimeKind.Local).AddTicks(9784), "Clothing" },
                    { new Guid("405a961e-f313-4d9d-9ecb-69a83f17cc41"), new DateTime(2025, 7, 9, 13, 53, 25, 302, DateTimeKind.Local).AddTicks(9795), "Home & Kitchen" },
                    { new Guid("4c4edc31-1df9-4a6b-8d76-27f1d7e76b4d"), new DateTime(2025, 7, 9, 13, 53, 25, 301, DateTimeKind.Local).AddTicks(9853), "Electronics" }
                });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { new Guid("109a51f1-9b4b-f42c-475d-6709b525de9e"), new DateTime(2025, 7, 9, 10, 23, 25, 357, DateTimeKind.Utc).AddTicks(5482), "گلستان" },
                    { new Guid("1c25d366-2d0a-3327-d464-b8ed3c2c3d73"), new DateTime(2025, 7, 9, 10, 23, 25, 357, DateTimeKind.Utc).AddTicks(5196), "تهران" },
                    { new Guid("1c6f8c6a-4ee4-da52-7d12-360a189bd735"), new DateTime(2025, 7, 9, 10, 23, 25, 357, DateTimeKind.Utc).AddTicks(5467), "کهگیلویه وبویراحمد" },
                    { new Guid("1d436afc-ef42-1885-c6af-b02635b0e0d9"), new DateTime(2025, 7, 9, 10, 23, 25, 357, DateTimeKind.Utc).AddTicks(5227), "خراسان جنوبی" },
                    { new Guid("2acf226d-ed63-0c67-9744-591e072a0227"), new DateTime(2025, 7, 9, 10, 23, 25, 357, DateTimeKind.Utc).AddTicks(5126), "ایلام" },
                    { new Guid("2db6cdf4-e7e4-2953-2b24-514ef08ae35c"), new DateTime(2025, 7, 9, 10, 23, 25, 357, DateTimeKind.Utc).AddTicks(5551), "هرمزگان" },
                    { new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b"), new DateTime(2025, 7, 9, 10, 23, 25, 357, DateTimeKind.Utc).AddTicks(5274), "خراسان رضوی" },
                    { new Guid("3757e8ea-143b-52ce-0d66-c474d3849f2f"), new DateTime(2025, 7, 9, 10, 23, 25, 357, DateTimeKind.Utc).AddTicks(5160), "آذربایجان غربی" },
                    { new Guid("3f984b02-77d5-9338-533c-3be530b980ba"), new DateTime(2025, 7, 9, 10, 23, 25, 357, DateTimeKind.Utc).AddTicks(5420), "کرمان" },
                    { new Guid("41c307e8-f2bf-6b3b-244a-cc9215eb4046"), new DateTime(2025, 7, 9, 10, 23, 25, 357, DateTimeKind.Utc).AddTicks(5211), "چهارمحال وبختیاری" },
                    { new Guid("5a38d1f0-760a-c889-5d99-00030afbd6ce"), new DateTime(2025, 7, 9, 10, 23, 25, 357, DateTimeKind.Utc).AddTicks(5565), "همدان" },
                    { new Guid("64d234e7-5952-b881-3cf5-33a4c9965544"), new DateTime(2025, 7, 9, 10, 23, 25, 357, DateTimeKind.Utc).AddTicks(4971), "اصفهان" },
                    { new Guid("64f76e56-c5a6-b275-2871-a3b26437139e"), new DateTime(2025, 7, 9, 10, 23, 25, 357, DateTimeKind.Utc).AddTicks(5509), "لرستان" },
                    { new Guid("66a07236-f93a-4cb5-0ad6-e0416ba72886"), new DateTime(2025, 7, 9, 10, 23, 25, 357, DateTimeKind.Utc).AddTicks(5581), "یزد" },
                    { new Guid("71d4f39f-c32f-780a-4215-6c4ee11cc61e"), new DateTime(2025, 7, 9, 10, 23, 25, 357, DateTimeKind.Utc).AddTicks(5111), "البرز" },
                    { new Guid("77881601-9f29-c4a9-8076-92a9b3c61aff"), new DateTime(2025, 7, 9, 10, 23, 25, 357, DateTimeKind.Utc).AddTicks(5288), "خراسان شمالی" },
                    { new Guid("82ad2f1a-eb42-c56b-8834-78d95d49e1ba"), new DateTime(2025, 7, 9, 10, 23, 25, 357, DateTimeKind.Utc).AddTicks(5441), "کرمانشاه" },
                    { new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8"), new DateTime(2025, 7, 9, 10, 23, 25, 357, DateTimeKind.Utc).AddTicks(5302), "خوزستان" },
                    { new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410"), new DateTime(2025, 7, 9, 10, 23, 25, 357, DateTimeKind.Utc).AddTicks(5523), "مازندران" },
                    { new Guid("9335ae23-0144-99e7-2a2f-c733db6c3cb9"), new DateTime(2025, 7, 9, 10, 23, 25, 357, DateTimeKind.Utc).AddTicks(4718), "اردبیل" },
                    { new Guid("a4211e9c-ea7b-a182-d1c8-7c6aa71befaf"), new DateTime(2025, 7, 9, 10, 23, 25, 357, DateTimeKind.Utc).AddTicks(5182), "بوشهر" },
                    { new Guid("a56b5e1e-dc63-8684-bf85-c3b187949d66"), new DateTime(2025, 7, 9, 10, 23, 25, 357, DateTimeKind.Utc).AddTicks(5406), "کردستان" },
                    { new Guid("ae50e237-9bf3-fb82-b997-1ae7b059875a"), new DateTime(2025, 7, 9, 10, 23, 25, 357, DateTimeKind.Utc).AddTicks(5332), "سمنان" },
                    { new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10"), new DateTime(2025, 7, 9, 10, 23, 25, 357, DateTimeKind.Utc).AddTicks(5141), "آذربایجان شرقی" },
                    { new Guid("b84f97cd-d4ec-2d65-63d7-3aeb35a3c9e8"), new DateTime(2025, 7, 9, 10, 23, 25, 357, DateTimeKind.Utc).AddTicks(5346), "سیستان وبلوچستان" },
                    { new Guid("d6106951-3204-f3ab-6ec8-6e9c5efb825e"), new DateTime(2025, 7, 9, 10, 23, 25, 357, DateTimeKind.Utc).AddTicks(5391), "قم" },
                    { new Guid("dd60a9d0-60cf-c6d3-b4a4-e1e09f7989b0"), new DateTime(2025, 7, 9, 10, 23, 25, 357, DateTimeKind.Utc).AddTicks(5537), "مرکزی" },
                    { new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d"), new DateTime(2025, 7, 9, 10, 23, 25, 357, DateTimeKind.Utc).AddTicks(5361), "فارس" },
                    { new Guid("e4f80638-3050-9434-78bd-358733300127"), new DateTime(2025, 7, 9, 10, 23, 25, 357, DateTimeKind.Utc).AddTicks(5316), "زنجان" },
                    { new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89"), new DateTime(2025, 7, 9, 10, 23, 25, 357, DateTimeKind.Utc).AddTicks(5495), "گیلان" },
                    { new Guid("f27b547f-a3c0-29ff-19c5-0d8c899abc3d"), new DateTime(2025, 7, 9, 10, 23, 25, 357, DateTimeKind.Utc).AddTicks(5377), "قزوین" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CreatedAt", "Name", "ProvinceId" },
                values: new object[,]
                {
                    { new Guid("003150c1-ff85-4262-a248-317a0cb6d4e9"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7457), "دیواندره", new Guid("a56b5e1e-dc63-8684-bf85-c3b187949d66") },
                    { new Guid("00421938-dcb9-4ab0-870c-af5ba1c3616b"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7983), "رشت", new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89") },
                    { new Guid("00dcb6eb-358d-4f9f-9c73-0afdc31c6aab"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8576), "قهاوند", new Guid("5a38d1f0-760a-c889-5d99-00030afbd6ce") },
                    { new Guid("017a1240-bd9c-4785-905f-2674e4990a31"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6937), "جالق", new Guid("b84f97cd-d4ec-2d65-63d7-3aeb35a3c9e8") },
                    { new Guid("024008cc-fd2f-46f0-958a-5a82f9cceab1"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6241), "هفشجان", new Guid("41c307e8-f2bf-6b3b-244a-cc9215eb4046") },
                    { new Guid("02715045-56b1-4013-9f0c-ac46666beed3"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8139), "ویسیان", new Guid("64f76e56-c5a6-b275-2871-a3b26437139e") },
                    { new Guid("0279b33c-d3f3-459f-84a0-d4f8f21d9d37"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6562), "جاجرم", new Guid("77881601-9f29-c4a9-8076-92a9b3c61aff") },
                    { new Guid("029a755a-7e53-4168-9245-b64620651c95"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8383), "فرمهین", new Guid("dd60a9d0-60cf-c6d3-b4a4-e1e09f7989b0") },
                    { new Guid("02dced4f-91e9-41cb-8a36-f6a9e7183776"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8332), "جاورسیان", new Guid("dd60a9d0-60cf-c6d3-b4a4-e1e09f7989b0") },
                    { new Guid("02e4da5a-7299-44cd-81d2-85d0d367dc5d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6713), "شوش", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("02fa4b11-b376-4075-84a3-43b909ce0253"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5955), "انارستان", new Guid("a4211e9c-ea7b-a182-d1c8-7c6aa71befaf") },
                    { new Guid("03168751-bebf-4cff-b5da-854bee41b024"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8184), "پل سفید", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("0330b095-1756-4915-a407-c5fc7aab6349"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6092), "رباط کریم", new Guid("1c25d366-2d0a-3327-d464-b8ed3c2c3d73") },
                    { new Guid("0331d7e0-942b-4f4b-9d90-9246b3afab29"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7610), "صفائیه", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("037f317c-0601-4bcc-b1bb-a87566fc8af6"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6456), "فریمان", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("041a6cab-8176-482f-b7d1-ec69d3e193d6"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6401), "دولت آباد", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("048d36a0-f889-41db-84fd-192667de23c1"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6146), "لواسان", new Guid("1c25d366-2d0a-3327-d464-b8ed3c2c3d73") },
                    { new Guid("04ecf92b-75f2-452b-bb73-dd8e0e676e78"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6419), "سرخس", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("04f42ce3-9254-473c-b2a9-2e47dfb23700"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5558), "ماهدشت", new Guid("71d4f39f-c32f-780a-4215-6c4ee11cc61e") },
                    { new Guid("05cad511-71ec-44a7-a8a1-76917df81989"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6892), "گرمسار", new Guid("ae50e237-9bf3-fb82-b997-1ae7b059875a") },
                    { new Guid("05e763e6-e11c-49cd-84c3-f0c8d30b2336"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5710), "خامنه", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("061eed92-8f26-48e9-93af-699612ef1d94"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6268), "آرین شهر", new Guid("1d436afc-ef42-1885-c6af-b02635b0e0d9") },
                    { new Guid("0674e837-91dc-4ff1-8adb-388e7fff40cd"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5448), "منظریه", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("07b937cf-0720-4ef7-a661-485884dd663c"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6002), "دالکی", new Guid("a4211e9c-ea7b-a182-d1c8-7c6aa71befaf") },
                    { new Guid("07bad0d9-fd00-4cee-aa71-2effecd10364"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6520), "نوخندان", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("08062639-88dd-4feb-9d36-5429ed7f53d9"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6302), "فردوس", new Guid("1d436afc-ef42-1885-c6af-b02635b0e0d9") },
                    { new Guid("0846bf91-d620-4da8-95cf-3a7e52d44c89"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6356), "بایگ", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("0849958d-e151-49cd-b7a5-13828ace677a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7967), "خشکبیجار", new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89") },
                    { new Guid("085169f8-a125-48a6-9bf6-29011a3c2bf8"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5699), "تسوج", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("0864c8e9-407b-488f-9bd2-6bd6cbb2cd1d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8441), "بندرچارک", new Guid("2db6cdf4-e7e4-2953-2b24-514ef08ae35c") },
                    { new Guid("093582a5-504b-4f80-aab6-2e41628545b6"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6219), "فرخ شهر", new Guid("41c307e8-f2bf-6b3b-244a-cc9215eb4046") },
                    { new Guid("095a8890-af86-426b-b11f-fb7fe0385f94"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6770), "ویس", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("09f21c77-5bea-4bb5-a1d2-fad8ef12872d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8226), "زرگر محله", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("0aa25c68-9eda-409a-9c14-da5c8fec38c8"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5734), "سیس", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("0aea5a79-2e32-4ba0-aee9-c2e515c0c427"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6136), "قرچک", new Guid("1c25d366-2d0a-3327-d464-b8ed3c2c3d73") },
                    { new Guid("0afa7fc7-09c4-450c-b9ee-24b06bf044fb"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7161), "دژکرد", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("0b0e837c-5fe0-4233-89ef-a84cbf7499b6"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5347), "دهق", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("0b9daff5-dabf-413e-8ab3-739cb81acb7a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7040), "هیدوج", new Guid("b84f97cd-d4ec-2d65-63d7-3aeb35a3c9e8") },
                    { new Guid("0baa5ee5-5b21-4f6d-90b5-2589f0cb51c1"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(4712), "کوراییم", new Guid("9335ae23-0144-99e7-2a2f-c733db6c3cb9") },
                    { new Guid("0be2954d-9967-4eef-ab54-e0617196e590"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7330), "اقبالیه", new Guid("f27b547f-a3c0-29ff-19c5-0d8c899abc3d") },
                    { new Guid("0bfa6653-3c9e-48e1-893d-36b0885d76d8"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5916), "مهاباد", new Guid("3757e8ea-143b-52ce-0d66-c474d3849f2f") },
                    { new Guid("0c5c7345-8f32-419b-ab98-a06fab09e546"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5750), "شهرجدیدسهند", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("0cb604cd-0b22-4939-8db5-42b810b3670b"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5875), "سرو", new Guid("3757e8ea-143b-52ce-0d66-c474d3849f2f") },
                    { new Guid("0cbe51e3-e4f9-4597-b659-583d5f2f1a4f"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6201), "سودجان", new Guid("41c307e8-f2bf-6b3b-244a-cc9215eb4046") },
                    { new Guid("0d9fb1b3-966d-4a52-b88e-cc7e898bdafe"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8123), "کونانی", new Guid("64f76e56-c5a6-b275-2871-a3b26437139e") },
                    { new Guid("0dd077ec-59ef-4c09-972c-d3dde5963c0e"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7703), "باینگان", new Guid("82ad2f1a-eb42-c56b-8834-78d95d49e1ba") },
                    { new Guid("0dfb8d6f-fdfd-4b31-b0f4-97a88485d66e"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7115), "بیرم", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("0e2987b1-39b8-4a5e-85c1-5afe1eff5a23"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7996), "سنگر", new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89") },
                    { new Guid("0e30b62c-6fbe-4a64-8349-3b3a9cd6fd18"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7737), "شاهو", new Guid("82ad2f1a-eb42-c56b-8834-78d95d49e1ba") },
                    { new Guid("0e6eeda0-8fc9-4a87-a238-123f59e3323e"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7194), "ششده", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("0e83fecf-53f3-497d-bdda-589b0ee55609"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6831), "گرماب", new Guid("e4f80638-3050-9434-78bd-358733300127") },
                    { new Guid("0eb0078c-6e96-4498-ad55-8a56de6388b0"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5714), "خسروشهر", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("0f15473e-2732-4cbc-8c90-a309725ff624"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5290), "جوشقان وکامو", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("0f5924ad-4fbd-4d8e-8996-b62fd16b82e4"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5905), "گردکشانه", new Guid("3757e8ea-143b-52ce-0d66-c474d3849f2f") },
                    { new Guid("0f722056-3b52-4de3-85e3-ab40c505ec3f"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7753), "گهواره", new Guid("82ad2f1a-eb42-c56b-8834-78d95d49e1ba") },
                    { new Guid("0f88b005-b05a-4bf6-9143-bc41fd8d6455"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6491), "گناباد", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("0fbc3fee-7c98-4266-8cfd-ce3266b19a02"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7241), "کازرون", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("0fd535a4-050b-4293-9a15-787465951f60"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7669), "نظام شهر", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("1062f7de-0d8a-45af-8de1-7e324d8129d0"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7490), "کانی دینار", new Guid("a56b5e1e-dc63-8684-bf85-c3b187949d66") },
                    { new Guid("106ffcab-552f-4894-a3d9-a74a9e5de44e"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7706), "بیستون", new Guid("82ad2f1a-eb42-c56b-8834-78d95d49e1ba") },
                    { new Guid("1073aec9-5de1-4606-9fd5-2ed757a90507"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5446), "مشکات", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("1078941a-e59f-43ba-b688-2f40b194dd2f"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8264), "کلاردشت", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("108798e3-c520-4c06-837d-c27cc283979e"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8239), "سورک", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("10adf612-c88d-4304-ad6f-3ceb0b0dc39d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7884), "کردکوی", new Guid("109a51f1-9b4b-f42c-475d-6709b525de9e") },
                    { new Guid("10baea62-a392-4780-b344-11aee862b578"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5992), "جم", new Guid("a4211e9c-ea7b-a182-d1c8-7c6aa71befaf") },
                    { new Guid("10e0e089-a6da-4bc9-8a81-032f3ff99bad"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7182), "سده", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("10ee1b61-dd5f-4e6c-9cff-2cbe78d6b359"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8356), "خنداب", new Guid("dd60a9d0-60cf-c6d3-b4a4-e1e09f7989b0") },
                    { new Guid("10f26468-c9c5-4dc7-ae87-eaa26924521d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8358), "داودآباد", new Guid("dd60a9d0-60cf-c6d3-b4a4-e1e09f7989b0") },
                    { new Guid("10f81a6b-b087-4642-a44b-2c036439a617"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5304), "حنا", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("112042a3-df9b-4899-abf6-607d8cb8d4dd"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(4676), "جعفرآباد", new Guid("9335ae23-0144-99e7-2a2f-c733db6c3cb9") },
                    { new Guid("112c52ba-f6e2-4f0c-aca7-4acd81d8e2b3"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7546), "پاریز", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("115d5d36-c18a-4378-a6c1-487e8e944ca6"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8506), "میناب", new Guid("2db6cdf4-e7e4-2953-2b24-514ef08ae35c") },
                    { new Guid("115e8064-6bac-426a-8794-6ca279103dc0"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8631), "بافق", new Guid("66a07236-f93a-4cb5-0ad6-e0416ba72886") },
                    { new Guid("11c2bd46-3201-4e21-b9a9-9720f3d3221a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5395), "فولادشهر", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("120bd32c-fd9a-45cd-b077-57fa731cfa38"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8017), "کومله", new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89") },
                    { new Guid("123eb555-a535-4cb1-9195-7d0a976e92ff"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5390), "فرخی", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("12b67fc5-d699-45fa-bffd-04b0d3399821"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5702), "تیکمه داش", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("12eefbcb-0357-4332-bb4b-1c3584ca5c10"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8330), "توره", new Guid("dd60a9d0-60cf-c6d3-b4a4-e1e09f7989b0") },
                    { new Guid("13199d55-93fb-48e7-8069-0f4e62e39abb"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6360), "بردسکن", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("131d3c27-36bc-4f68-9ed1-bc8a294406ee"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8175), "بلده", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("1382d829-fb2a-4553-aa90-3cc2263fcada"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6805), "حلب", new Guid("e4f80638-3050-9434-78bd-358733300127") },
                    { new Guid("1423cd19-79e4-436d-9be0-52fb49dceae8"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7769), "هلشی", new Guid("82ad2f1a-eb42-c56b-8834-78d95d49e1ba") },
                    { new Guid("14284a4c-d66f-47e8-a3e2-e9b10b544140"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5724), "زرنق", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("145940bb-2379-4257-a56f-c8af71bf67eb"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6008), "ریز", new Guid("a4211e9c-ea7b-a182-d1c8-7c6aa71befaf") },
                    { new Guid("14f69bd1-c1c5-4c48-87e9-df5432c298c3"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8169), "بابل", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("1507a95c-43dd-4b53-a6c7-5e23e37549e3"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5877), "سلماس", new Guid("3757e8ea-143b-52ce-0d66-c474d3849f2f") },
                    { new Guid("1529f3ae-1906-4ffb-b3fc-10961aaf9a64"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6213), "فارسان", new Guid("41c307e8-f2bf-6b3b-244a-cc9215eb4046") },
                    { new Guid("155e018e-cd7c-4b3d-9180-c01e350038ca"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7361), "سگزآباد", new Guid("f27b547f-a3c0-29ff-19c5-0d8c899abc3d") },
                    { new Guid("15872a9d-add3-4175-ac52-e2a55bf12702"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(4648), "اصلاندوز", new Guid("9335ae23-0144-99e7-2a2f-c733db6c3cb9") },
                    { new Guid("162bec3a-be11-462b-ac34-79f9122ec085"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7442), "بوئین سفلی", new Guid("a56b5e1e-dc63-8684-bf85-c3b187949d66") },
                    { new Guid("1662195a-c645-4ca5-a46b-656d004f3a72"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7890), "گرگان", new Guid("109a51f1-9b4b-f42c-475d-6709b525de9e") },
                    { new Guid("17088149-3784-4825-be38-78311174969d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5694), "ترک", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("1753a68e-c0f1-4fb3-b7e5-fbb8c76c3ee0"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6370), "تربت حیدریه", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("1753e1d3-a0a2-4de7-865b-c1388bb9b1d4"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6055), "آبسرد", new Guid("1c25d366-2d0a-3327-d464-b8ed3c2c3d73") },
                    { new Guid("1770d60c-5bf4-4851-8645-48961695b6a4"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5532), "آسارا", new Guid("71d4f39f-c32f-780a-4215-6c4ee11cc61e") },
                    { new Guid("178f4754-c6da-4048-8857-e36de2085321"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8247), "عباس آباد", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("17f68e38-a5d3-479b-b1ba-40ffc7695650"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8512), "هشتبندی", new Guid("2db6cdf4-e7e4-2953-2b24-514ef08ae35c") },
                    { new Guid("1826865f-731b-445e-988f-a07960d11321"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8624), "اردکان", new Guid("66a07236-f93a-4cb5-0ad6-e0416ba72886") },
                    { new Guid("18383634-4046-41e4-ac34-4769c841bab8"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5373), "سمیرم", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("18e4fad3-acc9-412b-a8b4-098f6ac51f2b"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(4722), "مرادلو", new Guid("9335ae23-0144-99e7-2a2f-c733db6c3cb9") },
                    { new Guid("19055f00-aceb-49e6-8083-3385de7cbc95"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7063), "ارسنجان", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("190dd97e-fc08-4533-99a2-f7bc2669c179"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8578), "کبودرآهنگ", new Guid("5a38d1f0-760a-c889-5d99-00030afbd6ce") },
                    { new Guid("19230939-1a57-491c-ab4a-071bf685564e"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6711), "شرافت", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("195cb894-8195-4cee-bf44-0ad33519cc14"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7538), "بزنجان", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("19745c6c-9c7e-4449-b4f7-8519a2b9cdfb"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7494), "مریوان", new Guid("a56b5e1e-dc63-8684-bf85-c3b187949d66") },
                    { new Guid("198af653-ce92-4549-bf6c-4099c78ff84c"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8676), "هرات", new Guid("66a07236-f93a-4cb5-0ad6-e0416ba72886") },
                    { new Guid("19e82757-5dc5-498d-8760-ed4a90f88eb6"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5260), "بادرود", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("1a234fe9-5348-4583-8492-1ee92491b02e"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8190), "جویبار", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("1a28664f-a31e-415d-a940-19d2ba386de8"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6635), "بندرماهشهر", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("1a428dc2-d0f8-485e-a306-306ff3a8eaf4"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8435), "بستک", new Guid("2db6cdf4-e7e4-2953-2b24-514ef08ae35c") },
                    { new Guid("1b2c6ed5-9a01-4d1a-a76e-7750362ecbaa"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6736), "صیدون", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("1b428709-e5f8-42e1-83a0-1d360c397db1"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6384), "چناران", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("1bdacfbf-52d6-4bde-b08e-1e3209bc7033"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6643), "جایزان", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("1c55b198-b68b-4179-87a0-50df398d37e7"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8249), "فریدونکنار", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("1c6ee788-dee5-44e8-9532-e1e374fe30e3"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8387), "قورچی باشی", new Guid("dd60a9d0-60cf-c6d3-b4a4-e1e09f7989b0") },
                    { new Guid("1c8b153e-2cc8-4d92-94f6-f343b0126a17"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8034), "لشت نشاء", new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89") },
                    { new Guid("1cccfae8-1cc9-4d3c-826d-e57827e0536c"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5450), "مهاباد", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("1d0c3e7c-3121-467f-a5ee-de5b4a9d3466"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6237), "نافچ", new Guid("41c307e8-f2bf-6b3b-244a-cc9215eb4046") },
                    { new Guid("1d5d7530-c1f7-4806-a596-60d9cfa33405"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8121), "فیروز آباد", new Guid("64f76e56-c5a6-b275-2871-a3b26437139e") },
                    { new Guid("1d6e412e-fc73-4ebf-a796-b42d6f7a479c"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8653), "طبس", new Guid("66a07236-f93a-4cb5-0ad6-e0416ba72886") },
                    { new Guid("1dac9dd9-3dad-43ae-839a-3b0c6fdc8fba"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5297), "چمگردان", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("1e31e5cb-832a-4f52-a5ad-eea6913ef879"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5562), "مشکین دشت", new Guid("71d4f39f-c32f-780a-4215-6c4ee11cc61e") },
                    { new Guid("1e89228d-8d9e-4af9-a07f-bb1981913ade"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8570), "فیروزان", new Guid("5a38d1f0-760a-c889-5d99-00030afbd6ce") },
                    { new Guid("1ebad67f-9c33-40b9-b574-3802beb21d39"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7626), "کرمان", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("1ef889e3-7425-4e86-8cca-b0e23ab41096"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7653), "ماهان", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("1f454d45-8af7-4ffb-9d33-1be47de72c9a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5982), "بندرگناوه", new Guid("a4211e9c-ea7b-a182-d1c8-7c6aa71befaf") },
                    { new Guid("1f7e61b2-1c05-4bc2-b6bf-70d097a57bd7"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6695), "سالند", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("1f9d9ec5-0928-47da-b711-c6da40874e63"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5662), "ایلخچی", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("1fde0ee0-4938-4798-a8d4-e6774a8de1b3"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7237), "کارزین", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("204f4d1a-71e9-4d2c-b460-225b615d86a3"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7530), "بافت", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("206b0ac9-5c09-4bc4-97f4-9b35429b5fc7"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6156), "وحیدیه", new Guid("1c25d366-2d0a-3327-d464-b8ed3c2c3d73") },
                    { new Guid("20844ad7-3d22-4d32-8da3-0382a5e5171e"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7526), "اندوهجرد", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("20df4352-600b-44a3-8125-77d513bfa19c"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7554), "جوزم", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("2117714f-03c3-46d4-b85b-2b02c66ce1c1"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5683), "بستان آباد", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("216ac3b5-87d5-4620-b2c5-c7aeea26a605"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6118), "فرون آباد", new Guid("1c25d366-2d0a-3327-d464-b8ed3c2c3d73") },
                    { new Guid("21dd7110-0f1e-4b17-bd58-d49ca4a6bfed"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7642), "لاله زار", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("21fd95b3-47f8-41b6-9c2b-0332c240fa67"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7139), "خاوران", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("221ad5f3-8d2b-4e50-bedf-82e3495895bf"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5321), "داران", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("223e9e6e-9267-4ea9-83a8-9d08ac52179d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6138), "کهریزک", new Guid("1c25d366-2d0a-3327-d464-b8ed3c2c3d73") },
                    { new Guid("2246b426-05b6-447d-b1d1-69e15c0f42c9"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8622), "احمدآباد", new Guid("66a07236-f93a-4cb5-0ad6-e0416ba72886") },
                    { new Guid("22a7b1c3-3786-4862-877c-3cf5eb8b6d88"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6304), "قائن", new Guid("1d436afc-ef42-1885-c6af-b02635b0e0d9") },
                    { new Guid("22c74df3-43ec-4ae8-886e-0af2c00e094b"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7135), "خانه زنیان", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("237495e7-101c-4790-ae55-92ca65344203"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8266), "کله بست", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("2397ee73-1d0b-4245-b895-4cd8b40f55c1"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5471), "ورزنه", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("24687d5f-a5f7-4dc4-b53b-10971466fe74"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5965), "برازجان", new Guid("a4211e9c-ea7b-a182-d1c8-7c6aa71befaf") },
                    { new Guid("24727d41-fecb-480b-970d-903818241ec3"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7017), "گلمورتی", new Guid("b84f97cd-d4ec-2d65-63d7-3aeb35a3c9e8") },
                    { new Guid("247baa37-d2c2-41f8-848e-8d73076ee829"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5332), "دهاقان", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("24aee656-8515-4657-8ae4-4369d5bc7fca"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8544), "جوکار", new Guid("5a38d1f0-760a-c889-5d99-00030afbd6ce") },
                    { new Guid("24d7797b-0127-414f-acb3-1296c1879b59"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5426), "گزبرخوار", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("24e24c48-16fd-4ab9-9b23-247a101ee5c4"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6442), "شهرزو", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("2513bf6a-3e0b-46be-aaa1-d27c92ebfa28"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5730), "سراب", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("253e9242-8602-451b-af9f-624eacc92633"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8635), "بهاباد", new Guid("66a07236-f93a-4cb5-0ad6-e0416ba72886") },
                    { new Guid("254229c1-751b-4319-9196-80f4b150a61b"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5617), "زرنه", new Guid("2acf226d-ed63-0c67-9744-591e072a0227") },
                    { new Guid("25b8a5b4-d1ca-4dfd-b32d-0173060992b0"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7632), "کهنوج", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("25bd8c6a-e5fb-4a88-8dfc-6b4ff15f0d6d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7413), "قنوات", new Guid("d6106951-3204-f3ab-6ec8-6e9c5efb825e") },
                    { new Guid("25f8cf49-254f-4cd2-9db0-873caa8196a6"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7025), "محمدی", new Guid("b84f97cd-d4ec-2d65-63d7-3aeb35a3c9e8") },
                    { new Guid("262e5b48-f618-455e-9793-5c238fa1b45e"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5720), "خواجه", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("26373618-ab04-4176-ae84-089af892ed35"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7255), "گراش", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("265a030b-46fb-497b-9d8d-1ba30d55aa98"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6013), "سیراف", new Guid("a4211e9c-ea7b-a182-d1c8-7c6aa71befaf") },
                    { new Guid("26758550-8c67-4e08-b9bf-43170effdb17"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7733), "سومار", new Guid("82ad2f1a-eb42-c56b-8834-78d95d49e1ba") },
                    { new Guid("268ac06a-c400-4863-a65d-70447ab23444"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8567), "فرسفج", new Guid("5a38d1f0-760a-c889-5d99-00030afbd6ce") },
                    { new Guid("2709c587-f0ae-4b5f-9d7d-85e452b901f7"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5632), "موسیان", new Guid("2acf226d-ed63-0c67-9744-591e072a0227") },
                    { new Guid("27daa3e9-a3da-46f2-b849-4ae0a5f174f9"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6061), "باغستان", new Guid("1c25d366-2d0a-3327-d464-b8ed3c2c3d73") },
                    { new Guid("280fba59-120f-43e1-98be-e234e2bba86b"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8484), "سیریک", new Guid("2db6cdf4-e7e4-2953-2b24-514ef08ae35c") },
                    { new Guid("2819d31f-76d9-4123-8af7-08bacd3a91b4"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6407), "رشتخوار", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("29051160-0226-443b-9181-792dfd664dfd"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7145), "خنج", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("290b3c0b-634a-4496-a782-c7aa910a4127"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5600), "پهله", new Guid("2acf226d-ed63-0c67-9744-591e072a0227") },
                    { new Guid("29b2feb1-01f6-4a7d-821a-0e736c854e4d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5712), "خراجو", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("2a7b30c0-b69b-4381-abce-dbc1d9b3092e"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6099), "شاهدشهر", new Guid("1c25d366-2d0a-3327-d464-b8ed3c2c3d73") },
                    { new Guid("2b0170b7-b8b8-49a8-ab6b-bfef39429207"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7581), "راین", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("2b3c821e-bf23-4ff9-93ec-baff658118c3"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6227), "گهرو", new Guid("41c307e8-f2bf-6b3b-244a-cc9215eb4046") },
                    { new Guid("2b82c180-f31f-48c8-b0a0-bca820f9ed9a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6489), "گلمکان", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("2b8997a8-af35-4860-8b36-115b80ae65e5"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7657), "محی آباد", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("2b91fd92-7b62-4f20-8914-996a13aacba7"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6930), "بنت", new Guid("b84f97cd-d4ec-2d65-63d7-3aeb35a3c9e8") },
                    { new Guid("2bb35594-a478-468b-b048-d20301a83286"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5284), "تیران", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("2c32fd0c-33e8-4804-bcb8-7e7cb28ac96c"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7931), "اطاقور", new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89") },
                    { new Guid("2c4cba4a-9251-4d5c-a112-ca6ecbe7aaa1"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7186), "سعادت شهر", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("2c5ef33d-4586-4559-a7ca-113c1763b49c"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8363), "رازقان", new Guid("dd60a9d0-60cf-c6d3-b4a4-e1e09f7989b0") },
                    { new Guid("2c5efc22-26c6-4f36-9be6-e72d3a8ab9e8"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8160), "ایزدشهر", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("2c6f3ba5-40fb-4d12-98eb-86acf90189cf"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6516), "نصر آباد", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("2c871d02-a1bf-4ae9-bfa4-3db014e7df97"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7452), "دلبران", new Guid("a56b5e1e-dc63-8684-bf85-c3b187949d66") },
                    { new Guid("2c8d8fdd-e2bb-4fcb-afd4-6d9b149023be"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7731), "سنقر", new Guid("82ad2f1a-eb42-c56b-8834-78d95d49e1ba") },
                    { new Guid("2ca2eda1-27d3-4571-bd0b-4e9fe4c97b49"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7222), "فیروزآباد", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("2ce06eef-0117-490e-861c-c8414cdadbf0"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7233), "قطرویه", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("2d28dcfb-48a8-46b4-8ca7-e2f62717675f"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8494), "قلعه قاضی", new Guid("2db6cdf4-e7e4-2953-2b24-514ef08ae35c") },
                    { new Guid("2d4f4193-02a0-450b-9ae4-4d222215794a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5787), "میانه", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("2d6949f1-b5e2-4036-8594-0688127e8dd4"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7023), "محمد آباد", new Guid("b84f97cd-d4ec-2d65-63d7-3aeb35a3c9e8") },
                    { new Guid("2d7ba93e-add6-4e27-8c92-fc6a41177f77"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7176), "زاهدشهر", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("2da68c46-e226-42bf-b8d1-1204e206a5a9"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6835), "ماه نشان", new Guid("e4f80638-3050-9434-78bd-358733300127") },
                    { new Guid("2e092538-1612-4c21-bfe3-ae527c48aff1"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6508), "مشهدریزه", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("2e228e53-0952-459b-a885-861e61065baa"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8528), "ازندریان", new Guid("5a38d1f0-760a-c889-5d99-00030afbd6ce") },
                    { new Guid("2e2d7dda-8b63-41be-a106-0e567f78030b"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6612), "امیدیه", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("2e51362a-d890-4a41-a652-53176730cd47"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6859), "آرادان", new Guid("ae50e237-9bf3-fb82-b997-1ae7b059875a") },
                    { new Guid("2e556ec7-7ea3-462c-adc2-4b93ded8a4de"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6452), "فرهادگرد", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("2eb65e4a-241b-4902-b3f5-e8d4578c3fc5"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7303), "نی ریز", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("2ed2a829-f0d2-4415-ab52-26d8f169e071"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7673), "نگار", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("2ef2553b-7549-44aa-85e5-dfe49eed66cb"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7094), "آباده طشک", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("2ef955b7-f91d-4d9b-a357-821f3b693e4b"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6058), "آبعلی", new Guid("1c25d366-2d0a-3327-d464-b8ed3c2c3d73") },
                    { new Guid("2f1bf485-d920-47b1-9e46-ccff7db88b05"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8453), "تخت", new Guid("2db6cdf4-e7e4-2953-2b24-514ef08ae35c") },
                    { new Guid("2f29978f-a2bb-48d4-99a1-89a697820303"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6873), "سرخه", new Guid("ae50e237-9bf3-fb82-b997-1ae7b059875a") },
                    { new Guid("2f7c0775-e770-463a-ba6d-e84a883fc1c6"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7933), "املش", new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89") },
                    { new Guid("2fa20171-976a-450f-bc14-5ad0a846c684"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5271), "بوئین ومیاندشت", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("2fe329fe-6bbc-4c4a-b8ee-f5f1782a1d0f"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6660), "حمزه", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("2fe9bad5-e025-49ce-b772-7ae8acf88381"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6967), "سوران", new Guid("b84f97cd-d4ec-2d65-63d7-3aeb35a3c9e8") },
                    { new Guid("30169372-57f2-404a-95bc-b165d17072aa"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5972), "بندردیر", new Guid("a4211e9c-ea7b-a182-d1c8-7c6aa71befaf") },
                    { new Guid("302a7e53-890b-4cdf-93cd-20117e6aee73"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7528), "باغین", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("3032c9d3-6ac6-42e3-945a-46544ce3b8cc"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8391), "کمیجان", new Guid("dd60a9d0-60cf-c6d3-b4a4-e1e09f7989b0") },
                    { new Guid("303e8a6a-6f2d-43aa-a998-1e3f4191da87"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5945), "امام حسن", new Guid("a4211e9c-ea7b-a182-d1c8-7c6aa71befaf") },
                    { new Guid("3058918d-018a-40dd-86f9-8d7cd9481a7f"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8315), "اراک", new Guid("dd60a9d0-60cf-c6d3-b4a4-e1e09f7989b0") },
                    { new Guid("305f888a-53a5-46f3-818c-863cbb7e0b61"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5254), "آران وبیدگل", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("310d2130-03d5-42ca-9592-e9e6cd75e11d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6922), "ایرانشهر", new Guid("b84f97cd-d4ec-2d65-63d7-3aeb35a3c9e8") },
                    { new Guid("312f1900-fc26-40c2-8ae5-609574dbafc4"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5357), "زرین شهر", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("317f4223-74bd-40af-b332-cd3ab41125dc"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8180), "بهنمیر", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("318b7812-6a2b-4dbf-80b0-973a87aebc71"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7344), "بوئین زهرا", new Guid("f27b547f-a3c0-29ff-19c5-0d8c899abc3d") },
                    { new Guid("31a075fb-401a-47cc-83d1-859b900ca9c3"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6450), "عشق آباد", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("32130347-3e94-4917-832d-10d6002f5089"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8040), "لوشان", new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89") },
                    { new Guid("3266dd7b-c25a-479d-b195-1d14df7c370a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8031), "لاهیجان", new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89") },
                    { new Guid("3281c315-665e-46ca-a210-d640a08594a8"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7708), "پاوه", new Guid("82ad2f1a-eb42-c56b-8834-78d95d49e1ba") },
                    { new Guid("32b9484f-5718-4889-8bc4-1f887635683c"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6076), "تجریش", new Guid("1c25d366-2d0a-3327-d464-b8ed3c2c3d73") },
                    { new Guid("332aeb11-c089-44b2-a710-b886ad10ad87"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7282), "مشکان", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("333ef3ce-f9ed-44d4-9353-d626ec1a3a3b"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8116), "سراب دوره", new Guid("64f76e56-c5a6-b275-2871-a3b26437139e") },
                    { new Guid("33fb94f7-def3-475e-822f-e86b61418cba"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8063), "هشتپر", new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89") },
                    { new Guid("3414eb5c-25af-4545-b175-77123c60be07"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(4671), "تازه کندانگوت", new Guid("9335ae23-0144-99e7-2a2f-c733db6c3cb9") },
                    { new Guid("344a5e35-6160-47c0-a3f5-1305b3adc54e"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5269), "برف انبار", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("34a41116-b81a-4773-b047-31abf3e2e6af"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5846), "پیرانشهر", new Guid("3757e8ea-143b-52ce-0d66-c474d3849f2f") },
                    { new Guid("35225c82-57a4-4883-8310-2fabcf08c769"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7949), "پره سر", new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89") },
                    { new Guid("352d8343-7b98-4958-91ba-ec7e74c51c45"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7280), "مرودشت", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("3532fe6d-7b0d-4e34-9a7c-923a045d4e08"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7561), "خاتون آباد", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("364e6999-5deb-4815-b271-a5bf540273f1"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7667), "نرماشیر", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("36ab3da7-94da-4f57-8f7e-37c7a1483fdd"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6573), "سنخواست", new Guid("77881601-9f29-c4a9-8076-92a9b3c61aff") },
                    { new Guid("36ae21f6-8064-4af6-9547-8f7118b10502"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8561), "صالح آباد", new Guid("5a38d1f0-760a-c889-5d99-00030afbd6ce") },
                    { new Guid("36b04701-6245-45c2-89df-4de1abe3d857"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7369), "شریفیه", new Guid("f27b547f-a3c0-29ff-19c5-0d8c899abc3d") },
                    { new Guid("36baaac3-ac33-4d32-aa9f-166d488da39d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8649), "زارچ", new Guid("66a07236-f93a-4cb5-0ad6-e0416ba72886") },
                    { new Guid("3733fdd1-b36e-4162-b592-b2fd5e820b94"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8270), "کیاسر", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("37e946fe-6fb1-49e7-a65e-31b589f5da89"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8127), "کوهدشت", new Guid("64f76e56-c5a6-b275-2871-a3b26437139e") },
                    { new Guid("37f6e9b4-c2a4-4210-aaa5-9f3a3d3063e4"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8055), "مرجقل", new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89") },
                    { new Guid("3879b994-6094-4fb9-9b8a-47876a2340ab"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8085), "الشتر", new Guid("64f76e56-c5a6-b275-2871-a3b26437139e") },
                    { new Guid("389d5a78-1954-4d1f-b3f0-2e595319feac"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7206), "صفاشهر", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("38ada301-a78b-440a-8433-58462da5893e"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6795), "ابهر", new Guid("e4f80638-3050-9434-78bd-358733300127") },
                    { new Guid("38bdf8b5-7995-49e7-b03d-ba77cf1a4872"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5893), "فیرورق", new Guid("3757e8ea-143b-52ce-0d66-c474d3849f2f") },
                    { new Guid("3914d569-2d75-4df3-964e-a64ca9104202"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7111), "بوانات", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("391e4f09-ae4d-4e5a-b1f9-f45a80c1d094"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8204), "خوش رودپی", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("392e00b0-f124-44f3-8eae-5169b27da56d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7806), "سی سخت", new Guid("1c6f8c6a-4ee4-da52-7d12-360a189bd735") },
                    { new Guid("396d62ce-b22a-426d-bd96-900995340bdf"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(4686), "عنبران", new Guid("9335ae23-0144-99e7-2a2f-c733db6c3cb9") },
                    { new Guid("3a1921b4-6517-4d40-88db-63ac47153bb3"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8476), "سرگز", new Guid("2db6cdf4-e7e4-2953-2b24-514ef08ae35c") },
                    { new Guid("3a481fbd-c952-4f54-bc02-4637c9e9d9c1"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7065), "استهبان", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("3a570275-ff52-472e-92f1-15c31bf05b83"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5869), "ربط", new Guid("3757e8ea-143b-52ce-0d66-c474d3849f2f") },
                    { new Guid("3a6b890c-cac9-40e5-a645-9d37821ea071"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5797), "هادیشهر", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("3ad3efe4-c788-47f0-84fd-1d55a77269e2"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7587), "رودبار", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("3afeff77-7496-4dfb-87e8-9acb2fd3d86d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7536), "بروات", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("3b3224c3-f4e2-4878-9922-b6162770757d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6807), "خرمدره", new Guid("e4f80638-3050-9434-78bd-358733300127") },
                    { new Guid("3b36faa5-dbe6-4fc5-bced-826d3cdf2b9f"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5689), "بناب جدید", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("3b9e02a5-2ef1-4929-aa87-376730eedd3f"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6655), "حر", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("3bbf5578-e45c-4ca2-a3a3-7857cc5ec0fa"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7886), "کلاله", new Guid("109a51f1-9b4b-f42c-475d-6709b525de9e") },
                    { new Guid("3be3a5c4-6264-4eb8-967b-7461379d99c5"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5848), "تازه شهر", new Guid("3757e8ea-143b-52ce-0d66-c474d3849f2f") },
                    { new Guid("3c32ab3e-4857-437b-89eb-c893307499c9"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6829), "قیدار", new Guid("e4f80638-3050-9434-78bd-358733300127") },
                    { new Guid("3c553386-0c9d-4a93-82d0-dde07f9b916a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7357), "دانسفهان", new Guid("f27b547f-a3c0-29ff-19c5-0d8c899abc3d") },
                    { new Guid("3c8ee4a4-c43a-4f36-812d-814e87a82aec"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8256), "قائم شهر", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("3c9bdd20-127c-45df-849f-a6994264cea8"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7946), "بندرانزلی", new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89") },
                    { new Guid("3cc4af69-687f-4d5d-ab07-de83825a35ba"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7159), "دبیران", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("3d3f76a7-e1eb-45f7-8186-1ee8119cd054"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6529), "همت آباد", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("3d529ba4-4324-46a5-ab0f-c1b37fdc5ba8"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5998), "خارک", new Guid("a4211e9c-ea7b-a182-d1c8-7c6aa71befaf") },
                    { new Guid("3d5783b0-1ca4-4966-81dc-4c37bfdcaeda"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7556), "جیرفت", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("3d75a222-3ae7-499e-a4fa-17b393d77447"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6481), "کدکن", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("3dd3162e-82ec-4d71-a7c7-91651bf1c0e0"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8455), "جناح", new Guid("2db6cdf4-e7e4-2953-2b24-514ef08ae35c") },
                    { new Guid("3dd89c2b-fc23-45eb-893e-b676138f9eee"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7749), "کنگاور", new Guid("82ad2f1a-eb42-c56b-8834-78d95d49e1ba") },
                    { new Guid("3e1b63ff-de0e-4232-ba08-cac5aa4afd5b"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5968), "بردخون", new Guid("a4211e9c-ea7b-a182-d1c8-7c6aa71befaf") },
                    { new Guid("3e38f075-8e2e-4395-805b-dbae740c96fe"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5930), "نوشین", new Guid("3757e8ea-143b-52ce-0d66-c474d3849f2f") },
                    { new Guid("3e6cbee7-58db-4122-96e4-622c22f70c4e"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6411), "روداب", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("3ee201a9-18d7-4a8d-a6ec-492d5737f95f"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7225), "قادرآباد", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("3fa54de9-cd4a-46ea-8607-d2d156ff12a5"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7067), "اسیر", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("40432d41-a5d8-4c37-af85-aa78b61c06fe"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6142), "کیلان", new Guid("1c25d366-2d0a-3327-d464-b8ed3c2c3d73") },
                    { new Guid("406c2970-315a-499e-8a41-03495d81383a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5356), "زاینده رود", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("40d4e35c-34da-430c-b8be-7fcca2fe398b"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5629), "مورموری", new Guid("2acf226d-ed63-0c67-9744-591e072a0227") },
                    { new Guid("40e79b2a-14f6-4dd1-9685-655b3f478a90"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6953), "زابلی", new Guid("b84f97cd-d4ec-2d65-63d7-3aeb35a3c9e8") },
                    { new Guid("412808c8-79f8-4ea1-8f2c-02b927ea4e0c"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8633), "بفروئیه", new Guid("66a07236-f93a-4cb5-0ad6-e0416ba72886") },
                    { new Guid("4135664f-8435-48f7-86a5-d26f91662198"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8167), "آمل", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("419f153a-a984-4611-bf57-1059843f65a8"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6314), "مود", new Guid("1d436afc-ef42-1885-c6af-b02635b0e0d9") },
                    { new Guid("41b0ee09-062c-4f91-b214-dcaa6ed1352e"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6627), "باغ ملک", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("41b6372c-7b92-471a-95d1-e3e7c3e056ad"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8366), "زاویه", new Guid("dd60a9d0-60cf-c6d3-b4a4-e1e09f7989b0") },
                    { new Guid("41ddc416-84c8-4e9b-8c28-a0afac404403"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7998), "سیاهکل", new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89") },
                    { new Guid("42551771-6621-45ae-807a-0a645b26d93a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5275), "بهاران شهر", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("4291ea93-9053-4e6e-8e3f-739776682f2f"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5444), "محمدآباد", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("42bb1987-c4d5-4290-96bc-086c751144ff"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6323), "نهبندان", new Guid("1d436afc-ef42-1885-c6af-b02635b0e0d9") },
                    { new Guid("42d39e0f-19e8-449c-8187-e2957830f787"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7367), "شال", new Guid("f27b547f-a3c0-29ff-19c5-0d8c899abc3d") },
                    { new Guid("42fcae74-6da2-4c57-bcb7-b6e402e7aaf7"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6589), "گرمه", new Guid("77881601-9f29-c4a9-8076-92a9b3c61aff") },
                    { new Guid("43b6a43b-0818-4304-998d-032644c30ec4"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8237), "سلمان شهر", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("43fd2ddb-7905-4974-94c4-715e116395b9"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7985), "رضوانشهر", new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89") },
                    { new Guid("449a4ce8-b558-482e-b442-1034f8f33fb4"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7299), "نودان", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("44c2bf02-a092-4591-b4fe-d6d345fccdab"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6399), "درود", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("44e97d01-853c-41b4-b6ee-bb8027ba0a36"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6514), "نشتیفان", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("45368958-8442-412d-913b-1dd05d42c169"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6483), "کلات", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("4581b039-9730-4075-9394-c10be4390383"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7265), "لپوئی", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("45b84daf-d182-41b9-b918-ed75201608b1"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5736), "سیه رود", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("45cace2e-e2d8-4b2a-ae5e-195ebb1b3b88"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5459), "نصرآباد", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("45d50169-b0e0-4ab3-81a1-0c537cf012b7"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5330), "دولت آباد", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("45dc9dad-5f8f-4363-bdeb-8a1921cf622f"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7149), "خور", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("45f487fa-202f-44ea-8b47-eca718a5fa40"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6231), "مال خلیفه", new Guid("41c307e8-f2bf-6b3b-244a-cc9215eb4046") },
                    { new Guid("4602f970-8310-44bb-bb96-5368ac8095da"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6284), "خوسف", new Guid("1d436afc-ef42-1885-c6af-b02635b0e0d9") },
                    { new Guid("46b838f4-97e2-44ef-8411-953e8100ebcb"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5398), "قمصر", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("46e68938-a70b-43ca-ac8a-ef02b2f622a3"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7814), "لنده", new Guid("1c6f8c6a-4ee4-da52-7d12-360a189bd735") },
                    { new Guid("4713c1dc-d2c8-4967-9c97-1fb16b4dff5a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7952), "توتکابن", new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89") },
                    { new Guid("4777f94b-2397-4acb-a3f4-607eaffde939"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7290), "میمند", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("47ca7445-3275-4cc3-a6ce-40c7634cb0f5"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5658), "اهر", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("485ba050-4306-4a75-96c9-b5f38879097d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6731), "صالح مشطط", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("488ceebc-9a86-4cd9-9c01-6176ccfe1ead"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8590), "ملایر", new Guid("5a38d1f0-760a-c889-5d99-00030afbd6ce") },
                    { new Guid("4890ddee-fff1-4965-8eff-37d63fc8cfdd"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7301), "نورآباد", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("48b0b082-5cc8-49e7-ad33-456624d70f2c"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8443), "بندرعباس", new Guid("2db6cdf4-e7e4-2953-2b24-514ef08ae35c") },
                    { new Guid("48c32a59-75e7-4ce6-ba6c-e3deec15653d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7243), "کامفیروز", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("48d7cd34-63d3-41c5-b31b-25ba831777d5"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7338), "آبیک", new Guid("f27b547f-a3c0-29ff-19c5-0d8c899abc3d") },
                    { new Guid("48f48ea5-8714-4ddd-8d83-3b72437ac8b8"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6947), "راسک", new Guid("b84f97cd-d4ec-2d65-63d7-3aeb35a3c9e8") },
                    { new Guid("49240d57-2c46-463b-b449-acaa3eb3f815"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8089), "بروجرد", new Guid("64f76e56-c5a6-b275-2871-a3b26437139e") },
                    { new Guid("4938f7d6-8e7f-4129-bc4d-9332525a4d21"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6955), "زاهدان", new Guid("b84f97cd-d4ec-2d65-63d7-3aeb35a3c9e8") },
                    { new Guid("4a01cb9a-1eda-4e96-b677-a81cbcafa5fe"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5777), "مرند", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("4a02f30b-2b9b-478f-8a98-c4eb688e3be9"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6510), "ملک آباد", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("4a182961-3b8d-40fe-874f-193262639cd2"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8664), "مهردشت", new Guid("66a07236-f93a-4cb5-0ad6-e0416ba72886") },
                    { new Guid("4a723f5b-73bb-46ed-8290-764d52c98b75"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8002), "شفت", new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89") },
                    { new Guid("4aabdafd-6596-4eb8-85e7-d2e785478ce9"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7567), "خورسند", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("4abd3eb1-a491-4bdd-9876-b298f8d3ee65"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6703), "سوسنگرد", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("4ae0f0ec-c0f7-456a-8c74-a3d7d37f6449"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6229), "لردگان", new Guid("41c307e8-f2bf-6b3b-244a-cc9215eb4046") },
                    { new Guid("4af7d1cb-6b00-4628-b7eb-9bd07c9c2b72"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6896), "مجن", new Guid("ae50e237-9bf3-fb82-b997-1ae7b059875a") },
                    { new Guid("4b818967-6cb5-4603-be4b-64b9c78bd8e5"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7727), "سرمست", new Guid("82ad2f1a-eb42-c56b-8834-78d95d49e1ba") },
                    { new Guid("4b9b0529-bad1-45a1-8377-769a14799d2b"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6368), "تربت جام", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("4bf57fea-b74c-4882-b78f-f14a5d02f117"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5840), "بوکان", new Guid("3757e8ea-143b-52ce-0d66-c474d3849f2f") },
                    { new Guid("4c1148a6-be35-4448-a154-2982ab8c90aa"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5980), "بندرکنگان", new Guid("a4211e9c-ea7b-a182-d1c8-7c6aa71befaf") },
                    { new Guid("4c2da795-77b6-40d7-b1ac-40c52d954765"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6298), "طبس مسینا", new Guid("1d436afc-ef42-1885-c6af-b02635b0e0d9") },
                    { new Guid("4c469966-831a-4405-8648-681da91bbb46"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5608), "دره شهر", new Guid("2acf226d-ed63-0c67-9744-591e072a0227") },
                    { new Guid("4ccdc297-91e0-42a5-86a0-d793f233afa2"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7227), "قائمیه", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("4d244d50-5963-49ce-a8ab-8fd1a307a053"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5783), "ممقان", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("4d6b8e71-5ebf-4f33-9e43-f08bd1824e3a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6827), "صائین قلعه", new Guid("e4f80638-3050-9434-78bd-358733300127") },
                    { new Guid("4d7b14fb-b676-4b9e-9b7f-a19d4fd42100"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6154), "نصیرآباد", new Guid("1c25d366-2d0a-3327-d464-b8ed3c2c3d73") },
                    { new Guid("4dd3c47c-f75c-4c49-9ff1-95582542945a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6438), "ششتمد", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("4ea8d752-a29b-47f5-bd05-582cb53d610b"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6047), "ارجمند", new Guid("1c25d366-2d0a-3327-d464-b8ed3c2c3d73") },
                    { new Guid("4eb47b19-71d8-42ae-af70-eadb8c4d02f9"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7071), "اشکنان", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("4ecec50a-23a5-4fef-8d44-6f8bd7f3e1e1"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7328), "اسفرورین", new Guid("f27b547f-a3c0-29ff-19c5-0d8c899abc3d") },
                    { new Guid("4fa619df-ff12-4208-a81b-3a3cb3c3044c"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6432), "شادمهر", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("4fcb7060-6b4d-4a41-b403-ea93c0a5136a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5753), "صوفیان", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("503108b5-6bd5-4954-80b8-89f45e52a917"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6680), "رامهرمز", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("50573350-a237-4477-908b-40a7701e5fe1"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7787), "پاتاوه", new Guid("1c6f8c6a-4ee4-da52-7d12-360a189bd735") },
                    { new Guid("50598486-06e1-4c6e-9c99-05bc92ca3b5d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6623), "آبادان", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("505db2be-58df-4741-9902-97959f152b82"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7371), "ضیاءآباد", new Guid("f27b547f-a3c0-29ff-19c5-0d8c899abc3d") },
                    { new Guid("50a1026c-8b05-48fc-a282-bf1a93599ce9"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5242), "اژیه", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("50be30cc-7e08-43e8-88cc-1131bf70b220"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5453), "میمه", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("50c01841-3b34-4e83-8d5b-428bd12aa1f2"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8133), "مؤمن آباد", new Guid("64f76e56-c5a6-b275-2871-a3b26437139e") },
                    { new Guid("5114c697-ee78-45b0-a178-8e02e483f9b3"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(4728), "نمین", new Guid("9335ae23-0144-99e7-2a2f-c733db6c3cb9") },
                    { new Guid("514d5570-d8ef-4f2b-b284-be63d1a031c0"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6668), "دارخوین", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("5166b0f9-5d50-41d1-9806-1f03e61d0f9d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7856), "آق قلا", new Guid("109a51f1-9b4b-f42c-475d-6709b525de9e") },
                    { new Guid("5179e842-c16e-4eed-903e-217f175dfecf"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6021), "عسلویه", new Guid("a4211e9c-ea7b-a182-d1c8-7c6aa71befaf") },
                    { new Guid("519fec3d-9b4d-458d-8587-94b10fd7e3be"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7444), "بیجار", new Guid("a56b5e1e-dc63-8684-bf85-c3b187949d66") },
                    { new Guid("51d172ba-f26a-4526-8d6c-0b52d67d7b00"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8433), "ابوموسی", new Guid("2db6cdf4-e7e4-2953-2b24-514ef08ae35c") },
                    { new Guid("51fce7f7-d78c-4c00-918e-575ee2ea5447"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7131), "حسامی", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("526d0eeb-7c5d-421a-a90b-e73e5a8cb327"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5863), "خلیفان", new Guid("3757e8ea-143b-52ce-0d66-c474d3849f2f") },
                    { new Guid("5296613a-3c48-450f-a185-634dd3790cef"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5910), "محمدیار", new Guid("3757e8ea-143b-52ce-0d66-c474d3849f2f") },
                    { new Guid("52a3b3b9-f188-4dd7-aa9c-5cb11da63266"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6560), "تیتکانلو", new Guid("77881601-9f29-c4a9-8076-92a9b3c61aff") },
                    { new Guid("52d9fed0-7217-4880-b5cb-f5e5efe00248"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5838), "بازرگان", new Guid("3757e8ea-143b-52ce-0d66-c474d3849f2f") },
                    { new Guid("5323b185-8666-4081-838b-6bdd1badb3f2"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7962), "چوبر", new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89") },
                    { new Guid("53388d09-a99b-4f0d-ae48-6bb460ccd3bd"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7599), "سرچشمه", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("5374315e-381a-4448-824f-a300b50d07ec"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5976), "بندردیلم", new Guid("a4211e9c-ea7b-a182-d1c8-7c6aa71befaf") },
                    { new Guid("538fe761-2271-47c1-adcb-2b25aea360bd"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7486), "کامیاران", new Guid("a56b5e1e-dc63-8684-bf85-c3b187949d66") },
                    { new Guid("53b47809-3151-43ae-9a1c-065ef129c4c1"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5546), "طالقان", new Guid("71d4f39f-c32f-780a-4215-6c4ee11cc61e") },
                    { new Guid("53b9ac6d-5811-4b97-b728-6833313c554b"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6920), "اسپکه", new Guid("b84f97cd-d4ec-2d65-63d7-3aeb35a3c9e8") },
                    { new Guid("54359efd-f2cb-483d-bd07-2dc05491c223"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7991), "رودبنه", new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89") },
                    { new Guid("5446dafb-329a-459a-bb27-6c140b5963fe"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7214), "فدامی", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("55078120-b541-4e81-becc-14ebd6580f43"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6123), "فیروزکوه", new Guid("1c25d366-2d0a-3327-d464-b8ed3c2c3d73") },
                    { new Guid("5519c85c-3367-4e12-a54d-fe7d6c301fe7"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6266), "اسلامیه", new Guid("1d436afc-ef42-1885-c6af-b02635b0e0d9") },
                    { new Guid("5524bdc0-bdf0-4bf5-9b60-07a074dc3e83"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8274), "کیاکلا", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("55d778b2-261d-4110-89f2-305bad0651ea"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5716), "خمارلو", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("55dcb035-7d9b-4cf8-8eb5-fffe37014452"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7801), "دیشموک", new Guid("1c6f8c6a-4ee4-da52-7d12-360a189bd735") },
                    { new Guid("563a9865-943c-4fa2-b4c9-53f728854a1d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8461), "خمیر", new Guid("2db6cdf4-e7e4-2953-2b24-514ef08ae35c") },
                    { new Guid("56409bd9-39ad-4b08-9766-b4ebf307aa17"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(4687), "فخرآباد", new Guid("9335ae23-0144-99e7-2a2f-c733db6c3cb9") },
                    { new Guid("56485348-2e27-4b79-a13d-267d1a8549ca"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6115), "فردوسیه", new Guid("1c25d366-2d0a-3327-d464-b8ed3c2c3d73") },
                    { new Guid("569fcaff-a7bf-444d-bcae-cd8aad04c99f"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7212), "عمادده", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("56b83df5-55d8-4f8b-8d29-3bfd33470ebf"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6645), "جنت مکان", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("56d5713e-9400-4bd2-b355-b46c4b17247a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7019), "محمدان", new Guid("b84f97cd-d4ec-2d65-63d7-3aeb35a3c9e8") },
                    { new Guid("56f5c055-29a8-401e-bf1f-be927fee8502"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(4726), "مشگین شهر", new Guid("9335ae23-0144-99e7-2a2f-c733db6c3cb9") },
                    { new Guid("570b33aa-ab06-44b1-8399-e046f8ce946a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7751), "کوزران", new Guid("82ad2f1a-eb42-c56b-8834-78d95d49e1ba") },
                    { new Guid("57145cb6-d22d-42aa-a7f1-3e7d4c1092c9"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7757), "گیلانغرب", new Guid("82ad2f1a-eb42-c56b-8834-78d95d49e1ba") },
                    { new Guid("575ba6e6-ddb4-449a-9187-1a48fa9f033d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5744), "شرفخانه", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("5771fe8c-fd03-4f11-9e45-feaac4aa4336"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7822), "مارگون", new Guid("1c6f8c6a-4ee4-da52-7d12-360a189bd735") },
                    { new Guid("57dbfae3-9257-415f-b87a-b63b8a0e7c03"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6674), "دزفول", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("57e4c34a-a399-4c72-932e-7546eb0af851"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8474), "سردشت بشاگرد", new Guid("2db6cdf4-e7e4-2953-2b24-514ef08ae35c") },
                    { new Guid("585764b7-e2c3-45ec-8dbd-6fd8b83e505c"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8672), "ندوشن", new Guid("66a07236-f93a-4cb5-0ad6-e0416ba72886") },
                    { new Guid("5873d9a0-7f90-4f58-bf82-54987ebac030"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6016), "شبانکاره", new Guid("a4211e9c-ea7b-a182-d1c8-7c6aa71befaf") },
                    { new Guid("58b39577-7ac1-4bc8-b4e5-b4ddf8b9e334"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(4651), "آبی بیگلو", new Guid("9335ae23-0144-99e7-2a2f-c733db6c3cb9") },
                    { new Guid("58f8012b-8dc1-419e-a9c6-376957a9c90b"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8008), "فومن", new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89") },
                    { new Guid("594adc5c-bd87-40ba-9da2-bdbc8de1a484"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6415), "ریوش", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("595c630a-6695-4df1-9ae3-4049aeba1d71"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5996), "چغادک", new Guid("a4211e9c-ea7b-a182-d1c8-7c6aa71befaf") },
                    { new Guid("59b4e2bb-e9c8-4f8b-92ac-7d3ca809fbda"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8142), "هفت چشمه", new Guid("64f76e56-c5a6-b275-2871-a3b26437139e") },
                    { new Guid("5a0666e7-c972-403d-aa04-123a24badf37"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6762), "میانرود", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("5a0ebabf-7971-4160-8d1c-179e05623eec"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7030), "نصرت آباد", new Guid("b84f97cd-d4ec-2d65-63d7-3aeb35a3c9e8") },
                    { new Guid("5a48250d-5ec6-4993-a7ba-a3fca60958f5"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8397), "محلات", new Guid("dd60a9d0-60cf-c6d3-b4a4-e1e09f7989b0") },
                    { new Guid("5a48a4c7-9357-4cdb-8eff-9fde1091453d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8100), "چقابل", new Guid("64f76e56-c5a6-b275-2871-a3b26437139e") },
                    { new Guid("5a657b09-e92b-4b44-a610-330883e2383b"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7411), "قم", new Guid("d6106951-3204-f3ab-6ec8-6e9c5efb825e") },
                    { new Guid("5b14c249-b145-4491-94a1-ce89187b06b1"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7713), "جوانرود", new Guid("82ad2f1a-eb42-c56b-8834-78d95d49e1ba") },
                    { new Guid("5b3d4d38-62cd-4d29-a3dc-b24c45745b0c"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7793), "چیتاب", new Guid("1c6f8c6a-4ee4-da52-7d12-360a189bd735") },
                    { new Guid("5b4068e2-430d-44fc-baf5-d8e440dd862c"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6609), "الوان", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("5bc0b918-8d38-4c16-ba89-f18843f50e9a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5832), "آواجیق", new Guid("3757e8ea-143b-52ce-0d66-c474d3849f2f") },
                    { new Guid("5bd2bb80-52bc-4ba2-9cdc-e59a9b3c18ee"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5550), "کرج", new Guid("71d4f39f-c32f-780a-4215-6c4ee11cc61e") },
                    { new Guid("5c188c5b-1ae0-44e2-a1d8-a3d0f16fb9d8"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6606), "اروندکنار", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("5c1a0da3-a2df-4b96-b14a-9e49b8b051be"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7901), "مینودشت", new Guid("109a51f1-9b4b-f42c-475d-6709b525de9e") },
                    { new Guid("5c298998-7a89-49ba-b49c-31e8f7a39233"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7665), "نجف شهر", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("5c2b309e-6c03-400c-9d41-3f176e3ce986"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7143), "خشت", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("5c3eecfd-3b16-409d-bc08-f21881a3a6b5"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7141), "خرامه", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("5c959f76-6fce-4416-b22f-aa2277a9e2dc"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8061), "واجارگاه", new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89") },
                    { new Guid("5cb59b80-0826-4954-b31f-a08161615687"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6943), "خاش", new Guid("b84f97cd-d4ec-2d65-63d7-3aeb35a3c9e8") },
                    { new Guid("5cb66550-9d80-485f-adcc-28a0fdaebbcd"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8674), "نیر", new Guid("66a07236-f93a-4cb5-0ad6-e0416ba72886") },
                    { new Guid("5d3c4b0b-2fff-4935-8199-49498dbba0c9"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8538), "تویسرکان", new Guid("5a38d1f0-760a-c889-5d99-00030afbd6ce") },
                    { new Guid("5d6100f1-54f0-43d2-9618-7dfd1fe38844"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5757), "قره آغاج", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("5d7bad75-9974-42a1-9710-bd8b3eb2b3e9"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6760), "ملاثانی", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("5dd01f20-5145-4296-973d-869e7fa734ee"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5237), "اردستان", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("5dffdeb8-01a2-4e91-b2dd-bd404795decb"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8014), "کوچصفهان", new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89") },
                    { new Guid("5e24e8a3-8636-454f-a167-aee542e85ccf"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7928), "اسالم", new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89") },
                    { new Guid("5e27a9ba-7206-4f64-bf28-be88c52c3cb5"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6916), "ادیمی", new Guid("b84f97cd-d4ec-2d65-63d7-3aeb35a3c9e8") },
                    { new Guid("5e29c82f-955f-4e8b-a42f-23b8158b3570"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7520), "امین شهر", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("5e8a7bbb-22a8-40c6-a4db-28ce012d1a8c"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6276), "بیرجند", new Guid("1d436afc-ef42-1885-c6af-b02635b0e0d9") },
                    { new Guid("5e8c119e-be77-4aca-9f6d-3eca767f08e8"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6583), "فاروج", new Guid("77881601-9f29-c4a9-8076-92a9b3c61aff") },
                    { new Guid("5eb6a711-ea5b-4418-93bb-609b76e3a629"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7798), "دهدشت", new Guid("1c6f8c6a-4ee4-da52-7d12-360a189bd735") },
                    { new Guid("5f42e9b8-58d5-4043-84bc-c230312a4450"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7163), "دوبرجی", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("5f5a9109-b8e5-4000-ac71-90d1f0581906"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6211), "طاقانک", new Guid("41c307e8-f2bf-6b3b-244a-cc9215eb4046") },
                    { new Guid("5f723cfa-5003-469c-a3fe-835c21290e81"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6766), "مینوشهر", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("5fef0a3e-56e2-4e8c-ad58-ecdfc45c316f"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6294), "سه قلعه", new Guid("1d436afc-ef42-1885-c6af-b02635b0e0d9") },
                    { new Guid("6010bbc7-e9a6-43d2-99bf-6e6d741e50c3"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8596), "همدان", new Guid("5a38d1f0-760a-c889-5d99-00030afbd6ce") },
                    { new Guid("60305681-341e-4ac3-8c60-c078ec7793d7"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8137), "نور آباد", new Guid("64f76e56-c5a6-b275-2871-a3b26437139e") },
                    { new Guid("606b98f9-88cf-4b2b-81d7-cfe99066b52d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6815), "زرین رود", new Guid("e4f80638-3050-9434-78bd-358733300127") },
                    { new Guid("60a8044d-e909-41a7-a298-c167b9e09a44"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6181), "باباحیدر", new Guid("41c307e8-f2bf-6b3b-244a-cc9215eb4046") },
                    { new Guid("60ac59ec-2781-487a-ab6d-a00da140918b"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6429), "سنگان", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("60e792ca-75fa-4170-a9d8-e6ae08bade18"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6350), "باخرز", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("612d2d18-60f3-4db5-9dbf-d7c1db795b8d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6707), "شاوور", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("61b0da15-8860-454d-b1cb-b98fe391095d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5842), "پلدشت", new Guid("3757e8ea-143b-52ce-0d66-c474d3849f2f") },
                    { new Guid("62379f43-140a-4a69-aa1a-87447fe86c2b"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(4716), "گرمی", new Guid("9335ae23-0144-99e7-2a2f-c733db6c3cb9") },
                    { new Guid("6281e858-0af5-47db-8c6d-103af8a3d4f9"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7492), "کانی سور", new Guid("a56b5e1e-dc63-8684-bf85-c3b187949d66") },
                    { new Guid("63577b4c-6c9b-4d00-8791-51195fcc7425"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5775), "مراغه", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("637c5ff4-37d6-433a-94c6-ef8a39494b27"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5908), "ماکو", new Guid("3757e8ea-143b-52ce-0d66-c474d3849f2f") },
                    { new Guid("63da9dbb-fe16-4eb5-b712-4e686bdb0216"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6309), "گزیک", new Guid("1d436afc-ef42-1885-c6af-b02635b0e0d9") },
                    { new Guid("63e2453e-32ab-44d5-b72b-e778b419c066"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7569), "درب بهشت", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("63e8cf9c-d6a6-4598-8ee5-f257f1d322f9"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8445), "بندرلنگه", new Guid("2db6cdf4-e7e4-2953-2b24-514ef08ae35c") },
                    { new Guid("641e79f4-90d4-4b11-8625-d2e6856a1641"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5887), "شاهین دژ", new Guid("3757e8ea-143b-52ce-0d66-c474d3849f2f") },
                    { new Guid("6440c027-d564-47b8-88ff-44a774620893"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6670), "دزآب", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("6483046b-dc6d-4c14-94f7-7b3ad51f3185"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6729), "صالح شهر", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("64c3b07a-faf6-47e1-9ab0-0df05e8cf7a0"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7125), "جهرم", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("655e885a-a04a-4218-a7d9-582631304c96"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5722), "دوزدوزان", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("656eee44-a3cc-4ecb-9b09-c721500ef11c"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7377), "کوهین", new Guid("f27b547f-a3c0-29ff-19c5-0d8c899abc3d") },
                    { new Guid("6590d6d8-992b-4929-aabc-c8f36557d981"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8298), "نور", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("65d8c8f5-1e81-4418-ad69-9e3fb54275de"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7785), "باشت", new Guid("1c6f8c6a-4ee4-da52-7d12-360a189bd735") },
                    { new Guid("6639471f-1295-4092-8f26-7dcd700ed2b0"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5232), "ابریشم", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("664d32ef-fe0a-429a-b307-328214c17200"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7803), "سوق", new Guid("1c6f8c6a-4ee4-da52-7d12-360a189bd735") },
                    { new Guid("66984434-0d56-4143-a8db-f4ea43872917"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6504), "مزدآوند", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("66fb85c4-38b9-4c39-8b0f-0c93ea3397bc"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7088), "ایزدخواست", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("67155e52-0528-4db8-a01e-ae5a3f6593e7"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6010), "سعدآباد", new Guid("a4211e9c-ea7b-a182-d1c8-7c6aa71befaf") },
                    { new Guid("67188737-77fd-4b0c-b433-07df19fe4f01"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7860), "ترکمن", new Guid("109a51f1-9b4b-f42c-475d-6709b525de9e") },
                    { new Guid("6718ef68-d7e7-4dbe-a08a-5302d0228dab"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8620), "ابرکوه", new Guid("66a07236-f93a-4cb5-0ad6-e0416ba72886") },
                    { new Guid("678dea5d-0605-4ca9-ab62-50b5f70b8d6a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5382), "طالخونچه", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("67e0f9ff-5308-4107-aa2d-a7511bf6db8d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6261), "اسدیه", new Guid("1d436afc-ef42-1885-c6af-b02635b0e0d9") },
                    { new Guid("68283cea-729f-45e5-bf11-ff42903d1d0c"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8588), "مریانج", new Guid("5a38d1f0-760a-c889-5d99-00030afbd6ce") },
                    { new Guid("6858b2b6-e43d-4e3b-98d3-2af1e8ddb1d0"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7027), "میرجاوه", new Guid("b84f97cd-d4ec-2d65-63d7-3aeb35a3c9e8") },
                    { new Guid("6896fac0-f183-4655-96d5-d0bce040b9aa"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5978), "بندرریگ", new Guid("a4211e9c-ea7b-a182-d1c8-7c6aa71befaf") },
                    { new Guid("68b122bd-fb3d-4fcd-b356-b87fef60447d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6257), "ارسک", new Guid("1d436afc-ef42-1885-c6af-b02635b0e0d9") },
                    { new Guid("68df9229-d407-42a3-821c-a1019e937dcb"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6961), "زهک", new Guid("b84f97cd-d4ec-2d65-63d7-3aeb35a3c9e8") },
                    { new Guid("68eedd8c-f008-4754-800b-1942159549bd"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6570), "راز", new Guid("77881601-9f29-c4a9-8076-92a9b3c61aff") },
                    { new Guid("69362489-05fb-4e06-8307-eceb44004666"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5668), "آقکند", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("694427c5-e88a-4be5-8f61-a0e7bec96dd7"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7679), "هماشهر", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("698bedec-bce1-4df5-882c-8f70df8243d7"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5859), "چهاربرج", new Guid("3757e8ea-143b-52ce-0d66-c474d3849f2f") },
                    { new Guid("69a206d1-1c35-4f36-9db2-194af052d39a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7448), "دزج", new Guid("a56b5e1e-dc63-8684-bf85-c3b187949d66") },
                    { new Guid("69c931b5-29d2-4f8b-8289-5b3190149b59"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7564), "خانوک", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("69dd9f7b-cb7c-49fd-8995-c5d234d6bc31"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6776), "هویزه", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("6a08f2f5-3dd4-45d3-b5a6-575244608c22"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5767), "کوزه کنان", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("6a8fd913-8d54-42b6-98d5-8e2630d83b44"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8079), "ازنا", new Guid("64f76e56-c5a6-b275-2871-a3b26437139e") },
                    { new Guid("6aa3527a-33b0-4cb1-81ed-74313f60bb79"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7960), "چاف وچمخاله", new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89") },
                    { new Guid("6aca3881-34bd-4202-b726-171f4a5e588e"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6799), "آب بر", new Guid("e4f80638-3050-9434-78bd-358733300127") },
                    { new Guid("6b0018e5-e02d-4912-8f76-7930b2f76b77"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7618), "فهرج", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("6b0f8052-00e7-4214-9925-3f012708d7d7"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8224), "رینه", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("6b1b9adb-2d51-415e-80ef-cac9b3e9ee38"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6973), "علی اکبر", new Guid("b84f97cd-d4ec-2d65-63d7-3aeb35a3c9e8") },
                    { new Guid("6b4232dc-7cb6-438a-b523-405943cac820"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8110), "زاغه", new Guid("64f76e56-c5a6-b275-2871-a3b26437139e") },
                    { new Guid("6b537788-b148-4056-b3e1-cb5fd086e874"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8459), "حاجی آباد", new Guid("2db6cdf4-e7e4-2953-2b24-514ef08ae35c") },
                    { new Guid("6b55b394-a7fe-4b59-8c9d-0a2eb7c2f9c5"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5625), "صالح آباد", new Guid("2acf226d-ed63-0c67-9744-591e072a0227") },
                    { new Guid("6bc03cd4-b81e-494e-8c11-b78481dc4652"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5303), "حسن آباد", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("6be76800-4496-4e2a-828e-d181560fb340"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8399), "میلاجرد", new Guid("dd60a9d0-60cf-c6d3-b4a4-e1e09f7989b0") },
                    { new Guid("6c20abc6-fc91-40a5-b621-c2051a2001cf"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6817), "زنجان", new Guid("e4f80638-3050-9434-78bd-358733300127") },
                    { new Guid("6c93ad01-b745-40d1-9c67-474fbccf1970"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6811), "زرین آباد", new Guid("e4f80638-3050-9434-78bd-358733300127") },
                    { new Guid("6d1f1c51-1610-4d0e-8dd0-503d721fb94c"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7119), "بیضا", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("6d509285-f45b-4495-a7be-fdc159c99d69"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6152), "نسیم شهر", new Guid("1c25d366-2d0a-3327-d464-b8ed3c2c3d73") },
                    { new Guid("6d512f3c-2954-4b51-abb5-84ec83a4c04b"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5404), "کاشان", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("6d5b5597-d9e7-4e77-8d04-a43ccafa70df"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6819), "سجاس", new Guid("e4f80638-3050-9434-78bd-358733300127") },
                    { new Guid("6d5beb78-b24b-4d0f-8d59-81f3e0e3c8dc"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8510), "هرمز", new Guid("2db6cdf4-e7e4-2953-2b24-514ef08ae35c") },
                    { new Guid("6dab7e8f-c355-4080-b6dd-60d95a93173e"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5267), "برزک", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("6db82f8e-00cb-4ceb-ae81-c7b7acbee27a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5477), "ونک", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("6e4326b3-b11d-4892-831f-7cd5aac05ab1"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5664), "آبش احمد", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("6e80b804-d088-434b-a7aa-f6e1e2b2f352"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7591), "زرند", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("6e906e2e-9dd8-4368-9816-a0b41fff7b2a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7534), "بردسیر", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("6eb227e5-f326-4c62-a29e-46ff67880e10"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8479), "سندرک", new Guid("2db6cdf4-e7e4-2953-2b24-514ef08ae35c") },
                    { new Guid("6ec95cea-d1bd-402f-a6be-4f3b33e9a94d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7612), "عنبرآباد", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("6ed24b0f-bead-4e6d-9e5e-7b67ddbbbe7b"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5781), "ملکان", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("701ca443-3aec-4322-a622-9b0644ba69bd"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8118), "شول آباد", new Guid("64f76e56-c5a6-b275-2871-a3b26437139e") },
                    { new Guid("70442e32-0155-45c3-9b1e-3fdbba8d0c84"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6223), "گندمان", new Guid("41c307e8-f2bf-6b3b-244a-cc9215eb4046") },
                    { new Guid("709af5f0-617b-475c-88ce-787e42b10570"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6750), "لالی", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("70dbc3eb-f1ed-4a6e-a821-5456634c5b5d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8322), "آشتیان", new Guid("dd60a9d0-60cf-c6d3-b4a4-e1e09f7989b0") },
                    { new Guid("70df3f57-6e55-4a2e-8dd4-1ac6f49dda0d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6064), "باقرشهر", new Guid("1c25d366-2d0a-3327-d464-b8ed3c2c3d73") },
                    { new Guid("70e93b98-5882-4732-82ae-c70df3de333c"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5761), "کشکسرای", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("70ec5248-1798-4c6d-a94c-81eb928d1254"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7210), "علامرودشت", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("719e8897-84b8-48d6-a6c0-bc4f0d0ceeb5"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6263), "اسفدن", new Guid("1d436afc-ef42-1885-c6af-b02635b0e0d9") },
                    { new Guid("72945cf6-939b-4a69-8e40-224e22011b46"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6853), "امیریه", new Guid("ae50e237-9bf3-fb82-b997-1ae7b059875a") },
                    { new Guid("72a083d5-f2cf-498a-84ae-af827d4f408e"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8407), "نیمور", new Guid("dd60a9d0-60cf-c6d3-b4a4-e1e09f7989b0") },
                    { new Guid("72c58e58-947c-48cb-a2bc-7e7b763c88c9"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6926), "بمپور", new Guid("b84f97cd-d4ec-2d65-63d7-3aeb35a3c9e8") },
                    { new Guid("72dd1170-1069-46b3-b5ed-0a14d2442225"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5262), "باغ بهادران", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("72fbe1a9-a0ea-46b0-ac93-6bbadd9b94a0"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5726), "زنوز", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("732e21ac-d8d8-4fff-9d3c-f1c89d4b2665"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(4669), "تازه کند", new Guid("9335ae23-0144-99e7-2a2f-c733db6c3cb9") },
                    { new Guid("7373d9eb-5fdf-4dfe-aa78-385071ebd322"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7575), "دهج", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("737fa066-5b06-49a9-a96c-54ec1125e68b"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6436), "شاندیز", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("738d8cfb-799f-417c-9dc9-2e623cae5d3b"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7870), "رامیان", new Guid("109a51f1-9b4b-f42c-475d-6709b525de9e") },
                    { new Guid("73a69aee-d3ef-4d2e-8087-3b8a36c57b26"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6386), "خرو", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("73f6a404-1ee9-487c-91ce-36dfa5e4c19e"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5883), "سیمینه", new Guid("3757e8ea-143b-52ce-0d66-c474d3849f2f") },
                    { new Guid("749d2f14-f70b-4734-b9df-d196d1c250d4"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8369), "ساروق", new Guid("dd60a9d0-60cf-c6d3-b4a4-e1e09f7989b0") },
                    { new Guid("75015daa-2d7a-4e3b-b634-6f8a5234435f"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8389), "کرهرود", new Guid("dd60a9d0-60cf-c6d3-b4a4-e1e09f7989b0") },
                    { new Guid("7552d80a-2263-41c7-93cd-2e82e2bed83d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7153), "داراب", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("75a7d096-acc8-4634-a148-9bd2d45fce05"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8042), "لولمان", new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89") },
                    { new Guid("7620ddba-5a95-4077-bf1a-08bdfe9c3685"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6691), "رفیع", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("7656d781-ad7d-4f5e-964b-084337d0c73f"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6554), "بجنورد", new Guid("77881601-9f29-c4a9-8076-92a9b3c61aff") },
                    { new Guid("76a8d407-4477-41ac-93ad-fa2ad1b9309a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5679), "باسمنج", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("76e04c7c-8571-47c5-8ef8-76f7ac266e11"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7309), "هماشهر", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("771997b7-0186-410d-bf77-ca82d52aa1a4"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8377), "شازند", new Guid("dd60a9d0-60cf-c6d3-b4a4-e1e09f7989b0") },
                    { new Guid("771bc69b-218b-4b71-b761-9044073a75b9"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6197), "سامان", new Guid("41c307e8-f2bf-6b3b-244a-cc9215eb4046") },
                    { new Guid("77b00e71-3f37-4b64-8b17-4400e673760c"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5473), "ورنامخواست", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("77c79c19-67f3-4374-91e6-b07a9350177a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7711), "تازه آباد", new Guid("82ad2f1a-eb42-c56b-8834-78d95d49e1ba") },
                    { new Guid("77d0d72d-4dec-44d8-a005-90e4c1277a30"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5441), "مبارکه", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("7819e53d-b004-42b8-a295-cd8b8a466dd8"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8295), "نکا", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("782fbb01-88a9-46a3-8ab0-65cedb83a6b6"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8188), "تنکابن", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("784eb875-4840-4b68-93f7-6a8a1f3f34a1"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8131), "معمولان", new Guid("64f76e56-c5a6-b275-2871-a3b26437139e") },
                    { new Guid("7859cc1a-2dc4-4c2b-a747-09658c36f664"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7898), "مراوه تپه", new Guid("109a51f1-9b4b-f42c-475d-6709b525de9e") },
                    { new Guid("786b3ee9-5aef-4132-a957-3c18b4351ae8"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5538), "چهارباغ", new Guid("71d4f39f-c32f-780a-4215-6c4ee11cc61e") },
                    { new Guid("78eef5a6-a495-4219-a66d-a58e1ad218c1"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7906), "نوده خاندوز", new Guid("109a51f1-9b4b-f42c-475d-6709b525de9e") },
                    { new Guid("793932ad-8fba-445a-8df9-7b266c3983ec"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5691), "تبریز", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("7979bd0c-4911-475a-961a-b60b7ecb33a9"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5391), "فریدونشهر", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("797c5f98-d301-474f-a70f-6d9d6882a452"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7463), "سروآباد", new Guid("a56b5e1e-dc63-8684-bf85-c3b187949d66") },
                    { new Guid("79810f19-8c42-421d-bc67-ed5703d02a48"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7288), "مهر", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("79da8408-6f62-4f86-b960-fbd78754f595"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7597), "زیدآباد", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("79f4d9ef-0bd2-4a58-a8bb-b6789248b828"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8173), "بابلسر", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("7a1f6243-9ce4-44db-b653-b871075dcb07"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6493), "لطف آباد", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("7a2c9414-5d4c-4944-ad28-56f2c746e0fa"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7351), "خاکعلی", new Guid("f27b547f-a3c0-29ff-19c5-0d8c899abc3d") },
                    { new Guid("7a66e434-cc6f-444f-9100-eced2b1dfc2f"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(4689), "کلور", new Guid("9335ae23-0144-99e7-2a2f-c733db6c3cb9") },
                    { new Guid("7aa3133c-b370-4976-bedd-84d70fb95323"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7085), "ایج", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("7adace61-1eb7-4e55-aa8c-050b1bfb8d50"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8287), "مرزن آباد", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("7adc62d6-dee2-4c48-a30b-9866b236f0b1"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5439), "لای بید", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("7adf3ea6-6c17-4b8e-9814-fe52a0ce57b9"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7108), "بنارویه", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("7b35af17-3e96-4bff-9cf4-becbba96e8b1"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6825), "سهرورد", new Guid("e4f80638-3050-9434-78bd-358733300127") },
                    { new Guid("7b9295a5-bff0-4508-8157-71edd311bf57"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5367), "سفیدشهر", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("7bd078cd-e6d7-4175-8b58-b9b0f1915dc3"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7200), "شهرپیر", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("7be1487a-b08f-4301-8f0b-2e5841597229"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7334), "الوند", new Guid("f27b547f-a3c0-29ff-19c5-0d8c899abc3d") },
                    { new Guid("7c320ea2-621a-4c9f-b1fd-bd0c0734b0bd"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6107), "صالح آباد", new Guid("1c25d366-2d0a-3327-d464-b8ed3c2c3d73") },
                    { new Guid("7c78a03f-785c-4eee-bd87-d51d19c7dad8"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5466), "نیاسر", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("7c8720e4-f635-43d6-8763-7c3a5eae343c"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7247), "کنارتخته", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("7c9b7d53-32cd-41c1-9010-1cd659fba88d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7970), "خمام", new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89") },
                    { new Guid("7ce17081-59b2-402f-bee4-a7f16e4a3acf"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7202), "شیراز", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("7ce8613e-f727-4322-aa32-7f4ee65cc3fa"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6364), "بیدخت", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("7d2eb1bc-82b0-4069-a7e5-8202629d9dc3"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6940), "چاه بهار", new Guid("b84f97cd-d4ec-2d65-63d7-3aeb35a3c9e8") },
                    { new Guid("7d2fa429-15c7-4fb2-89fb-e020eb8bb03e"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8258), "کتالم وسادات شهر", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("7d5f0ad6-086e-48d6-af9a-358503858275"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5288), "جوزدان", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("7d6425be-5c6e-4e43-941f-4c70a8cc5bc4"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8046), "لیسار", new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89") },
                    { new Guid("7d8e047b-0925-467a-8f6b-907710fcf0b4"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5413), "کمه", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("7d965853-d7d1-46ee-99af-45f28f892e97"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6031), "وحدتیه", new Guid("a4211e9c-ea7b-a182-d1c8-7c6aa71befaf") },
                    { new Guid("7d9af441-a5c5-4c2b-ba53-5cd39566f356"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8106), "درب گنبد", new Guid("64f76e56-c5a6-b275-2871-a3b26437139e") },
                    { new Guid("7ddbe741-d7de-4f84-a832-d2aff5b54b6a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7349), "تاکستان", new Guid("f27b547f-a3c0-29ff-19c5-0d8c899abc3d") },
                    { new Guid("7e3666cb-fdb1-4eb0-8f53-2bfc2db04e09"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7767), "هرسین", new Guid("82ad2f1a-eb42-c56b-8834-78d95d49e1ba") },
                    { new Guid("7e7d7b7c-7ea2-4c84-b46a-28cfb9fa5dde"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6565), "حصارگرمخان", new Guid("77881601-9f29-c4a9-8076-92a9b3c61aff") },
                    { new Guid("7ef5defa-133e-4df1-8133-e9ed036cc764"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5455), "نائین", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("7efedc58-96cb-4c00-816b-0708e8f65e3f"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5732), "سردرود", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("7f07f9af-7236-4a27-920d-59a5c82ea861"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8006), "صومعه سرا", new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89") },
                    { new Guid("7f13660c-1666-4eac-92f6-caf42bb6b3a8"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8466), "دهبارز", new Guid("2db6cdf4-e7e4-2953-2b24-514ef08ae35c") },
                    { new Guid("7f21a8db-e780-46be-a8b7-ee2334967a71"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6744), "گتوند", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("7f3c70ec-fb32-4459-ae44-09dcc52bd5ab"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6029), "نخل تقی", new Guid("a4211e9c-ea7b-a182-d1c8-7c6aa71befaf") },
                    { new Guid("7f7b08df-1f0d-4981-bb62-3700492e80c7"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7605), "شهداد", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("7fa2137c-bc6e-4a15-b282-c5733513c709"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7640), "گلزار", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("7fb2d705-f4a5-4704-a58c-661dc664b231"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6865), "دامغان", new Guid("ae50e237-9bf3-fb82-b997-1ae7b059875a") },
                    { new Guid("7fb73dd7-35e2-407e-81bb-ad76d63766d8"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5308), "خمینی شهر", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("7fcdd565-103b-463d-af20-c259cda863b1"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6470), "قوچان", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("8014620c-9f26-43ca-aaa2-8da9f6efbc8c"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8371), "ساوه", new Guid("dd60a9d0-60cf-c6d3-b4a4-e1e09f7989b0") },
                    { new Guid("807a3aed-7c98-4f21-a70d-c05bb23de87d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8036), "لنگرود", new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89") },
                    { new Guid("807f906f-5e9d-436c-b83e-fa264afdd790"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5836), "باروق", new Guid("3757e8ea-143b-52ce-0d66-c474d3849f2f") },
                    { new Guid("80a1dbca-7b34-47ba-997d-3cf417c25324"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7516), "اختیارآباد", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("80bf5ee6-54c1-4a13-a194-08909951f904"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6366), "تایباد", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("80da2144-5959-4f1b-b0b7-6db3234060ad"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7518), "ارزوئیه", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("81004126-fa84-4419-9e6a-1e15ad0e07d9"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6446), "صالح آباد", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("810dcec5-b18c-4486-8545-1226c9e38cad"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7548), "جبالبارز", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("810ebdc3-3df9-4938-a918-27038ba8e47e"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7743), "کرمانشاه", new Guid("82ad2f1a-eb42-c56b-8834-78d95d49e1ba") },
                    { new Guid("8129a5a9-e7a9-41ca-96e4-9a8b5e402ee1"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7077), "امام شهر", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("812c1b1e-d365-4d5a-bfe2-8f749025ea92"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7850), "اینچه برون", new Guid("109a51f1-9b4b-f42c-475d-6709b525de9e") },
                    { new Guid("81302c41-5bc2-48c0-bef3-2e60ebea8d31"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8373), "سنجان", new Guid("dd60a9d0-60cf-c6d3-b4a4-e1e09f7989b0") },
                    { new Guid("81403762-ad31-4679-8988-0db889171c21"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5590), "ایوان", new Guid("2acf226d-ed63-0c67-9744-591e072a0227") },
                    { new Guid("819088ec-1a08-43ac-98e2-435ab6e98d46"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6861), "بسطام", new Guid("ae50e237-9bf3-fb82-b997-1ae7b059875a") },
                    { new Guid("820f94f4-4205-4f7b-9892-74281fae0da1"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5428), "گلپایگان", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("8214c4ce-1bbb-4d26-819b-78cf31d77284"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5371), "سگزی", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("821c1885-4f16-496a-a1a6-25bd5032814a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7305), "وراوی", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("8239a3d9-7908-4e81-8595-f8aafb6266e3"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5306), "خالدآباد", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("82b8b103-e2df-427f-adbd-e2b90546e081"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5826), "ارومیه", new Guid("3757e8ea-143b-52ce-0d66-c474d3849f2f") },
                    { new Guid("82c00c74-e197-40b8-823a-788eb6205083"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7874), "سرخنکلاته", new Guid("109a51f1-9b4b-f42c-475d-6709b525de9e") },
                    { new Guid("82e0a123-5365-41ef-a5de-e6278fa99afb"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5435), "گلشهر", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("82f8eb80-10c7-4c81-bcb6-a9e4a39abe53"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6774), "هندیجان", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("83aa6850-5003-4605-b5b0-9569e0326e84"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7083), "اهل", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("83d2c703-cf29-44a0-be46-f8a2f4b66909"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7261), "لار", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("83d833fe-b878-4769-bea9-e54b0fa35313"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5568), "هشتگرد", new Guid("71d4f39f-c32f-780a-4215-6c4ee11cc61e") },
                    { new Guid("840608aa-9a93-4269-80e6-99070b11f869"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5740), "شبستر", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("848f4d11-e7e9-4405-a72e-5c6dcc183ccf"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5785), "مهربان", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("84c81553-d4d6-48de-8628-566db1854726"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(4721), "لاهرود", new Guid("9335ae23-0144-99e7-2a2f-c733db6c3cb9") },
                    { new Guid("8520ecd0-b8b3-434d-9085-d4c5394c56e5"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5903), "کشاورز", new Guid("3757e8ea-143b-52ce-0d66-c474d3849f2f") },
                    { new Guid("853ace83-bc2d-4606-a413-e71de88c8b10"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7257), "گله دار", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("858394df-e7a9-4b56-9794-32190cb77528"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7700), "اسلام آبادغرب", new Guid("82ad2f1a-eb42-c56b-8834-78d95d49e1ba") },
                    { new Guid("8605d7fa-04d4-43e3-8988-94c0676b002d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8102), "خرم آباد", new Guid("64f76e56-c5a6-b275-2871-a3b26437139e") },
                    { new Guid("86383daa-c00a-4400-9426-64d2101d0897"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6176), "اردل", new Guid("41c307e8-f2bf-6b3b-244a-cc9215eb4046") },
                    { new Guid("86afdc77-dfa6-45d3-9b36-855bd2772988"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6126), "قدس", new Guid("1c25d366-2d0a-3327-d464-b8ed3c2c3d73") },
                    { new Guid("86eb0995-1dfb-4fb9-92a0-c69f79fc7be0"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6705), "شادگان", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("871eff86-d081-4e45-b7c8-3e42e63656e9"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7675), "نودژ", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("8745fb7a-f8bb-4c02-b83e-43acdd6ef278"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8326), "تفرش", new Guid("dd60a9d0-60cf-c6d3-b4a4-e1e09f7989b0") },
                    { new Guid("874917d3-d26a-4ee6-894f-fa46732f6fff"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8534), "برزول", new Guid("5a38d1f0-760a-c889-5d99-00030afbd6ce") },
                    { new Guid("876287ea-af3a-4a2c-9d52-b4d0de27795b"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6345), "انابد", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("880ffe10-79c4-4212-b573-a8906d1db06d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7217), "فراشبند", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("8830757d-2646-4232-9a05-9766516df613"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5803), "هشترود", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("883210d1-7edc-481c-87c2-0935d2540e06"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6183), "بروجن", new Guid("41c307e8-f2bf-6b3b-244a-cc9215eb4046") },
                    { new Guid("88680dec-906d-4ca2-88b3-d6fcedf2c801"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7268), "لطیفی", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("8873779d-4f15-451e-a26e-22ed4072f0ea"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8557), "سرکان", new Guid("5a38d1f0-760a-c889-5d99-00030afbd6ce") },
                    { new Guid("88bf5d36-b23f-4e1e-b445-8f5ea3651614"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8409), "هندودر", new Guid("dd60a9d0-60cf-c6d3-b4a4-e1e09f7989b0") },
                    { new Guid("892d6eaa-a4ff-43d6-a74c-93f66087bd68"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7129), "حاجی آباد", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("8934b485-4f87-4ddd-a51c-b7951254d937"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6409), "رضویه", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("899e0796-4ce7-48f1-9ab9-f532f69b1bf9"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5323), "دامنه", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("8a0dbbec-524b-409d-b182-4e8705c46a5f"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6397), "درگز", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("8a170cf7-b225-46ce-bce9-d02c869e1ad6"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7981), "رستم آباد", new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89") },
                    { new Guid("8ad60a6d-908a-4ec4-a3d0-3210f16d3f98"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8350), "خشکرود", new Guid("dd60a9d0-60cf-c6d3-b4a4-e1e09f7989b0") },
                    { new Guid("8ad678ec-a848-4d81-8c40-b78055cc5581"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5704), "جلفا", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("8aef05c2-d84b-4291-8784-aae313aa2fb5"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7818), "مادوان", new Guid("1c6f8c6a-4ee4-da52-7d12-360a189bd735") },
                    { new Guid("8b259169-e0c5-4a38-b313-eba972aa2576"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5879), "سیلوانه", new Guid("3757e8ea-143b-52ce-0d66-c474d3849f2f") },
                    { new Guid("8b43c46e-5e3f-4f28-a053-852a166d3f09"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6951), "زابل", new Guid("b84f97cd-d4ec-2d65-63d7-3aeb35a3c9e8") },
                    { new Guid("8b5a5799-ab28-4334-9221-06fba25e5854"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6617), "اهواز", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("8b8048bf-d8aa-4202-b126-0d765edf5f94"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7035), "نوک آباد", new Guid("b84f97cd-d4ec-2d65-63d7-3aeb35a3c9e8") },
                    { new Guid("8bbad3f9-2305-42c5-a56d-a5300f742848"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8492), "قشم", new Guid("2db6cdf4-e7e4-2953-2b24-514ef08ae35c") },
                    { new Guid("8bcaadf0-19be-4686-8718-c3c5c4cd66b6"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6697), "سردشت", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("8c392b99-95d7-4da1-9fa7-e6e4f7c3fd7d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5363), "زیباشهر", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("8cba9c3e-4897-43f2-900c-798fe0364df4"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5365), "سده لنجان", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("8d432605-4235-45a7-89fb-4a0b06159f9d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5765), "کلیبر", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("8d94131a-5fd8-4005-9dae-221c54548a53"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8165), "آلاشت", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("8e4b2e72-2379-45e9-816a-c9701f939235"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8656), "عشق آباد", new Guid("66a07236-f93a-4cb5-0ad6-e0416ba72886") },
                    { new Guid("8ea1d046-f279-484d-9d54-c0868cdf1cfa"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7121), "جنت شهر", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("8ea27c5a-eda7-4446-829a-21ca4c07e6a3"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7285), "مصیری", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("8eab24ce-f7fc-448e-a1ed-19cab59a623a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6296), "شوسف", new Guid("1d436afc-ef42-1885-c6af-b02635b0e0d9") },
                    { new Guid("8f31b88f-71f4-40b3-978e-9c092d0bdb76"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7909), "نوکنده", new Guid("109a51f1-9b4b-f42c-475d-6709b525de9e") },
                    { new Guid("8f33df82-8007-4db8-8c05-809318ec8848"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8228), "زیرآب", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("8f9c4958-9ab6-40d2-90c4-2bdb63267005"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8277), "گتاب", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("8fd8c649-96e7-407b-a915-e1356e7b6855"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6742), "قلعه خواجه", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("8ff68aa8-e1d7-4287-82e7-e9816f9cca25"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7251), "کوار", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("8ff99c02-04a7-4e0c-9fb8-e7828fc8e9bb"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8486), "فارغان", new Guid("2db6cdf4-e7e4-2953-2b24-514ef08ae35c") },
                    { new Guid("902bf702-c104-4c37-8c0e-197f78f0f8ed"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7359), "رازمیان", new Guid("f27b547f-a3c0-29ff-19c5-0d8c899abc3d") },
                    { new Guid("91076364-a2eb-4cdb-8524-63c598fbc23e"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6113), "صفادشت", new Guid("1c25d366-2d0a-3327-d464-b8ed3c2c3d73") },
                    { new Guid("91136cac-f88e-4565-aa56-90f0d4e19e1f"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7729), "سطر", new Guid("82ad2f1a-eb42-c56b-8834-78d95d49e1ba") },
                    { new Guid("91248d3b-24d8-4b98-9abf-e5c1c593d669"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7620), "قلعه گنج", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("912ccbdd-6798-4426-bbc7-50f597f9e03f"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5431), "گلشن", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("916feb9a-9499-4e74-b526-7c24d4c75ae1"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6666), "خرمشهر", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("91d66169-4838-4735-b432-dac68809d960"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5666), "آذرشهر", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("92213143-bb0f-4cc9-b7fb-64fcb9ef4f79"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5377), "شاهین شهر", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("924f06ee-90c1-4455-9722-1ca55bbf8f40"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7013), "کنارک", new Guid("b84f97cd-d4ec-2d65-63d7-3aeb35a3c9e8") },
                    { new Guid("92ffc587-fe5c-4ec2-912d-26073e75b2dc"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6466), "قدمگاه", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("9311b4b4-2972-4be7-9420-377cfd78194c"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8087), "الیگودرز", new Guid("64f76e56-c5a6-b275-2871-a3b26437139e") },
                    { new Guid("933e55e3-df73-4ffd-8475-6ea4eace1b8d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8112), "سپیددشت", new Guid("64f76e56-c5a6-b275-2871-a3b26437139e") },
                    { new Guid("9384869c-ee33-4142-845c-a5ea43e4d75a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7009), "قصرقند", new Guid("b84f97cd-d4ec-2d65-63d7-3aeb35a3c9e8") },
                    { new Guid("93d3f3e8-a12a-402a-afb0-7f0b67f16978"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5407), "کرکوند", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("93f6d65a-7acd-4a80-9099-07edddd0a4ea"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5384), "عسگران", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("94071fd2-8f6a-49a8-bd83-013351da0a01"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5393), "فلاورجان", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("94d3b513-1c50-4de2-8676-83163da5add7"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5553), "کوهسار", new Guid("71d4f39f-c32f-780a-4215-6c4ee11cc61e") },
                    { new Guid("951242ee-0c9c-41d9-983c-9588971189f1"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7480), "شویشه", new Guid("a56b5e1e-dc63-8684-bf85-c3b187949d66") },
                    { new Guid("95e95b6d-e166-4f83-a4ab-c9f67324947f"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5437), "گوگد", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("95ec4012-f19f-4d55-92ee-bf9144744c9b"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6078), "تهران", new Guid("1c25d366-2d0a-3327-d464-b8ed3c2c3d73") },
                    { new Guid("95f2dbb7-ccda-4d21-82fc-fe33c6fc2b07"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6875), "سمنان", new Guid("ae50e237-9bf3-fb82-b997-1ae7b059875a") },
                    { new Guid("95f5149a-15ab-417e-ae82-199b0811f8c6"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6468), "قلندرآباد", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("963ed831-2ece-4da9-a225-67be040fefe9"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7943), "بره سر", new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89") },
                    { new Guid("9682b08d-bce2-41fb-967b-3e41e5979c50"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6425), "سلامی", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("96916481-f59a-496f-82a0-e184d7e15e77"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7476), "سنندج", new Guid("a56b5e1e-dc63-8684-bf85-c3b187949d66") },
                    { new Guid("96933e0e-ea1b-47b5-a7a4-a2ca5c596c2a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6209), "شهرکرد", new Guid("41c307e8-f2bf-6b3b-244a-cc9215eb4046") },
                    { new Guid("96d50bc7-459e-4638-92c7-714d193eaaae"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8551), "زنگنه", new Guid("5a38d1f0-760a-c889-5d99-00030afbd6ce") },
                    { new Guid("96fa6549-e7c1-43c0-a8e4-a961b8224fc6"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5865), "خوی", new Guid("3757e8ea-143b-52ce-0d66-c474d3849f2f") },
                    { new Guid("97843bd8-6873-457c-a0ca-25de30a5a5a6"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6326), "نیمبلوک", new Guid("1d436afc-ef42-1885-c6af-b02635b0e0d9") },
                    { new Guid("97a0547e-2d51-41f7-af1a-9bd87a2f6949"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6458), "فیروزه", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("97b92448-7c6c-48f1-8789-1d35fc3b1c82"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5962), "آبدان", new Guid("a4211e9c-ea7b-a182-d1c8-7c6aa71befaf") },
                    { new Guid("97e8f101-4df7-4fce-87bd-30e5444a043e"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(4680), "رضی", new Guid("9335ae23-0144-99e7-2a2f-c733db6c3cb9") },
                    { new Guid("982c905c-a2ab-47a6-8406-bc34a2b0b59b"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7764), "نوسود", new Guid("82ad2f1a-eb42-c56b-8834-78d95d49e1ba") },
                    { new Guid("98375908-d5b9-490b-82f7-0b9f24e0d530"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5960), "آبپخش", new Guid("a4211e9c-ea7b-a182-d1c8-7c6aa71befaf") },
                    { new Guid("98a11f8e-ed5e-4cc8-b9c4-3a5c444f5f78"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7698), "ازگله", new Guid("82ad2f1a-eb42-c56b-8834-78d95d49e1ba") },
                    { new Guid("995491f6-e748-41dc-b381-787a0b83dc4f"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7723), "سرپل ذهاب", new Guid("82ad2f1a-eb42-c56b-8834-78d95d49e1ba") },
                    { new Guid("9966f87a-ef97-4dc5-ab88-5f00dcc83ba3"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6148), "ملارد", new Guid("1c25d366-2d0a-3327-d464-b8ed3c2c3d73") },
                    { new Guid("998baf4e-f86c-4ceb-bb5a-af62e83ef5b7"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6380), "چکنه", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("99b8aeef-a5d8-4c40-8e35-a5042a7b7a0b"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5362), "زواره", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("99d2aa2f-d21a-4509-b810-7996e2598cca"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7091), "آباده", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("99f93569-be9d-42e4-a313-2a9ed07257f5"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6957), "زرآباد", new Guid("b84f97cd-d4ec-2d65-63d7-3aeb35a3c9e8") },
                    { new Guid("9ac0c3ee-8b0a-4f63-9fbf-6e1d8207d7a4"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6051), "اسلامشهر", new Guid("1c25d366-2d0a-3327-d464-b8ed3c2c3d73") },
                    { new Guid("9b5b3bf6-fd99-4ac4-a062-688e6f49ffbe"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6120), "فشم", new Guid("1c25d366-2d0a-3327-d464-b8ed3c2c3d73") },
                    { new Guid("9b899049-6b89-4043-9b18-bfdff9f4b66c"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6756), "مقاومت", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("9be196f3-bbb1-4aa2-a0de-7430b220a6ff"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6394), "داورزن", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("9c1a64f9-bd0c-4ac5-96e6-b7fcb2b7f9f0"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8196), "چمستان", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("9c5f6c9f-b56e-45cb-8384-c4a970b1eb13"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7924), "احمدسرگوراب", new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89") },
                    { new Guid("9c9f34ee-8c85-4e49-9bcf-fafee0e57911"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7096), "باب انار", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("9cc9938f-6506-4722-9665-ca49d7648e46"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5857), "تکاب", new Guid("3757e8ea-143b-52ce-0d66-c474d3849f2f") },
                    { new Guid("9d28d5fb-4fa4-46b0-a8a2-6f812da574a0"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5900), "قوشچی", new Guid("3757e8ea-143b-52ce-0d66-c474d3849f2f") },
                    { new Guid("9d51ab08-5c70-4bcb-8932-4285d6665d7d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7204), "صغاد", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("9d5c5e2e-582a-45d0-a5b2-138765bb99d4"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7659), "مردهک", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("9d6e1891-7f84-4f65-8c1a-2bbc885fed4a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7904), "نگین شهر", new Guid("109a51f1-9b4b-f42c-475d-6709b525de9e") },
                    { new Guid("9db37a0c-7e26-440e-acf8-e21336ae3a88"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7540), "بم", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("9dfd6ff3-004a-48c3-b3de-179446c90d8a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8004), "شلمان", new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89") },
                    { new Guid("9e00f4d6-44ad-4135-9ceb-fedce8801a26"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7415), "کهک", new Guid("d6106951-3204-f3ab-6ec8-6e9c5efb825e") },
                    { new Guid("9e8a42f7-4a26-4588-bdb1-9d4104b70781"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7375), "قزوین", new Guid("f27b547f-a3c0-29ff-19c5-0d8c899abc3d") },
                    { new Guid("9eb816c9-0937-4f3c-ac03-313da6598b6b"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5793), "وایقان", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("9ec27ee6-c85a-432e-9bc4-1a0a4c33119b"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7336), "آبگرم", new Guid("f27b547f-a3c0-29ff-19c5-0d8c899abc3d") },
                    { new Guid("9f37292d-3323-4c12-818e-5d19a709b038"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7894), "گمیش تپه", new Guid("109a51f1-9b4b-f42c-475d-6709b525de9e") },
                    { new Guid("9f394c3d-a2ba-4c75-9a87-acf3dd25d542"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8651), "شاهدیه", new Guid("66a07236-f93a-4cb5-0ad6-e0416ba72886") },
                    { new Guid("9f4e6c1a-8dfe-46f2-8dcd-2de060c6cd6c"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7747), "کرندغرب", new Guid("82ad2f1a-eb42-c56b-8834-78d95d49e1ba") },
                    { new Guid("9f6caf02-1b2e-450c-a553-ee476023d19d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6934), "پیشین", new Guid("b84f97cd-d4ec-2d65-63d7-3aeb35a3c9e8") },
                    { new Guid("9f79bba5-e130-4f80-a081-59dd2f4a8a71"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7964), "حویق", new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89") },
                    { new Guid("9fe8211f-eaf6-47a5-9412-715ef01716e5"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8643), "خضرآباد", new Guid("66a07236-f93a-4cb5-0ad6-e0416ba72886") },
                    { new Guid("a0267b34-4d17-4343-89d1-1ff5a4419c55"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6109), "صباشهر", new Guid("1c25d366-2d0a-3327-d464-b8ed3c2c3d73") },
                    { new Guid("a03631b9-0bf0-49d3-b84e-2842ad4da93a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5417), "کوشک", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("a097048a-72cd-4ca8-9231-597157153d48"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5621), "سرابله", new Guid("2acf226d-ed63-0c67-9744-591e072a0227") },
                    { new Guid("a0c16cfc-e1be-4bfc-9842-761c9ac93dee"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6084), "چهاردانگه", new Guid("1c25d366-2d0a-3327-d464-b8ed3c2c3d73") },
                    { new Guid("a0e2665f-44e1-43c0-81e5-1edbfebf1b06"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6633), "بندرامام خمینی", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("a0f0c41a-84e9-4c63-a4f0-16ef060991f9"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8463), "درگهان", new Guid("2db6cdf4-e7e4-2953-2b24-514ef08ae35c") },
                    { new Guid("a121f569-bb57-40b4-ac07-57877c411abf"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8586), "لالجین", new Guid("5a38d1f0-760a-c889-5d99-00030afbd6ce") },
                    { new Guid("a15816bd-3a7d-423f-91fc-11518f5d503a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6097), "ری", new Guid("1c25d366-2d0a-3327-d464-b8ed3c2c3d73") },
                    { new Guid("a1b26cf2-398f-48bb-bc26-46ed78964550"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5464), "نوش آباد", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("a1d441f3-51ae-473e-884d-0e92fedf7db0"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8641), "حمیدیا", new Guid("66a07236-f93a-4cb5-0ad6-e0416ba72886") },
                    { new Guid("a1fdb43e-7d36-4d01-b422-135dce8b918c"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6278), "حاجی آباد", new Guid("1d436afc-ef42-1885-c6af-b02635b0e0d9") },
                    { new Guid("a237d08b-a4cc-4182-8553-b1682f143f0f"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8052), "ماسوله", new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89") },
                    { new Guid("a2500793-9812-45bc-8db1-d43af04ee47e"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8536), "بهار", new Guid("5a38d1f0-760a-c889-5d99-00030afbd6ce") },
                    { new Guid("a2566e7b-4e64-4da6-adec-7a87d75b588c"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7245), "کره ای", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("a276ea53-3dda-44e0-8873-d93a9e61877b"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7868), "دلند", new Guid("109a51f1-9b4b-f42c-475d-6709b525de9e") },
                    { new Guid("a308435c-69d2-4e68-b8cd-3b58dd29d243"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6701), "سماله", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("a3d92c25-849e-47be-aafb-9c160bda2702"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6348), "باجگیران", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("a429868f-aea0-4b0b-8228-389dc9e56889"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7939), "آستانه اشرفیه", new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89") },
                    { new Guid("a42a3a85-3677-4e54-b03f-2aac4a1590fd"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6272), "آیسک", new Guid("1d436afc-ef42-1885-c6af-b02635b0e0d9") },
                    { new Guid("a45dfa92-7852-43d2-9a2a-a16c95411559"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6971), "سیرکان", new Guid("b84f97cd-d4ec-2d65-63d7-3aeb35a3c9e8") },
                    { new Guid("a46972bf-aea6-4e81-9954-3bd6c4aa5ae0"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(4732), "هشتجین", new Guid("9335ae23-0144-99e7-2a2f-c733db6c3cb9") },
                    { new Guid("a4e1d363-6b43-4a0d-97ec-a37a49f4a7c4"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8260), "کلارآباد", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("a4ead53c-b9e7-43b4-af77-577bc9a2b436"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5313), "خور", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("a4fa7b84-91f8-406d-b003-8db24f3e503a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8281), "گلوگاه", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("a5281a01-8168-45e4-8a63-47d88ca34e18"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6963), "سراوان", new Guid("b84f97cd-d4ec-2d65-63d7-3aeb35a3c9e8") },
                    { new Guid("a55f2e0b-7c0d-4b6a-b6c4-d8567003cdde"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5400), "قهجاورستان", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("a5601f85-a968-462b-8cbc-d8346111b45f"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6863), "بیارجمند", new Guid("ae50e237-9bf3-fb82-b997-1ae7b059875a") },
                    { new Guid("a5da1a01-70f0-46e0-866d-8bb89a4551d8"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6189), "بن", new Guid("41c307e8-f2bf-6b3b-244a-cc9215eb4046") },
                    { new Guid("a5f8b7f8-bff3-4dc6-a9c0-b96ad21391db"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(4730), "نیر", new Guid("9335ae23-0144-99e7-2a2f-c733db6c3cb9") },
                    { new Guid("a626cf42-0bd7-4a2d-8da1-01e00a7fcc71"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6186), "بلداجی", new Guid("41c307e8-f2bf-6b3b-244a-cc9215eb4046") },
                    { new Guid("a66121b2-92e1-424f-9013-662ae10f1d64"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5598), "بدره", new Guid("2acf226d-ed63-0c67-9744-591e072a0227") },
                    { new Guid("a669b7d1-3104-4c25-8440-2204481aa6b8"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5747), "شندآباد", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("a6b801af-8e13-4bbc-af10-1c01f235711c"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6006), "دلوار", new Guid("a4211e9c-ea7b-a182-d1c8-7c6aa71befaf") },
                    { new Guid("a795774c-715a-4f17-8dcc-c04cbe7b87b8"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6821), "سلطانیه", new Guid("e4f80638-3050-9434-78bd-358733300127") },
                    { new Guid("a7e36f02-f830-4f73-8393-7ec80800b81c"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6354), "بار", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("a7e731a2-6add-4b66-be45-0e58b8e1d121"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6178), "آلونی", new Guid("41c307e8-f2bf-6b3b-244a-cc9215eb4046") },
                    { new Guid("a847771c-2c84-4533-907f-8b6e4c780cc0"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8680), "یزد", new Guid("66a07236-f93a-4cb5-0ad6-e0416ba72886") },
                    { new Guid("a87cbde6-44da-4538-b243-db243e23b85e"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8565), "فامنین", new Guid("5a38d1f0-760a-c889-5d99-00030afbd6ce") },
                    { new Guid("a8d837fe-02d6-49a2-9135-e95ec786ada6"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7326), "ارداق", new Guid("f27b547f-a3c0-29ff-19c5-0d8c899abc3d") },
                    { new Guid("a976b2c4-37a6-4b5f-bb75-49215d415633"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8549), "رزن", new Guid("5a38d1f0-760a-c889-5d99-00030afbd6ce") },
                    { new Guid("a9cb114d-583a-4ef8-a8a9-8498acd7aadd"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8285), "محمود آباد", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("a9e6e72f-39af-4696-a1de-e61b40f4d4cb"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7878), "علی آباد", new Guid("109a51f1-9b4b-f42c-475d-6709b525de9e") },
                    { new Guid("aa716196-dcf7-4e76-bc73-d40dde099bc7"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6389), "خلیل آباد", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("aa87f988-f76f-4dab-9dd0-29349acbdc57"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6027), "کلمه", new Guid("a4211e9c-ea7b-a182-d1c8-7c6aa71befaf") },
                    { new Guid("aaf23956-ad8c-4505-97cc-e838cc848837"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6086), "حسن آباد", new Guid("1c25d366-2d0a-3327-d464-b8ed3c2c3d73") },
                    { new Guid("ab0391d3-f13a-41ad-91c2-1a3c5efdcf85"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7459), "زرینه", new Guid("a56b5e1e-dc63-8684-bf85-c3b187949d66") },
                    { new Guid("ab479faa-d1ba-46fc-a44f-22ca8abe6edd"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8546), "دمق", new Guid("5a38d1f0-760a-c889-5d99-00030afbd6ce") },
                    { new Guid("ab4f1e24-3fc5-4f80-8e80-080e82fa775b"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6105), "شهریار", new Guid("1c25d366-2d0a-3327-d464-b8ed3c2c3d73") },
                    { new Guid("ab84de74-41fe-4286-aae4-e80a01854f56"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7935), "آستارا", new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89") },
                    { new Guid("ab86f303-8529-491e-8802-77fead8f6fd6"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7615), "فاریاب", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("abc90c49-cba3-450c-8645-adeba8ef9e40"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7081), "اوز", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("abdf1243-0438-4864-beb3-909cf4e12175"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8661), "مروست", new Guid("66a07236-f93a-4cb5-0ad6-e0416ba72886") },
                    { new Guid("abf364b8-947c-44c1-87f3-f5e73e2d33bc"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7293), "نوبندگان", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("ac071337-c258-4aef-901f-7dad2a1dd564"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8222), "رویان", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("ac08d27f-2a46-49f8-b487-16a46d0f6e73"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5475), "وزوان", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("ac0c1358-ac85-425f-aa5e-e4da072b29b6"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7638), "گلباف", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("ac22061f-e9f5-4e5a-b7d4-b167d9774c86"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7190), "سورمق", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("ac3f0052-2aca-4683-a196-3e64fed3db40"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6053), "اندیشه", new Guid("1c25d366-2d0a-3327-d464-b8ed3c2c3d73") },
                    { new Guid("ac480dd6-7771-496a-ada4-a1b81d02ee6c"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7061), "اردکان", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("ac75e9b4-d34d-4360-86da-c6062e16b9a0"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7006), "فنوج", new Guid("b84f97cd-d4ec-2d65-63d7-3aeb35a3c9e8") },
                    { new Guid("ad1e0da5-d3f6-47b8-891f-7bf79324939a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6286), "زهان", new Guid("1d436afc-ef42-1885-c6af-b02635b0e0d9") },
                    { new Guid("ad7b4c15-3a16-49c2-bd3c-c075dd733fef"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6619), "ایذه", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("ada4deba-9e67-4c7e-96a7-1d0a0db45cdc"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7585), "رفسنجان", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("adb47898-5bb3-4e93-97f0-eefee56c1d63"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5897), "قطور", new Guid("3757e8ea-143b-52ce-0d66-c474d3849f2f") },
                    { new Guid("ae4b94ce-52a7-4967-a141-12e2ebb3c26b"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7365), "سیردان", new Guid("f27b547f-a3c0-29ff-19c5-0d8c899abc3d") },
                    { new Guid("ae82bf8c-f778-41cb-a811-a4f7e19cf036"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5742), "شربیان", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("ae909d85-8a3a-47f9-b2fb-73288a75881d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7816), "لیکک", new Guid("1c6f8c6a-4ee4-da52-7d12-360a189bd735") },
                    { new Guid("aedd589c-7681-4b01-93e3-246325bab8f5"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6965), "سرباز", new Guid("b84f97cd-d4ec-2d65-63d7-3aeb35a3c9e8") },
                    { new Guid("af65397b-04e5-4f3c-9863-fd88f2eba058"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6615), "اندیمشک", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("b01323e6-abb4-4f18-9390-4e2454d90198"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8593), "نهاوند", new Guid("5a38d1f0-760a-c889-5d99-00030afbd6ce") },
                    { new Guid("b0791a6c-349a-408d-a6fb-2893a0330551"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6924), "بزمان", new Guid("b84f97cd-d4ec-2d65-63d7-3aeb35a3c9e8") },
                    { new Guid("b0970b0d-d87e-4b0c-83cc-b56013fdf84d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5429), "گلدشت", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("b0e8c878-4361-42d9-85e0-5752962955c0"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6653), "چوئبده", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("b123b748-3a44-4242-84cd-b78c99bfad3c"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6282), "خضری دشت بیاض", new Guid("1d436afc-ef42-1885-c6af-b02635b0e0d9") },
                    { new Guid("b12bb5e1-70c9-4f86-b011-eb6c70de5751"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8095), "چالانچولان", new Guid("64f76e56-c5a6-b275-2871-a3b26437139e") },
                    { new Guid("b14bb2cd-7dc2-4775-ad67-6a4107ca5e8b"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8659), "عقدا", new Guid("66a07236-f93a-4cb5-0ad6-e0416ba72886") },
                    { new Guid("b22736f1-11dd-4e3b-852c-e91466a049f8"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6312), "محمد شهر", new Guid("1d436afc-ef42-1885-c6af-b02635b0e0d9") },
                    { new Guid("b247b7a6-9dcd-4ca7-afe8-0803fb44fe50"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7864), "جلین", new Guid("109a51f1-9b4b-f42c-475d-6709b525de9e") },
                    { new Guid("b28b6f84-cb78-495b-9047-b4ba0c713b02"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6207), "شلمزار", new Guid("41c307e8-f2bf-6b3b-244a-cc9215eb4046") },
                    { new Guid("b3401e78-dc09-4262-bdb7-b6113ab7aa63"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8289), "مرزیکلا", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("b35161c1-50c7-4fd7-88ec-8238e5336588"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6693), "زهره", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("b361a1be-e2f3-4a6e-8473-d98f72e2dc6b"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7551), "جوپار", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("b375f9cd-a8f5-4779-9aca-82573c7865c7"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8108), "دورود", new Guid("64f76e56-c5a6-b275-2871-a3b26437139e") },
                    { new Guid("b3824afa-6dcf-4f04-8e76-f682394453ba"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5795), "ورزقان", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("b3ad9e0a-18aa-4c99-9b90-37d937b53fed"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7677), "هجدک", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("b3ae9c8b-5724-43fc-b6e6-887c236ea6cf"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5235), "ابوزیدآباد", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("b41017f0-3fc7-444b-a705-2f7da4ff8198"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6089), "دماوند", new Guid("1c25d366-2d0a-3327-d464-b8ed3c2c3d73") },
                    { new Guid("b4903279-e6b2-45e1-9d5b-520a7cf9dc87"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7075), "اقلید", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("b4a87ba5-46ae-4b6e-985b-6831d9496418"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5773), "لیلان", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("b545f029-368b-4dad-8e33-7b28d6a2f94f"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8194), "چالوس", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("b5695a11-98f8-4130-817e-cd3a3761b703"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6274), "بشرویه", new Guid("1d436afc-ef42-1885-c6af-b02635b0e0d9") },
                    { new Guid("b5fb016a-b12e-467c-a974-88bdf579677c"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6855), "ایوانکی", new Guid("ae50e237-9bf3-fb82-b997-1ae7b059875a") },
                    { new Guid("b65c5287-b94a-42fa-ac4a-9e414f173ecf"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8469), "رویدر", new Guid("2db6cdf4-e7e4-2953-2b24-514ef08ae35c") },
                    { new Guid("b6805890-a6a9-4c28-b3d7-e3a8643c63d1"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8669), "میبد", new Guid("66a07236-f93a-4cb5-0ad6-e0416ba72886") },
                    { new Guid("b68cdb0d-b835-449c-b4f0-bd82788458a4"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6239), "نقنه", new Guid("41c307e8-f2bf-6b3b-244a-cc9215eb4046") },
                    { new Guid("b6eea416-5735-4259-bda9-70361d4a29fe"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6427), "سلطان آباد", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("b6f8daed-17b1-4f16-8b7a-dcae7ae2139f"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6647), "چغامیش", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("b705f37c-8998-4ad1-adfa-fb6a0df10004"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5635), "مهران", new Guid("2acf226d-ed63-0c67-9744-591e072a0227") },
                    { new Guid("b76a8190-3c0e-4c16-b895-96322050550e"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7524), "انار", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("b7aadbf3-5a1e-4507-8115-b04ec224473c"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6440), "شهرآباد", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("b7fd28c2-0be5-49ba-ae51-0d971edbd0f8"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5468), "نیک آباد", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("b80b9775-ad32-475d-b06f-df005ec987ec"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6575), "شوقان", new Guid("77881601-9f29-c4a9-8076-92a9b3c61aff") },
                    { new Guid("b8f12ed7-7c25-430b-bbd1-9bef33b53b15"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8253), "فریم", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("b95dd32c-abde-45f5-ada9-755849f89f9f"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6405), "رباط سنگ", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("b97ce3fb-b86c-4dfb-a895-264277b918c5"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8559), "شیرین سو", new Guid("5a38d1f0-760a-c889-5d99-00030afbd6ce") },
                    { new Guid("b99d1be8-e88d-4c57-87d2-4efb7ced3693"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8156), "امیرکلا", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("b9c0f40d-d84e-45fd-b9d7-6c1f570905bb"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7387), "نرجه", new Guid("f27b547f-a3c0-29ff-19c5-0d8c899abc3d") },
                    { new Guid("b9dd8f16-e305-413f-a6c1-bbdd0d959e79"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5555), "گرمدره", new Guid("71d4f39f-c32f-780a-4215-6c4ee11cc61e") },
                    { new Guid("b9f3bce2-2b69-45ca-b195-360effd87c3a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6637), "بهبهان", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("b9f79316-f6c4-4f4a-9ff2-cfc367a4a08a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7663), "منوجان", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("ba68c021-0f81-4fa4-86b2-ef4ed705181b"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6871), "دیباج", new Guid("ae50e237-9bf3-fb82-b997-1ae7b059875a") },
                    { new Guid("baa72be4-94e7-40b4-be07-2b91481230b2"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(4150), "اردبیل", new Guid("9335ae23-0144-99e7-2a2f-c733db6c3cb9") },
                    { new Guid("bac32270-b65d-4097-8073-aa338af53c8e"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5604), "توحید", new Guid("2acf226d-ed63-0c67-9744-591e072a0227") },
                    { new Guid("bae40104-1fe9-44b7-9680-621f3364edc8"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5873), "سردشت", new Guid("3757e8ea-143b-52ce-0d66-c474d3849f2f") },
                    { new Guid("baf35eaf-2912-4266-9138-cfb5c07430fb"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5278), "پیربکران", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("bb8ef8c6-5ff7-41cc-b38c-58ce565aae91"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6506), "مشهد", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("bbf29459-e91f-4d23-ba49-3951125d3f28"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8211), "رستمکلا", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("bc2e15ad-f080-4af1-95c2-ad483c7e6273"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8292), "نشتارود", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("bc9e9779-056d-4de0-bfe5-c059bbf9962b"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8496), "کنگ", new Guid("2db6cdf4-e7e4-2953-2b24-514ef08ae35c") },
                    { new Guid("bcb83b14-f111-4c6b-ad11-0980da24ef70"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7622), "کاظم آباد", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("bcbf6890-ed92-463a-ae89-7003e578891b"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6550), "ایور", new Guid("77881601-9f29-c4a9-8076-92a9b3c61aff") },
                    { new Guid("bd13ee1e-0b60-4413-8cee-aa92b7ce0487"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7876), "سیمین شهر", new Guid("109a51f1-9b4b-f42c-475d-6709b525de9e") },
                    { new Guid("bd4c55b0-5cce-4044-a861-13c4c6969321"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6568), "درق", new Guid("77881601-9f29-c4a9-8076-92a9b3c61aff") },
                    { new Guid("bd55fe8a-45d2-4916-ae7d-31ea889c8cd9"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8279), "گزنک", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("bd6c55df-a700-482e-ad3c-6a2f6f10d30f"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7184), "سروستان", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("bd7e2797-9b25-40f9-b5ae-6c99b2fcd91b"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8268), "کوهی خیل", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("bdda940b-3e97-41e7-89a3-f2711cfd2473"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5312), "خوانسار", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("be09e40b-8214-45c3-b39b-3ce88c3f4aee"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7446), "چناره", new Guid("a56b5e1e-dc63-8684-bf85-c3b187949d66") },
                    { new Guid("becc2537-0129-47e5-ba1c-575050967c7a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7123), "جویم", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("bed5b3b7-097e-4f85-b4fd-a2a087f873b8"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7761), "نودشه", new Guid("82ad2f1a-eb42-c56b-8834-78d95d49e1ba") },
                    { new Guid("bee5ace1-0167-44f5-aa69-9bcdce139149"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8319), "آستانه", new Guid("dd60a9d0-60cf-c6d3-b4a4-e1e09f7989b0") },
                    { new Guid("beef174e-fd7b-4cc2-9696-5c0c5270f44a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7379), "محمدیه", new Guid("f27b547f-a3c0-29ff-19c5-0d8c899abc3d") },
                    { new Guid("bf0b2031-7fee-4b6a-be60-8857a9d2a09c"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7954), "جیرنده", new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89") },
                    { new Guid("bf2d619f-8bfb-4bde-bfbe-aa8a641a162b"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7295), "نوجین", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("bf97bb36-e5ed-4ddb-a649-ee261c3a2409"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7858), "بندرگز", new Guid("109a51f1-9b4b-f42c-475d-6709b525de9e") },
                    { new Guid("c01c567f-6d3b-4c46-ba43-9eaad788f710"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6082), "جوادآباد", new Guid("1c25d366-2d0a-3327-d464-b8ed3c2c3d73") },
                    { new Guid("c0ad1e9c-d08d-4f5a-b756-bd892736c063"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6764), "میداود", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("c0d85678-fd15-44ed-85e6-8182010f9915"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6193), "چلگرد", new Guid("41c307e8-f2bf-6b3b-244a-cc9215eb4046") },
                    { new Guid("c2497d78-ba33-43a7-8bb7-fdfd6cd49fce"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7739), "صحنه", new Guid("82ad2f1a-eb42-c56b-8834-78d95d49e1ba") },
                    { new Guid("c24e25f0-0365-4912-9caa-9eb20fb64505"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6203), "سورشجان", new Guid("41c307e8-f2bf-6b3b-244a-cc9215eb4046") },
                    { new Guid("c29495e5-50d7-415f-a84b-3392bbd0a5dc"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7577), "رابر", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("c3386af8-9551-4e0a-8d32-c72e5244221c"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6292), "سربیشه", new Guid("1d436afc-ef42-1885-c6af-b02635b0e0d9") },
                    { new Guid("c3433def-188f-4e4c-b1b8-af4974bcdb50"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8628), "اشکذر", new Guid("66a07236-f93a-4cb5-0ad6-e0416ba72886") },
                    { new Guid("c3459cf2-05d8-4de3-a6ab-50e5b95ad0a3"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7579), "راور", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("c3879feb-0492-4ca2-91cb-3bc20e18e8d3"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5926), "نقده", new Guid("3757e8ea-143b-52ce-0d66-c474d3849f2f") },
                    { new Guid("c3d0bea2-7583-4c63-a7b3-eca0d68f4be8"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7941), "بازارجمعه", new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89") },
                    { new Guid("c43eee49-8f2d-47be-b57e-2296cf6ec025"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6095), "رودهن", new Guid("1c25d366-2d0a-3327-d464-b8ed3c2c3d73") },
                    { new Guid("c4459b49-0470-4bd4-ad67-ef113c33e124"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7589), "ریحان شهر", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("c4857b8a-3233-42ff-abd0-2dc1cbc26e1a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6526), "نیل شهر", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("c4aae4a1-dd31-48ed-b1af-51874b052d59"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5564), "نظرآباد", new Guid("71d4f39f-c32f-780a-4215-6c4ee11cc61e") },
                    { new Guid("c4ae3dab-2b04-45ee-93cd-d281e7765502"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8500), "کوشکنار", new Guid("2db6cdf4-e7e4-2953-2b24-514ef08ae35c") },
                    { new Guid("c4b59490-af20-4baa-a369-77ecf7d30737"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6144), "گلستان", new Guid("1c25d366-2d0a-3327-d464-b8ed3c2c3d73") },
                    { new Guid("c4c4db4c-0293-4997-a392-0ddb0422ef90"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5990), "تنگ ارم", new Guid("a4211e9c-ea7b-a182-d1c8-7c6aa71befaf") },
                    { new Guid("c4e36554-07f3-477f-b3b6-2b73566da65b"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6752), "مسجدسلیمان", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("c4f7c812-a086-4040-91bf-c07c43c61527"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5409), "کلیشادوسودرجان", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("c56deef6-7f05-4ce1-b9bd-c394da3b516d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6473), "کاخک", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("c5ec3b12-9b70-4c14-8ff2-0de1fe4cc8fd"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7812), "گراب سفلی", new Guid("1c6f8c6a-4ee4-da52-7d12-360a189bd735") },
                    { new Guid("c5ffc91a-5b33-4fc1-bfe3-24743d295196"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6376), "جنگل", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("c618de3a-37e3-466d-a6aa-d52de70e7f73"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5611), "دلگشا", new Guid("2acf226d-ed63-0c67-9744-591e072a0227") },
                    { new Guid("c64556a6-5a27-487c-b791-0a5971275e7a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7853), "آزادشهر", new Guid("109a51f1-9b4b-f42c-475d-6709b525de9e") },
                    { new Guid("c66bd396-631d-4f1f-b814-7a164cd983b5"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5560), "محمدشهر", new Guid("71d4f39f-c32f-780a-4215-6c4ee11cc61e") },
                    { new Guid("c6a0d78d-aad8-44f6-985b-2def6e9be983"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7171), "رامجرد", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("c6d24d7b-46ad-4edd-acd1-f4e9002cd3d1"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8580), "گل تپه", new Guid("5a38d1f0-760a-c889-5d99-00030afbd6ce") },
                    { new Guid("c720c3a5-b1db-431d-907b-3c3793392658"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5986), "بنک", new Guid("a4211e9c-ea7b-a182-d1c8-7c6aa71befaf") },
                    { new Guid("c72b0115-cd47-4351-bf0c-451c90716280"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8471), "زیارتعلی", new Guid("2db6cdf4-e7e4-2953-2b24-514ef08ae35c") },
                    { new Guid("c7c01de6-9d1f-4ab1-9ce3-b5cdbfb4adfb"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5534), "تنکمان", new Guid("71d4f39f-c32f-780a-4215-6c4ee11cc61e") },
                    { new Guid("c7ddb1f0-e6da-4d84-a790-761c55d656d2"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5619), "سراب باغ", new Guid("2acf226d-ed63-0c67-9744-591e072a0227") },
                    { new Guid("c7de4e87-5c42-4ef8-aba9-ee9168c35c4b"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5402), "قهدریجان", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("c8750cf4-1d95-41ae-9414-e5e90ca44137"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5791), "نظرکهریزی", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("c87c7ac3-b060-442b-bdf3-1a88f7c2a3dc"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5420), "کهریزسنگ", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("c8ad91e2-6e0d-42fc-9314-3e4af3a3ec51"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8012), "کلاچای", new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89") },
                    { new Guid("c8d5db04-366b-42e0-95a7-b438fb065407"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5354), "رضوانشهر", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("c8f1835a-750f-4446-9757-376393883c67"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7896), "گنبد کاووس", new Guid("109a51f1-9b4b-f42c-475d-6709b525de9e") },
                    { new Guid("c8f290d7-fbcd-47c1-b2e1-5b4287f3d847"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6676), "دهدز", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("c90adae8-9c7f-4287-9215-c1a0d55dd67e"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5299), "حبیب آباد", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("c970be31-1216-4527-b0a1-b040e23c93a6"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7628), "کشکوئیه", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("c9f0c2a3-c9bc-48f0-8115-e7d982f3d742"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7432), "آرمرده", new Guid("a56b5e1e-dc63-8684-bf85-c3b187949d66") },
                    { new Guid("ca23ab61-045b-4d18-97d4-1bb1537d8f98"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5348), "دیزیچه", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("ca63a858-65e2-4b46-8f97-bfd73862383a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5914), "محمودآباد", new Guid("3757e8ea-143b-52ce-0d66-c474d3849f2f") },
                    { new Guid("ca6e0a0a-ce1c-4605-9915-99a18803eda4"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5801), "هریس", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("ca7707ab-4d37-4c8a-8b42-b34292df1f6a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6487), "کندر", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("ca928f07-d9a1-4e34-8d81-e1cff4714194"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5352), "رزوه", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("caa91eca-25ad-4489-9c2c-f121ad9705a1"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8186), "پول", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("cafd68ef-b575-4af5-9877-4a1714fb9b11"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6074), "پیشوا", new Guid("1c25d366-2d0a-3327-d464-b8ed3c2c3d73") },
                    { new Guid("cbc0afe2-0601-473c-87a5-7016cf40b335"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6072), "پردیس", new Guid("1c25d366-2d0a-3327-d464-b8ed3c2c3d73") },
                    { new Guid("cbd3084a-2b1c-4a0d-bfa5-a9ae0381e18d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6518), "نقاب", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("cbf046c1-3b71-4b10-9ad0-1c6e542e6744"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7465), "سریش آباد", new Guid("a56b5e1e-dc63-8684-bf85-c3b187949d66") },
                    { new Guid("cc0a4dfa-5405-425d-b4b6-fd9101436c5d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6625), "آغاجاری", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("ccb2629b-1692-4a8b-96e9-f708ee214f37"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5480), "هرند", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("ccf3b15a-e6e8-4159-81ba-fa01c423e2c2"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6288), "سرایان", new Guid("1d436afc-ef42-1885-c6af-b02635b0e0d9") },
                    { new Guid("cd3d597d-573a-49f6-ac80-f5eb9eb9a2d8"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7166), "دوزه", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("cd54ce5f-fb8e-433c-8c3a-fdd3f428b64b"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5327), "دستگرد", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("cdbe654d-b72b-4b59-93c5-d090a654cbdb"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5295), "چرمهین", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("cddf413d-532d-496f-9536-03dbaa4b0038"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5315), "خوراسگان", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("ce09921a-abe4-487f-a092-2351524ef9e3"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5771), "گوگان", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("ce1153a7-99c7-4d0b-8e38-2dd4189d854f"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5828), "اشنویه", new Guid("3757e8ea-143b-52ce-0d66-c474d3849f2f") },
                    { new Guid("ce2dd08f-6990-4446-8c4c-dbbc16ee74ff"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5918), "میاندوآب", new Guid("3757e8ea-143b-52ce-0d66-c474d3849f2f") },
                    { new Guid("ce8d0c58-a4a9-42c7-8e67-a5bfb11bd42f"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6374), "جغتای", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("cf33dc8f-3449-4c25-9088-7f07a6f450c8"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(4682), "سرعین", new Guid("9335ae23-0144-99e7-2a2f-c733db6c3cb9") },
                    { new Guid("cf5854f4-0e70-481f-883c-e64e4d00a47d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(4660), "بیله سوار", new Guid("9335ae23-0144-99e7-2a2f-c733db6c3cb9") },
                    { new Guid("cf7380c2-a482-42c9-9f2c-4af63a7de14d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7607), "شهربابک", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("cf86ec97-6c5a-4973-a32b-daa9cf71b12e"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7033), "نگور", new Guid("b84f97cd-d4ec-2d65-63d7-3aeb35a3c9e8") },
                    { new Guid("cf8e2aad-a47a-459b-b603-d54c9813de70"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8201), "خلیل شهر", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("cffb157b-ee78-427a-802f-0adebfb74338"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6629), "بستان", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("d0355a33-1c84-405e-b0e1-795cf5f54c64"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7133), "حسن آباد", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("d05bc718-f3d2-4ddf-94ca-95c76375a542"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6479), "کاشمر", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("d088ff39-28ce-4c29-90cf-e15515661c51"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5924), "نالوس", new Guid("3757e8ea-143b-52ce-0d66-c474d3849f2f") },
                    { new Guid("d0befa35-b243-47ed-9e81-2d1019f2514c"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8198), "خرم آباد", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("d0caf7fd-df8c-4fff-af71-7b0088d6692a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7385), "معلم کلایه", new Guid("f27b547f-a3c0-29ff-19c5-0d8c899abc3d") },
                    { new Guid("d0ebf5c0-d501-4033-80bb-1d295e3694ad"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6460), "فیض آباد", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("d1323b7e-a366-4a38-ac1e-bb5e78dbe933"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6890), "کلاته خیج", new Guid("ae50e237-9bf3-fb82-b997-1ae7b059875a") },
                    { new Guid("d1697e4a-a6cb-4b07-9a50-c0840ee2031a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6159), "ورامین", new Guid("1c25d366-2d0a-3327-d464-b8ed3c2c3d73") },
                    { new Guid("d18e4c0d-fce1-430b-ae4a-6b31850547d7"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5588), "ایلام", new Guid("2acf226d-ed63-0c67-9744-591e072a0227") },
                    { new Guid("d1d096ef-6c3b-48ec-b32e-040634f62980"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8502), "کیش", new Guid("2db6cdf4-e7e4-2953-2b24-514ef08ae35c") },
                    { new Guid("d1dc847a-0152-4ca5-b545-bdcf6c8dd47d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5957), "اهرم", new Guid("a4211e9c-ea7b-a182-d1c8-7c6aa71befaf") },
                    { new Guid("d1f40a7b-963f-4b05-af5f-c7346cda10fa"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6746), "گوریه", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("d212dab9-5c2f-45a6-a815-cb4f849e4851"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7956), "چابکسر", new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89") },
                    { new Guid("d24c248a-5da7-4ace-a128-c2d5c12643b9"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8439), "بندرجاسک", new Guid("2db6cdf4-e7e4-2953-2b24-514ef08ae35c") },
                    { new Guid("d2f81968-6b0a-4034-852a-c1e3d3775ccc"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8232), "ساری", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("d31a3dbc-de58-47ab-a67b-c4492182e259"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6343), "احمدآبادصولت", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("d33f10bd-f80b-480a-9365-3ea7b9a4fd2b"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8245), "شیرود", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("d365b80b-9865-4a29-8c83-33448791cc11"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7405), "دستجرد", new Guid("d6106951-3204-f3ab-6ec8-6e9c5efb825e") },
                    { new Guid("d431294c-124d-45fe-a77a-0fc827baeb83"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7038), "نیک شهر", new Guid("b84f97cd-d4ec-2d65-63d7-3aeb35a3c9e8") },
                    { new Guid("d4862b08-0b4e-4730-aa5f-80aacbea53d0"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6754), "مشراگه", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("d49d565a-e22e-46dd-8aa9-176d612f111f"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7977), "رحیم آباد", new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89") },
                    { new Guid("d56c38cb-1ce2-48e7-9a56-3611e8d2cb4b"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7409), "سلفچگان", new Guid("d6106951-3204-f3ab-6ec8-6e9c5efb825e") },
                    { new Guid("d598045d-5e76-44c6-b6d8-1f82a13c3c52"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7571), "دوساری", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("d5c8d942-7337-4e6c-b3a8-fc3d4b8be43b"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7402), "جعفریه", new Guid("d6106951-3204-f3ab-6ec8-6e9c5efb825e") },
                    { new Guid("d5d3bbfa-13a5-4116-919d-ec78f72b40c4"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6658), "حسینیه", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("d604f33f-6e48-43b9-9bd9-ba324b0c2afa"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6809), "دندی", new Guid("e4f80638-3050-9434-78bd-358733300127") },
                    { new Guid("d61bb889-dec9-40da-b4a7-2b65f021c955"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5889), "شوط", new Guid("3757e8ea-143b-52ce-0d66-c474d3849f2f") },
                    { new Guid("d677eb38-80a2-4c4e-9f91-6a8a98084247"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7454), "دهگلان", new Guid("a56b5e1e-dc63-8684-bf85-c3b187949d66") },
                    { new Guid("d6be2ad2-67f4-4df9-ab4c-0a2fb1f26594"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6739), "قلعه تل", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("d6d68ea1-b0c3-4b74-bbe8-00c03e89cd2e"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7263), "لامرد", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("d724f93f-1a2a-4d7e-aba0-12e339948ac5"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5988), "بوشهر", new Guid("a4211e9c-ea7b-a182-d1c8-7c6aa71befaf") },
                    { new Guid("d7409add-b2f6-49f4-91fc-74e16ce0c231"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7808), "قلعه رئیسی", new Guid("1c6f8c6a-4ee4-da52-7d12-360a189bd735") },
                    { new Guid("d74b32f2-0c0e-42a6-83d2-0b868cd96d28"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6797), "ارمغانخانه", new Guid("e4f80638-3050-9434-78bd-358733300127") },
                    { new Guid("d78582e3-a9e4-4ca3-9b5e-2608a9329f12"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6019), "شنبه", new Guid("a4211e9c-ea7b-a182-d1c8-7c6aa71befaf") },
                    { new Guid("d8ea37b5-2a4a-43b8-9e7c-3f0082007929"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5462), "نطنز", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("d8fcaf9e-0b75-4878-bdf6-cf6c09bdb0db"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8381), "غرق آباد", new Guid("dd60a9d0-60cf-c6d3-b4a4-e1e09f7989b0") },
                    { new Guid("d94416fc-49de-495b-be59-8f12b1d9a1cf"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8097), "چغلوندی", new Guid("64f76e56-c5a6-b275-2871-a3b26437139e") },
                    { new Guid("d95f354f-1d88-4490-94f4-fc7ceec900e9"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8482), "سوزا", new Guid("2db6cdf4-e7e4-2953-2b24-514ef08ae35c") },
                    { new Guid("d9d59142-a823-4cd9-841b-2d357e6d5ae8"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5867), "دیزج دیز", new Guid("3757e8ea-143b-52ce-0d66-c474d3849f2f") },
                    { new Guid("d9da6f72-2b6a-4a38-91df-7adabd0594d1"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5530), "اشتهارد", new Guid("71d4f39f-c32f-780a-4215-6c4ee11cc61e") },
                    { new Guid("da065c2b-cc0b-409f-8849-7a781d41bcc4"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7741), "قصرشیرین", new Guid("82ad2f1a-eb42-c56b-8834-78d95d49e1ba") },
                    { new Guid("da12e3a4-965a-4f69-9487-592d88fa3a3d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6932), "بنجار", new Guid("b84f97cd-d4ec-2d65-63d7-3aeb35a3c9e8") },
                    { new Guid("da2eebf3-c640-4857-88c8-d38d3577c647"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5763), "کلوانق", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("da49104a-69bb-47b4-a757-c20674642cfb"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5551), "کمال شهر", new Guid("71d4f39f-c32f-780a-4215-6c4ee11cc61e") },
                    { new Guid("da622c85-12c2-4131-ae3e-f30220fab5ce"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8403), "نوبران", new Guid("dd60a9d0-60cf-c6d3-b4a4-e1e09f7989b0") },
                    { new Guid("da749323-ea5d-4d94-83b8-fa6cae5c23dd"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5317), "خورزوق", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("da9fd466-f110-4031-a19a-50862eb4545b"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8091), "پلدختر", new Guid("64f76e56-c5a6-b275-2871-a3b26437139e") },
                    { new Guid("daa87406-5a70-4b60-9d64-f2b051c177bd"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6378), "چاپشلو", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("dae26d50-9b01-43f8-93ca-30fd2242cb3e"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8582), "گیان", new Guid("5a38d1f0-760a-c889-5d99-00030afbd6ce") },
                    { new Guid("db161624-adf4-4be9-888a-34ebeeaeb4d8"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7595), "زنگی آباد", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("db480235-e4c9-4938-9694-9fc48815ecba"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8401), "نراق", new Guid("dd60a9d0-60cf-c6d3-b4a4-e1e09f7989b0") },
                    { new Guid("dbd0aef2-06be-4352-b023-876035c7ad6d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8129), "گراب", new Guid("64f76e56-c5a6-b275-2871-a3b26437139e") },
                    { new Guid("dbd0e513-b359-478b-b921-6c53ae58af4a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6358), "بجستان", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("dc4c18e0-0baf-4282-82fe-733e5a4024c2"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6869), "درجزین", new Guid("ae50e237-9bf3-fb82-b997-1ae7b059875a") },
                    { new Guid("dc837ccc-4289-4f45-9202-3121ddc80ad8"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5586), "ارکواز", new Guid("2acf226d-ed63-0c67-9744-591e072a0227") },
                    { new Guid("dc9771a6-5629-4adb-84d4-fcd6c4f429ec"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5280), "تودشک", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("dcc28856-ee49-43ac-b28f-5a637514293f"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8451), "پارسیان", new Guid("2db6cdf4-e7e4-2953-2b24-514ef08ae35c") },
                    { new Guid("dcc432f4-3685-4345-8b43-25757e293bda"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5411), "کمشچه", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("dd697c8d-b958-4b40-b0c0-108ce18c994b"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5248), "انارک", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("dd7008a2-7ea5-422a-9cb6-139d227684bc"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6639), "ترکالکی", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("dd712967-f461-4d51-8c8f-457797b31966"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7630), "کوهبنان", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("dd78bf2f-0627-4d54-b3ba-442890f324b0"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7987), "رودبار", new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89") },
                    { new Guid("dd7a0ba3-61d7-424a-b72a-77a15b608925"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7098), "بالاده", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("dd7a92e1-ef18-4d45-aa20-66b97b67ed67"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8243), "شیرگاه", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("dd9a7e60-893e-4711-aa8d-85dc0ce7186c"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5246), "افوس", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("ddc1fdac-7e50-4a13-904e-34e036668e13"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6103), "شریف آباد", new Guid("1c25d366-2d0a-3327-d464-b8ed3c2c3d73") },
                    { new Guid("ddcd1768-1afe-4e0d-859c-3701ec4dbbf7"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6885), "شاهرود", new Guid("ae50e237-9bf3-fb82-b997-1ae7b059875a") },
                    { new Guid("ddfdf724-f652-44b2-96e2-755eb0aca395"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5266), "بافران", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("de293159-741a-47cb-809c-12458779daf3"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7151), "خومه زار", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("de5e8d25-8c21-4620-a0df-9a843770b32a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5830), "ایواوغلی", new Guid("3757e8ea-143b-52ce-0d66-c474d3849f2f") },
                    { new Guid("de8732c7-f94e-4589-97ef-b000be31f90f"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8572), "قروه در جزین", new Guid("5a38d1f0-760a-c889-5d99-00030afbd6ce") },
                    { new Guid("df260640-d721-4816-9951-988ae7c35338"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7341), "آوج", new Guid("f27b547f-a3c0-29ff-19c5-0d8c899abc3d") },
                    { new Guid("df862a5d-9f20-4925-9893-289b10960cc6"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5457), "نجف آباد", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("df90c593-b608-40f2-9206-3b093f0b3f32"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6726), "شیبان", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("e04ee1ce-ca87-4812-b353-96d4cd3e032b"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5685), "بناب", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("e0aee54c-1c66-4f6e-8346-dd153ef7e178"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5325), "درچه پیاز", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("e0c762f0-65e0-4eef-8098-27a9518e60ef"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7888), "گالیکش", new Guid("109a51f1-9b4b-f42c-475d-6709b525de9e") },
                    { new Guid("e0c92997-2c6e-4b4f-92f9-e97e76b90092"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5606), "چوار", new Guid("2acf226d-ed63-0c67-9744-591e072a0227") },
                    { new Guid("e0e2ff70-8f8b-496b-a7fc-4a314b5ec9f7"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7975), "رانکوه", new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89") },
                    { new Guid("e0e5e97a-3357-4bb8-a5b2-65547caabad1"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6191), "جونقان", new Guid("41c307e8-f2bf-6b3b-244a-cc9215eb4046") },
                    { new Guid("e0fb1625-8270-48ee-8e39-dae87ae664c8"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6664), "حمیدیه", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("e1a8ff82-d3b5-4e88-bafd-40090b8e6928"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7169), "دهرم", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("e1b8a1f6-f051-48b6-95fb-ec96a550e62c"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7721), "روانسر", new Guid("82ad2f1a-eb42-c56b-8834-78d95d49e1ba") },
                    { new Guid("e1d32c5c-3bc6-4807-a93f-0b7468565f74"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7602), "سیرجان", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("e1dd0d7e-9f4e-4bac-bb5a-b20a131906b4"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7015), "گشت", new Guid("b84f97cd-d4ec-2d65-63d7-3aeb35a3c9e8") },
                    { new Guid("e1e9a7be-d930-4592-852e-c92890eb3119"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8044), "لوندویل", new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89") },
                    { new Guid("e22435d7-71d1-4b71-9336-375eb385313d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6462), "قاسم آباد", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("e2d5d66a-9579-4594-bfc8-6aa923bf78c0"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7278), "مبارک آباد", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("e2f94779-e408-4f89-84ff-2122463b1199"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6217), "فرادنبه", new Guid("41c307e8-f2bf-6b3b-244a-cc9215eb4046") },
                    { new Guid("e30e27b7-67a5-4ae6-9fc8-1968c9d9bbac"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8360), "دلیجان", new Guid("dd60a9d0-60cf-c6d3-b4a4-e1e09f7989b0") },
                    { new Guid("e332e78f-bea5-467d-b9c0-1195c38b389e"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8177), "بهشهر", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("e429604b-98b9-43f7-ae67-8999f8586d61"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6548), "اسفراین", new Guid("77881601-9f29-c4a9-8076-92a9b3c61aff") },
                    { new Guid("e42a15ae-21c9-45e5-82c9-78424bfcb9a5"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6945), "دوست محمد", new Guid("b84f97cd-d4ec-2d65-63d7-3aeb35a3c9e8") },
                    { new Guid("e434581c-10a3-4217-b483-697c52e7ceb0"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5596), "آسمان آباد", new Guid("2acf226d-ed63-0c67-9744-591e072a0227") },
                    { new Guid("e44638e1-1923-47bb-a9f4-70da0f503f2f"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5286), "جندق", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("e46708e9-bafc-406c-b4ed-59649fb841fb"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6898), "مهدی شهر", new Guid("ae50e237-9bf3-fb82-b997-1ae7b059875a") },
                    { new Guid("e47659c6-a817-424d-852e-17b0b607d54c"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7155), "داریان", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("e4c37066-21c4-4a68-8acf-e8bd37ceeef7"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5970), "بردستان", new Guid("a4211e9c-ea7b-a182-d1c8-7c6aa71befaf") },
                    { new Guid("e4e00038-2b99-4225-80cc-00f78b5bfa3a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6558), "پیش قلعه", new Guid("77881601-9f29-c4a9-8076-92a9b3c61aff") },
                    { new Guid("e549e66a-a347-46ae-be85-25bb29f06070"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7824), "یاسوج", new Guid("1c6f8c6a-4ee4-da52-7d12-360a189bd735") },
                    { new Guid("e5a5a808-ca6c-4b73-8347-4eb9f1f7659e"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8081), "اشترینان", new Guid("64f76e56-c5a6-b275-2871-a3b26437139e") },
                    { new Guid("e5ba715b-d58a-4d1d-b909-79d15fd92952"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6591), "لوجلی", new Guid("77881601-9f29-c4a9-8076-92a9b3c61aff") },
                    { new Guid("e5e369ec-d1bd-4aaa-95bd-059911cf81b5"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6391), "خواف", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("e638b7d1-1e3f-4d5d-9878-fa832be5e928"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5418), "کوهپایه", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("e66dd374-a223-42a4-a01c-3bdd3b8da075"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6900), "میامی", new Guid("ae50e237-9bf3-fb82-b997-1ae7b059875a") },
                    { new Guid("e6e2926c-03e2-4005-ba50-3d835181641e"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8666), "مهریز", new Guid("66a07236-f93a-4cb5-0ad6-e0416ba72886") },
                    { new Guid("e6e84291-2689-4c1b-b838-49897e3eb76d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5277), "بهارستان", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("e70d85d1-64ae-4483-af66-98ea9ec5a904"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5808), "یامچی", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("e713481f-87ac-4298-b247-21d026ef5a87"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7719), "رباط", new Guid("82ad2f1a-eb42-c56b-8834-78d95d49e1ba") },
                    { new Guid("e715afd3-39dd-440b-8295-9beb11b4321d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8209), "رامسر", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("e72413f9-8891-4fbd-aa50-e7d84a30aa9a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8555), "سامن", new Guid("5a38d1f0-760a-c889-5d99-00030afbd6ce") },
                    { new Guid("e76003f7-f537-45a6-a340-0a4c95b6363a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7500), "یاسوکند", new Guid("a56b5e1e-dc63-8684-bf85-c3b187949d66") },
                    { new Guid("e7a213f0-a59a-483a-9e8a-f5f15918a699"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6678), "رامشیر", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("e7e1f89f-1062-4c78-a425-db33acaf8b6c"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6524), "نیشابور", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("e80eb917-ce61-498b-9bde-0f2d17c208ce"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6000), "خورموج", new Guid("a4211e9c-ea7b-a182-d1c8-7c6aa71befaf") },
                    { new Guid("e8306e39-10c2-40ba-9be4-42265d927f6e"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7073), "افزر", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("e8559a70-294c-4832-8bac-df089a592ef4"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7683), "یزدان شهر", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("e871d3ad-af7e-4189-a11a-06f877fdfc01"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5885), "سیه چشمه", new Guid("3757e8ea-143b-52ce-0d66-c474d3849f2f") },
                    { new Guid("e885a61c-64de-4aa2-a9c3-5cae1cac328e"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6233), "ناغان", new Guid("41c307e8-f2bf-6b3b-244a-cc9215eb4046") },
                    { new Guid("e8a6ff17-91b6-405a-951c-dc43c7c46a34"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5386), "علویچه", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("e8c95d96-bbd5-4b2d-90ca-46b87b9263eb"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8050), "ماسال", new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89") },
                    { new Guid("e8cf601a-bbd2-40f0-bffb-3f515e884814"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8019), "کیاشهر", new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89") },
                    { new Guid("e8dbdfff-500a-401f-8873-0cd8ebbe4725"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6476), "کاریز", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("e9a17ecf-7fe7-4206-9ef4-fba4b8c8c633"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6421), "سفیدسنگ", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("e9a67e72-09d4-4a45-a69b-b4d68e5e6a78"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7484), "قروه", new Guid("a56b5e1e-dc63-8684-bf85-c3b187949d66") },
                    { new Guid("e9f73214-2547-46a7-b58b-dc8fb1956412"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7220), "فسا", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("ea0fb533-49ac-45b0-a1e9-592d9e9165a2"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7791), "چرام", new Guid("1c6f8c6a-4ee4-da52-7d12-360a189bd735") },
                    { new Guid("eaac1ff4-0b1e-46a4-8945-2e8806385bea"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6448), "طرقبه", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("eaac292f-21ea-48bd-bf19-55d0460921f5"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6023), "کاکی", new Guid("a4211e9c-ea7b-a182-d1c8-7c6aa71befaf") },
                    { new Guid("eadb118d-e805-445e-92d2-94aa9bbb5036"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6199), "سفیددشت", new Guid("41c307e8-f2bf-6b3b-244a-cc9215eb4046") },
                    { new Guid("eaed4151-5033-4c75-b888-3df2b01ff666"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6068), "پاکدشت", new Guid("1c25d366-2d0a-3327-d464-b8ed3c2c3d73") },
                    { new Guid("eb95f168-014f-4fd3-bec8-ee13530cfe5e"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8530), "اسدآباد", new Guid("5a38d1f0-760a-c889-5d99-00030afbd6ce") },
                    { new Guid("ebbdab63-53a0-4586-8c74-425d49930e02"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6585), "قاضی", new Guid("77881601-9f29-c4a9-8076-92a9b3c61aff") },
                    { new Guid("ec163287-1952-49c6-a63a-2a2f05b916d7"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7346), "بیدستان", new Guid("f27b547f-a3c0-29ff-19c5-0d8c899abc3d") },
                    { new Guid("ec484102-9fb2-48fe-ae5b-0f7969f2a51a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6888), "شهمیرزاد", new Guid("ae50e237-9bf3-fb82-b997-1ae7b059875a") },
                    { new Guid("ec9a5a02-f478-4ab2-abfd-d1dc3c644ead"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7973), "دیلمان", new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89") },
                    { new Guid("ecaccf52-5f3d-492f-b4d3-6c614a7b00ab"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7434), "بابارشانی", new Guid("a56b5e1e-dc63-8684-bf85-c3b187949d66") },
                    { new Guid("ecdf4a3d-2c91-4e6d-b9f2-accb64b9d587"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5615), "دهلران", new Guid("2acf226d-ed63-0c67-9744-591e072a0227") },
                    { new Guid("ecfcd50a-37e7-40f6-b283-6a82ab65d4c8"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6801), "چورزق", new Guid("e4f80638-3050-9434-78bd-358733300127") },
                    { new Guid("ecfe5a46-bb4a-4688-86dd-9d54da3726b6"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6734), "صفی آباد", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("ed606510-3443-41cf-bee2-2f2aa3c16976"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8379), "شهرجدیدمهاجران", new Guid("dd60a9d0-60cf-c6d3-b4a4-e1e09f7989b0") },
                    { new Guid("eda6ac47-9b7e-400e-9e0e-c1cf43064374"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5920), "میرآباد", new Guid("3757e8ea-143b-52ce-0d66-c474d3849f2f") },
                    { new Guid("eda96a7e-3a15-45fa-bc99-d46029945fd2"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7636), "کیانشهر", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("edf35937-a174-41bc-b99e-dbb17caea880"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8540), "جورقان", new Guid("5a38d1f0-760a-c889-5d99-00030afbd6ce") },
                    { new Guid("ee239016-38d4-4066-8066-080300719394"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6306), "قهستان", new Guid("1d436afc-ef42-1885-c6af-b02635b0e0d9") },
                    { new Guid("ee7878d9-2cc3-4f7e-8f4b-d459a7659096"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7847), "انبارآلوم", new Guid("109a51f1-9b4b-f42c-475d-6709b525de9e") },
                    { new Guid("eee233cd-51e0-41ed-a048-df81b08164a7"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8490), "فین", new Guid("2db6cdf4-e7e4-2953-2b24-514ef08ae35c") },
                    { new Guid("ef4f2dbc-1a98-48d9-bcf8-806f42617447"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6531), "یونسی", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("f00252c4-258d-4cc3-85d6-c472faa0d70f"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8645), "دیهوک", new Guid("66a07236-f93a-4cb5-0ad6-e0416ba72886") },
                    { new Guid("f0067f05-7951-4f5a-b7fc-1778990b0b5c"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7880), "فاضل آباد", new Guid("109a51f1-9b4b-f42c-475d-6709b525de9e") },
                    { new Guid("f04f6c5f-5537-4dde-bf07-fca4dbd36bad"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5805), "هوراند", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("f0a28f06-e218-40dc-bc17-969874bd4ed1"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6581), "صفی آباد", new Guid("77881601-9f29-c4a9-8076-92a9b3c61aff") },
                    { new Guid("f1178022-8f51-4825-a2e9-a7bdff495122"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7496), "موچش", new Guid("a56b5e1e-dc63-8684-bf85-c3b187949d66") },
                    { new Guid("f18cccce-8457-4e5a-a2fe-cb9ca5e5b0dd"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8207), "دابودشت", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("f1a5c459-929e-4fc9-82dc-4eb8790aa6ad"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6723), "شوشتر", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("f1d19ca9-d4fd-4359-a4ce-0f0577fd8584"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8029), "گوراب زرمیخ", new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89") },
                    { new Guid("f201cb15-c158-4828-83f4-60be3096005d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(4735), "هیر", new Guid("9335ae23-0144-99e7-2a2f-c733db6c3cb9") },
                    { new Guid("f246634c-4f7e-4c7d-9d0f-e65698e5c3fb"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6772), "هفتگل", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("f251fd2d-fea4-4b28-be84-5581d0c6be4a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5706), "خاروانا", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("f2712494-43dc-454b-9e74-2c74fbb21b73"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8324), "پرندک", new Guid("dd60a9d0-60cf-c6d3-b4a4-e1e09f7989b0") },
                    { new Guid("f2785cec-1899-4653-afae-9e7454b7c955"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5755), "عجب شیر", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("f2843967-38dc-41d3-8b89-dc7266bca1e6"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7113), "بهمن", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("f2ad13e0-20b3-49b9-8570-9c9a33cf942a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5540), "سیف آباد", new Guid("71d4f39f-c32f-780a-4215-6c4ee11cc61e") },
                    { new Guid("f2dc2eeb-0a6f-43a3-aa61-657d9bb329b3"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8449), "بیکاه", new Guid("2db6cdf4-e7e4-2953-2b24-514ef08ae35c") },
                    { new Guid("f2e6c874-0ac4-4ec2-a3fe-0b6acff94ab7"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7230), "قطب آباد", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("f2eb73a4-7abd-41de-80db-12084e5678e4"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5375), "شاپورآباد", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("f2f7fd58-6c74-46ad-a37a-78626af10989"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5244), "اصفهان", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("f43fa2d6-80a1-4b66-ab71-39be1152addc"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6552), "آشخانه", new Guid("77881601-9f29-c4a9-8076-92a9b3c61aff") },
                    { new Guid("f48ebf9a-a4ad-48be-b5ad-3725dcd0b9be"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7655), "محمد آباد", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("f4a9d71d-ad8c-4599-91da-d4972006d78e"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5637), "میمه", new Guid("2acf226d-ed63-0c67-9744-591e072a0227") },
                    { new Guid("f4bcbf49-2af7-4a27-a0e9-242ffb0a30f4"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8639), "تفت", new Guid("66a07236-f93a-4cb5-0ad6-e0416ba72886") },
                    { new Guid("f4c32c0f-6f0d-4f01-b40f-638781a89732"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5681), "بخشایش", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("f4cd5c01-0800-42c2-a42c-3f2f80c8346a"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7436), "بانه", new Guid("a56b5e1e-dc63-8684-bf85-c3b187949d66") },
                    { new Guid("f4f9f93d-00fe-4732-b2a7-e5320a6e7e54"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7180), "زرقان", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("f5759ce4-14b7-4a92-9d4f-4861df53ebfb"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6837), "هیدج", new Guid("e4f80638-3050-9434-78bd-358733300127") },
                    { new Guid("f5ec1ef4-a074-42a5-b9bb-bede93aa24d4"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7559), "چترود", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("f677d2c0-830d-4a18-b9a3-a946ff3dbede"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5381), "شهرضا", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("f6d0b45f-c7e2-4f53-b026-4cf2910cccc1"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5293), "چادگان", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("f70717ef-2410-4dc9-90b9-55f4502bc361"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(4662), "پارس آباد", new Guid("9335ae23-0144-99e7-2a2f-c733db6c3cb9") },
                    { new Guid("f74797f6-fcad-47a6-b195-ed5494e94231"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8234), "سرخرود", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("f7df2c66-5467-48cb-8720-de9cfab339ab"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6650), "چمران", new Guid("867b7a93-1af2-9cb8-bd2d-b1e2e03b8cb8") },
                    { new Guid("f80a7899-56b9-4783-b521-b7a2d8c2d9f6"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8352), "خمین", new Guid("dd60a9d0-60cf-c6d3-b4a4-e1e09f7989b0") },
                    { new Guid("f8c5e499-6e85-4ce2-b9de-3b597f04b947"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7795), "دوگنبدان", new Guid("1c6f8c6a-4ee4-da52-7d12-360a189bd735") },
                    { new Guid("f9483d85-e593-4f0a-ac23-3109183b168b"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7994), "رودسر", new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89") },
                    { new Guid("f959529d-d071-4c73-bdcd-793790ecc304"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6066), "بومهن", new Guid("1c25d366-2d0a-3327-d464-b8ed3c2c3d73") },
                    { new Guid("f96c1b8a-2c49-4227-9e71-a67122e03555"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7474), "سقز", new Guid("a56b5e1e-dc63-8684-bf85-c3b187949d66") },
                    { new Guid("f970a908-e862-4bef-8887-e53a995356d1"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7381), "محمودآبادنمونه", new Guid("f27b547f-a3c0-29ff-19c5-0d8c899abc3d") },
                    { new Guid("f97ef74b-dfee-43f6-86f9-9ae30aab83c6"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7544), "بهرمان", new Guid("3f984b02-77d5-9338-533c-3be530b980ba") },
                    { new Guid("f98ad9d3-b7ff-46bd-a648-537959d368de"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5544), "شهرجدیدهشتگرد", new Guid("71d4f39f-c32f-780a-4215-6c4ee11cc61e") },
                    { new Guid("f9f41d2d-403f-4e82-a549-dc7779dc73de"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5252), "ایمانشهر", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("f9fef5f1-add2-40d0-afa4-af96e08157d1"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7482), "صاحب", new Guid("a56b5e1e-dc63-8684-bf85-c3b187949d66") },
                    { new Guid("f9ff02e0-74fc-4da3-9e90-6a4ef1d6ba00"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8300), "نوشهر", new Guid("8c34ec27-905c-8f3b-40d9-485f33a0b410") },
                    { new Guid("fa05fafd-3e6f-4331-8c33-e25098ede938"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7355), "خرمدشت", new Guid("f27b547f-a3c0-29ff-19c5-0d8c899abc3d") },
                    { new Guid("fa2175cd-e657-4f44-a510-a3843350841e"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8393), "مأمونیه", new Guid("dd60a9d0-60cf-c6d3-b4a4-e1e09f7989b0") },
                    { new Guid("fa24f752-f27e-452e-9ae3-61be1e60cc40"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6579), "شیروان", new Guid("77881601-9f29-c4a9-8076-92a9b3c61aff") },
                    { new Guid("fa920d7d-c53d-4caa-99a1-8a76873b63c7"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5627), "لومار", new Guid("2acf226d-ed63-0c67-9744-591e072a0227") },
                    { new Guid("fb04fb05-bd55-4023-8146-60de8dfc48ff"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8057), "منجیل", new Guid("ee12a0a9-55b1-7619-526e-c96b70465d89") },
                    { new Guid("fb183b89-81fc-48e3-84a1-50ecbe9e04aa"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7253), "کوهنجان", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("fb495af1-da38-4adb-ae3c-7ec47206aaf0"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7174), "رونیز", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("fb6fe6cc-5722-46f4-882f-9ec09b080aab"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7866), "خان ببین", new Guid("109a51f1-9b4b-f42c-475d-6709b525de9e") },
                    { new Guid("fbb696c2-b646-404a-b971-03c5f85864e6"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7716), "حمیل", new Guid("82ad2f1a-eb42-c56b-8834-78d95d49e1ba") },
                    { new Guid("fbcdaf2c-17cd-4a76-ad46-1933815d5311"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6417), "سبزوار", new Guid("32195305-f35a-4ab9-6ae2-88ba595b7a6b") },
                    { new Guid("fc65ec5b-7e06-42fb-89fd-b9035d2530ee"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5594), "آبدانان", new Guid("2acf226d-ed63-0c67-9744-591e072a0227") },
                    { new Guid("fc730441-d1a9-4c1c-94d3-c6fab2c8e624"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5895), "قره ضیاءالدین", new Guid("3757e8ea-143b-52ce-0d66-c474d3849f2f") },
                    { new Guid("fc7596ca-db35-4e50-b080-f02bf5f90ebb"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5656), "اسکو", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("fce9df80-7296-4fa0-b947-8221589f1810"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(8504), "گوهران", new Guid("2db6cdf4-e7e4-2953-2b24-514ef08ae35c") },
                    { new Guid("fd359ac7-5a99-452e-a767-fbcc5145c67d"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(6221), "کیان", new Guid("41c307e8-f2bf-6b3b-244a-cc9215eb4046") },
                    { new Guid("fd49406e-1e35-4a8b-b0ec-dc87eb91e860"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7196), "شهر جدید صدرا", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("fdfe8c1f-530a-4877-b0e6-7f5fd6935f93"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7192), "سیدان", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("fe1ab617-1ea3-411a-8965-07e13b8e0e36"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5696), "ترکمانچای", new Guid("b13531cc-133a-6732-5a1d-0c77476b8b10") },
                    { new Guid("fe2be7ef-81cc-4791-9631-dc6c91137d5f"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7235), "قیر", new Guid("e46f0c16-307e-0a05-caca-d8f87057ff8d") },
                    { new Guid("fe4db984-1ebb-4148-ae34-417d4eedc725"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(4718), "گیوی", new Guid("9335ae23-0144-99e7-2a2f-c733db6c3cb9") },
                    { new Guid("fe4e7ebd-47fb-4d93-a05c-aeeac0508189"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(5422), "گرگاب", new Guid("64d234e7-5952-b881-3cf5-33a4c9965544") },
                    { new Guid("fe8b2624-3241-4a2b-a626-35e0404e7662"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7759), "میان راهان", new Guid("82ad2f1a-eb42-c56b-8834-78d95d49e1ba") },
                    { new Guid("ff342b34-071a-4664-8ca8-b11e89012ffc"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(7438), "بلبان آباد", new Guid("a56b5e1e-dc63-8684-bf85-c3b187949d66") },
                    { new Guid("ff78add1-1121-4a07-9e9a-d94aabf8b8d4"), new DateTime(2025, 7, 9, 10, 23, 25, 354, DateTimeKind.Utc).AddTicks(4677), "خلخال", new Guid("9335ae23-0144-99e7-2a2f-c733db6c3cb9") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FirstName",
                table: "AspNetUsers",
                column: "FirstName");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LastName",
                table: "AspNetUsers",
                column: "LastName");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_NationalCode",
                table: "AspNetUsers",
                column: "NationalCode");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserName",
                table: "AspNetUsers",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AuditableEntityBase_CreatedAt",
                table: "AuditableEntityBase",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_AuditableEntityBase_LastModifiedAt",
                table: "AuditableEntityBase",
                column: "LastModifiedAt");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CreatedAt",
                table: "CartItems",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_LastModifiedAt",
                table: "CartItems",
                column: "LastModifiedAt");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_CreatedAt",
                table: "Carts",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_LastModifiedAt",
                table: "Carts",
                column: "LastModifiedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CreatedAt",
                table: "Categories",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_LastModifiedAt",
                table: "Categories",
                column: "LastModifiedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CreatedAt",
                table: "Cities",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_LastModifiedAt",
                table: "Cities",
                column: "LastModifiedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Name",
                table: "Cities",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_ProvinceId",
                table: "Cities",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_CreatedAt",
                table: "OrderItems",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_LastModifiedAt",
                table: "OrderItems",
                column: "LastModifiedAt");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_Status",
                table: "OrderItems",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_VendorId",
                table: "OrderItems",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CreatedAt",
                table: "Orders",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_LastModifiedAt",
                table: "Orders",
                column: "LastModifiedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShipmentDepartmentId",
                table: "Orders",
                column: "ShipmentDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Status",
                table: "Orders",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CreatedAt",
                table: "Payments",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_LastModifiedAt",
                table: "Payments",
                column: "LastModifiedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UserId",
                table: "Payments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CreatedAt",
                table: "Products",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Products_LastModifiedAt",
                table: "Products",
                column: "LastModifiedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Price",
                table: "Products",
                column: "Price");

            migrationBuilder.CreateIndex(
                name: "IX_Products_VendorId",
                table: "Products",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_CreatedAt",
                table: "Provinces",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_LastModifiedAt",
                table: "Provinces",
                column: "LastModifiedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_Name",
                table: "Provinces",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_CreatedAt",
                table: "Questions",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_LastModifiedAt",
                table: "Questions",
                column: "LastModifiedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ProductId",
                table: "Questions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_UserId",
                table: "Questions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_CreatedAt",
                table: "Reviews",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_LastModifiedAt",
                table: "Reviews",
                column: "LastModifiedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentDepartments_CreatedAt",
                table: "ShipmentDepartments",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentDepartments_LastModifiedAt",
                table: "ShipmentDepartments",
                column: "LastModifiedAt");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentDepartments_UserId",
                table: "ShipmentDepartments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresses_CityId",
                table: "UserAddresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresses_CreatedAt",
                table: "UserAddresses",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresses_LastModifiedAt",
                table: "UserAddresses",
                column: "LastModifiedAt");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresses_Street",
                table: "UserAddresses",
                column: "Street");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresses_UserId",
                table: "UserAddresses",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_CreatedAt",
                table: "Vendors",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_LastModifiedAt",
                table: "Vendors",
                column: "LastModifiedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_Name",
                table: "Vendors",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_UserId",
                table: "Vendors",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AuditableEntityBase");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "UserAddresses");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "ShipmentDepartments");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Vendors");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
