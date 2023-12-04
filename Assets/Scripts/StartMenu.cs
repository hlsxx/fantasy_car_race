using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartMenu : MonoBehaviour {

    [SerializeField] TMP_Text playerNicknameText;

    void Start() {
      playerNicknameText.text = GlobalVariables.player.GetNickname();
    }

}
