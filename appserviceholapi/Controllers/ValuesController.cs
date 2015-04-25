using appserviceholapi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web.Http;

namespace appserviceholapi.Controllers
{
    public class ValuesController : ApiController
    {
        protected readonly string _connectionString;

        public ValuesController()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        [HttpGet]
        // GET api/values/
        public IEnumerable<TodoItem> GetUnProcessedItems()
        {
            List<TodoItem> values;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand selectCommand = new SqlCommand("SELECT [Id] ,[Text],[Complete],[PhoneNumber],[Processed] FROM [mobileHOL].[TodoItems] WHERE [Processed]=0 AND Complete=1", conn))
                {
                    conn.Open();
                    values = new List<TodoItem>();
                    foreach (DbDataRecord item in selectCommand.ExecuteReader())
                    {
                        values.Add(
                            new TodoItem
                            {
                                Id = item["Id"].ToString(),
                                Text = item["Text"].ToString(),
                                PhoneNumber = item["PhoneNumber"].ToString(),
                                Complete = Convert.ToBoolean(item["Complete"]),
                                Processed = Convert.ToBoolean(item["Processed"])
                            }
                        );
                    }
                }
            }

            return values;
        }

        [HttpPatch]
        // PATCH api/values/{id}
        public void PatchUnProcessedItem(string id)
        {
            using(SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand updateCommand = new SqlCommand("UPDATE [mobileHOL].[TodoItems] SET [Processed]=1 WHERE [Id]=@id", conn))
                {
                    conn.Open();

                    // Assign user provided value to @id
                    updateCommand.Parameters.Add("@id", SqlDbType.NVarChar, 128);
                    updateCommand.Parameters["@id"].Value = id;

                    updateCommand.ExecuteNonQuery();
                }
            }
        }
    }
}
