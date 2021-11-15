using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using DataAccessLib;
using DataAccessLib.Models;

namespace SQLServerUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(GetConnectionString());
            SqlCrud sql = new SqlCrud(GetConnectionString());
            //ReadAllContacts(sql);
            //ReadContact(sql, 1);

            Console.ReadLine(); 
        }

        private static void ReadAllContacts(SqlCrud sql)
        {
            var rows = sql.GetAllContacts();
            foreach (var row in rows)
            {
                Console.WriteLine($"{row.Id}: {row.FirstName} {row.LastName}");
            }
        }

        private static void ReadContact(SqlCrud sql, int contactId)
        {
            var contact = sql.GetFullContactById(contactId);
            Console.WriteLine($"{contact.BasicInfo.Id}: {contact.BasicInfo.FirstName} {contact.BasicInfo.LastName}");
        }

        private static string GetConnectionString(string connectionStringName = "Default")
        {
            string output = "";
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            output = config.GetConnectionString(connectionStringName);

            return output;
        }


    }
}
