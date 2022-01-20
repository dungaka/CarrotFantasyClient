using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace CarrotFantasy
{
    public class UIUtil
    {
        private static UIUtil _uiUtil;
        public UIUtil getInstance()
        {
            if (_uiUtil == null)
            {
                _uiUtil = new UIUtil();
            }
            return _uiUtil;
        }

        private Vector2 currentScreenSize = new Vector2(UnityEngine.Screen.width, UnityEngine.Screen.height);
        private float currentScreenRadiusScale ;

        public void initCanvasScale(CanvasScaler canvasScale) //初始化屏幕
        {
            canvasScale.uiScaleMode = UnityEngine.UI.CanvasScaler.ScaleMode.ScaleWithScreenSize;
            canvasScale.matchWidthOrHeight = getMatchWidthOrHeighRatio();
            canvasScale.referenceResolution = GameConfig.DEVELOPMENT_SCREEN_SIZE;
        }

        public float getMatchWidthOrHeighRatio()
        {
            currentScreenRadiusScale = currentScreenSize.y / currentScreenSize.x;
            if(currentScreenRadiusScale > 1.75)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
