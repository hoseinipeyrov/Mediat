using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mediat.Context.Dapper
{
    public class DapperDbContext : IDapperDbContext
    {
        private readonly Func<SqlConnection> _dbConnectionFactory;

        public DapperDbContext(Func<SqlConnection> dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<T> CommandAsync<T>(Func<SqlConnection, SqlTransaction, int, Task<T>> command)
        {
            using (var connection = _dbConnectionFactory.Invoke())
            {
                await connection.OpenAsync();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var result = await command(connection, transaction, 30);

                        transaction.Commit();

                        return result;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public async Task<T> GetAsync<T>(Func<SqlConnection, SqlTransaction, int, Task<T>> command)
        {
            return await CommandAsync(command);
        }

        public async Task<IList<T>> SelectAsync<T>(Func<SqlConnection, SqlTransaction, int, Task<IList<T>>> command)
        {
            return await CommandAsync(command);
        }
        public async Task<T> GetAsync<T>(string sql, object parameters)
        {
            return await CommandAsync(async (conn, trn, timeout) =>
            {
                T result = await conn.QuerySingleAsync<T>(sql, parameters, trn, timeout);
                return result;
            });
        }

        public async Task<IList<T>> SelectAsync<T>(string sql, object parameters)
        {
            return await CommandAsync<IList<T>>(async (conn, trn, timeout) =>
            {
                var result = (await conn.QueryAsync<T>(sql, parameters, trn, timeout)).ToList();
                return result;
            });
        }
    }

}
