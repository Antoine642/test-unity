using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score { get; private set; }
    private GameManager _gm;

    private void Awake()
    {
        _gm = GameManager.Instance;
        _gm.RupeeManager.OnCollected += RupeeCollectedHandler;
    }

    private void RupeeCollectedHandler(Rupee rupee)
    {
        score ++;
        Debug.Log($"Score: {score}");
    }

    private void OnDestroy()
    {
        _gm.RupeeManager.OnCollected -= RupeeCollectedHandler;
    }

    public void Reset()
    {
        score = 0;
    }
}
