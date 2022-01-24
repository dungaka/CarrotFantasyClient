using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;

namespace ETModel
{

    public class LocalStorageManager
    {
        private static LocalStorageManager _localStorageManager;
        private long _accountID;

        public static LocalStorageManager getInstance()
        {
            if (_localStorageManager == null)
            {
                _localStorageManager = new LocalStorageManager();
                _localStorageManager._accountID = AccountServer.getInstance().getAccountId();
            }
            return _localStorageManager;
        }

        private String getPlayerStorageData(String value)
        {
            return String.Format("{0}_{1}", _accountID, value);
        }

        private void setDataToLocal(String key, dynamic value, LocalStorageSaveType valueType)
        {
            if(valueType == LocalStorageSaveType.IntType)
            {
                PlayerPrefs.SetInt(key, value);
            }
            else if(valueType == LocalStorageSaveType.StringType)
            {
                PlayerPrefs.SetString(key, value);
            }
            else if (valueType == LocalStorageSaveType.FloatType)
            {
                PlayerPrefs.SetFloat(key, value);
            }
            else if (valueType == LocalStorageSaveType.BoolType)
            {
                if(value is Boolean) //判断是不是Boolean类型
                {
                    if((Boolean)value == true)
                    {
                        PlayerPrefs.SetString(key, "true");
                    }
                    else if((Boolean)value == false)
                    {
                        PlayerPrefs.SetString(key, "false");
                    }
                }
                
            }
        }

        private T getDataFromLocal<T>(String key, dynamic defaultValue, LocalStorageSaveType valueType)
        {
            if (valueType == LocalStorageSaveType.StringType)
            {
                return (T)(System.Object)PlayerPrefs.GetString(key, defaultValue);
            }
            else if (valueType == LocalStorageSaveType.IntType)
            {
                return (T)(System.Object)PlayerPrefs.GetInt(key, defaultValue);
            }
            else if (valueType == LocalStorageSaveType.FloatType)
            {
                return (T)(System.Object)PlayerPrefs.GetFloat(key, defaultValue);
            }
            else if (valueType == LocalStorageSaveType.BoolType)
            {
                String value = PlayerPrefs.GetString(key, defaultValue);
                if(string.Equals(value, "true"))
                {
                    return (T)(System.Object)true;
                }
                else if(string.Equals(value, "false"))
                {
                    return (T)(System.Object)false;
                }
            }
            return default(T);
        }

        public T getPlayerInfo<T>(String key, dynamic defaultValue, LocalStorageSaveType valueType)
        {
            if(key == null || defaultValue == null)
            {
                Debug.Log("本地信息获取失败");
                return default(T);
            }
            return getDataFromLocal<T>(getPlayerStorageData(key), defaultValue, valueType);
        }

        public void setPlayerInfo<T>(String key, dynamic defaultValue, LocalStorageSaveType valueType)
        {
            if (key == null || defaultValue == null)
            {
                Debug.Log("本地信息设置失败");
            }
            setDataToLocal(getPlayerStorageData(key), defaultValue, valueType);
        }
    }
}
