using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score { get; private set; }
    private GameManager _gm;
    public int BestScore { get; private set; } = 0;

    private void Awake()
    {
        _gm = GameManager.Instance;
        _gm.RupeeManager.OnCollected += RupeeCollectedHandler;
    }

    private void Start()
    {
        BestScore = PlayerPrefs.GetInt("best-score", 0);
    }

    private void RupeeCollectedHandler(Rupee rupee)
    {
        score += rupee.Data.score;
        if (score > BestScore)
        {
            BestScore = score;
            PlayerPrefs.SetInt("best-score", BestScore);
        }
    }

    private void OnDestroy()
    {
        _gm.RupeeManager.OnCollected -= RupeeCollectedHandler;
    }

    public void StartGame()
    {
        score = 0;
    }
}
