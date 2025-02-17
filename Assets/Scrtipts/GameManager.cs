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
    public Player player;
    public Transform playerStartPosition;
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
    }

    private void Start()
    {
       TimeManager.OnTimeUp += TimeUpHandler;
    }

    private void TimeUpHandler()
    {
        StopGame();
        FreezePlayer();
    }

    public void StartGame()
    {
        ScoreManager.Reset();
        RupeeManager.ResetSpawning();
        UiManager.StartGame();
        TimeManager.StartTimer();
        UnfreezePlayer();
        ResetPlayerPosition();
        IsGameStarted = true;
    }

    public void StopGame()
    {
        RupeeManager.StopSpawning();
        RupeeManager.ClearRupees();
        TimeManager.StopTimer();
        UiManager.StopGame();
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
        player.ResetPosition(playerStartPosition.position);
    }
}