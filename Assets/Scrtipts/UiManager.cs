using System;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI score;
    public TMPro.TextMeshProUGUI timer;
    private GameManager _gm;

    private void Awake()
    {
        _gm = GameManager.Instance;
    }

    private void Update()
    {
        score.text = $"Score: {_gm.ScoreManager.score}";
        timer.text = $"{TimeSpan.FromSeconds(_gm.TimeManager.Remaining):mm\\:ss}"; // Update timer text
    }
}
