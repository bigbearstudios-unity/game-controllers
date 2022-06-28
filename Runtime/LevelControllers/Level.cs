using UnityEngine;
using System.Collections.Generic;


namespace BBUnity.LevelControllers {

    /// <summary>
    /// Represents a level within a game.
    /// </summary>
    public class Level : MonoBehaviour {
        
        /// <summary>
        /// The spawn points in the level, these are set automatically.
        /// </summary>
        private List<LevelSpawnPoint> _spawnPoints;

        /// <summary>
        /// The level transition points in the level, these are set automatically.
        /// </summary>
        private List<LevelTransitionPoint> _transitionPoints;
    }
}


