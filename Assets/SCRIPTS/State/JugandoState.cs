using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugandoState : GameState
{
    public void Handle(GameManager gameManager)
    {

        if (Input.GetKey(KeyCode.Alpha9))
        {
            gameManager.TiempoDeJuego = 0;
        }

        if (gameManager.TiempoDeJuego <= 0)
        {
            gameManager.FinalizarCarrera();
        }

        if (gameManager.ConteoRedresivo)
        {
            gameManager.ConteoParaInicion -= T.GetDT();
            if (gameManager.ConteoParaInicion < 0)
            {
                gameManager.EmpezarCarrera();
                gameManager.ConteoRedresivo = false;
            }
        }
        else
        {
            //baja el tiempo del juego
            gameManager.TiempoDeJuego -= T.GetDT();
        }

        if (gameManager.ConteoRedresivo)
        {
            if (gameManager.ConteoParaInicion > 1)
            {
                gameManager.ConteoInicio.text = gameManager.ConteoParaInicion.ToString("0");
            }
            else
            {
                gameManager.ConteoInicio.text = "GO";
            }
        }

        gameManager.ConteoInicio.gameObject.SetActive(gameManager.state is JugandoState &&
                                                      (gameManager.ConteoParaInicion > 0));
        gameManager.TiempoDeJuegoText.text = gameManager.TiempoDeJuego.ToString("00");
    }
}