﻿using System;
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

            //Console.WriteLine("Working on Database Connectivity");
            int ch, choose, choicer;
            char co;
            char r, s;
            Connection.CreateConnection();
            Console.WriteLine("Enter User Name");
            string username = Console.ReadLine();
            Console.WriteLine("Enter Password:");
            string pass = Console.ReadLine();
            if (Connection.Validate(username, pass) == true)
            {
                

                
                Console.WriteLine("\n");
                
                Console.WriteLine("\t\t\t\t*************************************************************************");
                Console.WriteLine("\t\t\t\t*\t\t\t\t\t\t\t\t\t\t*");
                Console.WriteLine("\t\t\t\t*\t\t\t\t\t\t\t\t\t\t*");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\t\t\t\t*\t\t\t Library Management System \t\t\t\t*");
                Console.ResetColor();
                Console.WriteLine("\t\t\t\t*\t\t\t\t\t\t\t\t\t\t*");
                Console.WriteLine("\t\t\t\t*\t\t\t\t\t\t\t\t\t\t*");
                Console.WriteLine("\t\t\t\t*************************************************************************");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();


                do
                {
                    Console.WriteLine("\t\t\t\t@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("\n");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\t\t\t\t\t\t\t\t1.Library Funtions");
                    Console.WriteLine("\t\t\t\t\t\t\t\t2.Library Reports\n");
                    Console.ResetColor();

                    Console.WriteLine("\t\t\t\t@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                    Console.WriteLine("\n");
                    Console.WriteLine("\n");
                    Console.WriteLine("Enter Your Choice");
                    choose = Convert.ToInt32(Console.ReadLine());
                    switch (choose)
                    {
                        case 1:

                            do
                            {
                                Console.WriteLine();
                                Console.WriteLine();

                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine();
                                Console.WriteLine("\t\t\t\t*************************************************************************");
                                Console.WriteLine("\t\t\t\t\t\t1.Add New Book to Library");
                                Console.WriteLine("\t\t\t\t\t\t2.Remove Book From Library");
                                Console.WriteLine("\t\t\t\t\t\t3.Update Author Name/Price/Category of the Book");
                                Console.WriteLine("\t\t\t\t\t\t4.Search Book based on Author/Category/Book Name");
                                Console.WriteLine("\t\t\t\t\t\t5.Add New Member");
                                Console.WriteLine("\t\t\t\t\t\t6.Remove Member");
                                Console.WriteLine("\t\t\t\t\t\t7.Update Member information");
                                Console.WriteLine("\t\t\t\t\t\t8.Issue a Book to Member");
                                Console.WriteLine("\t\t\t\t\t\t9.Record returns of Book from Member");
                                Console.WriteLine("\t\t\t\t\t\t10.Calculate Fine if book is returned after due date");
                                Console.WriteLine();
                                Console.WriteLine("\t\t\t\t*************************************************************************");


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
                                        price = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Enter Book Category:");
                                        category = Console.ReadLine();
                                        Connection.InsertBook(booknm, authorname, price, category);

                                        break;

                                    case 2:
                                        Console.WriteLine("Enter Book ID");
                                        bookid = Convert.ToInt32(Console.ReadLine());
                                        Connection.DeleteBook(bookid);
                                        break;

                                    case 3:
                                        Console.ForegroundColor = ConsoleColor.Green ;
                                        Console.WriteLine("\t\t\t\t*************************************************************************");
                                        Console.WriteLine("\t\t\t\t\t\ta.Update Author Name of Book");
                                        Console.WriteLine("\t\t\t\t\t\tb.Update Price of Book");
                                        Console.WriteLine("\t\t\t\t\t\tc.Update Category of Book");
                                        Console.WriteLine();
                                        Console.WriteLine("\t\t\t\t*************************************************************************");
                                        Console.ResetColor();
                                        Console.WriteLine();
                                        Console.WriteLine("Enter your choice");
                                        char c = Convert.ToChar(Console.ReadLine());
                                        switch (c)
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
                                                category = Console.ReadLine();
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
                                        Connection.AddMember(membernm, mobileno);
                                        break;

                                    case 6:
                                        Console.WriteLine("Enter Member Id for delete member");
                                        memberid = Convert.ToInt32(Console.ReadLine());
                                        Connection.DeleteMember(memberid);

                                        break;

                                    case 7:
                                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                                        Console.WriteLine("\t\t\t\t*************************************************************************");
                                        Console.WriteLine("\t\t\t\t\t\ta.Update Member Name");
                                        Console.WriteLine("\t\t\tb.Update Mobile Number");
                                        Console.WriteLine("\t\t\t\t*************************************************************************");
                                        Console.ResetColor();
                                        Console.WriteLine();
                                        Console.WriteLine("Enter your choice");
                                        char c1 = Convert.ToChar(Console.ReadLine());
                                        switch (c1)
                                        {
                                            case 'a':
                                                Console.WriteLine("Enter Member Name and Member Id");
                                                membernm = Console.ReadLine();
                                                memberid = Convert.ToInt32(Console.ReadLine());
                                                Connection.UpdateMemberName(membernm, memberid);
                                                break;
                                            case 'b':
                                                Console.WriteLine("Enter Mobile No and Member Id");
                                                mobileno = Convert.ToInt64(Console.ReadLine());
                                                memberid = Convert.ToInt32(Console.ReadLine());
                                                Connection.UpdateMobileNumber(mobileno, memberid);
                                                break;

                                            default:
                                                Console.WriteLine("Incorrect Choice");
                                                break;
                                        }
                                        break;

                                    case 8:
                                        Console.WriteLine("Enter your Member Id");
                                        memberid = Convert.ToInt32(Console.ReadLine());
                                        Connection.IssueBook(memberid);
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
                                Console.WriteLine("Do you want to contionue press Y or N");
                                co = Convert.ToChar(Console.ReadLine());
                            } while (co != 'N');

                            break;
                        case 2:
                            do
                            {
                                Console.WriteLine("\t\t\t\t*************************************************************************");
                                Console.WriteLine("\n");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("\t\t\t\t\t1.List of members who have not returned book before due date");
                                Console.WriteLine("\t\t\t\t\t2.Members who have not borrowed any Book");
                                Console.WriteLine("\t\t\t\t\t3.Book which has been borrowed maximum times");
                                Console.WriteLine("\n");
                                Console.ResetColor();
                                Console.WriteLine("\t\t\t\t*************************************************************************");
                                Console.WriteLine("\n");
                                Console.WriteLine("Enter Your Choice:");
                                choicer = Convert.ToInt32(Console.ReadLine());
                                switch (choicer)
                                {
                                    case 1:
                                        Connection.NotReturnedBookBeforeDueDate();

                                        break;
                                    case 2:
                                        Connection.NotBorrowed();
                                        break;
                                    case 3:
                                        Connection.BorrowedMaxTimes();
                                        break;
                                    default:
                                        Console.WriteLine("Invalid Choice");
                                        break;



                                }
                                Console.WriteLine();
                                Console.WriteLine("Do you want to continue press Y or N");
                                s = Convert.ToChar(Console.ReadLine());

                            } while (s != 'N');


                            break;

                        default:
                            Console.WriteLine("Invalid Choice");
                            break;

                    }
                    Console.WriteLine("Do you want to continue enter Y or N");
                    r = Convert.ToChar(Console.ReadLine());

                } while (r != 'N');
            }
            else
            {
                Console.WriteLine("Login Failed!!!");
            }
                    Console.ReadLine();
         }
    }
}

