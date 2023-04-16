using System.Data;
using Microsoft.Data.SqlClient;

namespace ClassLib;

public class DbExecutor
{
    private MainConnector connector;
    public DbExecutor(MainConnector connector)
    {
        this.connector = connector;
    }

    public DataTable SelectAll(string table)
    {
        string selectcommandtext = "SELECT * FROM " + table;
        SqlDataAdapter adapter = new(
            selectcommandtext,
            connector.GetConnection()
        );
        DataSet ds = new();
        adapter.Fill(ds);
        return ds.Tables[0];
    }
}