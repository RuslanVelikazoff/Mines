using System.Collections;
using Unity.Advertisement.IosSupport;
using UnityEngine;
using UnityEngine.iOS;

public class IDFARequester : MonoBehaviour
{
    [SerializeField] private DatabaseExport dataBaseExport;
    
    private void Start()
    {
        if (ATTrackingStatusBinding.GetAuthorizationTrackingStatus() ==
            ATTrackingStatusBinding.AuthorizationTrackingStatus.NOT_DETERMINED)
        {
            StartCoroutine(RequestIDFA());
        }
        else
        {
            ProcessTrackingStatus(ATTrackingStatusBinding.GetAuthorizationTrackingStatus());
        }
    }

    private IEnumerator RequestIDFA()
    {
        ATTrackingStatusBinding.RequestAuthorizationTracking();

        while (ATTrackingStatusBinding.GetAuthorizationTrackingStatus() ==
               ATTrackingStatusBinding.AuthorizationTrackingStatus.NOT_DETERMINED)
        {
            yield return null;
        }
        
        ProcessTrackingStatus(ATTrackingStatusBinding.GetAuthorizationTrackingStatus());
    }

    private void ProcessTrackingStatus(ATTrackingStatusBinding.AuthorizationTrackingStatus status)
    {
        if (status == ATTrackingStatusBinding.AuthorizationTrackingStatus.AUTHORIZED)
        {
            string IDFA = Device.advertisingIdentifier;
            PlayerPrefs.SetString("IDFA", IDFA);
            dataBaseExport.gameObject.SetActive(true);
        }
        else
        {
            dataBaseExport.gameObject.SetActive(true);
        }
    }
}
