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
                string msg = "Update Error";
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
            Console.Write("Book ID\t\tBook Name\t\tAuthor Name\tPrice\tCategory\n");
            while (dr.Read())
            {
                Console.WriteLine();
                Console.Write("{0}\t\t{1}\t\t{2}\t  {3}\t{4}\n", dr[0], dr[1], dr[2], dr[3], dr[4]);
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
        public static void DeleteMember(int memberid)
        {
            con.Open();
            string query = "delete from MembersInfo where MemberId=" + memberid + "";
            cmd = new SqlCommand(query, con);
            //cmd.ExecuteNonQuery();

            try
            {

                cmd.ExecuteNonQuery();

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "Delete Error";
                msg += ex.Message;

            }
            finally
            {
                Console.WriteLine("Your Record Deleted Successfully");
                con.Close();
            }

        }
        public static void UpdateMemberName(string membernm, int memberid)
        {
            con.Open();
            string query = "update MembersInfo set MemberName='" + membernm + "' where MemberId=" + memberid + "";
            cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static void UpdateMobileNumber(long mobileno, int memberid)
        {
            con.Open();
            string query = "update MembersInfo set MobileNo=" + mobileno + " where MemberId=" + memberid + "";
            cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
      /*  public static void IssueBook(string booknm)
        {

           int m, p;
            try { 
            con.Open();
            string query= "Select BookId from BooksInfo where BookName = '"+booknm+"'";
            cmd = new SqlCommand(query, con);
             m =(int)cmd.ExecuteScalar();
            //int b = (int)m;
            string query1 = "select BookId from Library where BookId =" + m+ "";
            cmd = new SqlCommand(query1, con);
           // int n;
           
            

                p = (int)cmd.ExecuteScalar();
            }
            catch (NullReferenceException ne)
            {

                Console.WriteLine(ne);
                if (m != p)
                {
                    int bookid = m;
                    Console.WriteLine("Enter your MemberId");
                    int memberid = Convert.ToInt32(Console.ReadLine());
                    string query2 = "select Approval from Library where MemberId =" + memberid + "";
                    cmd = new SqlCommand(query2, con);
                    var apr = cmd.ExecuteScalar();
                    string approval = (string)apr;

                    if (approval == "Yes")
                    {
                        string query3 = "insert into Library (MemberId,BookId) values ('" + memberid + "'," + bookid + ")";
                        cmd = new SqlCommand(query3, con);
                    }
                    else
                    {
                        Console.WriteLine("You cannot issue book because you have not returned previous Book");
                    }


                }
                else
                {
                    Console.WriteLine("Book is already issued by someone");
                }
            }
            
            con.Close();



        }*/
        public static void ReturnBook(int bookid)
        {
            con.Open();
            string query = "update Library set Approval='Yes',ReturnDate=GETDATE() where BookId=" + bookid + "";
            
            cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            Console.WriteLine("You returned book successfully!!!!!!!! ");
            con.Close();
        }
        public static void CountFine(int mid)
        {
            con.Open();
            int fine=0;
            DateTime duedate;
            DateTime returndate;
           
            string query = "select * from Library where MemberId="+mid;
            cmd = new SqlCommand(query, con);
           
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine(dr[3]);

                Console.WriteLine(dr[4]);

                duedate = (DateTime)dr[3];
                returndate = (DateTime)dr[4];

                var diff = returndate.Subtract(duedate);
                int x = int.Parse(diff.ToString());
                Console.WriteLine(x);
                if (x > 7)
                {
                     fine = x * 10;
                        Console.WriteLine("Your fine is {0}", fine);
                }
            }

            string query1 = "Update Library set Fine=" + fine + " where MemberId=" + mid;
            cmd = new SqlCommand(query1, con);
            cmd.ExecuteNonQuery();
            con.Close();

        }



    }
}

