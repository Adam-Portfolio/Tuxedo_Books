using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookstore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    GenreId = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AuthorBook",
                columns: table => new
                {
                    AuthorsAuthorId = table.Column<int>(type: "int", nullable: false),
                    BooksBookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBook", x => new { x.AuthorsAuthorId, x.BooksBookId });
                    table.ForeignKey(
                        name: "FK_AuthorBook_Authors_AuthorsAuthorId",
                        column: x => x.AuthorsAuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBook_Books_BooksBookId",
                        column: x => x.BooksBookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Michelle", "Alexander" },
                    { 2, "Stephen E.", "Ambrose" },
                    { 3, "Margaret", "Atwood" },
                    { 4, "Jane", "Austen" },
                    { 5, "James", "Baldwin" },
                    { 6, "Emily", "Bronte" },
                    { 7, "Agatha", "Christie" },
                    { 8, "Ta-Nehisi", "Coates" },
                    { 9, "Jared", "Diamond" },
                    { 10, "Joan", "Didion" },
                    { 11, "Daphne", "Du Maurier" },
                    { 12, "Tina", "Fey" },
                    { 13, "Roxane", "Gay" },
                    { 14, "Dashiel", "Hammett" },
                    { 15, "Frank", "Herbert" },
                    { 16, "Aldous", "Huxley" },
                    { 17, "Stieg", "Larsson" },
                    { 18, "David", "McCullough" },
                    { 19, "Toni", "Morrison" },
                    { 20, "George", "Orwell" },
                    { 21, "Mary", "Shelley" },
                    { 22, "Sun", "Tzu" },
                    { 23, "Augusten", "Burroughs" },
                    { 25, "JK", "Rowling" },
                    { 26, "Seth", "Grahame-Smith" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "Name" },
                values: new object[,]
                {
                    { "history", "History" },
                    { "memoir", "Memoir" },
                    { "mystery", "Mystery" },
                    { "novel", "Novel" },
                    { "scifi", "Science Fiction" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "GenreId", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "history", 18.0, "1776" },
                    { 2, "scifi", 5.5, "1984" },
                    { 3, "mystery", 4.5, "And Then There Were None" },
                    { 4, "history", 11.5, "Band of Brothers" },
                    { 5, "novel", 10.99, "Beloved" },
                    { 6, "memoir", 13.5, "Between the World and Me" },
                    { 7, "memoir", 4.25, "Bossypants" },
                    { 8, "scifi", 16.25, "Brave New World" },
                    { 9, "history", 15.0, "D-Day" },
                    { 10, "memoir", 12.5, "Down and Out in Paris and London" },
                    { 11, "scifi", 8.75, "Dune" },
                    { 12, "novel", 9.0, "Emma" },
                    { 13, "scifi", 6.5, "Frankenstein" },
                    { 14, "novel", 10.25, "Go Tell it on the Mountain" },
                    { 15, "history", 15.5, "Guns, Germs, and Steel" },
                    { 16, "memoir", 14.5, "Hunger" },
                    { 17, "mystery", 6.75, "Murder on the Orient Express" },
                    { 18, "novel", 8.5, "Pride and Prejudice" },
                    { 19, "mystery", 10.99, "Rebecca" },
                    { 20, "history", 5.75, "The Art of War" },
                    { 21, "mystery", 8.5, "The Girl with the Dragon Tattoo" },
                    { 22, "scifi", 12.5, "The Handmaid's Tale" },
                    { 23, "mystery", 10.99, "The Maltese Falcon" },
                    { 24, "history", 13.75, "The New Jim Crow" },
                    { 25, "memoir", 13.5, "The Year of Magical Thinking" },
                    { 26, "novel", 9.0, "Wuthering Heights" },
                    { 27, "memoir", 11.0, "Running With Scissors" },
                    { 28, "novel", 8.75, "Pride and Prejudice and Zombies" },
                    { 29, "novel", 9.75, "Harry Potter and the Sorcerer's Stone" }
                });

            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "AuthorsAuthorId", "BooksBookId" },
                values: new object[,]
                {
                    { 1, 24 },
                    { 2, 4 },
                    { 2, 9 },
                    { 3, 22 },
                    { 4, 12 },
                    { 4, 18 },
                    { 4, 28 },
                    { 5, 14 },
                    { 6, 26 },
                    { 7, 3 },
                    { 7, 17 },
                    { 8, 6 },
                    { 9, 15 },
                    { 10, 25 },
                    { 11, 19 },
                    { 12, 7 },
                    { 13, 16 },
                    { 14, 23 },
                    { 15, 11 },
                    { 16, 8 },
                    { 17, 21 },
                    { 18, 1 },
                    { 19, 5 },
                    { 20, 2 },
                    { 20, 10 },
                    { 21, 13 },
                    { 22, 20 },
                    { 23, 27 },
                    { 25, 29 },
                    { 26, 28 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBook_BooksBookId",
                table: "AuthorBook",
                column: "BooksBookId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_GenreId",
                table: "Books",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorBook");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
