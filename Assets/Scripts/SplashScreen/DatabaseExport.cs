using Firebase.Firestore;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DatabaseExport : MonoBehaviour
{
    [SerializeField] private WebManager webManager;

    [SerializeField] private AppsflyerInitialisation appsflyerInitialisation;

    private FirebaseFirestore firestore;

    private void Start()
    {
        DataBaseExportStart();
    }

    private void DataBaseExportStart()
    {
        firestore = FirebaseFirestore.DefaultInstance;

        firestore.Document($"DateBase/0").GetSnapshotAsync().ContinueWith(task =>
        {
            if (task.Result.Exists)
            {
                var data = task.Result.ConvertTo<SaveData>();

                PlayerPrefs.SetInt("Day", data.Day);
                PlayerPrefs.SetInt("Month", data.Month);
                PlayerPrefs.SetInt("Year", data.Year);

                if (PlayerPrefs.GetString("policy", "") == "")
                {
                    appsflyerInitialisation.gameObject.SetActive(true);
                }
                else if (PlayerPrefs.GetString("policy", "") == "accept")
                {
                    SceneManager.LoadScene(1);
                }
                else
                {
                    webManager.WebStart();
                }
            }
            else
            {
                SceneManager.LoadScene(1);
            }
        });
    }
}
