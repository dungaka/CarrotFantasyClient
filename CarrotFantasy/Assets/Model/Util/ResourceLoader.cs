using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ETModel
{
    class ResourceLoader
    {
        private static ResourceLoader _resourceLoader;
        public ResourceLoader getInstance()
        {
            if(_resourceLoader == null)
            {
                _resourceLoader = new ResourceLoader();
            }
            return _resourceLoader;
        }

        /// <summary>
        /// 获取未实例化的游戏物体
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public GameObject GetGameObject(string type)
        {
            try
            {
                //加载AB包
                ResourcesComponent resourcesComponent = Game.Scene.GetComponent<ResourcesComponent>();
                resourcesComponent.LoadBundle($"{type}.unity3d");

                //获取预制体
                GameObject bundleGameObject = (GameObject)resourcesComponent.GetAsset($"{type}.unity3d", $"{type}");
                return bundleGameObject;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return null;
            }
        }

        public void UnloadBundle(string type)
        {
            Game.Scene.GetComponent<ResourcesComponent>().UnloadBundle($"{type}.unity3d");
        }

    }
}
