using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using Object =  System.Object;

namespace ETModel
{
    public delegate void CallBack(Dictionary<String, dynamic> arg);

    public class EventDispatcher
    {
        private Dictionary<String, List<EventObject>> eventTable = new Dictionary<String, List<EventObject>>();

        private void onListenerAdding(String eventName)
        {
            if (!eventTable.ContainsKey(eventName))
            {
                eventTable.Add(eventName, new List<EventObject>());
            }
        }

        private void addListenerProcess(String name, CallBack target, int priority)
        {
            List<EventObject> list = null;
            eventTable.TryGetValue(name, out list);
            if (list == null)
            {
                Debug.Log(String.Format("添加{0}事件失败", name));
            }
            EventObject eventObj = new EventObject(name, priority, target);
            for (int i = 0; i <= list.Count - 1; i++)
            {
                if (list[i].getPriority() <= priority)
                {
                    list.Insert(i, eventObj);
                    break;
                }
            }
        }

        private void onListenerRemoving(String eventName)
        {
            if (eventTable.ContainsKey(eventName))
            {
                List<EventObject> dList = eventTable[eventName];
                if (dList == null)
                {
                    throw new Exception(string.Format("移除监听错误：事件{0}没有对应的委托", eventName));
                }
            }
            else
            {
                throw new Exception(string.Format("移除监听错误：没有事件码{0}", eventName));
            }
        }
        private void onListenerRemoved(String eventName)
        {
            if (eventTable[eventName] == null)
            {
                eventTable.Remove(eventName);
            }
        }

        private void onListenerProcess(String name, CallBack target)
        {
            List<EventObject> list = null;
            eventTable.TryGetValue(name, out list);
            for (int i = list.Count - 1; i >= 0; i--) //倒叙
            {
                if (list[i].getCallBack() == target)
                {
                    list.RemoveAt(i);
                    break;
                }
            }
        }

        //no parameters
        public void addListener(String eventName, CallBack callBack, int priority = 0) //越大越先调用
        {
            onListenerAdding(eventName);
            addListenerProcess(eventName, callBack, priority);
        }

        //no parameters
        public void removeListener(String eventName, CallBack callBack)
        {
            onListenerRemoving(eventName);
            onListenerProcess(eventName, callBack);
        }

        //no parameters
        public void broadcast(String eventName,Dictionary<String, dynamic> arg)
        {
            List<EventObject> d;
            if (eventTable.TryGetValue(eventName, out d))
            {
                for(int i = 0; i < d.Count; i++)
                {
                    d[i].dispatcher(arg);
                }
            }
        }

        public void dipose()
        {
            eventTable.Clear();
        }
       
    }
}




