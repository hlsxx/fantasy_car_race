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
            //LeaderboardResponse leaderboardData = JsonUtility.FromJson<LeaderboardResponse>(res);
            LeaderboardResponse leaderboardData = JsonConvert.DeserializeObject<LeaderboardResponse>(res);

        foreach (var player in leaderboardData.players) {
            //GameObject row = Instantiate(leaderboardRow, leaderboardTable);
            //Text[] texts = row.GetComponentsInChildren<Text>();

            //texts[0].text = player.nickname;
           //Debug.Log(player.nickname);
           // GameObject playerEntry = new GameObject("PlayerEntry");
           // playerEntry.transform.SetParent(scrollTable.content);

           // Text playerNameText = playerEntry.AddComponent<Text>();
           // playerNameText.text = player.nickname;

           // playerNameText.transform.localPosition = new Vector2(0, -20);
           //
            var item = Instantiate(leaderboardRow);
            // do something with the instantiated item -- for instance
            item.GetComponentInChildren<TMP_Text>().text = "Item #" + player.nickname;
            //Debug.Log(item_go);
            //item_go.text = player.nickname;
            //item_go.GetComponent<Image>().color = i % 2 == 0 ? Color.yellow : Color.cyan;
            //parent the item to the content container
            item.transform.SetParent(leaderboardTable);

            //reset the item's scale -- this can get munged with UI prefabs
            //item_go.transform.localScale = Vector2.one;
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
