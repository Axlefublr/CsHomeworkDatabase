using System.Data;
using ADONETClasslib;

namespace ADONETConsole;

internal class Program
{
    static void Main(string[] args)
    {
        Manager manager = new();
        manager.Connect();
        manager.ShowData();
        manager.Disconnect();
        Console.ReadKey();
    }
}