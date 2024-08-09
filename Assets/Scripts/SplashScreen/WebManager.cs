using UnityEngine;
using UnityEngine.SceneManagement;

public class WebManager : MonoBehaviour
{
    [SerializeField] 
    private UniWebView webView;

    [SerializeField]
    private string policyURL;

    [SerializeField] 
    private GameObject webPanel;

    private void Start()
    {
        WebStart();
    }

    public void WebStart()
    {
        if (PlayerPrefs.GetString("policy", "") == "")
        {
            string[] keys = { 
                "IDFA", 
                "campaign",
                "hash",
                "af_sub1",
                "af_sub2",
                "af_sub3",
                "af_sub4",
                "af_sub5",
                "media_source",
                "clickid" };
            
            foreach (var key in keys)
            {
                policyURL += key + "=" + PlayerPrefs.GetString(key, "null") + "&";
            }
            policyURL = policyURL.TrimEnd('&');

            webView.OnPageFinished += (view, statusCode, url) => 
            {
                if (url == policyURL)
                {
                    PlayerPrefs.SetString("policy", "accept");
                    SceneManager.LoadScene(1);
                }
                else if (PlayerPrefs.GetString("saved", "") == "")
                {
                    webView.Show();
                    webPanel.SetActive(true);
                    PlayerPrefs.SetString("policy", url);
                    PlayerPrefs.SetString("saved", "1");
                }
            };

            webView.Load(policyURL);
        }
        else
        {
            webView.OnPageFinished += (view, statusCode, url) =>
            {
                webView.Show();
            };
            webPanel.SetActive(true);
            webView.Load(PlayerPrefs.GetString("policy", ""));
        }
    }

    #region ButtonsAction

    public void GoBack()
    {
        if (webView.CanGoBack)
        {
            webView.GoBack();
        }
    }

    public void GoForward()
    {
        if (webView.CanGoForward)
        {
            webView.GoForward();
        }
    }

    #endregion
}
