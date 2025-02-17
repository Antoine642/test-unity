using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public RupeeManager RupeeManager { get; private set; }
    public ScoreManager ScoreManager { get; private set; }
    public UiManager UiManager { get; private set; }
    public TimeManager TimeManager { get; private set; }
    public AudioManager AudioManager { get; private set; }
    public Player player;
    public bool IsGameStarted { get; private set; }

    private void Awake()
    {
        // si pas d'instance, on en crée celle-ci
        if (Instance == null){ Instance = this;}
        // si une instance existe déjà, on détruit celle-ci
        else if (Instance != this){ Destroy(gameObject);}

        RupeeManager = GetComponent<RupeeManager>();
        ScoreManager = GetComponent<ScoreManager>();
        UiManager = GetComponent<UiManager>();
        TimeManager = GetComponent<TimeManager>();
        AudioManager = GetComponent<AudioManager>();
    }
    private void TimeUpHandler()
    {
        StopGame();
        FreezePlayer();
    }

    public void StartGame()
    {
        TimeManager.OnTimeUp += TimeUpHandler;

        ScoreManager.StartGame();
        RupeeManager.ResetSpawning();
        UiManager.StartGame();
        TimeManager.StartTimer();
        AudioManager.StartGame();
        UnfreezePlayer();
        IsGameStarted = true;
    }

    public void StopGame()
    {
        RupeeManager.StopSpawning();
        RupeeManager.ClearRupees();
        TimeManager.StopTimer();
        UiManager.StopGame();
        AudioManager.StopGame();
        ResetPlayerPosition();
        FreezePlayer();
        IsGameStarted = false;
    }

    private void FreezePlayer()
    {
        player.Freeze();
    }

    private void UnfreezePlayer()
    {
        player.Unfreeze();
    }

    private void ResetPlayerPosition()
    {
        
        player.ResetPosition(new Vector3(-9.42f, -3.2f, 0f));
    }
}