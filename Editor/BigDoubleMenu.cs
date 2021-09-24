using UnityEditor;
using UnityEngine;

namespace LongMan.BigDouble.Editors
{
    internal static class BigDoubleMenu
    {
        [MenuItem("Tools/LongMan/BigDoubleSetting", priority = 1)]
        static void OpenBigDoubleSettings(MenuCommand menuCommand)
        {
            var bigDoubleSettings = Resources.Load<BigDoubleSettings>("BigDoubleSettings");

            if (bigDoubleSettings == null)
            {
                if (!AssetDatabase.IsValidFolder("Assets/Resources"))
                    AssetDatabase.CreateFolder("Assets", "Resources");

                bigDoubleSettings = ScriptableObject.CreateInstance<BigDoubleSettings>();
                AssetDatabase.CreateAsset(bigDoubleSettings, "Assets/Resources/BigDoubleSettings.asset");
            }

            Selection.activeObject = bigDoubleSettings;
        }
    }
}