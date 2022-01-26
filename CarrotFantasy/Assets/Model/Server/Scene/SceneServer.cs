using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ETModel
{
    public class SceneServer 
    {
        private static SceneServer _sceneServer;
        public EventDispatcher eventDispatcher;
        public Camera uiCamera; //固定的
        public Camera mainCamera; // 主摄像机（主要是拍3D物体）
        public BaseScene currentScene;

        public Dictionary<BaseSceneType, Dictionary<String, dynamic>> paramDic = new Dictionary<BaseSceneType, Dictionary<string, dynamic>>();

        public void init()
        {
            currentScene = null;
            eventDispatcher = new EventDispatcher();
            uiCamera = GameObject.Find("uiCamera").GetComponent<Camera>();
        }

        public EventDispatcher getEventDispatcher()
        {
            return eventDispatcher;
        }

        public bool loadScene(BaseSceneType sceneType, Dictionary<String, dynamic> param)
        {
            bool isLoad = false;
            if(paramDic.Count > 0)
            {
                if(currentScene.sceneType == sceneType)
                {
                    return isLoad;
                }
                isLoad = loadSceneProgress(sceneType, param);
            }
            else
            {
                isLoad = loadSceneProgress(sceneType, param);
            }
            return isLoad;
        }

        private bool loadSceneProgress(BaseSceneType sceneType, Dictionary<String, dynamic> param)
        {
            BaseScene targetScene = null;
            switch (sceneType) {
                case BaseSceneType.LoginScene:
                    targetScene = new LoginScene(sceneType, "LoginScene", param);
                    break;
                case BaseSceneType.MainScene:
                    targetScene = new LoginScene(sceneType, "LoginScene", param);
                    break;
                case BaseSceneType.FightScene:
                    targetScene = new LoginScene(sceneType, "LoginScene", param);
                    break;
                default:
                    Debug.Log("场景加载失败");
                    break;
            }
            if(targetScene == null)
            {
                return false;
            }
            currentScene = targetScene;
            paramDic.Add(sceneType, param);
            targetScene.start();
            Dictionary<String, dynamic> paramOne = new Dictionary<string, dynamic>()
            {
                {"sceneType", sceneType},
            };
            eventDispatcher.broadcast(SceneEventType.LOAD_SCENE, paramOne);
            return true;
        }

    }
}
