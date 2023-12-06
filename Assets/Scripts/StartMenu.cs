using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour {

    [SerializeField] TMP_Text playerNicknameText;
    [SerializeField] TMP_Text playerScoreText;
    [SerializeField] GameObject avatarArea;
    [SerializeField] Request request;

    void Start() {
      playerNicknameText.text = GlobalVariables.player.GetNickname();
      playerScoreText.text = GlobalVariables.player.GetScore();

      UnselectAllAvatars();
    }

    private void UnselectAllAvatars() {
      if (avatarArea == null) avatarArea = GameObject.FindGameObjectWithTag("AvatarArea");

      Image[] avatars = avatarArea.GetComponentsInChildren<Image>();

      int avatarIndex = 1;
      foreach (Image avatar in avatars) {
        if (GlobalVariables.player.GetIdActiveAvatar() != avatarIndex) {
          ChangeAlpha(avatar, 0.7f);
        }

        avatarIndex += 1;
      }
    }

    private void ChangeAlpha(Image image, float alpha) {
      Color currentColor = image.color;
      currentColor.a = alpha;
      image.color = currentColor;
    }

    public void ChooseAvatar(int avatarIndex) {
        GlobalVariables.player.SetActiveAvatar(avatarIndex);

        WWWForm form = new WWWForm();

        form.AddField("idPlayer", GlobalVariables.player.GetId());
        form.AddField("idAvatar", avatarIndex);

        StartCoroutine(request.Post(
            "profile-update-avatar", 
            form,
            null,
            null
        ));
    }

    public void ChooseAvatarImage(Image avatar) {
      UnselectAllAvatars();
      ChangeAlpha(avatar, 1.0f);
    }

}
