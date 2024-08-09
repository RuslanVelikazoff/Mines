using System;
using System.Collections.Generic;
using AppsFlyerSDK;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppsflyerInitialisation : MonoBehaviour
{
    [SerializeField]
    private string devKey;
    
    [SerializeField]
    private string appID;

    [SerializeField]
    private WebManager webManager;
    [SerializeField] 
    private PolicyManager policyManager;

    private void Start()
    {
        AppsFlyer.initSDK(devKey, appID, this);
        AppsFlyer.startSDK();
    }
    
     public void onConversionDataSuccess(string conversionData)
    {
        Dictionary<string, object> conversionDataDictionary = null;
        
        try
        {
            conversionDataDictionary = AppsFlyer.CallbackStringToDictionary(conversionData);
        }
        catch (Exception ex)
        {
            Debug.LogError("Error converting conversion data to dictionary: " + ex.Message);
            return;
        }

        if (conversionDataDictionary == null)
        {
            Debug.LogError("Conversion data dictionary is null");
            return;
        }

        foreach (var key in conversionDataDictionary)
        {
            if (key.Value != null)
            {
                PlayerPrefs.SetString(key.Key, key.Value.ToString());
            }
            else
            {
                Debug.LogWarning($"Value for key {key.Key} is null. Skipping setting PlayerPrefs.");
            }
        }

        if (InvalidateDate())
        {
            DateTime date = new DateTime(
                PlayerPrefs.GetInt("Year"), PlayerPrefs.GetInt("Month"), PlayerPrefs.GetInt("Day"));

            if (date < DateTime.Now)
            {
                if (policyManager != null)
                {
                    policyManager.gameObject.SetActive(true);
                }
            }
            else
            {
                if (webManager != null)
                {
                    webManager.gameObject.SetActive(true);
                }
            }
        }
        else
        {
            if (PlayerPrefs.GetString("policy", "") == "accept")
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                if (policyManager != null)
                {
                    policyManager.gameObject.SetActive(true);
                }
            }
        }
    }

    public void onConversionDataFail(string error)
    {
        Debug.LogError("Conversion data retrieval failed: " + error);
    }

    public void onAppOpenAttribution(string attributionData)
    {
        Debug.Log("Attribution data received: " + attributionData);
    }

    public void onAppOpenAttributionFailure(string error)
    {
        Debug.LogError("Attribution data retrieval failed: " + error);
    }
    
    private bool InvalidateDate()
    {
        string dateString =
            $"{PlayerPrefs.GetInt("Year")}.{PlayerPrefs.GetInt("Month")}.{PlayerPrefs.GetInt("Day")}";

        if (DateTime.TryParse(dateString, out DateTime result))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
