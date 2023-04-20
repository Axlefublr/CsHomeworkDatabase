
namespace ADONETConsole;

internal class Program
{
    static void Main(string[] args)
    {
        Manager manager = new();
        manager.Connect();
        manager.ShowData();
        manager.Disconnect();
        Console.WriteLine("Введите логин для удаления:");
        int rowsAffected = manager.DeleteUserByLogin(Console.ReadLine());
        Console.WriteLine(rowsAffected);
        manager.ShowData();
        Console.ReadKey();
    }
}