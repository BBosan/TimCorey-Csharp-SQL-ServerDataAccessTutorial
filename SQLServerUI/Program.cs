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

            //ReadContact(sql, 2);

            //CreateNewContact(sql);

            //UpdateContact(sql);

            RemovePhoneNumberFromContact(sql, 1, 1);

            Console.WriteLine("Done processing");

            Console.ReadLine();
        }

        private static void RemovePhoneNumberFromContact(SqlCrud sql, int contactId, int phoneNumberId)
        {
            sql.RemovePhoneNumberFromContact(contactId, phoneNumberId);
        }

        private static void UpdateContact(SqlCrud sql)
        {
            BasicContactModel contact = new BasicContactModel()
            {
                Id = 1,
                FirstName = "Marko",
                LastName = "Ivanovic"
            };

            sql.UpdateContactName(contact);
        }

        private static void CreateNewContact(SqlCrud sql)
        {
            FullContactModel user = new FullContactModel
            {
                BasicInfo = new BasicContactModel
                {
                    FirstName = "Ivana",
                    LastName = "Ivanic"
                }
            };

            user.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "nope@aol.com" });
            user.EmailAddresses.Add(new EmailAddressModel { Id = 2, EmailAddress = "me@ivanic.com" });

            user.PhoneNumbers.Add(new PhoneNumberModel { Id = 1, PhoneNumber = "555-1212" });
            user.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "555-9876" });

            sql.CreateContact(user);
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
