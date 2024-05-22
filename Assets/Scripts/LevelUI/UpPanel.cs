using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpPanel : MonoBehaviour
{
    [SerializeField] 
    private Button pauseButton;
    [SerializeField]
    private Button helpButton;
    
    [SerializeField] 
    private GameObject helpPanel;

    private void Start()
    {
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (pauseButton != null)
        {
            pauseButton.onClick.RemoveAllListeners();
            pauseButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
                Time.timeScale = 1f;
                SceneManager.LoadScene("MainMenuScene");
            });
        }

        if (helpButton != null)
        {
            helpButton.onClick.RemoveAllListeners();
            helpButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
                helpPanel.SetActive(true);
                Time.timeScale = 0f;
            });
        }
    }
}
