using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class ProfileData {
    //public string id;
    public string nickname; 
    //public string password; 
    //public string id_active_avatar;
    //public string score;
    //public string total_kills;
    //public string total_deaths;
}

public class LoginResponse {
    public string status;

    #nullable enable
    public string? message;

    #nullable enable
    public string? nickname;

    //#nullable enable
    //public ProfileData profileData;
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
        try {
            LoginResponse loginRes = JsonUtility.FromJson<LoginResponse>(res);
            if (loginRes.status == "success") {
                SceneManager.LoadScene("StartMenu");

                //Debug.Log(loginRes.profileData);
                GlobalVariables.InitPlayer(
                    //loginRes.id,
                    loginRes.nickname
                    //loginRes.password
                );
            } else {
                errorText.text = loginRes.message;
            } 
        } catch (Exception ex) {
            Debug.LogError("Error during deserialization: " + ex.Message);
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
