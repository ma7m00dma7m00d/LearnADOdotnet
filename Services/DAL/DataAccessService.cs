using Microsoft.Data.SqlClient;
using System.Data;
using LearnAdoDotnet.Settings;

public class DataAccessService : IDisposable
{
    private readonly string? _connectionString;
    private readonly SqlConnection _sqlConnection;

    // ! this is bad
    // ! Do not hard code the connection string ever
    // public DataAccessService()
    // {
    //     _connectionString =
    //         "Data Source=MAHMOUD\\SQLEXPRESS;Initial Catalog=AdvancedProgramming2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    //     _sqlConnection = new SqlConnection(_connectionString);
    // }

    // Better (preferred)
    public DataAccessService(ConnectionStrings connectionStrings)
    {
        _connectionString = connectionStrings.DefaultConnection;
        _sqlConnection = new SqlConnection(_connectionString);
    }

    /// <summary>
    /// > Execute a SQL query and return the number of rows affected
    /// </summary>
    /// <param name="query">The SQL query to execute.</param>
    /// <param name="parameters"></param>
    /// <returns>
    /// The number of rows affected by the query.
    /// </returns>
    public int ExecuteNonQuery(string query, IEnumerable<SqlParameter>? parameters = null)
    {
        using (var command = new SqlCommand(query, _sqlConnection))
        {
            if (parameters != null && parameters.Any())
            {
                foreach (var param in parameters)
                {
                    command.Parameters.Add(param);
                }
            }

            try
            {
                _sqlConnection.Open();
                return command.ExecuteNonQuery();
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("Error Details");
                throw;
            }
        }
    }

    /// <summary>
    /// > Execute a query and return the results as a data reader
    /// </summary>
    /// <param name="query">The SQL query to execute</param>
    /// <param name="parameters"></param>
    /// <returns>
    /// A SqlDataReader object.
    /// </returns>
    public IDataReader ExecuteReader(string query, IEnumerable<SqlParameter>? parameters = null)
    {
        using (var command = new SqlCommand(query, _sqlConnection))
        {
            if (parameters != null && parameters.Any())
            {
                foreach (var param in parameters)
                {
                    command.Parameters.Add(param);
                }
            }

            try
            {
                _sqlConnection.Open();
                return command.ExecuteReader();
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("Error Details");
                throw;
            }
        }
    }

    public object? ExecuteScalar(string query, IEnumerable<SqlParameter>? parameters = null)
    {
        using (var connection = new SqlConnection(_connectionString))
        using (var command = new SqlCommand(query, connection))
        {
            if (parameters != null && parameters.Any())
            {
                foreach (var param in parameters)
                {
                    command.Parameters.Add(param);
                }
            }

            try
            {
                connection.Open();
                return command.ExecuteScalar();
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("Error Details");
                throw;
            }
        }
    }

    public void Dispose()
    {
        _sqlConnection.Dispose();
    }
}
