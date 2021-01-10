using UnityEngine;


namespace BBUnity {

    /// <summary>
    /// Representation of a single / Multiple loading scene which can be shown through-out
	/// the game. This should be used in conjuction with the LoadingSceneController class for maximum useful-ness
    /// </summary>
    public class LoadingScreen : BaseBehaviour {

        /// <summary>
        /// The loading operation whos loading is linked to the loading
        /// scene. This can be null if the loading scene has been displayed
        /// by the developer through the .show api
        /// </summary>
        private AsyncOperation _loadingOperation = null;

        private float CurrentProgress {
            get { return _loadingOperation != null ? Mathf.Clamp01(_loadingOperation.progress / 0.9f) : 0.0f; }
        }


        private void Awake() {
            
        }

        private void Start() {
            
        }

        private void Update() {
            
        }

        /*
         * Public Methods
         */



        /*
         * Virtual methods which can be utilized by the subclass
         */

        protected virtual void OnShow() {
            
        }

        protected virtual void OnProgressUpdate(float progress) {

        }

        protected virtual void OnLoadingComplete() {

        }

        protected virtual void OnHide() {

        }
    }
}


