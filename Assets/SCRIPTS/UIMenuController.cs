using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenuController : MonoBehaviour
{
    public void OnClickedEasy()
    {
        DifficultyManager.Instance.SetDifficulty(1);
    }
    public void OnClickedMedium()
    {
        DifficultyManager.Instance.SetDifficulty(2);
    }
    public void OnClickedHard()
    {
        DifficultyManager.Instance.SetDifficulty(3);
    }
}
