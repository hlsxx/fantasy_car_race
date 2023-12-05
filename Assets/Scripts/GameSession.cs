using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour {
    int score = 0;

    [SerializeField] Request request;

    private void Awake() {
        SetUpSingleton();
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

    public void SaveGame() {
        WWWForm form = new WWWForm();

        form.AddField("idPlayer", GlobalVariables.player.GetId());
        form.AddField("score", GlobalVariables.player.GetId());
        form.AddField("totalKills", GlobalVariables.player.GetId());
        form.AddField("totalDeaths", GlobalVariables.player.GetId());

        //StartCoroutine(request.post(
        //    "profile-update", 
        //    null, 
        //    LeaderboardSuccessCallback,
        //    LeaderboardErrorCallback
        //));
    }
}
