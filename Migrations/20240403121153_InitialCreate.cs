using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OriCafe.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quan_Ca_Phe",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ten_quan = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    dia_chi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    dien_thoai = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    trang_thai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Quan_Ca___3213E83FB31B1790", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Quyen_Han",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ten_quyen_han = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    mo_ta = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Quyen_Ha__3213E83FA8787227", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Khach_Hang",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ten_khach_hang = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    dia_chi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    dien_thoai = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    diem_tich_luy = table.Column<int>(type: "int", nullable: false),
                    id_quan = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Khach_Ha__3213E83F026668A9", x => x.id);
                    table.ForeignKey(
                        name: "FK__Khach_Han__id_qu__4E88ABD4",
                        column: x => x.id_quan,
                        principalTable: "Quan_Ca_Phe",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Loai_San_Pham",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_quan = table.Column<int>(type: "int", nullable: true),
                    ten_loai_san_pham = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Loai_San__3213E83FD369CAF2", x => x.id);
                    table.ForeignKey(
                        name: "FK__Loai_San___id_qu__5165187F",
                        column: x => x.id_quan,
                        principalTable: "Quan_Ca_Phe",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Nhan_Vien",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ten_nhan_vien = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    dia_chi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    dien_thoai = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    trang_thai = table.Column<int>(type: "int", nullable: false),
                    id_quan = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Nhan_Vie__3213E83FA07ABEBA", x => x.id);
                    table.ForeignKey(
                        name: "FK__Nhan_Vien__id_qu__4BAC3F29",
                        column: x => x.id_quan,
                        principalTable: "Quan_Ca_Phe",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "San_Pham",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    id_quan = table.Column<int>(type: "int", nullable: true),
                    ten_san_pham = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    gia_ban = table.Column<double>(type: "float", nullable: false),
                    mo_ta = table.Column<string>(type: "text", nullable: true),
                    id_loai_san_pham = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__San_Pham__3213E83FC7304E05", x => x.id);
                    table.ForeignKey(
                        name: "FK__San_Pham__id_loa__5535A963",
                        column: x => x.id_loai_san_pham,
                        principalTable: "Loai_San_Pham",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__San_Pham__id_qua__5441852A",
                        column: x => x.id_quan,
                        principalTable: "Quan_Ca_Phe",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Hoa_Don",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    ngay_tao = table.Column<DateTime>(type: "datetime", nullable: false),
                    tong_tien = table.Column<int>(type: "int", nullable: false),
                    trang_thai = table.Column<int>(type: "int", nullable: false),
                    id_nhan_vien = table.Column<int>(type: "int", nullable: true),
                    id_khach_hang = table.Column<int>(type: "int", nullable: true),
                    id_quan = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Hoa_Don__3213E83FA4CC0DC5", x => x.id);
                    table.ForeignKey(
                        name: "FK__Hoa_Don__id_khac__59063A47",
                        column: x => x.id_khach_hang,
                        principalTable: "Khach_Hang",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Hoa_Don__id_nhan__5812160E",
                        column: x => x.id_nhan_vien,
                        principalTable: "Nhan_Vien",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Hoa_Don__id_quan__59FA5E80",
                        column: x => x.id_quan,
                        principalTable: "Quan_Ca_Phe",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Tai_Khoan",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ten_tai_khoan = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    mat_khau = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    vai_tro = table.Column<int>(type: "int", nullable: false),
                    trang_thai = table.Column<int>(type: "int", nullable: false),
                    id_quan = table.Column<int>(type: "int", nullable: true),
                    id_nhan_vien = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tai_Khoa__3213E83FACED733D", x => x.id);
                    table.ForeignKey(
                        name: "FK__Tai_Khoan__id_nh__619B8048",
                        column: x => x.id_nhan_vien,
                        principalTable: "Nhan_Vien",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Tai_Khoan__id_qu__60A75C0F",
                        column: x => x.id_quan,
                        principalTable: "Quan_Ca_Phe",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Chi_Tiet_Hoa_Don",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    so_luong = table.Column<int>(type: "int", nullable: false),
                    gia_ban = table.Column<double>(type: "float", nullable: false),
                    id_hoa_don = table.Column<int>(type: "int", nullable: true),
                    id_san_pham = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Chi_Tiet__3213E83F7838515E", x => x.id);
                    table.ForeignKey(
                        name: "FK__Chi_Tiet___id_ho__5CD6CB2B",
                        column: x => x.id_hoa_don,
                        principalTable: "Hoa_Don",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Chi_Tiet___id_sa__5DCAEF64",
                        column: x => x.id_san_pham,
                        principalTable: "San_Pham",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Phan_Quyen",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_tai_khoan = table.Column<int>(type: "int", nullable: true),
                    id_quyen_han = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Phan_Quy__3213E83F61BE7027", x => x.id);
                    table.ForeignKey(
                        name: "FK__Phan_Quye__id_qu__6754599E",
                        column: x => x.id_quyen_han,
                        principalTable: "Quyen_Han",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Phan_Quye__id_ta__66603565",
                        column: x => x.id_tai_khoan,
                        principalTable: "Tai_Khoan",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chi_Tiet_Hoa_Don_id_hoa_don",
                table: "Chi_Tiet_Hoa_Don",
                column: "id_hoa_don");

            migrationBuilder.CreateIndex(
                name: "IX_Chi_Tiet_Hoa_Don_id_san_pham",
                table: "Chi_Tiet_Hoa_Don",
                column: "id_san_pham");

            migrationBuilder.CreateIndex(
                name: "IX_Hoa_Don_id_khach_hang",
                table: "Hoa_Don",
                column: "id_khach_hang");

            migrationBuilder.CreateIndex(
                name: "IX_Hoa_Don_id_nhan_vien",
                table: "Hoa_Don",
                column: "id_nhan_vien");

            migrationBuilder.CreateIndex(
                name: "IX_Hoa_Don_id_quan",
                table: "Hoa_Don",
                column: "id_quan");

            migrationBuilder.CreateIndex(
                name: "IX_Khach_Hang_id_quan",
                table: "Khach_Hang",
                column: "id_quan");

            migrationBuilder.CreateIndex(
                name: "IX_Loai_San_Pham_id_quan",
                table: "Loai_San_Pham",
                column: "id_quan");

            migrationBuilder.CreateIndex(
                name: "IX_Nhan_Vien_id_quan",
                table: "Nhan_Vien",
                column: "id_quan");

            migrationBuilder.CreateIndex(
                name: "IX_Phan_Quyen_id_quyen_han",
                table: "Phan_Quyen",
                column: "id_quyen_han");

            migrationBuilder.CreateIndex(
                name: "IX_Phan_Quyen_id_tai_khoan",
                table: "Phan_Quyen",
                column: "id_tai_khoan");

            migrationBuilder.CreateIndex(
                name: "IX_San_Pham_id_loai_san_pham",
                table: "San_Pham",
                column: "id_loai_san_pham");

            migrationBuilder.CreateIndex(
                name: "IX_San_Pham_id_quan",
                table: "San_Pham",
                column: "id_quan");

            migrationBuilder.CreateIndex(
                name: "IX_Tai_Khoan_id_nhan_vien",
                table: "Tai_Khoan",
                column: "id_nhan_vien");

            migrationBuilder.CreateIndex(
                name: "IX_Tai_Khoan_id_quan",
                table: "Tai_Khoan",
                column: "id_quan");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chi_Tiet_Hoa_Don");

            migrationBuilder.DropTable(
                name: "Phan_Quyen");

            migrationBuilder.DropTable(
                name: "Hoa_Don");

            migrationBuilder.DropTable(
                name: "San_Pham");

            migrationBuilder.DropTable(
                name: "Quyen_Han");

            migrationBuilder.DropTable(
                name: "Tai_Khoan");

            migrationBuilder.DropTable(
                name: "Khach_Hang");

            migrationBuilder.DropTable(
                name: "Loai_San_Pham");

            migrationBuilder.DropTable(
                name: "Nhan_Vien");

            migrationBuilder.DropTable(
                name: "Quan_Ca_Phe");
        }
    }
}
