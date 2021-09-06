using ASPSQLServer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ASPSQLServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {

        // working with https://localhost:[port]/user

        // ADO
        // www.c-sharpcorner.com/UploadFile/97fc7a/webapi-restful-operations-in-webapi-using-ado-net-objects-a

        // EF
        // www.dotnettutorials.net/lesson/web-api-with-sql-server
        // www.betterprogramming.pub/building-a-restful-api-with-asp-net-web-api-and-sql-server-ce7873d5b331

        // Angular
        // www.c-sharpcorner.com/article/crud-operations-with-asp-net-core-using-angular-5-and-ado-net/

        // Authentication LDAP Angular + .NET
        // www.c-sharpcorner.com/article/enable-windows-authentication-in-web-api-and-angular-app/
        // www.stackoverflow.com/questions/48318464/angular-4-httpclient-cors-windows-auth
        // www.stackoverflow.com/questions/57768965/windows-authentication-and-angular-7-application

        // Async
        // www.stackoverflow.com/questions/31185072/effectively-use-async-await-with-asp-net-web-api
        [HttpGet]
        public IActionResult Get()
        {
            //return listEmp.First(e => e.ID == id);  
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = "Data Source=(LocalDb)\\MSSQLLocalDB; Initial Catalog=Estudents; Trusted_Connection=True;";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select * from [Estudents].[dbo].[Person]";
            sqlCmd.Connection = myConnection;

            // Open conn and executeReader.
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();

            // Creating List of Users to get de array of elements.
            List<User> UserList = new List<User>();

            while (reader.Read())
            {
                // Creating a Individual User.
                var userInd = new User();
                userInd.id = Convert.ToInt32(reader.GetValue(0));
                userInd.nombre = reader.GetValue(1).ToString().Trim();
                userInd.apellido = reader.GetValue(2).ToString().Trim();
                UserList.Add(userInd);
            }

            // Closing conn.
            myConnection.Close();

            //return user List with Ok (200) status.
            return Ok(UserList);
        }

        /*
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            //return listEmp.First(e => e.ID == id);  
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = "Data Source=(LocalDb)\\MSSQLLocalDB; Initial Catalog=Estudents; Trusted_Connection=True;";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select * from [Estudents].[dbo].[Person]";
            sqlCmd.Connection = myConnection;

            // Open conn and executeReader.
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();

            // Creating List of Users to get de array of elements.
            List<User> UserList = new List<User>();

            while (reader.Read())
            {
                // Creating a Individual User.
                var userInd = new User();
                userInd.id = Convert.ToInt32(reader.GetValue(0));
                userInd.nombre = reader.GetValue(1).ToString().Trim();
                userInd.apellido = reader.GetValue(2).ToString().Trim();
                UserList.Add(userInd);
            }

            // Closing conn.
            myConnection.Close();

            //return user List with Ok (200) status.
            return Ok(UserList);
        }*/

    }
}
