using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using UnityEngine.UI;

public class NasaSpacePics : MonoBehaviour
{

    public RawImage nasaPic;
    public Text nasaPicTitle;

    private readonly string nasaPicsURL = "https://api.nasa.gov/planetary/apod?api_key=zrxYhsnJPXN4yRcpERyWTW6Zn9EPIQYdsyjkwRZK";

    //private readonly string apiKey = "5K2I9os600xZHogE6YHQXAFUplabHRfY9WT10e6a";

    // Start is called before the first frame update
    void Start()
    {
        nasaPic.texture = Texture2D.blackTexture;
        nasaPicTitle.text = "";

    }

    public void OnButtonRandomPic()
    {
        nasaPic.texture = Texture2D.blackTexture;
        nasaPicTitle.text = "Loading...";

        StartCoroutine(GetNasaImage());

    }

    IEnumerator GetNasaImage()
    {

        // Getting the info
        UnityWebRequest nasaInfoRequest = UnityWebRequest.Get(nasaPicsURL);

        yield return nasaInfoRequest.SendWebRequest();

        if (nasaInfoRequest.isNetworkError || nasaInfoRequest.isHttpError)
        {
            Debug.LogError(nasaInfoRequest.error);
            yield break;
        }

        JSONNode nasaInfo = JSON.Parse(nasaInfoRequest.downloadHandler.text);

        string picTitle = nasaInfo["title"];

        string picURL = nasaInfo["url"];


        // Get Pic

        UnityWebRequest nasaSpriteRequest = UnityWebRequestTexture.GetTexture(picURL);

        yield return nasaSpriteRequest.SendWebRequest();

        if (nasaSpriteRequest.isNetworkError || nasaSpriteRequest.isHttpError)
        {
            Debug.LogError(nasaSpriteRequest.error);
            yield break;
        }

        // Setting UI Objects

        nasaPic.texture = DownloadHandlerTexture.GetContent(nasaSpriteRequest);
        nasaPic.texture.filterMode = FilterMode.Point;

        nasaPicTitle.text = picTitle;

    }
}
