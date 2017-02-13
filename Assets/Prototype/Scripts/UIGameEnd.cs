using UnityEngine;

namespace Assets.Prototype.Scripts
{
    public class UIGameEnd : MonoBehaviour {

        public GameStateManager StateManager;
        public GameObject WinPanel;
        public GameObject LosePanel;

        // Use this for initialization
        void Start () {
            StateManager.OnGameWon += StateManager_OnGameWon;
            StateManager.OnGameLose += StateManager_OnGameLose;
        }

        private void StateManager_OnGameLose(object sender, System.EventArgs e)
        {
            WinPanel.SetActive(false);
            LosePanel.SetActive(true);
        }

        private void StateManager_OnGameWon(object sender, System.EventArgs e)
        {
            WinPanel.SetActive(true);
            LosePanel.SetActive(false);
        }

        public void Replay()
        {
            StateManager.Reset();
        }

        public void Next()
        {
            if(StateManager.HasNextLevel) StateManager.LoadNextLevel();
        }
    }
}
