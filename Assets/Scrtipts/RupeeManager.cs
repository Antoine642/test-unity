using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RupeeManager : MonoBehaviour
{
    public Transform spawner;
    public Rupee prefab;
    public Transform container;
    [Range(2, 10)]
    public float spawnDelay = 2f;
    private readonly List<Rupee> _rupees = new List<Rupee>();
    private Coroutine _spawnRoutine;

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
        _rupees.Add(rupee); // Add the rupee to the list
        Debug.Log("Rupee added : " + _rupees.Count); // Log the number of rupees
    }

    private void RemoveRupee(Rupee rupee)
    {
        _rupees.Remove(rupee); // Remove the rupee from the list
        Debug.Log("Rupee removed : " + _rupees.Count); // Log the number of rupees
    }
}
