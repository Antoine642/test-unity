using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public RupeeManager RupeeManager { get; private set; }
    public ScoreManager ScoreManager { get; private set; }

    private void Awake()
    {
        // si pas d'instance, on en crée celle-ci
        if (Instance == null){ Instance = this;}
        // si une instance existe déjà, on détruit celle-ci
        else if (Instance != this){ Destroy(gameObject);}

        RupeeManager = GetComponent<RupeeManager>();
        ScoreManager = GetComponent<ScoreManager>();
    }

    

}