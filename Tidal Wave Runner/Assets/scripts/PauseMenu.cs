using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public string mainMenuLevel;
    public GameObject pauseMenu;
    public GameObject deathMenu; // Referência ao DeathMenu

    public void PauseGame()
    {
        // Verifica se o DeathMenu está ativo
        if (deathMenu != null && deathMenu.activeSelf)
        {
            // Se o DeathMenu está ativo, não permite pausar o jogo
            return;
        }

        Time.timeScale = 0f;
        pauseMenu.SetActive(true);

        // Toca o som do menu de pausa
        
        if (AudioManager.instance != null)
        {
            AudioManager.instance.StopGameMusic(); // Para a música do jogo
            AudioManager.instance.PlayPauseSound(); // Toca a música do menu de pausa
        }
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);

        if (AudioManager.instance != null)
        {
            AudioManager.instance.StopPauseSound(); // Para a música do menu de pausa
            AudioManager.instance.PlayGameMusic(); // Retoma a música do jogo
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);

        // Para o som do menu de pausa
        AudioManager.instance.StopPauseSound();
        AudioManager.instance.PlayGameMusic(); // Reinicia a música do jogo

        FindObjectOfType<GameManager>().Reset();
    }

    public void QuitToMain()
    {
        Time.timeScale = 1f;

        // Para o som do menu de pausa
        AudioManager.instance.StopPauseSound();

        SceneManager.LoadScene(mainMenuLevel);
    }
}
