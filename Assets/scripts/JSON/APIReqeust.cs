using System.Collections;
using UnityEngine;
using SimpleJSON;
using UnityEditor.PackageManager;
using UnityEngine.Networking;
using UnityEngine.UI;

/// <summary>
/// 
/// </summary>
public class APIReqeust : MonoBehaviour
{
    public APIReqeust instance;
    public InputField input;
    private static string GetBaseUrl = "https://api.genderize.io/?name=";
    public static bool isMale;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            StartCoroutine(GETGender(GetBaseUrl));
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
