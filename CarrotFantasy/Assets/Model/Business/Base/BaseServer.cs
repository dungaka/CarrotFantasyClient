using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETModel
{
    public class BaseServer
    {
        public bool isFirstLoad = false;
        public virtual void init() { }//初始化
        public virtual void loadModule() { }
        public virtual void reloadModule() { }
        public virtual void dispose() { }
    }
}
