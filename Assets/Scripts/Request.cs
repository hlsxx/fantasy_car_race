using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections;
using System.Collections.Generic;

public class Request {

    private string serverUrl = "http://localhost/ucm/planet_of_the_aliens/index.php?page=";
    private string postData = "{\"key1\":\"value1\",\"key2\":\"value2\"}";
    
    private string GetUrl(string page) {
        return serverUrl + page;
    }

    private Dictionary<string, string> parameters = new Dictionary<string, string> {
        { "idPlayer", "1" }
    };

    private string GetUrlWithParams(string url, Dictionary<string, string> parameters) {
        foreach (var param in parameters) {
            url += $"&{param.Key}={UnityWebRequest.EscapeURL(param.Value)}";
        }

        return url;
    }

    public IEnumerator Post(string page) {
        using (UnityWebRequest webRequest = UnityWebRequest.PostWwwForm(GetUrl(page), postData)) {
            webRequest.SetRequestHeader("Content-Type", "application/json");

            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success) {
                Debug.LogError("Error sending POST request: " + webRequest.error);
                //callback?.Invoke(null);
            } else {
                string response = webRequest.downloadHandler.text;
                //callback?.Invoke(response);
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
