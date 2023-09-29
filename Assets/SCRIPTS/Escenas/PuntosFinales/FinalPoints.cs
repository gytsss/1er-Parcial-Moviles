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

    void Start()
    {
        player1WinnerImage.enabled = false;
        player2WinnerImage.enabled = false;
        player2Car.SetActive(false);
        
        StartCoroutine(ShowEndGame());
    }

    IEnumerator ShowEndGame()
    {
        // Display the winner and points
        if (GameManager.Instancia.playersCount == 1)
        {
            player1WinnerImage.enabled = true;
            player1PointsText.text = "$" + DatosPartida.PtsGanador;
            player2Image.enabled = false;
            player2PointsText.enabled = false;
        }
        else if (GameManager.Instancia.playersCount == 2)
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
        }

       
        yield return new WaitForSeconds(timeToWait);

        
        SceneManager.LoadScene(0);
    }
}
