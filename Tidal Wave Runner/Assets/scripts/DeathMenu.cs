using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour
{
    public string mainMenuLevel;
    public Button pauseButton; // Referência ao botão de pausa

    private void OnEnable()
    {
        // Desativa o botão de pausa
        if (pauseButton != null)
        {
            pauseButton.interactable = false;
        }

        // Toca a música da tela de morte
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayDeathSound();
        }
    }

    private void OnDisable()
    {
        // Para o som de morte sem destruir o AudioSource
        if (AudioManager.instance != null)
        {
            AudioManager.instance.StopDeathSound();
        }

        // Reativa o botão de pausa
        if (pauseButton != null)
        {
            pauseButton.interactable = true;
        }
    }

    public void RestartGame()
    {
        // Para o som de morte ao reiniciar
        if (AudioManager.instance != null)
        {
            AudioManager.instance.StopDeathSound();
        }

        FindObjectOfType<GameManager>().Reset();
    }

    public void QuitToMain()
    {
        // Para o som de morte ao sair para o menu principal
        if (AudioManager.instance != null)
        {
            AudioManager.instance.StopDeathSound();
        }

        SceneManager.LoadScene(mainMenuLevel);
    }
}
