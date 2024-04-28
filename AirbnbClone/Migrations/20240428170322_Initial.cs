using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirbnbClone.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Host",
                columns: table => new
                {
                    host_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullname = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    pictureUrl = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    createAt = table.Column<long>(type: "bigint", nullable: true),
                    isSuperhost = table.Column<bool>(type: "bit", nullable: true),
                    policyNumber = table.Column<int>(type: "int", nullable: true),
                    responseTime = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    location = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    about = table.Column<string>(type: "varchar(2000)", unicode: false, maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Host__A397C7AEE232B358", x => x.host_id);
                });

            migrationBuilder.CreateTable(
                name: "ListingUser",
                columns: table => new
                {
                    ListingId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListingUser", x => new { x.ListingId, x.UserId });
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    location_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    country = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    countryCode = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    city = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    address = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    lat = table.Column<decimal>(type: "decimal(9,6)", nullable: true),
                    lan = table.Column<decimal>(type: "decimal(9,6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Location__771831EAB1B20E67", x => x.location_id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    _id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyerId = table.Column<int>(type: "int", nullable: true),
                    BuyerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GuestAdult = table.Column<int>(type: "int", nullable: true),
                    Guestchildren = table.Column<int>(type: "int", nullable: true),
                    Guestinfant = table.Column<int>(type: "int", nullable: true),
                    Guestpets = table.Column<int>(type: "int", nullable: true),
                    StayId = table.Column<int>(type: "int", nullable: true),
                    StayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    HostId = table.Column<int>(type: "int", nullable: true),
                    HostName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x._id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    fullname = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    imgUrl = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    userMsg = table.Column<int>(type: "int", nullable: true),
                    hostMsg = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__3213E83FC7291D1E", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Listing",
                columns: table => new
                {
                    listing_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    summary = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    capacity = table.Column<int>(type: "int", nullable: true),
                    roomType = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    bathrooms = table.Column<int>(type: "int", nullable: true),
                    bedrooms = table.Column<int>(type: "int", nullable: true),
                    host_id = table.Column<int>(type: "int", nullable: true),
                    location_id = table.Column<int>(type: "int", nullable: true),
                    statCleanliness = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    statCommunication = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    statCheckIn = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    statAccuracy = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    statLocation = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    statValue = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    likedbyusers = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Listing__89D817742A5ED1B7", x => x.listing_id);
                    table.ForeignKey(
                        name: "FK__Listing__host_id__44FF419A",
                        column: x => x.host_id,
                        principalTable: "Host",
                        principalColumn: "host_id");
                    table.ForeignKey(
                        name: "FK__Listing__locatio__45F365D3",
                        column: x => x.location_id,
                        principalTable: "Location",
                        principalColumn: "location_id");
                });

            migrationBuilder.CreateTable(
                name: "ListingAmenities",
                columns: table => new
                {
                    listing_id = table.Column<int>(type: "int", nullable: false),
                    amenity = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ListingA__F2B0D0F1CF9269A4", x => new { x.listing_id, x.amenity });
                    table.ForeignKey(
                        name: "FK__ListingAm__listi__534D60F1",
                        column: x => x.listing_id,
                        principalTable: "Listing",
                        principalColumn: "listing_id");
                });

            migrationBuilder.CreateTable(
                name: "ListingFilter",
                columns: table => new
                {
                    listing_id = table.Column<int>(type: "int", nullable: false),
                    likeByUser = table.Column<int>(type: "int", nullable: true),
                    place = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    label = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    host_id = table.Column<int>(type: "int", nullable: true),
                    isPetAllowed = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ListingF__89D81774CF6A2297", x => x.listing_id);
                    table.ForeignKey(
                        name: "FK__ListingFi__host___49C3F6B7",
                        column: x => x.host_id,
                        principalTable: "Host",
                        principalColumn: "host_id");
                    table.ForeignKey(
                        name: "FK__ListingFi__listi__48CFD27E",
                        column: x => x.listing_id,
                        principalTable: "Listing",
                        principalColumn: "listing_id");
                });

            migrationBuilder.CreateTable(
                name: "ListingImgUrls",
                columns: table => new
                {
                    listing_id = table.Column<int>(type: "int", nullable: false),
                    imgUrl = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ListingI__AF217F5416DBF50A", x => new { x.listing_id, x.imgUrl });
                    table.ForeignKey(
                        name: "FK__ListingIm__listi__5070F446",
                        column: x => x.listing_id,
                        principalTable: "Listing",
                        principalColumn: "listing_id");
                });

            migrationBuilder.CreateTable(
                name: "ListingLabels",
                columns: table => new
                {
                    listing_id = table.Column<int>(type: "int", nullable: false),
                    label = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ListingL__AD5A28AFBE899D07", x => new { x.listing_id, x.label });
                    table.ForeignKey(
                        name: "FK__ListingLa__listi__5629CD9C",
                        column: x => x.listing_id,
                        principalTable: "Listing",
                        principalColumn: "listing_id");
                });

            migrationBuilder.CreateTable(
                name: "ListingLikedByUsers",
                columns: table => new
                {
                    listing_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ListingL__6243F404862A6FE6", x => new { x.listing_id, x.user_id });
                    table.ForeignKey(
                        name: "FK__ListingLi__listi__59063A47",
                        column: x => x.listing_id,
                        principalTable: "Listing",
                        principalColumn: "listing_id");
                    table.ForeignKey(
                        name: "FK__ListingLi__user___59FA5E80",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    review_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    listing_id = table.Column<int>(type: "int", nullable: true),
                    at = table.Column<long>(type: "bigint", nullable: true),
                    txt = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    reviewer_id = table.Column<int>(type: "int", nullable: true),
                    reviewerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rimgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Review__60883D90C73E7D5E", x => x.review_id);
                    table.ForeignKey(
                        name: "FK__Review__listing___4CA06362",
                        column: x => x.listing_id,
                        principalTable: "Listing",
                        principalColumn: "listing_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Listing_host_id",
                table: "Listing",
                column: "host_id");

            migrationBuilder.CreateIndex(
                name: "IX_Listing_location_id",
                table: "Listing",
                column: "location_id");

            migrationBuilder.CreateIndex(
                name: "IX_ListingFilter_host_id",
                table: "ListingFilter",
                column: "host_id");

            migrationBuilder.CreateIndex(
                name: "IX_ListingLikedByUsers_user_id",
                table: "ListingLikedByUsers",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Review_listing_id",
                table: "Review",
                column: "listing_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListingAmenities");

            migrationBuilder.DropTable(
                name: "ListingFilter");

            migrationBuilder.DropTable(
                name: "ListingImgUrls");

            migrationBuilder.DropTable(
                name: "ListingLabels");

            migrationBuilder.DropTable(
                name: "ListingLikedByUsers");

            migrationBuilder.DropTable(
                name: "ListingUser");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Listing");

            migrationBuilder.DropTable(
                name: "Host");

            migrationBuilder.DropTable(
                name: "Location");
        }
    }
}
