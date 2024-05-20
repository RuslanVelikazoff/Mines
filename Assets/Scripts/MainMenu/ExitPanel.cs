using UnityEngine;
using UnityEngine.UI;

public class ExitPanel : MonoBehaviour
{
    [SerializeField]
    private Button yesButton;
    [SerializeField] 
    private Button noButton;

    [SerializeField] 
    private GameObject mainPanel;

    private void Start()
    {
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (yesButton != null)
        {
            yesButton.onClick.RemoveAllListeners();
            yesButton.onClick.AddListener(() =>
            {
                Application.Quit();
            });
        }

        if (noButton != null)
        {
            noButton.onClick.RemoveAllListeners();
            noButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                mainPanel.SetActive(true);
            });
        }
    }
}
