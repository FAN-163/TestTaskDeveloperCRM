using Microsoft.Data.Sqlite;
using OfficeOpenXml;
using System.Text;
namespace TestTaskDeveloperCRM.DataAccess
{
    public class DataAccess1
    {
		
        string connectionString;
		public DataAccess1()
        {
			ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
			string relativePath = "crm.db";
			connectionString = $"Data Source={relativePath};";
		}

        public decimal GetTotalContractAmountForCurrentYear()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                decimal result = 0;
                connection.Open();
		
				string sql = @"SELECT SUM(ContractAmount) AS total_amount
                            FROM Contracts
                            WHERE strftime('%Y', SigningDate) = strftime('%Y', 'now')";

                var command = connection.CreateCommand();
                command.CommandText = sql;


				using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
						result = reader.GetDecimal(0); 
                        return result;
                    }
                }
                return result;
            }
        }

        public decimal GetContractAmountsByRussianCounterparty()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                decimal result = 0;
                connection.Open();

                string sql = @"SELECT SUM(ContractAmount) AS total_amount
                             FROM contracts 
                             LEFT JOIN companies ON companies.CompanyId = contracts.Counterparty 
                             WHERE companies.Country = 'Россия'
                             AND contracts.Status = '1';";

                var command = connection.CreateCommand();
                command.CommandText = sql;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result = reader.GetDecimal(0);
                        return result;
                    }
                }
                return result;
            }
        }

		public string GetAuthorizedPersonsEmailsForHighValueContractsLast30Days()
		{
			using (var connection = new SqliteConnection(connectionString))
			{
                StringBuilder builder = new StringBuilder();
				List<string> result = new List<string>();
				connection.Open();

				string sql = @"SELECT email
                             FROM persons 
                             LEFT JOIN contracts ON contracts.AuthorizedPerson = persons.personId 
                             WHERE contracts.SigningDate >= date('now', '-30 days')
                             AND contracts.ContractAmount > 40000;";

				var command = connection.CreateCommand();
				command.CommandText = sql;

				using (var reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
                        for (int i = 0; i < reader.FieldCount; i++)
						builder.Append(reader.GetString(i) + "\n");
						
					}
					return builder.ToString();
				}
			}
		}

		public void UpdateContractStatusForElderlyPersons()
		{
			using (var connection = new SqliteConnection(connectionString))
			{
				List<string> result = new List<string>();
				connection.Open();

				string sql = @"UPDATE Contracts
                             SET Status = '2'
                             WHERE AuthorizedPerson IN (
                                SELECT PersonId
                                FROM Persons
                                WHERE Age >= 60
                             ) AND Status = '1';";

				var command = connection.CreateCommand();
				command.CommandText = sql;
                command.ExecuteReader();
			}
		}

        public void GenerateReportForMoscowResidents()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                List<ReportItem> reportItems = new List<ReportItem>();
                connection.Open();

                string sql = @"SELECT Name, LastName, Persons.Email, Persons.Phone, DateOfBirth
					         FROM persons 
					         JOIN contracts ON persons.PersonId = contracts.AuthorizedPerson
					         JOIN companies ON contracts.Counterparty = companies.CompanyId 
					         WHERE companies.City = 'Москва' AND contracts.Status = '1'";
			
				var command = connection.CreateCommand();
				command.CommandText = sql;
				using (var reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
                        ReportItem reportItem = new ReportItem();
						reportItem.Name = reader.GetString(0);
						reportItem.LastName = reader.GetString(1);
						reportItem.Email = reader.GetString(2);
						reportItem.Phone = reader.GetString(3);
						reportItem.DateOfBirth = reader.GetString(4);

						reportItems.Add(reportItem);
					}
				}

				string filePath = "report.xlsx";
				if (!File.Exists(filePath))
                {
                    File.Create(filePath);
                }
                FileInfo file = new FileInfo(filePath);

                using (ExcelPackage package = new ExcelPackage(file))
                {
					
					ExcelWorksheet worksheet = package.Workbook.Worksheets.Add($"Moscow Residents Report {DateTime.Now.Microsecond}" );

                    worksheet.Cells[1, 1].Value = "Name";
                    worksheet.Cells[1, 2].Value = "Last Name";
                    worksheet.Cells[1, 3].Value = "Email";
                    worksheet.Cells[1, 4].Value = "Phone";
                    worksheet.Cells[1, 5].Value = "Date of Birth";

                    int row = 2;
                    foreach (var rowValue in reportItems)
                    {
                        worksheet.Cells[row, 1].Value = rowValue.Name;
                        worksheet.Cells[row, 2].Value = rowValue.LastName;
                        worksheet.Cells[row, 3].Value = rowValue.Email;
                        worksheet.Cells[row, 4].Value = rowValue.Phone;
                        worksheet.Cells[row, 5].Value = rowValue.DateOfBirth;
                        row++;
                    }
                    package.SaveAsync();
  
                }
            }
        }

        class ReportItem
        {
            public string Name { get; set; }
            public string LastName { get; set; }
			public string Email { get; set; }
			public string Phone { get; set; }
			public string DateOfBirth { get; set; }
		}
	}
}
