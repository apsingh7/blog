using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Model;

namespace WebApplication3.Services
{
    public class BlogService
    {
        internal List<Blog> GetData()
        {
            DataTable dt;
            string query = "Select * from blog";
            List<Blog> blogList = new List<Blog>();
            dt = DataReader.ExecuteReader(query);
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Blog data = new Blog();
                    {
                        data.Id = row.Field<int>("Id");
                        data.Name = row.Field<string>("Name");
                        data.Content = row.Field<string>("Content");
                        data.CreatedDate = row.Field<DateTime>("CreatedDate");
                        data.CreatedBy = row.Field<int>("CreatedBy");

                        data.Status = row.Field<int>("Status");
                    };
                    blogList.Add(data);
                }
            }
            return blogList;
        }

        internal void Create(Blog blog, int userId)
        {
            string script = @"Insert into [dbo].[Blog] (Name, Content, CreatedDate, CreatedBy,Status)
                                values( '" + blog.Name + "', '" + blog.Content + "', GETUTCDATE(), " + userId.ToString() + ", 1)";
            DataReader.ExecuteNonQuery(script);
        }
    }
}
