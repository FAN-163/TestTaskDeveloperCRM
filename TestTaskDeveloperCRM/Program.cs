using TestTaskDeveloperCRM.DataAccess;
using static System.Net.Mime.MediaTypeNames;

namespace TestTaskDeveloperCRM
{
    public class Program
    {
        static void Main(string[] args)
        {
            var db = new DataAccess1();

            while (true)
            {
                ViewLegend();

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine(db.GetTotalContractAmountForCurrentYear());
                        break;
                    case "2":
                        Console.WriteLine(db.GetContractAmountsByRussianCounterparty());
                        break;
                    case "3":
                        Console.WriteLine(db.GetAuthorizedPersonsEmailsForHighValueContractsLast30Days());
                        break;
                    case "4":
                        db.UpdateContractStatusForElderlyPersons();
                        break;
                    case "5":
                        db.GenerateReportForMoscowResidents();
                        break;
                    case "exit":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Такой команды нет");
                        break;
                }
            }

            Console.ReadLine();
        }

        public static void ViewLegend()
        {
            Console.WriteLine("\t\t\t\t\t\tВведите номер пункта меню или Выход");
            Console.WriteLine("1\t - \ttВывести сумму всех заключенных договоров за текущий год.");
            Console.WriteLine("2\t - \tВывести сумму заключенных договоров по каждому контрагенту из России.");
            Console.WriteLine("3\t - \tВывести список e-mail уполномоченных лиц, заключивших договора за последние 30 дней, на сумму больше 40000.");
            Console.WriteLine("4\t - \tИзменить статус договора на \"Расторгнут\" для физических лиц, у которых есть действующий договор, и возраст которых старше 60 лет включительно.");
            Console.WriteLine("5\t - \tСоздать отчет xlsx, содержащий ФИО, e-mail, моб. телефон, дату рождения физ. лиц, у которых есть действующие договора по компаниям, расположенных в городе Москва.");
			Console.WriteLine("exit\t - \tВыход");

		}

		public static void Refresh()
        {

        }
    }
}
