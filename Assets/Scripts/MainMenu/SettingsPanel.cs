using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField] 
    private Button backButton;
    [SerializeField] 
    private Button musicButton;
    [SerializeField] 
    private Button soundButton;
    [SerializeField]
    private Button easyButton;
    [SerializeField] 
    private Button mediumButton;
    [SerializeField] 
    private Button hardButton;

    [SerializeField]
    private GameObject mainPanel;

    [SerializeField] 
    private Sprite[] difficultyActiveSprites;
    [SerializeField] 
    private Sprite[] difficultyInactiveSprites;
    [SerializeField]
    private Sprite onSprite;
    [SerializeField] 
    private Sprite offSprite;

    private int easyDifficultyIndex = 0;
    private int mediumDifficultyIndex = 1;
    private int hardDifficultyIndex = 2;

    private void OnEnable()
    {
        SetSoundButtonSprite();
        SetMusicButtonSprite();
        SetDifficultyButtonSprite();
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (backButton != null)
        {
            backButton.onClick.RemoveAllListeners();
            backButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                mainPanel.SetActive(true);
            });
        }

        if (musicButton != null)
        {
            musicButton.onClick.RemoveAllListeners();
            musicButton.onClick.AddListener(() =>
            {
                if (AudioManager.Instance.MusicPlay())
                {
                    AudioManager.Instance.OffMusic();
                }
                else
                {
                    AudioManager.Instance.OnMusic();
                }
                
                SetMusicButtonSprite();
            });
        }

        if (soundButton != null)
        {
            soundButton.onClick.RemoveAllListeners();
            soundButton.onClick.AddListener(() =>
            {
                if (AudioManager.Instance.SoundsPlay())
                {
                    AudioManager.Instance.OffSounds();
                }
                else
                {
                    AudioManager.Instance.OnSounds();
                }
                
                SetSoundButtonSprite();
            });
        }

        if (easyButton != null)
        {
            easyButton.onClick.RemoveAllListeners();
            easyButton.onClick.AddListener(() =>
            {
                Data.Instance.SetDifficulty(easyDifficultyIndex);
                SetDifficultyButtonSprite();
            });
        }

        if (mediumButton != null)
        {
            mediumButton.onClick.RemoveAllListeners();
            mediumButton.onClick.AddListener(() =>
            {
                Data.Instance.SetDifficulty(mediumDifficultyIndex);
                SetDifficultyButtonSprite();
            });
        }

        if (hardButton != null)
        {
            hardButton.onClick.RemoveAllListeners();
            hardButton.onClick.AddListener(() =>
            {
                Data.Instance.SetDifficulty(hardDifficultyIndex);
                SetDifficultyButtonSprite();
            });
        }
    }

    private void SetSoundButtonSprite()
    {
        if (AudioManager.Instance.SoundsPlay())
        {
            soundButton.GetComponent<Image>().sprite = onSprite;
        }
        if (!AudioManager.Instance.SoundsPlay())
        {
            soundButton.GetComponent<Image>().sprite = offSprite;
        }
    }

    private void SetMusicButtonSprite()
    {
        if (AudioManager.Instance.MusicPlay())
        {
            musicButton.GetComponent<Image>().sprite = onSprite;
        }

        if (!AudioManager.Instance.MusicPlay())
        {
            musicButton.GetComponent<Image>().sprite = offSprite;
        }
    }

    private void SetDifficultyButtonSprite()
    {
        switch (Data.Instance.GetDifficultyIndex())
        {
            case 0:
                easyButton.GetComponent<Image>().sprite = difficultyActiveSprites[0];
                mediumButton.GetComponent<Image>().sprite = difficultyInactiveSprites[1];
                hardButton.GetComponent<Image>().sprite = difficultyInactiveSprites[2];
                break;
            case 1:
                easyButton.GetComponent<Image>().sprite = difficultyInactiveSprites[0];
                mediumButton.GetComponent<Image>().sprite = difficultyActiveSprites[1];
                hardButton.GetComponent<Image>().sprite = difficultyInactiveSprites[2];
                break;
            case 2:
                easyButton.GetComponent<Image>().sprite = difficultyInactiveSprites[0];
                mediumButton.GetComponent<Image>().sprite = difficultyInactiveSprites[1];
                hardButton.GetComponent<Image>().sprite = difficultyActiveSprites[2];
                break;
        }
    }
}
