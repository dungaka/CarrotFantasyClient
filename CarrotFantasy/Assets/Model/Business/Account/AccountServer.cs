using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETModel
{
    public class AccountServer
    {
        private static AccountServer _accountServer;
        public long accountID { get; private set; }
        private bool isInit = false;
        public static AccountServer getInstance()
        {
            if (_accountServer == null)
            {
                _accountServer = new AccountServer();
            }
            return _accountServer;
        }

        public void setAccountId(long id)
        {
            if(isInit == false)
            {
                accountID = id;
            }
            isInit = true;
        }

    }
}
