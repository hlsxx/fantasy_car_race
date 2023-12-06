using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlayerGlobal {

    int id;
    string nickname;
    int score;
    int totalKills;
    int totalDeaths;
    int idActiveAvatar;

    public PlayerGlobal(ProfileData profileData) {
        id = profileData.id;
        nickname = profileData.nickname;
        score = profileData.score;
        totalKills = profileData.total_kills;
        totalDeaths = profileData.total_deaths;
        idActiveAvatar = profileData.id_active_avatar;
    }

    public string GetId() => id.ToString();
    public string GetNickname() => nickname;
    public string GetScore() => score.ToString();
    public string GetTotalKills() => totalKills.ToString();
    public string GetTotalDeaths() => totalDeaths.ToString();
    public int GetIdActiveAvatar() => idActiveAvatar;

    public void SetScore(int _score) {
        score = _score;
    }

    public void SetActiveAvatar(int _idActiveAvatar) {
        idActiveAvatar = _idActiveAvatar;
    }

}

public static class GlobalVariables {
    public static PlayerGlobal player;

    public static void InitPlayer(ProfileData profileData) {
        player = new PlayerGlobal(profileData);
    }
}
