using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    [Serializable]
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

        public List<Account> getAccList()
        {
            return accounts;
        }

        public int getSize()
        {
            return accounts.Count;
        }

        public void removeAccount(Account acc)
        {
            accounts.Remove(acc);
        }
    }
}
