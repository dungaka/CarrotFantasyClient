using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETModel
{
    public class SceneLayerData
    {
        public static Dictionary<SceneLayerType, bool> sceneLayerSetting = new Dictionary<SceneLayerType, bool>
        {
            { SceneLayerType.Default, true},
            { SceneLayerType.Hud, true},
            { SceneLayerType.UI, true},
            { SceneLayerType.Tip, true},
        };

        public static Dictionary<SceneLayerType, String> sceneLayerName = new Dictionary<SceneLayerType, String>
        {
            { SceneLayerType.Default, "Default"},
            { SceneLayerType.Hud, "Hud"},
            { SceneLayerType.UI, "UI"},
            { SceneLayerType.Tip, "Tip"},
        };

        public static int[] layerType = new int[] //Layer的层级
        {
            0, //Default
            5, //UI
            9, //Hidden
        };

    }

    public enum SceneLayerType 
    { 
        Default = 1,
        Hud = 2,
        UI = 3,
        Tip = 4,
    }

}
