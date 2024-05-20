using UnityEngine;

public class Data : MonoBehaviour
{
    public static Data Instance;

    private bool[] _levelUnlock;
    private bool[] _difficulty;

    private const string saveKey = "MainSave";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Load();
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    private void OnDisable()
    {
        Save();
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            Save();
        }
    }

    private void Load()
    {
        var data = SaveManager.Load<GameData>(saveKey);

        _levelUnlock = data.levelUnlock;
        _difficulty = data.difficulty;
        
        Debug.Log("Data load");
    }

    private void Save()
    {
        SaveManager.Save(saveKey, GetSaveSnapshot());
        PlayerPrefs.Save();
        
        Debug.Log("Data save");
    }

    private GameData GetSaveSnapshot()
    {
        var data = new GameData()
        {
            levelUnlock = _levelUnlock,
            difficulty = _difficulty
        };

        return data;
    }

    public int GetDifficultyIndex()
    {
        for (int i = 0; i < _difficulty.Length; i++)
        {
            if (_difficulty[i])
            {
                return i;
                break;
            }
        }

        return 0;
    }

    public void SetDifficulty(int index)
    {
        for (int i = 0; i < _difficulty.Length; i++)
        {
            if (i == index)
            {
                _difficulty[i] = true;
            }
            else
            {
                _difficulty[i] = false;
            }
        }
    }
}
