using UnityEngine;

using BBUnity.BaseControllers;
using BBUnity.SceneControllers;
using BBUnity.LoadingControllers;

namespace BBUnity.MobileControllers {

    [System.Serializable]
    public struct MobileBootSettings {
        [SerializeField, Tooltip("The delay on the splash screen, this overrides the default wait for the scene to load")]
        public float delay;
    }

    public enum MobileDefaultSceneSelections {
        Default, //The default scene (E.g. The one containing this controller)
        GameWithLoadingScreen, //The game scene with a loading screen
        GameWithoutLoadingScreen, //The game scene without a loading screen
        LoadingScreenOnly //The loading screen
    }

    [System.Serializable]
    public struct MobileSceneSettings {

        [SerializeField]
        public MobileDefaultSceneSelections defaultScene;

        [SerializeField, Tooltip("The primary game scene, if set the loading screen will be displayed and the scene will be loaded.")]
        public SceneReference gameScene;

        [SerializeField, Tooltip("The loading scene, this is displayed directly after the start-up screen.")]
        public SceneReference loadingScene;

        [SerializeField, Tooltip("Should the loading screen be cached? E.g. Kept around after first load")]
        public bool cacheLoadingScreen;
    }

    [System.Serializable]
    public struct MobileAdSettings {
        [SerializeField]
        public string iOSUnityAdId;

        [SerializeField]
        public string androidUnityAdId;
    }

    /*
     * The MobileGameController is a simplified single controller which enables the creation
     * of mobile games with minimal effort.
     * 
     * Limitations: 
     *  - Single Loading Screen for the entire game
     * 
     * The Flow: 
     *  - Boots application
     *  - Loads either the main scene or the loading scene
     */
    public class MobileGameController : Controller {

        [SerializeField]
        private MobileSceneSettings _sceneSettings = new MobileSceneSettings();

        // [SerializeField]
        // private MobileAdSettings _mobileAdSetting = new MobileAdSettings();

        /// <summary>
        /// The splash screen which is displayed, this could be null
        /// </summary>
        private SplashScreen _splashScreen;

        /// <summary>
        /// The scene controller owned by the mobileController
        /// </summary>
        private SceneController _sceneController;

        /// <summary>
        /// The loading scene controller. This is created for the user in the majority of
        /// cases but will be searched for first
        /// </summary>
        private LoadingScreenController _loadingSceneController;

        private void Awake() {
            _splashScreen = FindSplashScreen();

            _loadingSceneController = CreateLoadingSceneController();
            _sceneController = CreateSceneController();

            SetInstance(this, true);
        }

        private void Start() {
            StartLoading();
        }

        private SceneController CreateSceneController() {
            return SceneController.CreateOrFind();
        }

        private LoadingScreenController CreateLoadingSceneController() {
            return LoadingScreenController.CreateOrFind(_sceneSettings.loadingScene);
        }

        private SplashScreen FindSplashScreen() {
            return FindObjectOfType<SplashScreen>();
        }

        private void StartLoading() {
            switch(_sceneSettings.defaultScene) {
                case MobileDefaultSceneSelections.Default: {

                }return;
 
                case MobileDefaultSceneSelections.GameWithLoadingScreen: {
                    /*
                     * - Shows the loading screen
                     * - Changes to the game screen with the loading screen 
                     */
                    
                } return;
                case MobileDefaultSceneSelections.GameWithoutLoadingScreen: {

                } return;
                case MobileDefaultSceneSelections.LoadingScreenOnly: {

                } return;
            }
        }

        /*
         * Static Access
         */

        private static MobileGameController _Instance;

        private MobileGameController Instance {
            get {
                return _Instance;
            }
        }

        private void SetInstance(MobileGameController instance, bool dontDestoryOnLoad = true) {
            _Instance = instance;
            if(dontDestoryOnLoad) {
                DontDestroyOnLoad(this);
            }
        }
    }
}


