using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    private static DifficultyManager instance;

    public static DifficultyManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("DifficultyManager").AddComponent<DifficultyManager>();
            }
            return instance;
        }
    }

    public int difficulty = 1;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void SetDifficulty(int diff)
    {
        difficulty = diff;
    }
}