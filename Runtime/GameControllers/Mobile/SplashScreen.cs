using System;
using System.Collections;

using UnityEngine;

namespace BBUnity.GameControllers.Mobile {

    /// <summary>
    /// A simple splashscreen wrapper which allows the super fast loading of a scene
    /// to be coupled with the transition to a loading screen or another scene but
    /// under the control of the developer instead of the OS / Unity
    /// </summary>
    public class SplashScreen : BaseBehaviour {

        [SerializeField, Tooltip("The duration of the splash screen, 0 will keep it on until removed manually")]
        private float _duration = 0.0f;

        [SerializeField, Tooltip("The fade time, this will be used for automatic dismissal but will be overriden by the manual call to hide.")]
        private float _fadeDuration = 1.0f;

        /// <summary>
        /// The underlying canvas group for the splash screen
        /// </summary>
        private CanvasGroup _canvasGroup;

        public bool HasDuration {
            get { return _duration > 0.1; }
        }

        public float Duration {
            get { return _duration; }
            set { _duration = value;}
        }

        public float FadeDuration {
            get { return _fadeDuration; }
            set { _fadeDuration = value;}
        }

        private void Awake() {
            _canvasGroup = FindCanvasGroup();
            if(!_canvasGroup) {
                _canvasGroup = FindOrCreateCanvasGroup();
            }

            DontDestroyOnLoad(this);
        }

        private CanvasGroup FindCanvasGroup() {
            return GetComponentInChildren<CanvasGroup>();
        }

        private CanvasGroup FindOrCreateCanvasGroup() {
            Canvas canvas = GetComponentInChildren<Canvas>();
            if(!canvas) {
                return null;
            }

            return Utilities.AddOrGetComponent<CanvasGroup>(canvas.gameObject);
        }

        private void Update() {
            
        }

        public void SetDuration(float duration) {
            _duration = duration;
        }

        public void SetFadeDuration(float fadeDuration) {
            _fadeDuration = fadeDuration;
        }

        /// <summary>
        /// Hides the splash screen after the delay has passed
        /// </summary>
        public void Hide() {
            //if(ShouldHideWithDelay) {
            //    WaitThen(_duration, FadeThenDestroy(_duration));
            //}
        }

        public void HideWithDelay(Action onHide) {

        }

        /// <summary>
        /// Hides the SplashScreen immediately by deleting the object
        /// </summary>
        public void HideImmediately() {
            Destroy(gameObject);
        }

        private IEnumerator FadeThenDestroy(float duration) {
            float startValue = _canvasGroup.alpha;
            float time = 0;

            while (time < duration) {
                _canvasGroup.alpha = Mathf.Lerp(startValue, 1, time / duration);
                time += Time.deltaTime;
                yield return null;
            }

            Destroy(gameObject);
        }
    }
}

