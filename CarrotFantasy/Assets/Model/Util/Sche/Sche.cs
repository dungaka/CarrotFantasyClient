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
        private static float lastResetTime = 0;

        private static long RESET_SCHE_INTERVAL_TIME = 5; //每隔5秒清理一次
        private static List<ScheObject> scheList = new List<ScheObject>();
        private static Dictionary<int, ScheObject> scheDic = new Dictionary<int, ScheObject>();

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
                float evenLastTime = even.lastStartTime;
                float deltaClock = curTime - evenLastTime;
                if(deltaClock > even.intervalTime && even.ucallBack != null)
                {
                    even.ucallBack();
                    even.lastStartTime = curTime;
                    if(even.isOnce == true)
                    {
                        silenceSingleSche(even.uid);
                        curUnscheCount += 1;
                    }
                }
            }

            if (curTime - lastResetTime > RESET_SCHE_INTERVAL_TIME || curUnscheCount * 20 >= scheList.Count)
            {
                lastResetTime = curTime;
                if(curUnscheCount > 0)
                {
                    List<ScheObject> schelist = new List<ScheObject>();
                    foreach(ScheObject even in scheList)
                    {
                        if(even.isUnscheduled == false)
                        {
                            schelist.Add(even);
                        }
                    }
                    scheList = null;
                    scheList = schelist;
                }
            }
        }

        public static void addSingleSche(callBack call, float interval)
        {
            int id = getUniqueId();
            ScheObject sche = new ScheObject(id, call, interval, curTime);
            scheList.Add(sche);
            scheDic.Add(id, sche);
        }

        public static void silenceSingleSche(int id)
        {
            ScheObject sche;
            if(scheDic.TryGetValue(id, out sche))
            {
                sche.isUnscheduled = true;
                scheDic.Remove(id);
            }
        }

        public static int getUniqueId()
        {
            curIndex += 1;
            return curIndex;
        }
    }
}
