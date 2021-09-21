using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryDLL;

namespace LibraryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            //string r;
            Console.WriteLine("Working on Database Connectivity");
            int ch;

            Connection.CreateConnection();
            Console.WriteLine("Enter User Name");
            string username = Console.ReadLine();
            Console.WriteLine("Enter Password:");
            string pass = Console.ReadLine();
            Connection.Validate(username, pass);


            Console.WriteLine("*********WELCOME TO LIBRARY MANAGEMENT SYSTEM*********");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("****************************************************");
            Console.WriteLine("1.Add New Book to Library");
            Console.WriteLine("2.Remove Book From Library");
            Console.WriteLine("3.Update Author Name/Price/Category of the Book");
            Console.WriteLine("4.Search Book based on Author/Category/Book Name");
            Console.WriteLine("5.Add New Member");
            Console.WriteLine("6.Remove Member");
            Console.WriteLine("7.Update Member information");
            Console.WriteLine("8.Issue a Book to Member");
            Console.WriteLine("9.Record returns of Book from Member");
            Console.WriteLine("10.Calculate Fine if book is returned after due date");
            Console.WriteLine("****************************************************");


            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine();

            string booknm;
            string authorname;
            int price;
            string category;
            int bookid;
            string membernm;
            long mobileno;
            int memberid;


            Console.WriteLine("Enter your choice:");
            ch = Convert.ToInt32(Console.ReadLine());

            switch (ch)
            {
                case 1:
                    Console.WriteLine("Enter Book Name:");
                    booknm = Console.ReadLine();
                    Console.WriteLine("Enter Author Name:");
                    authorname = Console.ReadLine();
                    Console.WriteLine("Enter Book Price:");
                    price =Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Book Category:");
                    category = Console.ReadLine();
                    Connection.InsertBook(booknm,authorname,price,category);

                    break;

                case 2:
                    Console.WriteLine("Enter Book ID");
                    bookid = Convert.ToInt32(Console.ReadLine());
                    Connection.DeleteBook(bookid);
                    break;

                case 3:
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("****************************************************");
                    Console.WriteLine("a.Update Author Name of Book");
                    Console.WriteLine("b.Update Price of Book");
                    Console.WriteLine("c.Update Category of Book");
                    Console.WriteLine("****************************************************");
                    Console.ResetColor();
                    Console.WriteLine("Enter your choice");
                    char c = Convert.ToChar(Console.ReadLine());
                    switch(c)
                    {
                        case 'a':
                            Console.WriteLine("Enter Author Name and Book Id");
                            authorname = Console.ReadLine();
                            bookid = Convert.ToInt32(Console.ReadLine());
                            Connection.UpdateAuthorName(authorname, bookid);
                            break;

                        case 'b':
                            Console.WriteLine("Enter Book Price and Book Id");
                            price = Convert.ToInt32(Console.ReadLine());
                            bookid = Convert.ToInt32(Console.ReadLine());
                            Connection.UpdateBookPrice(price, bookid);
                            break;
                            

                        case 'c':
                            Console.WriteLine("Enter Book Category and Book Id");
                            category =Console.ReadLine();
                            bookid = Convert.ToInt32(Console.ReadLine());
                            Connection.UpdateBookCategory(category, bookid);
                            break;
                            

                        default:
                            Console.WriteLine("Invalid Choice");
                            break;

                    }
                    break;

                case 4:
                    Console.WriteLine("Enter Author Name or Category or Book Name");
                    string choice = Console.ReadLine();
                    Connection.SearchDetails(choice);
                    break;

                case 5:
                    Console.WriteLine("Enter New Member's Name and Mobile No ");
                    membernm = Console.ReadLine();
                    mobileno = Convert.ToInt64(Console.ReadLine());
                    Connection.AddMember(membernm,mobileno);
                    break;

                case 6:
                    Console.WriteLine("Enter Member Id for delete member");
                    memberid = Convert.ToInt32(Console.ReadLine());
                    Connection.DeleteMember(memberid);
                    
                    break;

                case 7:
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("****************************************************");
                    Console.WriteLine("a.Update Member Name");
                    Console.WriteLine("b.Update Mobile Number");
                    Console.WriteLine("****************************************************");
                    Console.ResetColor();
                    Console.WriteLine("Enter your choice");
                    char c1 = Convert.ToChar(Console.ReadLine());
                    switch(c1)
                    {
                        case 'a':
                            Console.WriteLine("Enter Member Name and Member Id");
                            membernm = Console.ReadLine();
                            memberid = Convert.ToInt32(Console.ReadLine());
                            Connection.UpdateMemberName(membernm, memberid);
                            break;
                        case 'b':
                            Console.WriteLine("Enter Mobile No and Member Id");
                            mobileno =Convert.ToInt64(Console.ReadLine());
                            memberid = Convert.ToInt32(Console.ReadLine());
                            Connection.UpdateMobileNumber(mobileno, memberid);
                            break;
                            
                        default:
                            Console.WriteLine("Incorrect Choice");
                            break;
                    }
                    break;

                case 8:
                    Console.WriteLine("Enter Book Name you want to issue");
                    booknm = Console.ReadLine();
                    //Connection.IssueBook(booknm);
                    break;

                case 9:
                    Console.WriteLine("Enter Book Id");
                    bookid = Convert.ToInt32(Console.ReadLine());
                    Connection.ReturnBook(bookid);
                    break;

                case 10:
                    Console.WriteLine("Enter Member Id");
                    memberid = Convert.ToInt32(Console.ReadLine());
                    Connection.CountFine(memberid);
                    break;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;

            }


            




            Console.ReadLine();






        }
    }
}

