using UnityEngine;
using UnityEngine.SceneManagement; // Necessário para gerenciar cenas

public class MainMenu : MonoBehaviour
{
    public string playGameLevel; // Nome da cena do jogo
    public string creditsScene; // Nome da cena de créditos
    public string InformativeScreen;

    void Start()
    {
        // Verifica se o GameManager existe na cena e o destrói
        GameManager existingGameManager = FindObjectOfType<GameManager>();
        if (existingGameManager != null)
        {
            Destroy(existingGameManager.gameObject);
        }
    }

    // Método para iniciar o jogo
    public void PlayGame()
    {
        SceneManager.LoadScene(playGameLevel); // Carrega a cena do jogo
    }

    // Método para abrir os créditos
    public void OpenCredits()
    {
        SceneManager.LoadScene(creditsScene); // Carrega a cena dos créditos
    }

    public void OpenInfos()
    {
        SceneManager.LoadScene(InformativeScreen);
    }

    // Método para sair do jogo
    public void QuitGame()
    {
        Application.Quit(); // Fecha o aplicativo (não funciona no editor)
    }
}
