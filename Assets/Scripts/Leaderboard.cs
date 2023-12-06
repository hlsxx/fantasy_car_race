using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Newtonsoft.Json;
using UnityEngine.UI;
using TMPro;

public class LeaderboardPlayer {
    public string nickname { get; set; }
    public string score { get; set; }
    public string total_kills { get; set; }
    public string total_deaths { get; set; }
}

public class LeaderboardResponse {
    public string status { get; set; }
    public List<LeaderboardPlayer> players { get; set; }
}

public class Leaderboard : MonoBehaviour {
    [SerializeField] Request request;
    [SerializeField] Transform leaderboardTable;
    [SerializeField] ScrollRect scrollTable;
    [SerializeField] GameObject leaderboardRow;
    //[SerializeField] TMP_Text leaderboardRow;

    private void LeaderboardErrorCallback(string res) {
        //Debug.Log(res);
    }

    private void LeaderboardSuccessCallback(string res) {
        try {
            LeaderboardResponse leaderboardData = JsonConvert.DeserializeObject<LeaderboardResponse>(res);

            int i = 1;
            foreach (var player in leaderboardData.players) {
                var item = Instantiate(leaderboardRow);
                item.GetComponentInChildren<TMP_Text>().text = player.nickname + " | " + player.score;

                if (i == 1)  {
                    Image itemImage = item.GetComponent<Image>();

                    Color itemImageColor = itemImage.color;
                    itemImageColor.a = 0.2f;

                    itemImage.color = itemImageColor;
                }

                item.transform.SetParent(leaderboardTable);

                i += 1;
            }
        } catch (Exception ex) {
            Debug.LogError("Error during deserialization: " + ex.Message);
        }
    }

    void Start() {
        StartCoroutine(request.Get(
            "leaderboard", 
            null, 
            LeaderboardSuccessCallback,
            LeaderboardErrorCallback
        ));
    }
}
