using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameManager Instance { get; private set; }

    [SerializeField] 
    private WinPanel winPanel;
    [SerializeField]
    private GameObject losePanel;

    private int currentLevelIndex;
    private int maxLevelIndex = 6;

    private void Awake()
    {
        Instance = this;
        Time.timeScale = 1f;
    }

    public void WinGame()
    {
        Time.timeScale = 0f;
        winPanel.OpenPanel(Data.Instance.GetCurrentIndexLevel(), maxLevelIndex);
        currentLevelIndex = Data.Instance.GetCurrentIndexLevel();

        if (currentLevelIndex + 1 < maxLevelIndex)
        {
            Data.Instance.SetCurrentIndexLevel(currentLevelIndex + 1);
        }
    }

    public void LoseGame()
    {
        Time.timeScale = 0f;
        losePanel.SetActive(true);
    }
}
