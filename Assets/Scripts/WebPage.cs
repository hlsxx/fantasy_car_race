using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class WebPage : MonoBehaviour {
    public string url = "https://www.example.com";

    private Request request;
    InputField nicknameInputField;
    InputField passwordInputField;

    private void Start() {
        request = GetComponent<Request>();
        nicknameInputField = GetComponent<InputField>();
        passwordInputField = GetComponent<InputField>();

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
        WWWForm form = new WWWForm();
        form.AddField("nickname", nicknameInputField.text);
        form.AddField("password", passwordInputField.text);

        StartCoroutine(request.Post("login", form));
    }
}
