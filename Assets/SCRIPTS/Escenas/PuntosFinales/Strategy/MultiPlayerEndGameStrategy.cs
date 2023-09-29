using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MultiPlayerEndGameStrategy : EndGameStrategy
{
    private GameObject player2Car;
    private Image player1WinnerImage;
    private TextMeshProUGUI player1PointsText;
    private Image player2WinnerImage;
    private TextMeshProUGUI player2PointsText;
    private int timeToWait = 10;

    public MultiPlayerEndGameStrategy(GameObject player2Car, Image player1WinnerImage, TextMeshProUGUI player1PointsText, Image player2WinnerImage, TextMeshProUGUI player2PointsText, int timeToWait)
    {
        this.player2Car = player2Car;
        this.player1WinnerImage = player1WinnerImage;
        this.player1PointsText = player1PointsText;
        this.player2WinnerImage = player2WinnerImage;
        this.player2PointsText = player2PointsText;
        this.timeToWait = timeToWait;
    }

    public IEnumerator ShowEndGame()
    {
        player2Car.SetActive(true);

        if (DatosPartida.LadoGanadaor == DatosPartida.Lados.Izq)
        {
            player1WinnerImage.enabled = true;
            player1PointsText.text = "$" + DatosPartida.PtsGanador;
            player2PointsText.text = "$" + DatosPartida.PtsPerdedor;
        }
        else
        {
            player2WinnerImage.enabled = true;
            player1PointsText.text = "$" + DatosPartida.PtsPerdedor;
            player2PointsText.text = "$" + DatosPartida.PtsGanador;
        }
        

        
        yield return new WaitForSeconds(timeToWait);
        SceneManager.LoadScene(0);
    }
}
