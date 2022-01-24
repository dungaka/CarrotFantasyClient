using System;
using System.Collections.Generic;
using UnityEngine;

namespace ETModel
{
    public delegate void callBack();

    public static class Sche //延时调用
    {
        private static int curIndex = 0;
        private static float curTime = 0;

        private static long RESET_SCHE_INTERVAL_TIME = 5; //每隔5秒清理一次
        private static List<ScheObject> scheList = new List<ScheObject>();

        public static void tick(float timeDeltaTime)
        {
            curTime += timeDeltaTime;
            int curUnscheCount = 0; //当前不参与延时调用方法的数量
            foreach(ScheObject even in scheList)
            {
                if(even.isUnscheduled == true)
                {
                    curUnscheCount += 1;
                    continue;
                }
                float evenTime = even.lastStartTime;
                    even.ucallBack();
                
            }
        }
    }
}
