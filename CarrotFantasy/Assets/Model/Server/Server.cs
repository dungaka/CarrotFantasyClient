using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETModel
{
    public class Server
    {
        private static Server _server;
        public PanelServer panelServer;
        public SceneServer sceneServer;

        public Server getInstance()
        {
            if(_server == null)
            {
                _server = new Server();
                _server.init();
            }
            return _server;
        }

        public void init()
        {
            panelServer = new PanelServer();
            panelServer.init();
            sceneServer = new SceneServer();
            sceneServer.init();
        }
    }
}
