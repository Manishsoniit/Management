using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management.Core.Interface;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Security;
using System.Reflection;

namespace Management.Infrastructure.Repository.Base
{
    public class SqlDataHelper : IDbHelper
    {
        public string connection { get; set; }
        
        public string DBUser { get; set; }
        public string DBPass { get; set; }
        public Boolean Devenvernment { get; set; }

        public SqlDataHelper(IConfiguration iconfig)
        {
            DBUser = Convert.ToString(iconfig.GetSection("DBUser").Value);
            DBPass = Convert.ToString(iconfig.GetSection("DBPass").Value);
            connection = Convert.ToString(iconfig.GetSection("DBConn").Value);
            Devenvernment= Convert.ToString(iconfig.GetSection("EnvName").Value)== "Development";
        }

        public async Task<DataTable> SqlProcGetData(string procedureName, Dictionary<string, object> parameter)
        {
            DataTable table = new DataTable();
            using (var con = new SqlConnection(connection, getCred()))
                using(var cmd=new SqlCommand(procedureName,con))
                using(var da=new SqlDataAdapter(cmd))
            {
                await con.OpenAsync();
                cmd.CommandTimeout = 0;
                if(parameter!=null)
                {
                    foreach(var item in parameter)
                    {
                        SqlParameter obj = cmd.Parameters.AddWithValue(Convert.ToString(item.Key), item.Value);
                        if(item.Value.GetType()==typeof(DataTable))
                        {
                            DataTable dt = (DataTable)item.Value;
                            obj.SqlDbType = SqlDbType.Structured;
                            obj.TypeName = dt.TableName;
                        }
                    }
                }
                cmd.CommandType = CommandType.StoredProcedure;
                da.Fill(table);
            }
            return table;
              
        }

        
        public SqlCredential getCred()
        {
            SecureString secpwd = new SecureString();
            if(Devenvernment)
            {
                foreach(var charpass in DBPass.ToCharArray())
                {
                    secpwd.AppendChar(charpass);
                }
            }
            else
            {
                //var Passwrd=
            }
            secpwd.MakeReadOnly();
            SqlCredential cred= new SqlCredential(DBUser,secpwd);
            return cred;
        }

        public List<T> DataTableToList<T>(DataTable dt)
        {
            const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
            var columnNames = dt.Columns.Cast<DataColumn>()
        .Select(c => c.ColumnName)
        .ToList();
            var objectProperties = typeof(T).GetProperties(flags);
            var targetList = dt.AsEnumerable().Select(dataRow =>
            {
                var instanceOfT = Activator.CreateInstance<T>();

                foreach (var properties in objectProperties.Where(properties => columnNames.Contains(properties.Name) && dataRow[properties.Name] != DBNull.Value))
                {
                    properties.SetValue(instanceOfT, dataRow[properties.Name], null);
                }
                return instanceOfT;
            }).ToList();

            return targetList;
        }
        //public Task<DataTable> SqlProcGetData(string procedureName, Dictionary<string, object> parameter)
        //{
        //    DataTable table = new DataTable();
        //    using (var con = new SqlConnection(Connection,getcr)
        //}
    }
}
