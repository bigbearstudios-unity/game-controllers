using UnityEngine;
using System.Collections.Generic;


namespace BBUnity.LevelBased {
    /// <summary>
    /// The based concept for a level. This should be the top level component
    /// in any prefab / scene created
    /// </summary>
    public class Level : MonoBehaviour {

        private List<LevelSpawnPoint> _spawnPoints;
        private List<LevelTransition> _transitions;


    }
}


