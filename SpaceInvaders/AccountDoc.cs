using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    public class AccountDoc
    {
        public List<Account> accounts { get; set; }
        public AccountDoc()
        {
            accounts = new List<Account>();
        }

        public void addAccount(Account acc)
        {
            accounts.Add(acc);
        }

        public void removeAccount(Account acc)
        {
            accounts.Remove(acc);
        }
    }
}
