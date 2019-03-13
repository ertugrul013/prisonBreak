using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using SimpleJSON;

public class APIReqeust : MonoBehaviour
{
    [Range(5, 100)] public int AmountOfPictures;
    public string URL = "http://shibe.online/api/shibes?count=&urls=true&httpsUrls=true";
    public string[] ImageURL;
    public List<Texture2D> Image;

    WebClient _webClient = new WebClient();

    private void Start()
    {
        ImageURL = new string[AmountOfPictures];
        
        URL = URL.Insert(37, AmountOfPictures.ToString());
        StartCoroutine(GetImages());
    }

    IEnumerator GetImages()
    {
        for (int i = 0; i < AmountOfPictures; i++)
        {
            Texture2D tex;
            tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
            using (WWW www = new WWW(URL))
            {
                yield return www;
                www.LoadImageIntoTexture(tex);
                Image.Add(tex);
            }
        }

    }

}
