using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETModel
{
    public class zh_language
    {
        private string[] zhcn = new string[100];

        public string getString(int id)
        {
            if (zhcn[id] != null)
            {
                return zhcn[id];
            }
            return null;
        }

        public string getFormatString(int id, String[] list)
        {
            return string.Format(zhcn[id], list);
        }
    }
}
