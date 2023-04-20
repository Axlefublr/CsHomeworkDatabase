using System.Data;
using Microsoft.Data.SqlClient;

namespace ADONETClasslib;

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

    public SqlDataReader SelectAllCommandReader(string table)
    {
        var command = new SqlCommand
        {
            CommandType = CommandType.Text,
            CommandText = "select * from " + table,
            Connection = connector.GetConnection(),
        };

        SqlDataReader reader = command.ExecuteReader();

        if (reader.HasRows)
        {
            return reader;
        }

        return null;
    }

    public int DeleteByColumn(string table, string column, string value)
    {
        var command = new SqlCommand
        {
            CommandType = CommandType.Text,
            CommandText = "delete from " + table + " where " + column + " = '" + value + "';",
            Connection = connector.GetConnection(),
        };

        return command.ExecuteNonQuery();
    }

    public int ExecProcedureAdding(string login, string name)
    {
        var command = new SqlCommand
        {
            CommandType = CommandType.StoredProcedure,
            CommandText = "AddingUserProc",
            Connection = connector.GetConnection(),
        };

        command.Parameters.Add(new SqlParameter("@Name", name));
        command.Parameters.Add(new SqlParameter("@Login", login));

        return command.ExecuteNonQuery();

    }

}