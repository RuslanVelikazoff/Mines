using UnityEngine;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour
{
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button levelsButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button exitButton;

    [SerializeField] private GameObject levelsPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject exitPanel;

    private void Start()
    {
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (newGameButton != null)
        {
            newGameButton.onClick.RemoveAllListeners();
            newGameButton.onClick.AddListener(() =>
            {
                Debug.Log("New Game");
            });
        }

        if (levelsButton != null)
        {
            levelsButton.onClick.RemoveAllListeners();
            levelsButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                levelsPanel.SetActive(true);
            });
        }

        if (settingsButton != null)
        {
            settingsButton.onClick.RemoveAllListeners();
            settingsButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                settingsPanel.SetActive(true);
            });
        }

        if (exitButton != null)
        {
            exitButton.onClick.RemoveAllListeners();
            exitButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                exitPanel.SetActive(true);
            });
        }
    }
}
