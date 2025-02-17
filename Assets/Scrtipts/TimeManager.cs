using System;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [Range(20f, 3600f)]
    public float duration = 20f;
    public float Remaining { get; private set; }
    public bool Running { get; private set; }
    public event Action OnTimeUp;
    private GameManager _gm;

    private void Awake()
    {
        _gm = GameManager.Instance;
    }

    public void Update()
    {
        if (Running)
        {
            Tick(Time.deltaTime);
        }
    }

    private void Tick(float deltaTime)
    {
        Remaining -= deltaTime;
        if (Remaining <= 0f)
        {
            Remaining = 0f;
            Running = false;
            OnTimeUp?.Invoke();
        }
    }

    public void StartTimer()
    {
        Remaining = duration;
        Running = true;
    }

    public void StopTimer()
    {
        Running = false;
    }
}
