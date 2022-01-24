using System;
using System.Collections.Generic;
using ETModel;
using System.Collections;

namespace ETModel
{
    public class EventObject
    {
        int _priority = 0;
        String _type;
        CallBack _delegate;
        public EventObject(String type, int priority, CallBack d)
        {
            _priority = priority;
            _type = type;
            _delegate = d;
        }

        public int getPriority()
        {
            return _priority;
        } 

        public String getEventName()
        {
            return _type;
        }

        public CallBack getCallBack()
        {
            return _delegate;
        }

        public void dispatcher(Dictionary<String, dynamic> arg)
        {
            if (_delegate != null)
            {
                CallBack callBack = _delegate as CallBack;
                if (callBack != null)
                {
                    callBack(arg);
                }
                else
                {
                    throw new Exception(string.Format("广播事件错误：事件{0}对应委托为空", _type));
                }
            }
        }
    }
}
