using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class RupeeManager : MonoBehaviour
{
    public Transform spawner;
    public Rupee prefab;
    public Transform container;
    [Range(0, 10)]
    public float spawnDelay = 3f;
    public List<RupeeData> rupeeDataList = new List<RupeeData>();
    private readonly List<Rupee> _rupees = new List<Rupee>();
    private Coroutine _spawnRoutine;

    public event Action<Rupee> OnCollected;

    public void ResetSpawning()
    {
        StopSpawning();
        ClearRupees();
        StartSpawning();
    }

    private void StartSpawning()
    {
        _spawnRoutine = StartCoroutine(SpawnRoutine());
    }

    public void StopSpawning()
    {
        if (_spawnRoutine != null)
        {
            StopCoroutine(_spawnRoutine);
            _spawnRoutine = null;
        }
        else{
            return;
        }
    }

    public void ClearRupees()
    {
        StopSpawning();
        for (var i = _rupees.Count - 1; i >= 0; i--)
        {
            RemoveRupee(_rupees[i]);
        }
        _rupees.Clear();
    }

    private void Spawn()
    {
        var data = rupeeDataList[UnityEngine.Random.Range(0, rupeeDataList.Count)]; // tirage o zor
        var rupee = Instantiate(prefab, spawner.position, Quaternion.identity); // instanciation
        rupee.transform.parent = container; // parentage
        rupee.Data = data; // assignation des données
        AddRupee(rupee); // ajout à la liste
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private void AddRupee(Rupee rupee)
    {
        rupee.OnCollected += RupeeCollectedHandler;
        _rupees.Add(rupee);
    }

    private void RemoveRupee(Rupee rupee)
    {
        rupee.OnCollected -= RupeeCollectedHandler;
        _rupees.Remove(rupee);
        Destroy(rupee.gameObject);
    }

    private void RupeeCollectedHandler(Rupee rupee)
    {
        OnCollected?.Invoke(rupee);
        RemoveRupee(rupee);
    }
}
