using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections;
using System.Collections.Generic;

public class Request : MonoBehaviour {

    private string serverUrl = "http://localhost/ucm/planet_of_the_aliens/index.php?page=";
    private string postData = "{\"key1\":\"value1\",\"key2\":\"value2\"}";
    
    private string GetUrl(string page) {
        return serverUrl + page;
    }

    private Dictionary<string, string> parameters = new Dictionary<string, string> {
        { "idPlayer", "1" },
        { "nickname", "holes" },
        { "password", "12345678" }
    };

    private string GetUrlWithParams(string url, Dictionary<string, string> parameters) {
        foreach (var param in parameters) {
            url += $"&{param.Key}={UnityWebRequest.EscapeURL(param.Value)}";
        }

        return url;
    }

    public IEnumerator Post(string page, WWWForm form) {
        //string postData = GetUrlWithParams("", parameters).Remove(0, 1);
        //Debug.Log("POST" + postData);

        using (UnityWebRequest webRequest = UnityWebRequest.Post(GetUrl(page), form)) {
            webRequest.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");

            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success) {
                Debug.Log(webRequest.error);
            } else {
                Debug.Log("GET request successful. Response: " + webRequest.downloadHandler.text);
            }
        }
    }

    public IEnumerator Get(string page) {
        var url = GetUrlWithParams(GetUrl(page), parameters);

        using (UnityWebRequest webRequest = UnityWebRequest.Get(url)) {

            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success) {
                Debug.LogError("Error sending GET request: " + webRequest.error);
            } else {
                // Request was successful, do something with the response
                Debug.Log("GET request successful. Response: " + webRequest.downloadHandler.text);
            }
        }
    }
}
