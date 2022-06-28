using UnityEngine;

using System;
using System.Collections.Generic;

using BBUnity.SceneManagement;
using BBUnity.BaseControllers;
using BBUnity.LoadingControllers.References;

namespace BBUnity.LoadingControllers {
    
    /// <summary>
    /// LoadingController allows a single loading screen to be shown to the user while
    /// loading of the game / levels is done in the background.
    /// </summary>
    public class LoadingScreenController : Controller {

        /// <summary>
        /// List of avalible Scene References. These are stored 
        /// </summary>
        [SerializeField, Tooltip("The loading scenes which are avalible to the loading scene controller")]
        private List<LoadingScreenReference> _loadableScenes;

        public int NumberOfAvalibleLoadingScreens { get { return _loadableScenes.Count; } }
        // public int NumberOfCachedScenes { get { return _avalibleLoadingScreens.Count; } }

        private void Awake() {
            // if(_avalibleLoadingScreens == null) {
            //     _avalibleLoadingScreens = new List<SceneReference>();
            // }
        }

        private void Start() {
            
        }

        private void AddAvalibleScene(SceneReference loadingScene) {
            // _avalibleLoadingScreens.Add(loadingScene);
        }


        /// <summary>
        /// Preloads the default loading screen
        /// </summary>
        // public static void PreloadDefaultLoadingScreen() {

        // }

        public static void ShowDefaultLoadingScreen(Action<LoadingScreen> onShow) {

        }

        public static LoadingController CreateOrFind() {
            LoadingController controller = FindObjectOfType<LoadingController>();
            if(!controller) {
                controller = Utilities.CreateGameObject<LoadingController>("Loading Scene Controller");
            }

            return controller;
        }

        public static LoadingController CreateOrFind(SceneReference loadingScene = null) {
            return Utilities.Tap(CreateOrFind(), (LoadingController controller) => {
                // controller.AddAvalibleScene(loadingScene);
            });
        }

        public static LoadingController CreateOrFind(List<SceneReference> loadingScenes = null) {
            return Utilities.Tap(CreateOrFind(), (LoadingController controller) => {
                // controller.AddAvalibleScenes(loadingScenes);
            });
        }
    }
}