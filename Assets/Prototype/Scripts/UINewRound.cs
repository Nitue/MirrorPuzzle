using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Prototype.Scripts
{
    public class UINewRound : MonoBehaviour {

        public GameStateManager StateManager;
        public CanvasGroup NewRound;
        public Text TargetText;

        public string[] Messages;

        // Use this for initialization
        void Start () {
            StateManager.OnNewRound += StateManager_OnNewRound; ;
        }

        private void StateManager_OnNewRound(object sender, System.EventArgs e)
        {
            Flash(1f);
        }

        public void Flash(float speed)
        {
            TargetText.text = (Messages.Length > 0) ? Messages[Random.Range(0, Messages.Length)] : TargetText.text;
            NewRound.gameObject.SetActive(true);
            NewRound.alpha = 1f;
            StartCoroutine(FadeOut(speed));
        }

        private IEnumerator FadeOut(float speed)
        {
            while (NewRound.alpha > 0f)
            {
                NewRound.alpha -= speed * Time.deltaTime;
                yield return null;
            }

            yield return null;
        }
    }
}
