using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreenManager : MonoBehaviour
{
    [SerializeField] private GameObject instructionsPanel;
    [SerializeField] private Button startButton;
    [SerializeField] private Button instructionsButton;
    [SerializeField] private Button closeButton;

    void Start()
    {
        instructionsPanel.SetActive(false);
        startButton.onClick.AddListener(StartGame);
        instructionsButton.onClick.AddListener(OpenInstructions);
        closeButton.onClick.AddListener(CloseInstructions);
    }

    void StartGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    void OpenInstructions()
    {
        instructionsPanel.SetActive(true);
    }

    void CloseInstructions()
    {
        instructionsPanel.SetActive(false);
    }
}