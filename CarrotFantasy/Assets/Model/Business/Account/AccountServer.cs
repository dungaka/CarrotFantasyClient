using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETModel
{
    public class AccountServer : BaseServer
    {
        public long accountID = 0;
        private bool isInit = false;

        public override void init()
        {
            base.init();
        }

        public override void loadModule()
        {
            base.loadModule();

        }

        public void setAccountId(long id)
        {
            if(isInit == false)
            {
                accountID = id;
            }
            isInit = true;
        }

        public long getAccountId()
        {
            return accountID;
        }

        public override void dispose()
        {
            
        }
    }
}
