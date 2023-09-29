using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SinglePlayerEndGameStrategy : EndGameStrategy
{
    private Image player1WinnerImage;
    private TextMeshProUGUI player1PointsText;
    private Image player2Image;
    private TextMeshProUGUI player2PointsText;
    private int timeToWait = 10;

    public SinglePlayerEndGameStrategy(Image player1WinnerImage, TextMeshProUGUI player1PointsText, Image player2Image,
        TextMeshProUGUI player2PointsText, int timeToWait)
    {
        this.player1WinnerImage = player1WinnerImage;
        this.player1PointsText = player1PointsText;
        this.player2Image = player2Image;
        this.player2PointsText = player2PointsText;
        this.timeToWait = timeToWait;
    }

    public IEnumerator ShowEndGame()
    {
        player1WinnerImage.enabled = true;
        player1PointsText.text = "$" + DatosPartida.PtsGanador;
        player2Image.enabled = false;
        player2PointsText.enabled = false;

        yield return new WaitForSeconds(timeToWait);


        SceneManager.LoadScene("Credits");
    }
}