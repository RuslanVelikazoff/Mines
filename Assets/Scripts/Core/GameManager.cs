using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] 
    private WinPanel winPanel;
    [SerializeField]
    private GameObject losePanel;

    [SerializeField] 
    private GameObject minefieldContainer;

    private int currentLevelIndex;
    private int maxLevelIndex = 5;

    private void Awake()
    {
        Instance = this;
        Time.timeScale = 1f;
    }

    public void WinGame()
    {
        Debug.Log("Win");
        AudioManager.Instance.Play("Win");
        minefieldContainer.SetActive(false);
        Time.timeScale = 0f;
        winPanel.gameObject.SetActive(true);
        winPanel.OpenPanel(Data.Instance.GetCurrentIndexLevel(), maxLevelIndex);
        currentLevelIndex = Data.Instance.GetCurrentIndexLevel();

        if (currentLevelIndex + 1 < maxLevelIndex)
        {
            Data.Instance.UnlockLevel(currentLevelIndex + 1);
            Data.Instance.SetCurrentIndexLevel(currentLevelIndex + 1);
        }
    }

    public void LoseGame()
    {
        AudioManager.Instance.Play("Lose");
        Debug.Log("Lose");
        minefieldContainer.SetActive(false);
        Time.timeScale = 0f;
        losePanel.SetActive(true);
    }
}
