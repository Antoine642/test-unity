using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class RupeeManager : MonoBehaviour
{
    public Transform spawner;
    public Rupee prefab;
    public Transform container;
     // Slider in Unity (0 to 10) step 1 (integers)
    [Range(0, 10)]

    public float spawnDelay = 3f;
    private readonly List<Rupee> _rupees = new List<Rupee>();
    private Coroutine _spawnRoutine;
    public event Action<Rupee> OnCollected;

    public void Start()
    {
        StartSpawning(); // Start the spawning
    }

    public void StartSpawning()
    {
        _spawnRoutine = StartCoroutine(SpawnRoutine()); // Start the coroutine
    }

    private void Spawn()
    {
        // Instantiate the prefab
        var rupee = Instantiate(prefab, spawner.position, Quaternion.identity);
        // Add the rupee to the list
        AddRupee(rupee);
        // Set the parent of the rupee to the container
        rupee.transform.parent = container;
    }

    private IEnumerator SpawnRoutine()
    {
        Spawn(); // Spawn a rupee
        yield return new WaitForSeconds(spawnDelay); // Wait for the delay
        StartSpawning(); // Start the spawning again
    }

    private void AddRupee(Rupee rupee)
    {
        rupee.OnCollected += RupeeCollectedHandler; // Subscribe to the event
        _rupees.Add(rupee); // Add the rupee to the list
    }

    private void RemoveRupee(Rupee rupee)
    {
        rupee.OnCollected -= RupeeCollectedHandler; // Unsubscribe from the event (prevent memory leaks)
        _rupees.Remove(rupee); // Remove the rupee from the list
    }

    private void RupeeCollectedHandler(Rupee rupee)
    {
        OnCollected?.Invoke(rupee); // Invoke the event
        RemoveRupee(rupee); // Remove the rupee
    }
}
