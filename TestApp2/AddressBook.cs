using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp2
{
    /// <summary>
    /// AddressBook - класс, который хранит список юзеров (User).
    /// Список пользователей не доступен вне класса.
    /// AddressBook должен иметь методы AddUser, RemoveUser и события UserAdded, UserRemoved.
    /// </summary>
    class AddressBook
    {
        private List<User> users;

        public AddressBook()
        {
            this.users = new List<User>();
        }

        public bool AddUser(User in_user)
        {
            try
            {
                users.Add(in_user);
                UserAdded("User " + in_user.ToString() + " - was added to address book");
                return true;
            }
            catch (Exception ex)
            {
                UserNotAdded("User " + in_user.ToString() + " - was not added to address book " + ex.Message);
                return false;
            }
        }
        public bool RemoveUser(User in_user)
        {
            if (users.Remove(in_user))
            {
                UserRemoved("User " + in_user.ToString() + " - was removed from address book");
                return true;
            }
            else
            {
                UserNotRemoved("User " + in_user.ToString() + " - was not removed from address book");
                return false;
            }

        }
        public delegate void EventHandler(string str);

        public event EventHandler UserAdded;
        public event EventHandler UserRemoved;
        public event EventHandler UserNotAdded;
        public event EventHandler UserNotRemoved;
    }
}
