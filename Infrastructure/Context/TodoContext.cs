using System.Data;
using Npgsql;
using Microsoft.Extensions.Configuration;
public class TodoContext
{
    IConfiguration configuration;
    public TodoContext( IConfiguration configuration)
    {
        this.configuration=configuration;
    }
    public IDbConnection CreateConnection(){
        return new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection"));
    }
}