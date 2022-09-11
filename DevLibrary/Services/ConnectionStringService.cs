using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DevLibrary
{
    class DatabaseInfo
    {
        public delegate string PassConnectionstring(DatabaseInfo databaseInfo);
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public string User_Id { get; set; }
        public string Password { get; set; }
        static public string connectionstring = "";


        public void GetTheDatabaseInfos(DatabaseInfo db)
        {
            connectionstring = "Server=" + db.ServerName + ";" + "Database=" + db.DatabaseName + ";Trusted_Connection=False;User Id=" + db.User_Id + ";Password=" + db.Password + ";";
        }



    }
    public static class ConnectionStringService
    {


        public static void EnteringInfo()
        {
            DatabaseInfo db = new DatabaseInfo();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Sever name");

            Console.ResetColor();
            db.ServerName = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("DataBase name: ");
            Console.ResetColor();
            db.DatabaseName = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("User Id");
            Console.ResetColor();
            db.User_Id = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("password");

            Console.ResetColor();
            db.Password = Console.ReadLine();//becareful change the Console.ReadLine() with password security
            db.GetTheDatabaseInfos(db);

        }
    }
}
