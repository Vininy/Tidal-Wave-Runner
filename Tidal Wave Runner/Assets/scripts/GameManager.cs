using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public PlayerController thePlayer;
    private Vector3 playerStartPoint;

    private PlatformDestroyer[] platformList;

    private ScoreManager theScoreManager;

    public DeathMenu theDeathScreen;
    public BackgroundFollow background;

    // Referência ao tsunami
    public TsunamiController tsunami;
    void Start()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.StopDeathSound(); // Para o som da morte, caso esteja tocando
            AudioManager.instance.StopGameMusic();  // Certifique-se de que outras músicas não estejam tocando
            AudioManager.instance.PlayGameMusic();  // Inicia a música do jogo
        }
        if (theDeathScreen == null)
        {
            theDeathScreen = FindObjectOfType<DeathMenu>();
        }

        if (thePlayer == null)
        {
            thePlayer = FindObjectOfType<PlayerController>();
        }

        // Garantir referência ao tsunami
        if (tsunami == null)
        {
            tsunami = FindObjectOfType<TsunamiController>();
        }


        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;

        theScoreManager = FindObjectOfType<ScoreManager>();
    }

    void Update()
    {
        
    }

    public void RestartGame()
    {
        theScoreManager.scoreIncreasing = false;
        thePlayer.gameObject.SetActive(false);
        background.ResetPosition();
        if (theDeathScreen != null)
        {
            theDeathScreen.gameObject.SetActive(true);
        }

        AudioManager.instance.PlayDeathSound();
        AudioManager.instance.StopGameMusic();
    }

    public void Reset()
    {
        if (theDeathScreen != null)
        {
            theDeathScreen.gameObject.SetActive(false);
        }

        platformList = FindObjectsOfType<PlatformDestroyer>();
        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }

        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);

        // Reseta o tsunami ao iniciar um novo jogo
        if (tsunami != null)
        {
            tsunami.ResetTsunami(); // Volta à posição inicial
        }

        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;

        AudioManager.instance.PlayGameMusic();
    }

    public void ResumeGame()
    {
        // Retoma o jogo sem alterar a posição atual do tsunami
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayGameMusic();
        }
    }
}
