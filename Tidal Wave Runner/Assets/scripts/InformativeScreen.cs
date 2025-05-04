using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI; 

public class InformativeScreen : MonoBehaviour
{
    public Button mainMenuButton; 
    public Button startGameButton;

    void Start()
    {

        if (mainMenuButton != null)
        {
            mainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
        }
        else
        {
            Debug.LogError("Main Menu Button não atribuído no Inspector.");
        }

        if (startGameButton != null)
        {
            startGameButton.onClick.AddListener(OnStartGameButtonClicked);
        }
        else
        {
            Debug.LogError("Start Game Button não atribuído no Inspector.");
        }
    }


    void OnMainMenuButtonClicked()
    {

        SceneManager.LoadScene("MainMenu"); 
    }


    void OnStartGameButtonClicked()
    {

        SceneManager.LoadScene("Endless"); 
    }
}
