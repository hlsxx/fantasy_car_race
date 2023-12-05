using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameSession : MonoBehaviour {
    int score = 0;

    [SerializeField] Request request;

    private void Awake() {
        SetUpSingleton();

        score = int.Parse(GlobalVariables.player.GetScore());
    }

    private void SetUpSingleton() {
        int numberGameSession = FindObjectsOfType<GameSession>().Length;

        if (numberGameSession > 1) {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore() {
        return score;
    }

    public void AddToScore(int scoreValue) {
        score += scoreValue;
    }

    public void ResetGame() {
        Destroy(gameObject);
    }

    private void SaveGameErrorCallback(string res) {
        Debug.Log(res);
    }

    private void SaveGameSuccessCallback(string res) {
        try {
            Debug.Log(res);
            GlobalVariables.player.SetScore(GetScore());
        } catch (Exception ex) {
            Debug.LogError("Error during deserialization: " + ex.Message);
        }
    }

    public void SaveGame() {
        if (request == null) request = gameObject.AddComponent<Request>();

        WWWForm form = new WWWForm();

        form.AddField("idPlayer", GlobalVariables.player.GetId());
        form.AddField("score", GetScore());
        form.AddField("totalKills", 1);
        form.AddField("totalDeaths", 3);

        StartCoroutine(request.Post(
            "profile-update", 
            form,
            SaveGameSuccessCallback,
            SaveGameErrorCallback
        ));
    }

    public void PickAvatar(int avatarIndex) {
        Debug.Log(avatarIndex);
    }
}
