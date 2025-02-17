using UnityEngine;

public class UiManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI score;
    private GameManager _gm;

    private void Awake()
    {
        _gm = GameManager.Instance;
    }

    private void Update()
    {
        score.text = $"Score: {_gm.ScoreManager.score}";
    } 
}
