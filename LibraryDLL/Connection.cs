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
        public static bool Validate(string username, string password)
        {
            if (username == "Supriya" && password == "Pass@123")
            {
                Console.WriteLine("Login Successfull!!!!!!!!");
                return true;
            }
            else
            {
                return false;
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
            //cmd.ExecuteNonQuery();
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
            Console.WriteLine("\t\t\t\t@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            Console.WriteLine();
            Console.Write("\tBook ID\t\tBook Name\tAuthor Name\tPrice\t\tCategory\n");
            while (dr.Read())
            {
                Console.WriteLine();
                Console.Write("\t{0}\t\t{1}\t\t{2}\t\t  {3}\t{4}\n", dr[0], dr[1], dr[2], dr[3], dr[4]);
            }
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
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
        public static bool CheckToIssue(int mid)
        {

            con.Open();
            cmd = new SqlCommand("prcBookNotReturn", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("mid", mid));
            dr = cmd.ExecuteReader();
            Console.WriteLine("\t\t\t\t@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            Console.WriteLine();
            Console.WriteLine("\tEmployee Name\t\t\tBook Name\n");
            
            while (dr.Read())
            {
                Console.Write("\t{0} \t\t\t\t{1}\n", dr[1], dr[0]);
            }
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            if (dr.HasRows)
            {
                return true;
            }

            con.Close();
            return false;
           


        }

        public static void IssueBook(int mid)
        {
            if (CheckToIssue(mid) == true)
            {
                Console.WriteLine("Cannot issue, please return previous book");
            }
            else
            {
                Console.WriteLine("Enter Book Id and Book Name You Want to Issue:");
                string booknm = Console.ReadLine();
                int bookid = Convert.ToInt32(Console.ReadLine());
                string query = "insert into Library(MemberId,BookId) values (" + mid + "," + bookid + ")";
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

                duedate = Convert.ToDateTime(dr[3]);
                returndate = Convert.ToDateTime((DateTime)dr[4]);
                var days = (returndate - duedate).TotalDays;

                int d = (int)days;

                //int diff = Convert.ToInt32(returndate.Subtract(duedate));
                //int x = int.Parse(diff.ToString());
                Console.WriteLine(days);
                if (d > 7)
                {
                    fine = d * 10;
                }
                Console.WriteLine("Your fine is {0}", fine);
            }

                dr.Close();

                string query1 = "Update Library set Fine=" + fine + " where MemberId=" + mid;
                cmd = new SqlCommand(query1, con);
                cmd.ExecuteNonQuery();
                con.Close();
            

        }

        public static void NotReturnedBookBeforeDueDate()
        {
            con.Open();
            string query ="select mf.MemberId ,mf.MemberName from MembersInfo mf inner join Library li on mf.MemberId =li.MemberId where ReturnDate> DueDate";
            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();
            Console.WriteLine("\t\t\t\t@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            Console.WriteLine();
            Console.Write("\t\t\t\t\tMember ID\t\tMember Name\n");
            while (dr.Read())
            {
                Console.WriteLine();
                Console.Write("\t\t\t\t\t{0}\t\t\t{1}\n", dr[0], dr[1]);
            }
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            con.Close();


        }
        public static void NotBorrowed()
        {
            con.Open();
            string query = " select mi.MemberId, mi.membername from MembersInfo mi where MemberId not in(select MemberId from Library)";
            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();
            Console.WriteLine("\t\t\t\t@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            Console.WriteLine();
            Console.Write("\t\t\t\t\tMember ID\t\tMember Name\n");
            while (dr.Read())
            {
                Console.WriteLine();
                Console.Write("\t\t\t\t\t{0}\t\t\t{1}\n", dr[0], dr[1]);
            }
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            con.Close();


        }
        public static void BorrowedMaxTimes()
        {
            con.Open();
            string query = " select top 1 bf.BookId, BookName , count(*) 'count' from Library l join BooksInfo bf on l.BookId = bf.BookId group by bf.BookId , BookName order by count desc";
            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();
            Console.WriteLine("\t\t\t\t@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            Console.WriteLine();
            Console.Write("\t\t\t\t\tBook ID\t\t\tBook Name\n");
            while (dr.Read())
            {
                Console.WriteLine();
                Console.Write("\t\t\t\t\t{0}\t\t\t{1}\n", dr[0], dr[1]);
            }
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
            Console.WriteLine();
            Console.WriteLine();
            con.Close();


        }



    }
}

