using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETModel
{
    class ConnectEventDispatcher
    {
        private static ConnectEventDispatcher _connectEventDispatcher;
        private Session _sessionRealm = null;
        private EventDispatcher eventDispatcher;
        public static ConnectEventDispatcher getInstance()
        {
            if (_connectEventDispatcher == null)
            {
                _connectEventDispatcher = new ConnectEventDispatcher();
            }
            return _connectEventDispatcher;
        }

        public ConnectEventDispatcher()
        {
            init();
        }

        public void init()
        {
            _sessionRealm = Game.Scene.GetComponent<NetOuterComponent>().Create(GlobalConfigComponent.Instance.GlobalProto.Address);
            eventDispatcher = new EventDispatcher();
        }

        public EventDispatcher getEventDispatcher()
        {
            return eventDispatcher;
        }

        public void dispatcherConnectEvent(String eventType, Dictionary<String, dynamic> mrg)
        {
            eventDispatcher.broadcast(eventType, mrg);
        }

        public void dispose()
        {
            eventDispatcher.dipose();
        }
    }
}
