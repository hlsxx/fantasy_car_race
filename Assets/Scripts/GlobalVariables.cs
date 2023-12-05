using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlayerGlobal {

    int id;
    string nickname;
    int score;
    int totalKills;
    int totalDeaths;

    public PlayerGlobal(ProfileData profile) {
        id = profile.id;
        nickname = profile.nickname;
        score = profile.score;
        totalKills = profile.total_kills;
        totalDeaths = profile.total_deaths;
    }

    public string GetId() => id.ToString();
    public string GetNickname() => nickname;
    public string GetScore() => score.ToString();
    public string GetTotalKills() => totalKills.ToString();
    public string GetTotalDeaths() => totalDeaths.ToString();
}

public static class GlobalVariables {
    public static PlayerGlobal player;

    public static void InitPlayer(ProfileData profile) {
        player = new PlayerGlobal(profile);
    }
}
