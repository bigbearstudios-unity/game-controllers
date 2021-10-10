using UnityEditor;
using UnityEngine;
using BBUnity.Mobile;

namespace BBUnity.Editor {

    [CustomEditor(typeof(MobileSceneSettings))]
    public class MobileSceneSettingsInspector : UnityEditor.Editor {

        public override void OnInspectorGUI() {
            GUILayout.Label ("This is a Label in a Custom Editor");
        }
    }
}