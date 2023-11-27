using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;

public class LoginResponse {
    public string status;
    public string? message;
    public string? profileData;
}

public class WebApi : MonoBehaviour {
    public string url = "https://www.example.com";

    [SerializeField] Request request;
    [SerializeField] TMP_InputField nicknameInputField;
    [SerializeField] TMP_InputField passwordInputField;
    [SerializeField] Button loginButton;
    [SerializeField] TMP_Text errorText;

    private void Start() {
        //StartCoroutine(request.SendPostRequest("profile"));
        //StartCoroutine(request.Get("profile"));
    }

    public void OpenWebpageURL() {
        Application.OpenURL(request.GetUrl("web"));
    }

    private void LoginErrorCallback(string res) {
        //Debug.Log(res);
    }

    private void LoginSuccessCallback(string res) {
        LoginResponse loginRes = JsonUtility.FromJson<LoginResponse>(res);
        
        //Debug.Log(res);

        if (loginRes.status == "success") {
            SceneManager.LoadScene("StartMenu");
        } else {
            errorText.text = loginRes.message;
        }
    }

    public void Login() {
        WWWForm form = new WWWForm();

        form.AddField("nickname", nicknameInputField.text);
        form.AddField("password", passwordInputField.text);

        StartCoroutine(request.Post(
            "login", 
            form, 
            LoginSuccessCallback,
            LoginErrorCallback
        ));
    }
}
