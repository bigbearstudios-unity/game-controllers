using UnityEngine;


namespace BBUnity.LevelControllers {

    /// <summary>
    /// LevelController, represents the main LevelController for the game. 
    /// This allows access to the underlying level (The current level) and any information
    /// to be used upon level transition.
    /// </summary>
    public class LevelController : MonoBehaviour {

        /// <summary>
        /// The current level which is in memory
        /// </summary>
        private Level _level;
    }
}