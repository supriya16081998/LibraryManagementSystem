using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarayModel
{
    public class MembersInfo
    {
        public int MemberId
        {
            get;
            set;

        }
        public string MemberName
        {
            get;
            set;

        }
        public long MobileNO
        {
            get;
            set;

        }
    }
    public class BooksInfo
    {
        public int BookId
        {
            get;
            set;
        }
        public string BookName
        {
            get;
            set;
        }
        public string AuthorName
        {
            get;
            set;
        }
        public int Price
        {
            get;
            set;
        }
        public string Category
        {
            get;
            set;
        }

    }
    public class Library
    {
        public int MemberId
        {
            get;
            set;
        }
        public int BookId
        {
            get;
            set;
        }
        public DateTime IssueDate
        {
            get;
            set;
        }
        public DateTime DueDate
        {
            get;
            set;
        }
        public DateTime ReturnDate
        {
            get;
            set;
        }
        public int Fine
        {
            get;
            set;
        }
        public string Approval
        {
            get;
            set;
        }
    }
}
