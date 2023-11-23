using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebPage : MonoBehaviour {
    public string url = "https://www.example.com";

    private Request request;

    private void Start() {
        request = GetComponent<Request>();
        
        if (request == null) {
            Debug.Log("Request not found");
        }
        //if (request != null) {
        //    StartCoroutine(request.Get("profile"));
        //} else {
        //    Debug.Log("xxx");
        //}
        //StartCoroutine(request.SendPostRequest("profile"));
        //StartCoroutine(request.Get("profile"));
    }

    public void OpenWebpageURL() {
        Application.OpenURL(url);
    }

    public void Login() {
        Debug.Log("xx");
        StartCoroutine(request.Post("login"));
    }
}
