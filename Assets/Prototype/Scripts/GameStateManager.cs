using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Prototype.Scripts
{
    public class GameStateManager : MonoBehaviour {

        public GameManager GameManager;

        public LevelsData LevelsData;

        public event EventHandler OnGameWon;
        public event EventHandler OnGameLose;
        public event EventHandler OnNewRound;

        public bool HasNextLevel
        {
            get { return (nextIndex <= lastIndex); }
        }

        public int CurrentIndex
        {
            get { return LevelsData.Levels.ToList().IndexOf(SceneManager.GetActiveScene().name); }
        }
        private int nextIndex
        {
            get { return CurrentIndex + 1; }
        }
        private int lastIndex
        {
            get { return LevelsData.Levels.Length - 1; }
        }

        // Use this for initialization
        void Start () {
            GameManager.PropertyChanged += GameManager_PropertyChanged;
            GameManager.Photons.OnItemRemoved += Photons_OnItemRemoved;
        }

        private void Photons_OnItemRemoved(Photon[] removedItems)
        {
            if(!TryEnding())
            {
                TrySetNewRound();
            }
        }

        private void GameManager_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (!TryEnding())
            {
                TrySetNewRound();
            }
        }

        private bool TryEnding()
        {
            if(PassLoseCondition())
            {
                if (OnGameLose != null) OnGameLose(this, new EventArgs());
                return true;
            }
            else if (PassWinConditions())
            {
                if (OnGameWon != null) OnGameWon(this, new EventArgs());
                return true;
            }

            return false;
        }

        private void TrySetNewRound()
        {
            if(GameManager.Photons.Count == 0 && !GameManager.IsAllPhotonsReceived())
            {
                GameManager.ResetReceivers();
                if (OnNewRound != null) OnNewRound(this, new EventArgs());
            }
        }

        private bool PassWinConditions()
        {
            return GameManager.IsAllPhotonsReceived();
        }

        private bool PassLoseCondition()
        {
            return (GameManager.Photons.Count == 0 && GameManager.PhotonCount == 0 && !PassWinConditions());
        }

        public void Reset()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void LoadNextLevel()
        {
            if (HasNextLevel)
            {
                SceneManager.LoadScene(LevelsData.Levels[nextIndex]);
            }
        }
    }
}
