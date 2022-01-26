using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETModel
{
    public class Business
    {
        private static Business _business;
        private Dictionary<string, BaseServer> businessDic = new Dictionary<string, BaseServer>();
        public static Business getInstance()
        {
            if(_business == null)
            {
                _business = new Business();
            }
            return _business;
        }

        private void loadBusiness()
        {
            businessDic.Add(BusinessType.AccountServer, new AccountServer());

            foreach(KeyValuePair<string, BaseServer> ser in businessDic)
            {
                BaseServer key = ser.Value;
                key.init();
                key.loadModule();
            }
        }

        private void reloadBusiness()
        {
            foreach (KeyValuePair<string, BaseServer> ser in businessDic)
            {
                BaseServer key = ser.Value;
                key.reloadModule();
            }
        }
    }
}
