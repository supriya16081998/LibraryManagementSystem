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
        static SqlDataReader dr;


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
        public static void InsertBook(string booknm,string authornm,int price,string category)
        {
            con.Open();
            string query = "insert into BooksInfo values ('"+ booknm +"','"+ authornm +"',"+price+",'"+ category +"')";
            cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            //con.Close();
            try
            {
                //con.Open();
                cmd.ExecuteNonQuery();

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "Insert Error";
                msg += ex.Message;

            }
            finally
            {
                Console.WriteLine("Your Data Inserted Successfully");
                con.Close();
            }

        }

        public static void DeleteBook(int bookid)
        {
            con.Open();
            string query = "delete from BooksInfo where BookId="+bookid+"";
            cmd = new SqlCommand(query, con);
            //cmd.ExecuteNonQuery();
            
            try
            {
                
                cmd.ExecuteNonQuery();

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "Insert Error";
                msg += ex.Message;

            }
            finally
            {
                Console.WriteLine("Your Record Deleted Successfully");
                con.Close();
            }

        }

        public static void UpdateAuthorName(string authornm,int bookid)
        {
            con.Open();
            string query = "update BooksInfo set AuthorName='" + authornm + "' where BookId=" + bookid + "";
            cmd = new SqlCommand(query, con);
            //cmd.ExecuteNonQuery();

            try
            {

                cmd.ExecuteNonQuery();

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "Insert Error";
                msg += ex.Message;

            }
            finally
            {
                Console.WriteLine("Your Record updated Successfully");
                con.Close();
            }

        }
        public static void UpdateBookPrice(int price, int bookid)
        {
            con.Open();
            string query = "update BooksInfo set BookPrice=" + price + " where BookId=" + bookid + "";
            cmd = new SqlCommand(query, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "Insert Error";
                msg += ex.Message;
            }
            finally
            {
                Console.WriteLine("Your Record updated Successfully");
                con.Close();
            }

        }
        public static void UpdateBookCategory(string category, int bookid)
        {
            con.Open();
            string query = "update BooksInfo set Category='"+ category +"' where BookId=" + bookid + "";
            cmd = new SqlCommand(query, con);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "Insert Error";
                msg += ex.Message;
            }
            finally
            {
                Console.WriteLine("Your Record updated Successfully");
                con.Close();
            }

        }
        public static void SearchDetails(string choice)
        {
            con.Open();
            string query = "select * from BooksInfo where Category='" + choice + "'or BookName='" + choice + "' or AuthorName='" + choice + "'";
            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();
            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            Console.WriteLine();
            Console.Write("Book ID\t\tBook Name\tAuthor Name\tPrice\tCategory\n");
            while (dr.Read())
            {
                Console.Write("{0}\t\t{1}\t\t{2}\t{3}\t{4}\n", dr[0], dr[1], dr[2], dr[3], dr[4]);
            }
            Console.WriteLine();
            Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            con.Close();
        }

        public static void AddMember(string membernm, long mobileno)
        {
           // con.Open();
            string query = "insert into MembersInfo values ('" + membernm + "'," + mobileno + ")";
            cmd = new SqlCommand(query, con);
            
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "Insert Error";
                msg += ex.Message;

            }
            finally
            {
                Console.WriteLine("Your Data Inserted Successfully");
                con.Close();
            }

        }


    }
}

