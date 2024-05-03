// using System;

// using BBUnity.BaseControllers;
// using BBUnity.LoadingControllers;

// using UnityEngine.SceneManagement;

// namespace BBUnity.SceneControllers {

//     /// <summary>
//     /// SceneController, 
//     /// </summary>
//     public class SceneController : Controller {

//         // private LoadingScreenController _loadingSceneController;

//         private void Awake() {
//             // _loadingSceneController = CreateOrFindLoadingScreenController();

//             SetInstance(this);
//         }

//         private void Start() {

//         }

//         // private LoadingScreenController CreateOrFindLoadingScreenController() {
//         //     return LoadingScreenController.CreateOrFind();
//         // }

//         /*
//          * Transition Scene
//          * Transitions to a new scene. E.g. Single Load Mode
//          */

//         /// <summary>
//         /// Transitions the scene to a new scene, allows the default (or first) loading screen to
//         /// be presented
//         /// </summary>
//         /// <param name="sceneReference"></param>
//         /// <param name="displayLoadingScene"></param>
//         // public void TransitionScene(SceneReference sceneReference, bool displayLoadingScene = false) {

//         // }

//         // public void TransitionScene(int sceneBuildIndex, bool displayLoadingScene = false) {

//         // }

//         // public void TransitionScene(string sceneName, bool displayLoadingScene = false) {

//         // }

//         // public void TransitionScene(SceneReference sceneReference, Action<LoadSceneState> action = null) {

//         // }

//         // public void TransitionScene(int sceneBuildIndex, Action<LoadSceneState> action = null) {

//         // }

//         // public void TransitionScene(string sceneName, Action<LoadSceneState> action = null) {

//         // }

//         // public void TransitionScene(SceneReference sceneReference, bool displayLoadingScene = false, Action<LoadSceneState> action = null) {
            
//         // }

//         // public void TransitionScene(int sceneBuildIndex, bool displayLoadingScene = false, Action<LoadSceneState> action = null) {

//         // }

//         // public void TransitionScene(string sceneName, bool displayLoadingScene = false, Action<LoadSceneState> action = null) {

//         // }

//         /*
//          * Load Scene 
//          * Loads a scene into the current scene, Sync versions
//          */

//         // public void LoadScene(SceneReference sceneReference) {

//         // }

//         // public void LoadScene(int sceneBuildIndex) {

//         // }

//         // public void LoadScene(string sceneName) {

//         // }

//         /*
//          * Load Scene 
//          * Loads a scene into the current scene, Async versions
//          */

//         // public void LoadSceneAsync(SceneReference sceneReference) {

//         // }

//         // public void LoadSceneAsync(int sceneBuildIndex) {

//         // }

//         // public void LoadSceneAsync(string sceneName) {

//         // }




//         /*
//          * Static Access
//          */

//         private static SceneController _Instance;

//         private SceneController Instance {
//             get {
//                 return _Instance;
//             }
//         }

//         private void SetInstance(SceneController instance, bool dontDestoryOnLoad = true) {
//             _Instance = instance;
//             if(dontDestoryOnLoad) {
//                 DontDestroyOnLoad(this);
//             }
//         }

//         public static SceneController CreateOrFind() {
//             SceneController controller = FindObjectOfType<SceneController>();
//             if(!controller) {
//                 controller = Utilities.CreateGameObject<SceneController>("Scene Controller");
//             }

//             return controller;
//         }
//     }
// }

