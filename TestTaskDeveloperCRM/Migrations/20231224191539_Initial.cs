using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestTaskDeveloperCRM.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompanyName = table.Column<string>(type: "TEXT", nullable: false),
                    INN = table.Column<string>(type: "TEXT", nullable: false),
                    OGRN = table.Column<string>(type: "TEXT", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    ContractId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Counterparty = table.Column<int>(type: "INTEGER", nullable: false),
                    AuthorizedPerson = table.Column<int>(type: "INTEGER", nullable: false),
                    ContractAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    SigningDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.ContractId);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    MiddleName = table.Column<string>(type: "TEXT", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Workplace = table.Column<string>(type: "TEXT", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                });

            migrationBuilder.Sql(
@"INSERT INTO Persons ('Name', 'LastName', 'MiddleName', 'Gender', 'Age', 'Workplace', 'Country', 'City', 'Address', 'Email', 'Phone', 'DateOfBirth') VALUES 
  ('Игорь', 'Петров', 'Петрович', 'male', '25', 'any company', 'Россия', 'Чапаевск', 'any adress', 'anyEmail1@mail.ru', +79171111111, 1990-01-01 ),
  ('Игорь', 'Петров', 'Петрович', 'male', '35', 'any company', 'Россия', 'Чапаевск', 'any adress', 'anyEmail2@mail.ru', +79171111112, 1990-01-02 ),
  ('Игорь', 'Петров', 'Петрович', 'male', '55', 'any company', 'Россия', 'Чапаевск', 'any adress', 'anyEmail3@mail.ru', +79171111113, 1990-01-03 ),
  ('Игорь', 'Петров', 'Петрович', 'male', '45', 'any company', 'Россия', 'Самара', 'any adress', 'anyEmail4@mail.ru', +79171111114, 1990-01-04 ),
  ('Игорь', 'Петров', 'Петрович', 'male', '26', 'any company', 'Россия', 'Самара', 'any adress', 'anyEmail5@mail.ru', +79171111115, 1990-01-05 ),
  ('Игорь', 'Петров', 'Петрович', 'male', '25', 'any company', 'Россия', 'Самара', 'any adress', 'anyEmail6@mail.ru', +79171111116, 1990-01-06 ),
  ('Игорь', 'Петров', 'Петрович', 'male', '37', 'any company', 'Россия', 'Самара', 'any adress', 'anyEmail7@mail.ru', +79171111117, 1990-01-07 ),
  ('Игорь', 'Петров', 'Петрович', 'male', '65', 'any company', 'Россия', 'Тольятти', 'any adress', 'anyEmail8@mail.ru', +79171111118, 1990-01-08 ),
  ('Игорь', 'Петров', 'Петрович', 'male', '29', 'any company', 'Россия', 'Тольятти', 'any adress', 'anyEmail9@mail.ru', +79171111119, 1990-01-09 ),
  ('Игорь', 'Петров', 'Петрович', 'male', '51', 'any company', 'Россия', 'Тольятти', 'any adress', 'anyEmail0@mail.ru', +79171111110, 1990-01-10 ),
  ('Игорь', 'Петров', 'Петрович', 'male', '43', 'any company', 'Россия', 'Тольятти', 'any adress', 'anyEmail11@mail.ru', +79171111121, 1990-01-11 ),
  ('Игорь', 'Петров', 'Петрович', 'male', '32', 'any company', 'Россия', 'Тольятти', 'any adress', 'anyEmail12@mail.ru', +79171111122, 1990-01-12 )
  ");

            migrationBuilder.Sql(
            @"INSERT INTO Companies ('CompanyName', 'INN', 'OGRN', 'Country', 'City', 'Address', 'Email', 'Phone') VALUES 
  ('AnyCompany', '9999999901', '9999999999901', 'Россия', 'Москва', 'any adress', 'anyEmail1@mail.ru', '79172222221'),
  ('AnyCompany', '9999999904', '9999999999904', 'Россия', 'Самара', 'any adress', 'anyEmail1@mail.ru', '79172222224'),
  ('AnyCompany', '9999999905', '9999999999905', 'Россия', 'Москва', 'any adress', 'anyEmail1@mail.ru', '79172222225'),
  ('AnyCompany', '9999999911', '9999999999911', 'Россия', 'Тольятти', 'any adress', 'anyEmail1@mail.ru', '79172222231'),
  ('AnyCompany', '9999999912', '9999999999912', 'Беларусь', 'Минск', 'any adress', 'anyEmail1@mail.ru', '79172222232')
  ");

            migrationBuilder.Sql(
          @"INSERT INTO Contracts ('Counterparty', 'AuthorizedPerson', 'ContractAmount', 'Status', 'SigningDate') VALUES 
  ('1', '1', '10000', '1', '2023-12-03'),
  ('1', '2', '10000', '2', '2023-11-05'),
  ('1', '3', '30000', '1', '2023-01-03'),
  ('2', '4', '30000', '1', '2023-01-03'),
  ('3', '5', '50000', '1', '2023-01-03'),
  ('3', '6', '50000', '1', '2023-12-03'),
  ('2', '7', '20000', '2', '2023-01-03'),
  ('2', '8', '60000', '1', '2023-12-03'),
  ('5', '9', '100000', '2', '2023-01-03'),
  ('5', '0', '40000', '1', '2023-01-03'),
  ('4', '11', '70000', '2', '2023-12-03'),
  ('4', '12', '80000', '1', '2023-01-03')
  ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
