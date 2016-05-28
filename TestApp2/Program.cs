using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp2
{
    /// <summary>
    /// Program - класс для тестирования Logger AddressBook.
    /// </summary>
    class Program
    {
        private static Logger log;

        static void Main(string[] args)
        {
            log = Logger.Instance(Strategy.RecordToFile);

            AddressBook addressBook = new AddressBook();
            log.Debug("Address Book was created");

            addressBook.UserAdded += log.Info;
            addressBook.UserRemoved += log.Info;

            addressBook.UserNotAdded += log.Error;
            addressBook.UserNotRemoved += log.Error;

            User user1 = new User("Fedorov", "Ivan", new DateTime(1990, 7, 13), "Kiev");
            User user2 = new User("Iovcheva", "Irina", new DateTime(1970, 7, 3), "Odessa");
            log.Debug("2 users were initialized");

            if (!addressBook.AddUser(user1)) { log.Warning("Program class was informed that user had not been added"); }
            if (!addressBook.RemoveUser(user2)) { log.Warning("Program class was informed that user had not been removed"); }

            if (!addressBook.AddUser(user2)) { log.Warning("Program class was informed that user had not been added"); }
            if (!addressBook.RemoveUser(user2)) { log.Warning("Program class was informed that user had not been removed"); }

            try
            {
                addressBook = null;
                addressBook.ToString();
            }
            catch (Exception ex)
            {
                log.Error("You can not return a string of null reference: " + ex.Message);
            }

            log.Dispose();
        }
    }
}
