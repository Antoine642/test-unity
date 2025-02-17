using System;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [Range(60f, 3600f)]
    public float duration = 120f;
    public float Remaining { get; private set; }
    public bool Running { get; private set; }
    public event Action OnTimeUp;

    public void Reset()
    {
        Remaining = duration;
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
            // Running = false;
            OnTimeUp?.Invoke();
        }
    }

    public void StartTimer()
    {
        Running = true;
    }

    public void StopTimer()
    {
        Running = false;
    }
}
