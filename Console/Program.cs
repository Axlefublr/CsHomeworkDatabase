using System.Data;
using ClassLib;

internal class Program
{
    static void Main(string[] args)
    {
        MainConnector connector = new();

        var result = connector.ConnectAsync();

        DataTable data = new();

        if (!result.Result)
        {
            Console.WriteLine("Ошибка подключения!");
            Console.ReadKey();
        }

        Console.WriteLine("Подключено успешно!");

        DbExecutor db = new(connector);

        string tablename = "NetworkUser";

        Console.WriteLine("Получаем данные таблицы " + tablename);

        data = db.SelectAll(tablename);

        Console.WriteLine("Отключаем БД!");
        connector.DisconnectAsync();

        Console.ReadKey();
    }
}