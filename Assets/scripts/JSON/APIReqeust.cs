using System.Collections;
using UnityEngine;
using SimpleJSON;
using UnityEngine.Networking;
using UnityEngine.UI;

/// <summary>
///
/// </summary>
public class APIReqeust : MonoBehaviour
{
    public APIReqeust instance;
    public string inputName;
    private static string GetBaseUrl = "https://api.genderize.io/?name=";
    public static bool isMale;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            StartCoroutine(GETGender(GetBaseUrl + inputName));
        }
        else
        {
            Destroy(this);
        }
    }
    private IEnumerator GETGender(string url)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();
            var json = JSON.Parse(webRequest.downloadHandler.text);
            var gender = json["gender"];
            isMale = false;

            if (gender == "male")
            {
                isMale = true;
                yield return isMale;
            }

            yield return isMale;
        }
    }
}
