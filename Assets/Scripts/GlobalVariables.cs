using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlayerGlobal {

    //public int id { get; set; }
    public string nickname { get; set; }
    //public string password { get; set; }

    public PlayerGlobal(/*int _id,*/ string _nickname/*, string _password*/) {
        //id = _id;
        nickname = _nickname;
        //password = _password;
    }

    public string GetNickname() => nickname;
}

public static class GlobalVariables {
    public static PlayerGlobal player;

    public static void InitPlayer(/*int id,*/ string nickname/*, string password*/) {
        player = new PlayerGlobal(nickname);
    }
}
