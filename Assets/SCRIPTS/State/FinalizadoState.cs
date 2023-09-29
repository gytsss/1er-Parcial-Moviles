using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalizadoState : GameState
{
    public void Handle(GameManager gameManager)
    {
        gameManager.TiempEspMuestraPts -= Time.deltaTime;
        if (gameManager.TiempEspMuestraPts <= 0)
        {
            if (gameManager.playersCount == 1) 
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            else if (gameManager.playersCount == 2)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
