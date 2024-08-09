using UnityEngine;
using UnityEngine.SceneManagement;

public class PolicyManager : MonoBehaviour
{
    [SerializeField]
    private UniWebView webView;

    [SerializeField] private string policyUrl;

    [SerializeField]
    private GameObject webPanel;

    void Start()
    {
        EnablePolicy();
    }

    public void EnablePolicy()
    {
        webView.Load(policyUrl);
        webView.Show();
        webPanel.SetActive(true);
    }

    public void AcceptPolicy()
    {
        PlayerPrefs.SetString("policy", "accept");
        SceneManager.LoadScene(1);
    }
}
