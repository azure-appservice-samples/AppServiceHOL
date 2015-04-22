using appserviceholapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.Common;

namespace appserviceholapi.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/values/5
        public string GetById(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            
        }

     
        public IEnumerable<TodoItem> GetUnProcessedItems()
        {
            List<TodoItem> values;

            values = new List<TodoItem>();

            using (SqlConnection conn = new SqlConnection("Server=tcp:holsql.database.windows.net,1433;Database=holsqlDB;User ID=yochay@holsql;Password=!QAZ2wsx;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                SqlCommand q1 = new SqlCommand
                    ("SELECT [Id] ,[Text],[Complete],[PhoneNumber],[Processed] FROM [mobileHOL].[TodoItems] where [Processed]= 0 and Complete=1", conn);

                conn.Open();
                foreach (var item in q1.ExecuteReader())
                {
                    
                    values.Add(
                        new TodoItem
                        {
                            Id = (string)((DbDataRecord)item)["Id"],
                            Text = (string)((DbDataRecord)item)["Text"],
                            PhoneNumber = (string)((DbDataRecord)item)["PhoneNumber"],
                            Complete = (bool)((DbDataRecord)item)["Complete"],
                            Processed = (bool)((DbDataRecord)item)["Processed"]
                        }
                        );
                }
            }
            

            return values;
        }
        

    }
}
