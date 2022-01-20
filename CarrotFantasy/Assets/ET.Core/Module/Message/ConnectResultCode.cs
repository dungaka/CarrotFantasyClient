using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETModel
{   
    //自定义结果码
    public static partial class ErrorCode//客户端服务端公用
    {

        //自定义错误
        public const int ERR_AccountAlreadyRegisted = 300001;
        public const int ERR_RepeatedAccountExist = 300002;
        public const int ERR_UserNotOnline = 300003;
        public const int ERR_CreateNewCharacter = 300004;

        public const int ERR_Disconnect = 210000;
        public const int ERR_JoinRoomError = 210002;
        //public const int ERR_UserMoneyLessError = 210003;
        //public const int ERR_PlayCardError = 210004;
        public const int ERR_LoginError = 210005;

    }
}
