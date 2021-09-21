using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace LibraryDLL
{
    public class Connection
    {
        static SqlConnection con;
        static SqlCommand cmd;


        public static void CreateConnection()
        {
            string constr = "Data source=DESKTOP-KTJNK95;initial catalog=LibraryManagementSystem;user=sa;password=user@1234";
            con = new SqlConnection();
            con.ConnectionString = constr;
        }
        public static void Validate(string username, string password)
        {
            if (username == "Supriya" && password == "Pass@123")
            {
                Console.WriteLine("Login Successfull!!!!!!!!");
            }
            else
            {
                Console.WriteLine("Login Failed!!!!!!");
            }

        }
        public static void GetMemberId()
        {
            con.Open();
            string query = "Select max(MemberId) from MembersInfo";
            cmd = new SqlCommand(query, con);

            var m = cmd.ExecuteScalar();
            Console.WriteLine("{0} is the Highest Member ID", m);
            con.Close();
        }
        public static void InsertBook(string booknm)
        {
            con.Open();
            string query = "insert into BooksInfo (BookName) values ('booknm')";
            cmd = new SqlCommand(query, con);
            Console.WriteLine("Your Data Inserted Successfully");
            con.Close();

        }

    }
}

