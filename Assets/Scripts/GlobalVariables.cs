using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlayerGlobal {

    int id;
    string nickname;
    int score;
    int totalKills;
    int totalDeaths;

    public PlayerGlobal(ProfileData profileData) {
        id = profileData.id;
        nickname = profileData.nickname;
        score = profileData.score;
        totalKills = profileData.total_kills;
        totalDeaths = profileData.total_deaths;
    }

    public string GetId() => id.ToString();
    public string GetNickname() => nickname;
    public string GetScore() => score.ToString();
    public string GetTotalKills() => totalKills.ToString();
    public string GetTotalDeaths() => totalDeaths.ToString();

    public void SetScore(int _score) => score = score;
}

public static class GlobalVariables {
    public static PlayerGlobal player;

    public static void InitPlayer(ProfileData profileData) {
        player = new PlayerGlobal(profileData);
    }
}
