using UnityEngine;

namespace BBUnity.LevelBased {
    public class LevelLoadingController : MonoBehaviour {

        /// <summary>
        /// The previous level, can be null
        /// </summary>
        private Level _previousLevel;

        /// <summary>
        /// The next level
        /// </summary>
        private Level _nextLevel;

        private SceneController _sceneController;
        private LoadingScreenController _loadingSceneController;
    }
}