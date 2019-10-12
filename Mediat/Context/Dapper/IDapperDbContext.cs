using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Mediat.Context.Dapper
{
    public interface IDapperDbContext
    {
        Task<T> CommandAsync<T>(Func<SqlConnection, SqlTransaction, int, Task<T>> command);

        // Func
        Task<T> GetAsync<T>(Func<SqlConnection, SqlTransaction, int, Task<T>> command);
        Task<IList<T>> SelectAsync<T>(Func<SqlConnection, SqlTransaction, int, Task<IList<T>>> command);

        // sql string
        Task<T> GetAsync<T>(string sql, object parameters);
        Task<IList<T>> SelectAsync<T>(string sql, object parameters);
    }
}