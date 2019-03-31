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
    public static APIReqeust instance;
    private static string GetBaseUrl = "https://api.genderize.io/?name=";
		private bool isMale;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    public bool GetGender(string name)
    {
      string url = GetBaseUrl + name;
    	StartCoroutine(JsonReqeust(url));
      return isMale;
    }

    private IEnumerator JsonReqeust(string url)
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
            }
        }
    }
}
