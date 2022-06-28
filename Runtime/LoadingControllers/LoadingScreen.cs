using UnityEngine;


namespace BBUnity.LoadingControllers {

    /// <summary>
    /// A top level 
    /// </summary>
    public class LoadingScreen : BaseBehaviour {

        /// <summary>
        /// The loading operation whos loading is linked to the loading
        /// scene, can be null.
        /// </summary>
        private AsyncOperation _loadingOperation = null;

        private float CurrentProgress {
            get { return _loadingOperation != null ? Mathf.Clamp01(_loadingOperation.progress / 0.9f) : 0.0f; }
        }

        private void Start() {}
        private void Update() {}

        /*
         * Virtual methods which can be utilized by the subclass
         */

        protected virtual void OnShow() {}
        protected virtual void OnProgressUpdate(float progress) {}
        protected virtual void OnLoadingComplete() {}
        protected virtual void OnHide() {}
    }
}


