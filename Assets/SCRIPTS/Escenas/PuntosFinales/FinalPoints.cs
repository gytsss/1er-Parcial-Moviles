using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalPoints : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI player1PointsText;
    [SerializeField] private TextMeshProUGUI player2PointsText;
    [SerializeField] private GameObject player2Car;
    [SerializeField] private Image player2Image;
    [SerializeField] private Image player1WinnerImage;
    [SerializeField] private Image player2WinnerImage;
    [SerializeField] private int timeToWait = 10;

    private EndGameStrategy endGameStrategy;

    void Start()
    {
        player1WinnerImage.enabled = false;
        player2WinnerImage.enabled = false;
        player2Car.SetActive(false);


        if (GameManager.Instancia.playersCount == 1)
        {
            endGameStrategy = new SinglePlayerEndGameStrategy(player1WinnerImage, player1PointsText, player2Image,
                player2PointsText, timeToWait);
        }
        else if (GameManager.Instancia.playersCount == 2)
        {
            endGameStrategy = new MultiPlayerEndGameStrategy(player2Car, player1WinnerImage, player1PointsText,
                player2WinnerImage, player2PointsText, timeToWait);
        }

        StartCoroutine(endGameStrategy.ShowEndGame());
    }

}