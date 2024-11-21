using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    // Durée totale du timer en secondes (5 minutes = 300 secondes)
    public float timerDuration = 300f;
    private float timeRemaining;
    private bool timerRunning = false;

    public GameObject victoryScreen;
    public bool isVictorious;

    public float restartTimer = 5f; // Temps avant le redémarrage (en secondes)
    private float restartTimeRemaining; // Temps restant avant le redémarrage
    private bool restartTimeRunning = false; // Indique si le timer de redémarrage est actif

    void Start()
    {
        restartTimeRunning = false;
        victoryScreen.SetActive(false);
        Time.timeScale = 1f;
        // Initialisation du timer principal
        timeRemaining = timerDuration;
        timerRunning = true; // Le timer commence automatiquement
    }

    void Update()
    {
        // Timer principal
        if (timerRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timerRunning = false;
                timeRemaining = 0;
                Victorious();
            }
        }

        // Timer de redémarrage
        if (restartTimeRunning)
        {
            if (restartTimeRemaining > 0)
            {
                restartTimeRemaining -= Time.deltaTime;
            }
            else
            {
                restartTimeRunning = false;
                restartTimeRemaining = 0;
                RestartGame();
            }
        }
    }

    public void Victorious()
    {
        victoryScreen.SetActive(true); // Affiche l'écran de victoire
        Time.timeScale = 0f; // Met le jeu en pause
        isVictorious = true; // Marque la victoire
        StartRestartTimer(); // Démarre le timer de redémarrage
    }

    private void StartRestartTimer()
    {
        restartTimeRunning = true; // Active le timer de redémarrage
        restartTimeRemaining = restartTimer; // Initialise le temps restant
        Time.timeScale = 0f; // Assurez-vous que le temps continue normalement pour le redémarrage
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Recharge la scène actuelle
    }
}