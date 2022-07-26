using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FBE.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Announce",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleEng = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionEng = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Enable = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    IsImportant = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announce", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EABD",
                columns: table => new
                {
                    EABD_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EABD_Ad_Tr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EABD_Ad_En = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EABD", x => x.EABD_Id);
                });

            migrationBuilder.CreateTable(
                name: "Ens_Gorevler",
                columns: table => new
                {
                    EGorev_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EGorev_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ens_Gorevler", x => x.EGorev_Id);
                });

            migrationBuilder.CreateTable(
                name: "Ens_Kurulu",
                columns: table => new
                {
                    Ens_Kurul_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    surname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ens_Kurulu", x => x.Ens_Kurul_ID);
                });

            migrationBuilder.CreateTable(
                name: "Icons",
                columns: table => new
                {
                    icon_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    iconName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    iconURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Icons", x => x.icon_id);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    MenuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MenuTitleEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MenuURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MenuTarget = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MenuStatus = table.Column<bool>(type: "bit", nullable: false),
                    MenuIsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    MenuChild = table.Column<int>(type: "int", nullable: true),
                    MenuOrder = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.MenuId);
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleEng = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionEng = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Program_Duzey",
                columns: table => new
                {
                    Prog_Duzey_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prog_Duzey = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Program_Duzey", x => x.Prog_Duzey_Id);
                });

            migrationBuilder.CreateTable(
                name: "Property",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitleEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Enable = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Target = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Child = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Slider",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Enable = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slider", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Slider2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Enable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slider2", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SliderImages",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUniqueTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SliderImages", x => x.ImageId);
                });

            migrationBuilder.CreateTable(
                name: "Unvan",
                columns: table => new
                {
                    Unvan_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Unvan_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unvan", x => x.Unvan_Id);
                });

            migrationBuilder.CreateTable(
                name: "UsefulLink",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Enable = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsefulLink", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnnounceFiles",
                columns: table => new
                {
                    FileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnounceFiles", x => x.FileId);
                    table.ForeignKey(
                        name: "FK_AnnounceFiles_Announce_PageId",
                        column: x => x.PageId,
                        principalTable: "Announce",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnnounceImages",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUniqueTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnnounceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnounceImages", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_AnnounceImages_Announce_AnnounceId",
                        column: x => x.AnnounceId,
                        principalTable: "Announce",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "PageFiles",
                columns: table => new
                {
                    FileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageFiles", x => x.FileId);
                    table.ForeignKey(
                        name: "FK_PageFiles_Pages_PageId",
                        column: x => x.PageId,
                        principalTable: "Pages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PageImages",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUniqueTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageImages", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_PageImages_Pages_PageId",
                        column: x => x.PageId,
                        principalTable: "Pages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Programs",
                columns: table => new
                {
                    Prog_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prog_Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prog_Ad_En = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prog_Ad_Ar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProgramDuzey = table.Column<int>(type: "int", nullable: false),
                    EABD_Id = table.Column<int>(type: "int", nullable: true),
                    EbsId = table.Column<int>(type: "int", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs", x => x.Prog_Id);
                    table.ForeignKey(
                        name: "FK_Programs_EABD_EABD_Id",
                        column: x => x.EABD_Id,
                        principalTable: "EABD",
                        principalColumn: "EABD_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Programs_Program_Duzey_ProgramDuzey",
                        column: x => x.ProgramDuzey,
                        principalTable: "Program_Duzey",
                        principalColumn: "Prog_Duzey_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Akademik_Kadro",
                columns: table => new
                {
                    Sicil_No = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kullanici_Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sicilno = table.Column<int>(type: "int", nullable: false),
                    EABDIdEABD_Id = table.Column<int>(type: "int", nullable: true),
                    Ens_KuruluIdEns_Kurul_ID = table.Column<int>(type: "int", nullable: true),
                    EABDBaskan = table.Column<bool>(type: "bit", nullable: false),
                    Yonetim = table.Column<bool>(type: "bit", nullable: false),
                    Enstitu = table.Column<bool>(type: "bit", nullable: false),
                    Unvan_Id = table.Column<int>(type: "int", nullable: true),
                    EGorevIdEGorev_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Akademik_Kadro", x => x.Sicil_No);
                    table.ForeignKey(
                        name: "FK_Akademik_Kadro_EABD_EABDIdEABD_Id",
                        column: x => x.EABDIdEABD_Id,
                        principalTable: "EABD",
                        principalColumn: "EABD_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Akademik_Kadro_Ens_Gorevler_EGorevIdEGorev_Id",
                        column: x => x.EGorevIdEGorev_Id,
                        principalTable: "Ens_Gorevler",
                        principalColumn: "EGorev_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Akademik_Kadro_Ens_Kurulu_Ens_KuruluIdEns_Kurul_ID",
                        column: x => x.Ens_KuruluIdEns_Kurul_ID,
                        principalTable: "Ens_Kurulu",
                        principalColumn: "Ens_Kurul_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Akademik_Kadro_Unvan_Unvan_Id",
                        column: x => x.Unvan_Id,
                        principalTable: "Unvan",
                        principalColumn: "Unvan_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Basvuru_Kos_Tr",
                columns: table => new
                {
                    Basvuru_Kos_Tr_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ogretim_Yili = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Donem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProgramProg_Id = table.Column<int>(type: "int", nullable: true),
                    Kontenjan = table.Column<int>(type: "int", nullable: false),
                    Yatay_Gec_Kontenjan = table.Column<int>(type: "int", nullable: false),
                    Min_Dil_Puan = table.Column<int>(type: "int", nullable: false),
                    Min_Ales = table.Column<int>(type: "int", nullable: false),
                    Lisans_Ort = table.Column<int>(type: "int", nullable: false),
                    Yuksek_Lisans_Ort = table.Column<int>(type: "int", nullable: false),
                    GRE_Yeni = table.Column<int>(type: "int", nullable: false),
                    GRE_Eski = table.Column<int>(type: "int", nullable: false),
                    Dil_Sart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kabul_Edilen_Program = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Basvuru_Kos_Tr", x => x.Basvuru_Kos_Tr_Id);
                    table.ForeignKey(
                        name: "FK_Basvuru_Kos_Tr_Programs_ProgramProg_Id",
                        column: x => x.ProgramProg_Id,
                        principalTable: "Programs",
                        principalColumn: "Prog_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Basvuru_Kos_Yab",
                columns: table => new
                {
                    Basvuru_Kos_Yab_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ogretim_Yili = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Donem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProgramProg_Id = table.Column<int>(type: "int", nullable: true),
                    Kontenjan = table.Column<int>(type: "int", nullable: false),
                    Yatay_Gec_Kontenjan = table.Column<int>(type: "int", nullable: false),
                    Min_Dil_Puan = table.Column<int>(type: "int", nullable: false),
                    Min_Ales = table.Column<int>(type: "int", nullable: false),
                    Lisans_Ort = table.Column<int>(type: "int", nullable: false),
                    Yuksek_Lisans_Ort = table.Column<int>(type: "int", nullable: false),
                    GRE_Yeni = table.Column<int>(type: "int", nullable: false),
                    GRE_Eski = table.Column<int>(type: "int", nullable: false),
                    Dil_Sart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kabul_Edilen_Program = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Basvuru_Kos_Yab", x => x.Basvuru_Kos_Yab_Id);
                    table.ForeignKey(
                        name: "FK_Basvuru_Kos_Yab_Programs_ProgramProg_Id",
                        column: x => x.ProgramProg_Id,
                        principalTable: "Programs",
                        principalColumn: "Prog_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dersler",
                columns: table => new
                {
                    Ders_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ders_Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ders_Ad_En = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Seviye = table.Column<bool>(type: "bit", nullable: false),
                    Tur = table.Column<bool>(type: "bit", nullable: false),
                    Dil = table.Column<bool>(type: "bit", nullable: false),
                    ProgramProg_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dersler", x => x.Ders_Id);
                    table.ForeignKey(
                        name: "FK_Dersler_Programs_ProgramProg_Id",
                        column: x => x.ProgramProg_Id,
                        principalTable: "Programs",
                        principalColumn: "Prog_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Program_Detay",
                columns: table => new
                {
                    PD_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Program_Detay_ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Program_Detay_En = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProgramId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Program_Detay", x => x.PD_Id);
                    table.ForeignKey(
                        name: "FK_Program_Detay_Programs_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "Programs",
                        principalColumn: "Prog_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EYKUyeler",
                columns: table => new
                {
                    eyk_uyeler_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Akademik_KadroSicil_No = table.Column<int>(type: "int", nullable: true),
                    EABD_Id = table.Column<int>(type: "int", nullable: true),
                    Ens_GorevlerEGorev_Id = table.Column<int>(type: "int", nullable: true),
                    Unvan_Id = table.Column<int>(type: "int", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EYKUyeler", x => x.eyk_uyeler_ID);
                    table.ForeignKey(
                        name: "FK_EYKUyeler_Akademik_Kadro_Akademik_KadroSicil_No",
                        column: x => x.Akademik_KadroSicil_No,
                        principalTable: "Akademik_Kadro",
                        principalColumn: "Sicil_No",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EYKUyeler_EABD_EABD_Id",
                        column: x => x.EABD_Id,
                        principalTable: "EABD",
                        principalColumn: "EABD_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EYKUyeler_Ens_Gorevler_Ens_GorevlerEGorev_Id",
                        column: x => x.Ens_GorevlerEGorev_Id,
                        principalTable: "Ens_Gorevler",
                        principalColumn: "EGorev_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EYKUyeler_Unvan_Unvan_Id",
                        column: x => x.Unvan_Id,
                        principalTable: "Unvan",
                        principalColumn: "Unvan_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FileKadro",
                columns: table => new
                {
                    FileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilesKadroSicil_No = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileKadro", x => x.FileId);
                    table.ForeignKey(
                        name: "FK_FileKadro_Akademik_Kadro_FilesKadroSicil_No",
                        column: x => x.FilesKadroSicil_No,
                        principalTable: "Akademik_Kadro",
                        principalColumn: "Sicil_No",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Idari_Personel",
                columns: table => new
                {
                    idari_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    soyad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sicil_No = table.Column<int>(type: "int", nullable: false),
                    Unvan_Id = table.Column<int>(type: "int", nullable: false),
                    EGorev_Id = table.Column<int>(type: "int", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    photo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idari_Personel", x => x.idari_Id);
                    table.ForeignKey(
                        name: "FK_Idari_Personel_Akademik_Kadro_Sicil_No",
                        column: x => x.Sicil_No,
                        principalTable: "Akademik_Kadro",
                        principalColumn: "Sicil_No",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Idari_Personel_Ens_Gorevler_EGorev_Id",
                        column: x => x.EGorev_Id,
                        principalTable: "Ens_Gorevler",
                        principalColumn: "EGorev_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Idari_Personel_Unvan_Unvan_Id",
                        column: x => x.Unvan_Id,
                        principalTable: "Unvan",
                        principalColumn: "Unvan_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KadroImages",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AkademikImageSicil_No = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KadroImages", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_KadroImages_Akademik_Kadro_AkademikImageSicil_No",
                        column: x => x.AkademikImageSicil_No,
                        principalTable: "Akademik_Kadro",
                        principalColumn: "Sicil_No",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProgramAkademik_Kadro",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramProg_Id = table.Column<int>(type: "int", nullable: true),
                    Akademik_KadroSicil_No = table.Column<int>(type: "int", nullable: true),
                    Yurutme_Kurulu = table.Column<bool>(type: "bit", nullable: false),
                    Yeterlilik_Kurulu = table.Column<bool>(type: "bit", nullable: false),
                    Koordinator = table.Column<bool>(type: "bit", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramAkademik_Kadro", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProgramAkademik_Kadro_Akademik_Kadro_Akademik_KadroSicil_No",
                        column: x => x.Akademik_KadroSicil_No,
                        principalTable: "Akademik_Kadro",
                        principalColumn: "Sicil_No",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProgramAkademik_Kadro_Programs_ProgramProg_Id",
                        column: x => x.ProgramProg_Id,
                        principalTable: "Programs",
                        principalColumn: "Prog_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EYK_ARA",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Akademik_KadroSicil_No = table.Column<int>(type: "int", nullable: true),
                    EABD_Id = table.Column<int>(type: "int", nullable: true),
                    Enstitu_Kurulu = table.Column<bool>(type: "bit", nullable: false),
                    Enstitu_Yonetim_Kurulu = table.Column<bool>(type: "bit", nullable: false),
                    Ens_GorevlerEGorev_Id = table.Column<int>(type: "int", nullable: true),
                    EYKUyelereyk_uyeler_ID = table.Column<int>(type: "int", nullable: true),
                    Unvan_Id = table.Column<int>(type: "int", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EYK_ARA", x => x.id);
                    table.ForeignKey(
                        name: "FK_EYK_ARA_Akademik_Kadro_Akademik_KadroSicil_No",
                        column: x => x.Akademik_KadroSicil_No,
                        principalTable: "Akademik_Kadro",
                        principalColumn: "Sicil_No",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EYK_ARA_EABD_EABD_Id",
                        column: x => x.EABD_Id,
                        principalTable: "EABD",
                        principalColumn: "EABD_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EYK_ARA_Ens_Gorevler_Ens_GorevlerEGorev_Id",
                        column: x => x.Ens_GorevlerEGorev_Id,
                        principalTable: "Ens_Gorevler",
                        principalColumn: "EGorev_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EYK_ARA_EYKUyeler_EYKUyelereyk_uyeler_ID",
                        column: x => x.EYKUyelereyk_uyeler_ID,
                        principalTable: "EYKUyeler",
                        principalColumn: "eyk_uyeler_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EYK_ARA_Unvan_Unvan_Id",
                        column: x => x.Unvan_Id,
                        principalTable: "Unvan",
                        principalColumn: "Unvan_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Akademik_Kadro_EABDIdEABD_Id",
                table: "Akademik_Kadro",
                column: "EABDIdEABD_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Akademik_Kadro_EGorevIdEGorev_Id",
                table: "Akademik_Kadro",
                column: "EGorevIdEGorev_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Akademik_Kadro_Ens_KuruluIdEns_Kurul_ID",
                table: "Akademik_Kadro",
                column: "Ens_KuruluIdEns_Kurul_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Akademik_Kadro_Unvan_Id",
                table: "Akademik_Kadro",
                column: "Unvan_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AnnounceFiles_PageId",
                table: "AnnounceFiles",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnounceImages_AnnounceId",
                table: "AnnounceImages",
                column: "AnnounceId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Basvuru_Kos_Tr_ProgramProg_Id",
                table: "Basvuru_Kos_Tr",
                column: "ProgramProg_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Basvuru_Kos_Yab_ProgramProg_Id",
                table: "Basvuru_Kos_Yab",
                column: "ProgramProg_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Dersler_ProgramProg_Id",
                table: "Dersler",
                column: "ProgramProg_Id");

            migrationBuilder.CreateIndex(
                name: "IX_EYK_ARA_Akademik_KadroSicil_No",
                table: "EYK_ARA",
                column: "Akademik_KadroSicil_No");

            migrationBuilder.CreateIndex(
                name: "IX_EYK_ARA_EABD_Id",
                table: "EYK_ARA",
                column: "EABD_Id");

            migrationBuilder.CreateIndex(
                name: "IX_EYK_ARA_Ens_GorevlerEGorev_Id",
                table: "EYK_ARA",
                column: "Ens_GorevlerEGorev_Id");

            migrationBuilder.CreateIndex(
                name: "IX_EYK_ARA_EYKUyelereyk_uyeler_ID",
                table: "EYK_ARA",
                column: "EYKUyelereyk_uyeler_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EYK_ARA_Unvan_Id",
                table: "EYK_ARA",
                column: "Unvan_Id");

            migrationBuilder.CreateIndex(
                name: "IX_EYKUyeler_Akademik_KadroSicil_No",
                table: "EYKUyeler",
                column: "Akademik_KadroSicil_No");

            migrationBuilder.CreateIndex(
                name: "IX_EYKUyeler_EABD_Id",
                table: "EYKUyeler",
                column: "EABD_Id");

            migrationBuilder.CreateIndex(
                name: "IX_EYKUyeler_Ens_GorevlerEGorev_Id",
                table: "EYKUyeler",
                column: "Ens_GorevlerEGorev_Id");

            migrationBuilder.CreateIndex(
                name: "IX_EYKUyeler_Unvan_Id",
                table: "EYKUyeler",
                column: "Unvan_Id");

            migrationBuilder.CreateIndex(
                name: "IX_FileKadro_FilesKadroSicil_No",
                table: "FileKadro",
                column: "FilesKadroSicil_No");

            migrationBuilder.CreateIndex(
                name: "IX_Idari_Personel_EGorev_Id",
                table: "Idari_Personel",
                column: "EGorev_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Idari_Personel_Sicil_No",
                table: "Idari_Personel",
                column: "Sicil_No");

            migrationBuilder.CreateIndex(
                name: "IX_Idari_Personel_Unvan_Id",
                table: "Idari_Personel",
                column: "Unvan_Id");

            migrationBuilder.CreateIndex(
                name: "IX_KadroImages_AkademikImageSicil_No",
                table: "KadroImages",
                column: "AkademikImageSicil_No");

            migrationBuilder.CreateIndex(
                name: "IX_PageFiles_PageId",
                table: "PageFiles",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_PageImages_PageId",
                table: "PageImages",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_Program_Detay_ProgramId",
                table: "Program_Detay",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramAkademik_Kadro_Akademik_KadroSicil_No",
                table: "ProgramAkademik_Kadro",
                column: "Akademik_KadroSicil_No");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramAkademik_Kadro_ProgramProg_Id",
                table: "ProgramAkademik_Kadro",
                column: "ProgramProg_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Programs_EABD_Id",
                table: "Programs",
                column: "EABD_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Programs_ProgramDuzey",
                table: "Programs",
                column: "ProgramDuzey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnnounceFiles");

            migrationBuilder.DropTable(
                name: "AnnounceImages");

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
                name: "Basvuru_Kos_Tr");

            migrationBuilder.DropTable(
                name: "Basvuru_Kos_Yab");

            migrationBuilder.DropTable(
                name: "Dersler");

            migrationBuilder.DropTable(
                name: "EYK_ARA");

            migrationBuilder.DropTable(
                name: "FileKadro");

            migrationBuilder.DropTable(
                name: "Icons");

            migrationBuilder.DropTable(
                name: "Idari_Personel");

            migrationBuilder.DropTable(
                name: "KadroImages");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "PageFiles");

            migrationBuilder.DropTable(
                name: "PageImages");

            migrationBuilder.DropTable(
                name: "Program_Detay");

            migrationBuilder.DropTable(
                name: "ProgramAkademik_Kadro");

            migrationBuilder.DropTable(
                name: "Property");

            migrationBuilder.DropTable(
                name: "Slider");

            migrationBuilder.DropTable(
                name: "Slider2");

            migrationBuilder.DropTable(
                name: "SliderImages");

            migrationBuilder.DropTable(
                name: "UsefulLink");

            migrationBuilder.DropTable(
                name: "Announce");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "EYKUyeler");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "Programs");

            migrationBuilder.DropTable(
                name: "Akademik_Kadro");

            migrationBuilder.DropTable(
                name: "Program_Duzey");

            migrationBuilder.DropTable(
                name: "EABD");

            migrationBuilder.DropTable(
                name: "Ens_Gorevler");

            migrationBuilder.DropTable(
                name: "Ens_Kurulu");

            migrationBuilder.DropTable(
                name: "Unvan");
        }
    }
}
