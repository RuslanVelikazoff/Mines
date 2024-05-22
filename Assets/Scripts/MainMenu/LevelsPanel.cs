using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsPanel : MonoBehaviour
{
    [SerializeField] 
    private Button backButton;
    [SerializeField] 
    private Button[] levelButtons;

    [SerializeField] 
    private GameObject mainPanel;

    [SerializeField]
    private Sprite[] activeSprites;
    [SerializeField] 
    private Sprite[] inactiveSprites;

    private void OnEnable()
    {
        SetButtonsSprite();
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (backButton != null)
        {
            backButton.onClick.RemoveAllListeners();
            backButton.onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
                this.gameObject.SetActive(false);
                mainPanel.SetActive(true);
            });
        }

        if (levelButtons[0] != null)
        {
            levelButtons[0].onClick.RemoveAllListeners();
            levelButtons[0].onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
                Data.Instance.SetCurrentIndexLevel(0);
                SceneManager.LoadScene("Level1");
                Debug.Log("Load level 1");
            });
        }
        
        if (levelButtons[1] != null)
        {
            levelButtons[1].onClick.RemoveAllListeners();
            levelButtons[1].onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
                Data.Instance.SetCurrentIndexLevel(1);
                SceneManager.LoadScene("Level2");
                Debug.Log("Load level 2");
            });
        }
        
        if (levelButtons[2] != null)
        {
            levelButtons[2].onClick.RemoveAllListeners();
            levelButtons[2].onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
                Data.Instance.SetCurrentIndexLevel(2);
                SceneManager.LoadScene("Level3");
                Debug.Log("Load level 3");
            });
        }
        
        if (levelButtons[3] != null)
        {
            levelButtons[3].onClick.RemoveAllListeners();
            levelButtons[3].onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
                Data.Instance.SetCurrentIndexLevel(3);
                SceneManager.LoadScene("Level4");
                Debug.Log("Load level 4");
            });
        }
        
        if (levelButtons[4] != null)
        {
            levelButtons[4].onClick.RemoveAllListeners();
            levelButtons[4].onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
                Data.Instance.SetCurrentIndexLevel(4);
                SceneManager.LoadScene("Level5");
                Debug.Log("Load level 5");
            });
        }
        
        if (levelButtons[5] != null)
        {
            levelButtons[5].onClick.RemoveAllListeners();
            levelButtons[5].onClick.AddListener(() =>
            {
                AudioManager.Instance.Play("Click");
                Data.Instance.SetCurrentIndexLevel(5);
                SceneManager.LoadScene("Level6");
                Debug.Log("Load level 6");
            });
        }
    }

    private void SetButtonsSprite()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (Data.Instance.IsUnlockLevel(i))
            {
                levelButtons[i].GetComponent<Image>().sprite = activeSprites[i];
            }
            else
            {
                levelButtons[i].GetComponent<Image>().sprite = inactiveSprites[i];
            }
        }
    }

}
