using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartMenu : MonoBehaviour {

    [SerializeField] TMP_Text playerNicknameText;
    [SerializeField] TMP_Text playerScoreText;

    void Start() {
      playerNicknameText.text = GlobalVariables.player.GetNickname();
      playerScoreText.text = GlobalVariables.player.GetScore();
    }

}
