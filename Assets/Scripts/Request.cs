using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections;
using System.Collections.Generic;

public class Request : MonoBehaviour {

    //private string serverUrl = "http://localhost/ucm/planet_of_the_aliens/index.php?page=";
    private string serverUrl = "https://grid3.kaim.fpv.ucm.sk/~patrikholes/planet_of_the_aliens/index.php?page=";
    
    public string GetUrl(string page) {
        return serverUrl + page;
    }

   // private Dictionary<string, string> parameters = new Dictionary<string, string> {
   //     { "idPlayer", "1" },
   //     { "nickname", "holes" },
   //     { "password", "12345678" }
   // };

    private string GetUrlWithParams(string url, Dictionary<string, string> parameters) {
        foreach (var param in parameters) {
            url += $"&{param.Key}={UnityWebRequest.EscapeURL(param.Value)}";
        }

        return url;
    }

    public IEnumerator Post(
        string page,
        WWWForm form,
        System.Action<string> successCallback,
        System.Action<string> errorCallback
    ) {
        using (UnityWebRequest webRequest = UnityWebRequest.Post(GetUrl(page), form)) {
            webRequest.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");

            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success) {
                errorCallback?.Invoke(webRequest.downloadHandler.text);
            } else {
                successCallback?.Invoke(webRequest.downloadHandler.text);
            }
        }
    }

    public IEnumerator Get(
        string page,
        Dictionary<string, string>? parameters,
        System.Action<string> successCallback,
        System.Action<string> errorCallback
    ) {
        //var url = GetUrlWithParams(GetUrl(page), parameters);
        var url = GetUrl(page);

        using (UnityWebRequest webRequest = UnityWebRequest.Get(url)) {

            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success) {
                errorCallback?.Invoke(webRequest.downloadHandler.text);
            } else {
                successCallback?.Invoke(webRequest.downloadHandler.text);
            }
        }
    }
}
