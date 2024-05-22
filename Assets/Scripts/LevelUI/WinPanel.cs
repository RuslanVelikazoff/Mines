using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinPanel : MonoBehaviour
{
    [SerializeField] 
    private Button nextLevelButton;
    [SerializeField] 
    private Button exitButton;
    
    private int currentLevelIndex;
    private int maxLevelIndex;

    public void OpenPanel(int currentIndex, int maxLevelIndex)
    {
        this.currentLevelIndex = currentIndex;
        this.maxLevelIndex = maxLevelIndex;
        this.gameObject.SetActive(true);
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (exitButton != null)
        {
            exitButton.onClick.RemoveAllListeners();
            exitButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
                SceneManager.LoadScene("MainMenuScene");
            });
        }

        if (nextLevelButton != null)
        {
            nextLevelButton.onClick.RemoveAllListeners();
            nextLevelButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
                if (currentLevelIndex + 1 < maxLevelIndex)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
                else
                {
                    Time.timeScale = 1f;
                    SceneManager.LoadScene("MainMenuScene");
                }
            });
        }
    }
}
