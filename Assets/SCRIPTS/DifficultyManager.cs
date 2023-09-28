using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    #region Singleton

    private static DifficultyManager instance = null;

    public static DifficultyManager Instance
    {
        get => instance;
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    #endregion

    public int difficulty = 1;
    
    public void SetDifficulty(int diff)
    {
        difficulty = diff;
    }
}