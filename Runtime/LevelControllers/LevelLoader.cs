using UnityEngine;

namespace BBUnity.LevelControllers {

    /// <summary>
    /// LevelLoader
    /// </summary>
    public class LevelLoader : MonoBehaviour {

        /// <summary>
        /// The previous level, can be null
        /// </summary>
        private Level _previousLevel;

        /// <summary>
        /// The next level
        /// </summary>
        private Level _nextLevel;
    }
}