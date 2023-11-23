using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebPage : MonoBehaviour {
    public string url = "https://www.example.com";

    private Request request;

    private void Start() {
        request = new Request();

        //StartCoroutine(request.SendPostRequest("profile"));
        StartCoroutine(request.Get("profile"));
    }

    public void OpenWebpageURL() {
        Application.OpenURL(url);
    }
}
