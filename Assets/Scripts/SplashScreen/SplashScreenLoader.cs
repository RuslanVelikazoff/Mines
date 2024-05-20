using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashScreenLoader : MonoBehaviour
{
    private float timeDownload = 2f;
    private float timeLeft;

    [SerializeField]
    private Slider loaderSlider;

    public bool load = true;

    private void Update()
    {
        if (load)
        {
            if (timeLeft < timeDownload)
            {
                timeLeft += Time.deltaTime;
                loaderSlider.value = timeLeft;
            }
            else
            {
                SceneManager.LoadScene("MainMenuScene");
            }
        }
    }
}
