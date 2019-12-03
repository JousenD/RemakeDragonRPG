using System.Collections;
using UnityEngine;

namespace RPG.SceneManagement
{
    public class Fader : MonoBehaviour
    {

        CanvasGroup canvasGroup;
        Coroutine currentlyActiveFade = null;

        private void Start() {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        public void FadeOutInmediate()
        {
            canvasGroup.alpha = 1;
        }

        private IEnumerator FadeRoutine(float target,float time)
        {
            while (!Mathf.Approximately(canvasGroup.alpha, target))
            {
                canvasGroup.alpha = Mathf.MoveTowards(canvasGroup.alpha, target,Time.deltaTime / time);
                yield return null;
            }
        }

        public Coroutine Fade (float target, float time)
        {
            if (currentlyActiveFade != null)
            {
                StopCoroutine(currentlyActiveFade);
            }
            currentlyActiveFade = StartCoroutine(FadeRoutine(target, time));
            return currentlyActiveFade;
        }


        public Coroutine FadeOut(float time)
        {
            return Fade(1, time);
        }

        public Coroutine FadeIn(float time)
        {
            return Fade(0, time);
        }
    }
}

