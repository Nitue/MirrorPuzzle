using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour {

    public GameManager GameManager;

    public event EventHandler OnGameWon;
    public event EventHandler OnGameLose;
    public event EventHandler OnNewRound;

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
        TryEnding();
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
}
