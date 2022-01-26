using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETModel
{
    public class PanelServer
    {
        private int uuid; //记录面板的id
        private Dictionary<int, BasePanel> panelDic = new Dictionary<int, BasePanel>(); //方便获取
        private List<BasePanel> panelList = new List<BasePanel>(); //方便增删
        public EventDispatcher eventDispatcher;

        public void init()
        {
            uuid = 0;
            eventDispatcher = new EventDispatcher();
        }

        public void showPanel()
        {

        }

        public void closePanel()
        {

        }

    }
}
