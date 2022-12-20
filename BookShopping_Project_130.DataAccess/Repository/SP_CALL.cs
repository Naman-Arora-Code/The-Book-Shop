using BookShopping_Project_130.DataAccess.Data;
using BookShopping_Project_130.DataAccess.Repository.IRepository;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BookShopping_Project_130.DataAccess.Repository
{
    public class SP_CALL : ISP_CALL
    {
        private readonly ApplicationDbContext _context;
        private static string connectionString = "";
        public SP_CALL(ApplicationDbContext context)
        {
            _context = context;
            connectionString = _context.Database.GetDbConnection().ConnectionString;
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public void Execute(string procName, DynamicParameters param = null)
        {
            using(SqlConnection sqlCon= new SqlConnection(connectionString))
            {
                sqlCon.Open();
                sqlCon.Execute(procName,param,commandType:CommandType.StoredProcedure);
            }
        }

        public IEnumerable<T> List<T>(string procName, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                return sqlCon.Query<T>(procName, param, commandType: 
                    CommandType.StoredProcedure);
            }
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>> List<T1, T2>(string procName, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                var result = SqlMapper.QueryMultiple(sqlCon,procName,
                    param,commandType:CommandType.StoredProcedure);
                var item1 = result.Read<T1>();
                var item2 = result.Read<T2>();
                if (item1 != null && item2 != null)
                    return new Tuple<IEnumerable<T1>, IEnumerable<T2>>(item1, item2);
            }
            return new Tuple<IEnumerable<T1>, IEnumerable<T2>>
                (new List<T1>(), new List<T2>());
        }

        public T OneRecord<T>(string procName, DynamicParameters param = null)
        {
            using (SqlConnection sqlcon=new SqlConnection(connectionString))
            {
                sqlcon.Open();
                var value = sqlcon.Query<T>(procName, param,
                    commandType: CommandType.StoredProcedure);
                return value.FirstOrDefault();
            }
        }
        public T Single<T>(string procName, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon=new SqlConnection(connectionString))
            {
                sqlCon.Open();
                return sqlCon.ExecuteScalar<T>(procName, param,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
