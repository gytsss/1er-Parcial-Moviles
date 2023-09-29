using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalibrandoState : GameState
{
    public void Handle(GameManager gameManager)
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.W) || Input.GetMouseButtonDown(0))
        {
            gameManager.Player1.Seleccionado = true;

            if (gameManager.playersCount == 2)
                gameManager.Player2.Seleccionado = true;
        }
#elif UNITY_ANDROID || UNITY_IOS
        if (Input.GetMouseButtonDown(0))
        {
            gameManager.Player1.Seleccionado = true;
        }
#elif UNITY_STANDALONE
        if (Input.GetKeyDown(KeyCode.W))
        {
            gameManager.Player1.Seleccionado = true;
        }
#endif

        if (Input.GetKeyDown(KeyCode.UpArrow) && gameManager.playersCount == 2)
        {
            gameManager.Player2.Seleccionado = true;
        }
    }
}