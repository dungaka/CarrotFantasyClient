using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETModel
{
    

    public class ScheObject
    {
        public int uid;
        public callBack ucallBack;
        public float lastStartTime;
        public bool isOnce = false; 
        public bool isUnscheduled = false;
        public ScheObject(int id, callBack call, float interval, float curScheTime)
        {
            uid = id;
            ucallBack = call;
            lastStartTime = curScheTime;
        }
    }
}
