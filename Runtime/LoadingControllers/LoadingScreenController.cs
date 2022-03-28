using UnityEngine;

using System;
using System.Collections.Generic;

using BBUnity.BaseControllers;
using BBUnity.SceneControllers;

namespace BBUnity.LoadingControllers {

    public class LoadingScreenReference {

        /// <summary>
        /// The scene which is going to be loaded
        /// </summary>
        SceneReference _sceneReference;

        /// <summary>
        /// The operation which is handling the loading of the scene
        /// </summary>
        AsyncOperation _loadingOperation;

        /// <summary>
        /// The loading screen itself which was loaded from the scene
        /// </summary>
        LoadingScreen _loadingScreen;

        public void Show() {

        }
    }

    /// <summary>
    /// LoadingScreenController allows a single loading screen to be shown to the user while
    /// loading of the game / levels is done in the background.
    /// </summary>
    public class LoadingScreenController : SceneController {

        [SerializeField, Tooltip("The loading scenes which are avalible to the loading scene controller")]
        private List<SceneReference> _avalibleScenes;

        /// <summary>
        /// The LoadingScreens which have been loaded by the system
        /// </summary>
        private Dictionary<string, LoadingScreenReference> _cachedScenes;

        private void Awake() {
            Setup();

            SetInstance(this);
        }

        private void Start() {
            
        }

        private void Setup() {
            if(_avalibleScenes == null) {
                _avalibleScenes = new List<SceneReference>();
            }

            if(_cachedScenes == null) {
                _cachedScenes = new Dictionary<string, LoadingScreenReference>();
            }
        }

        private void AddAvalibleScene(SceneReference loadingScene) {
            _avalibleScenes.Add(loadingScene);
        }

        private void AddAvalibleScenes(List<SceneReference> loadingScenes) {
            foreach(SceneReference loadingScene in loadingScenes) {
                _avalibleScenes.Add(loadingScene);
            }
        }

        /*
         * Static Access
         */

        private static LoadingScreenController _Instance;

        private LoadingScreenController Instance {
            get {
                return _Instance;
            }
        }

        private void SetInstance(LoadingScreenController instance, bool dontDestoryOnLoad = true) {
            _Instance = instance;
            if(dontDestoryOnLoad) {
                DontDestroyOnLoad(this);
            }
        }

        public int NumberOfScenes {
            get { return Instance._avalibleScenes.Count; }
        }

        public int NumberOfCachedScenes {
            get { return Instance._cachedScenes.Count; }
        }

        /// <summary>
        /// Preloads the default loading screen
        /// </summary>
        public static void PreloadDefaultLoadingScreen() {

        }

        public static void ShowDefaultLoadingScreen(Action<LoadingScreen> onShow) {

        }

        public static LoadingScreenController CreateOrFind() {
            LoadingScreenController controller = FindObjectOfType<LoadingScreenController>();
            if(!controller) {
                controller = Utilities.CreateGameObject<LoadingScreenController>("Loading Scene Controller");
            }

            return controller;
        }

        public static LoadingScreenController CreateOrFind(SceneReference loadingScene = null) {
            return Utilities.Tap(CreateOrFind(), (LoadingScreenController controller) => {
                controller.AddAvalibleScene(loadingScene);
            });
        }

        public static LoadingScreenController CreateOrFind(List<SceneReference> loadingScenes = null) {
            return Utilities.Tap(CreateOrFind(), (LoadingScreenController controller) => {
                controller.AddAvalibleScenes(loadingScenes);
            });
        }
    }
}