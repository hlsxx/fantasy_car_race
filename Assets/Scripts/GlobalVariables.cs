using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlayerGlobal {

    string nickname;
    int score;
    //int totalKills;
    //int totalDeaths;

    public PlayerGlobal(string _nickname, int _score) {
        nickname = _nickname;
        score = _score;
    }

    public string GetNickname() => nickname;
    public string GetScore() => score.ToString();
    //public int GetTotalKills() => totalKills;
    //public int GetTotalDeaths() => totalDeaths;
}

public static class GlobalVariables {
    public static PlayerGlobal player;

    public static void InitPlayer(string nickname, int score) {
        player = new PlayerGlobal(nickname, score);
    }
}
