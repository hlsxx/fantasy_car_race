using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class WebApi : MonoBehaviour {
    public string url = "https://www.example.com";

    [SerializeField] Request request;
    [SerializeField] TMP_InputField nicknameInputField;
    [SerializeField] TMP_InputField passwordInputField;
    [SerializeField] Button loginButton;

    private void Start() {
        //StartCoroutine(request.SendPostRequest("profile"));
        //StartCoroutine(request.Get("profile"));
    }

    private void OpenWebpageURL() {
        Application.OpenURL(url);
    }

    public void Login() {
        WWWForm form = new WWWForm();
        form.AddField("nickname", nicknameInputField.text);
        form.AddField("password", passwordInputField.text);

        StartCoroutine(request.Post("login", form));
    }
}
