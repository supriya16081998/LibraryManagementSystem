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

            Console.WriteLine("Enter your choice:");
            ch = Convert.ToInt32(Console.ReadLine());

            switch (ch)
            {
                case 1:
                    Console.WriteLine("Enter Book Name:");
                    String booknm = Console.ReadLine();
                    Connection.InsertBook(booknm);

                    break;

                case 2:
                    break;

                case 3:
                    break;

                case 4:
                    break;

                case 5:
                    break;

                case 6:
                    break;

                case 7:
                    break;

                case 8:
                    break;

                case 9:
                    break;

                case 10:
                    break;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;

            }


            Console.WriteLine("===========================================");
            Connection.GetMemberId();





            Console.ReadLine();






        }
    }
}

