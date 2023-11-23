using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections;

public class Request {

    private string serverUrl = "http://localhost/ucm/planet_of_the_aliens/index.php?page=";
    //private string postData = "{\"key1\":\"value1\",\"key2\":\"value2\"}";

    public IEnumerator SendPostRequest(Action<string> callback) {
        using (UnityWebRequest webRequest = UnityWebRequest.Post(serverUrl, postData)) {
            webRequest.SetRequestHeader("Content-Type", "application/json");

            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success) {
                Debug.LogError("Error sending POST request: " + webRequest.error);
                callback?.Invoke(null);
            } else {
                string response = webRequest.downloadHandler.text;
                callback?.Invoke(response);
            }
        }
    }
}
