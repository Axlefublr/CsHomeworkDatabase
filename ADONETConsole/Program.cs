using System.Data;
using ADONETClasslib;

namespace ADONETConsole;

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

        foreach (DataColumn column in data.Columns)
        {
            Console.WriteLine($"{column.ColumnName}\t");
        }
        Console.WriteLine();

        foreach (DataRow row in data.Rows)
        {
            var cells = row.ItemArray;
            foreach (var cell in cells)
            {
                Console.Write($"{cell}\t");
            }
            Console.WriteLine();
        }

        Console.WriteLine("Отключаем БД!");
        connector.DisconnectAsync();

        Console.ReadKey();
    }
}