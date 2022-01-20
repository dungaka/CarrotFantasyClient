using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETModel
{
    public static class LandHelper
    {
        //A0 01注册 02登录realm 03登录gate
        public static async ETVoid Register(Session sessionRealm, Dictionary<String, String> mrg)
        {
            A0001_Register_R2C message = (A0001_Register_R2C)await sessionRealm.Call(
                new A0001_Register_C2R() { Account = (String)mrg["Accout"], Password = (String)mrg["password"] });
            sessionRealm.Dispose();

            EventDispatcher m = ConnectEventDispatcher.getInstance().getEventDispatcher();
            Dictionary<string, object> md = new Dictionary<string, object>();

            if (message.Error == ErrorCode.ERR_AccountAlreadyRegisted)
            {
                md.Add("name", ConnectEventCMD.ACCOUNT_LOGIN_SUCCEED); //事件码
                md.Add("CMD", String.Format("%s", ErrorCode.ERR_AccountAlreadyRegisted));//结果码
                m.broadcast(md);
                return;
            }

            if (message.Error == ErrorCode.ERR_RepeatedAccountExist)
            {
                md.Add("name", ConnectEventCMD.ACCOUNT_LOGIN_SUCCEED); //事件码
                md.Add("CMD", String.Format("%s", ErrorCode.ERR_RepeatedAccountExist));//结果码
                m.broadcast(md);
                return;
            }
        }

        public static async ETVoid Login(Session sessionRealm, Dictionary<String, System.Object> mrg)
        {
            A0002_Login_R2C messageRealm = (A0002_Login_R2C)await sessionRealm.Call(
                new A0002_Login_C2R() { Account = (String)mrg["Accout"], Password = (String)mrg["password"]});
            sessionRealm.Dispose();
            EventDispatcher m = ConnectEventDispatcher.getInstance().getEventDispatcher();
            Dictionary<string, object> md = new Dictionary<string, object>();

            //判断Realm服务器返回结果
            if (messageRealm.Error == ErrorCode.ERR_AccountOrPasswordError)
            {
                md.Add("name", ConnectEventCMD.ACCOUNT_LOGIN_SUCCEED);//事件码
                md.Add("CMD", String.Format("%s", ErrorCode.ERR_AccountOrPasswordError));//结果码
                m.broadcast(md);
                return;
            }
            //判断通过则登陆Realm成功

            //创建网关 session
            Session sessionGate = Game.Scene.GetComponent<NetOuterComponent>().Create(messageRealm.GateAddress);
            if (SessionComponent.Instance == null)
            {
                Game.Scene.AddComponent<SessionComponent>().Session = sessionGate;
            }
            else
            {
                //存入SessionComponent方便我们随时使用
                SessionComponent.Instance.Session = sessionGate;
            }

            A0003_LoginGate_G2C messageGate = (A0003_LoginGate_G2C)await sessionGate.Call(new A0003_LoginGate_C2G() { GateLoginKey = messageRealm.GateLoginKey });

            //判断登陆Gate服务器返回结果
            if (messageGate.Error == ErrorCode.ERR_ConnectGateKeyError)
            {
                md.Add("name", ConnectEventCMD.ACCOUNT_LOGIN_SUCCEED); //事件码
                md.Add("CMD", String.Format("%s", ErrorCode.ERR_ConnectGateKeyError));//结果码
                m.broadcast(md);
                sessionGate.Dispose();
                return;
            }

            //判断通过则登陆Gate成功
            AccountServer.getInstance().setAccountId(messageGate.UserID);//设置用户Id
            md.Add("name", ConnectEventCMD.ACCOUNT_LOGIN_SUCCEED);
            m.broadcast(md);
            Log.Debug("登陆成功");
        }

        
    }
}
