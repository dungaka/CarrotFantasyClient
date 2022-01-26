using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace ETModel
{
    public class BaseScene
    {
        public BaseSceneType sceneType;
        private GameObject _gameObj;
        private Dictionary<SceneLayerType, GameObject> layerDic = new Dictionary<SceneLayerType, GameObject>();
        public BaseScene(BaseSceneType type, String name, Dictionary<String, dynamic> param)
        {
            sceneType = type;
            _gameObj = new GameObject(name);
            _gameObj.transform.SetSiblingIndex(0);

            GameObject mainCanvas = new GameObject("MainCanvas");
            mainCanvas.transform.SetParent(_gameObj.transform, false);
            foreach (KeyValuePair<SceneLayerType, bool> layerData in SceneLayerData.sceneLayerSetting)
            {
                GameObject layer = new GameObject(SceneLayerData.sceneLayerName[layerData.Key]);
                CanvasScaler scaler = layer.AddComponent<CanvasScaler>();
                if (layerData.Value == true)
                {
                    layer.layer = SceneLayerData.layerType[1]; // UI层
                    Canvas canvas = layer.AddComponent<Canvas>();
                    RectTransform rect = layer.GetComponent<RectTransform>();
                    rect.anchorMin = Vector2.zero;
                    rect.anchorMax = Vector2.one;

                    rect.offsetMin = Vector2.zero; // 未来可能做屏幕适配
                    rect.offsetMax = Vector2.zero;

                    layer.AddComponent<GraphicRaycaster>();

                    layer.transform.SetParent(mainCanvas.transform, false);
                }
                layer.transform.SetParent(_gameObj.transform, false);

                layerDic.Add(layerData.Key, layer);
            }

            foreach (KeyValuePair<SceneLayerType, GameObject> layerData in layerDic)
            {
                layerData.Value.transform.SetAsLastSibling();
            }
        }

        public virtual void start()
        {

        }

        public virtual GameObject getLayerGameObj(SceneLayerType type)
        {
            if(layerDic[type] != null)
            {
                return layerDic[type];
            }
            return null;
        }

        public BaseSceneType getSceneType()
        {
            return sceneType;
        }

        public void dispose()
        {
            GameObject.Destroy(_gameObj);
        }
    }
}
