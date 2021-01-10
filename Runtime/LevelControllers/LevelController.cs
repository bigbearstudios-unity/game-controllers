using UnityEngine;


namespace BBUnity.LevelBased {
    public class LevelController : MonoBehaviour {

        /// <summary>
        /// The current level which is being controlled
        /// </summary>
        private Level _level;


        /// <summary>
        /// This controller can be created by the LevelController or
        /// found from the scene
        /// </summary>
        private LevelLoadingController _loadingScreenController;
    }
}