using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsScroller : MonoBehaviour
{
    public float scrollSpeed = 50f; // Velocidade do movimento
    public RectTransform creditsText; // Referência ao RectTransform do texto
    public float endPositionY = 1000f; // Posição final no eixo Y (acima da tela)
    public Button exitButton; // Botão para voltar ao menu principal

    private float startPositionY; // Posição inicial do texto
    private bool hasReachedEnd = false; // Verifica se os créditos já chegaram ao fim

    void Start()
    {
        // Salva a posição inicial do texto
        startPositionY = creditsText.anchoredPosition.y;


        // Configura o botão de saída para retornar ao menu principal
        if (exitButton != null)
        {
            exitButton.onClick.AddListener(ReturnToMainMenu);
        }
    }

    void Update()
    {
        // Move o texto para cima
        if (!hasReachedEnd)
        {
            creditsText.anchoredPosition += new Vector2(0, scrollSpeed * Time.deltaTime);

            // Verifica se o texto atingiu a posição final
            if (creditsText.anchoredPosition.y >= endPositionY)
            {
                hasReachedEnd = true;
                ReturnToMainMenu(); // Retorna automaticamente ao menu principal
            }
        }
    }

    // Voltar ao menu principal
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Substitua "MainMenu" pelo nome exato da sua cena do menu principal
    }
}
