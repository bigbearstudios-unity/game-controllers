#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

using UnityEngine;

namespace BBUnity {

    [System.Serializable]
    public class SceneReference : ISerializationCallbackReceiver {

        [ReadOnly]
        [SerializeField]
        private string _sceneName = string.Empty;

        [ReadOnly]
        [SerializeField]
        private string _scenePath = string.Empty;

        private bool ValidScenePath {
            get {
                return !string.IsNullOrEmpty(_scenePath);
            }
        }

        public static implicit operator string(SceneReference sceneReference) {
            return sceneReference.ScenePath;
        }

        #if UNITY_EDITOR

        [SerializeField]
        private Object _sceneAsset = null;

        public string ScenePath {
            get {
                return AssetPathFor(_sceneAsset);
            }

            set {
                _scenePath = value;
                _sceneAsset = SceneAssetFor(_scenePath);
            }
        }

        private bool ValidSceneAsset {
            get {
                return _sceneAsset && _sceneAsset is SceneAsset;
            }
        }

        private string AssetPathFor(Object asset) {
            return asset == null ? string.Empty : AssetDatabase.GetAssetPath(asset);
        }

        private string AssetNameFor(string path) {
            return Path.GetFileNameWithoutExtension(path);
        }

        private SceneAsset SceneAssetFor(string path) {
            return string.IsNullOrEmpty(_scenePath) ? null : AssetDatabase.LoadAssetAtPath<SceneAsset>(_scenePath);
        }

        public void OnAfterDeserialize() {
            EditorApplication.delayCall += Deserialize;
        }

        private void Deserialize() {
            if(ValidSceneAsset || !ValidScenePath) {
                return;
            }

            _sceneAsset = SceneAssetFor(_scenePath);
            if(!ValidSceneAsset) {
                _scenePath = string.Empty;
                _sceneName = string.Empty;
            } else {
                _sceneName = AssetNameFor(_scenePath);
            }

            if(!Application.isPlaying) {
                EditorSceneManager.MarkAllScenesDirty();
            }
        }

        public void OnBeforeSerialize() {
            if (!ValidSceneAsset && ValidScenePath) {
                _sceneAsset = SceneAssetFor(_scenePath);
                if (_sceneAsset == null) {
                    _scenePath = string.Empty;
                    _sceneName = string.Empty;
                }

                EditorSceneManager.MarkAllScenesDirty();
            }
            else {
                _scenePath = AssetPathFor(_sceneAsset);
                _sceneName = AssetNameFor(_scenePath);
            }
        }

        #else

        public string ScenePath {
            get {
                return _scenePath;
            }

            set {
                _scenePath = value;
            }
        }

        public string SceneName {
            get {
                return _sceneName;
            }
        }

        public void OnAfterDeserialize() {}
        public void OnBeforeSerialize() {}

        #endif
    }
}


