using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETModel
{
    public enum LanguageType
    {
        zh_cn,
        zh_us,
    }

    public class LanguageUtil
    {
        private LanguageUtil _languageUtil;
        private zh_language curLanguageBag;
        private LanguageType curType;

        private Dictionary<UnityEngine.SystemLanguage, zh_language> systemLanguageList = new Dictionary<UnityEngine.SystemLanguage, zh_language>();

        public LanguageUtil getInstance()
        {
            if(_languageUtil == null)
            {
                _languageUtil = new LanguageUtil();
                _languageUtil.loadLanguageBag();
            }
            return _languageUtil;
        }

        private void loadLanguageBag()
        {
            systemLanguageList.Add(UnityEngine.SystemLanguage.Chinese, new zh_cn());
            systemLanguageList.Add(UnityEngine.SystemLanguage.English, new zh_cn());
            systemLanguageList.Add(UnityEngine.SystemLanguage.ChineseSimplified, new zh_cn());
            systemLanguageList.Add(UnityEngine.SystemLanguage.ChineseTraditional, new zh_cn());

            UnityEngine.SystemLanguage sys = UnityEngine.Application.systemLanguage;
            curLanguageBag = systemLanguageList[sys];
            if(sys == UnityEngine.SystemLanguage.Chinese) //暂时这样写
            {
                curType = LanguageType.zh_cn;
            }
            else
            {
                curType = LanguageType.zh_us;
            }
        }

        public LanguageType getCurLanguageType()
        {
            return curType;
        }

        public String getString(int id)
        {
            return curLanguageBag.getString(id);
        }

        public String getFormatString(int id, string[] list)
        {
            return curLanguageBag.getFormatString(id, list);
        }
    }
}
