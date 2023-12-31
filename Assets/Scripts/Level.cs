using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 2f;

    public void LoadStartMenu() {
        SceneManager.LoadScene(1);
    }

    public void LoadScene(string name) {
        SceneManager.LoadScene(name);
    }

    public void LoadGame() {
        SceneManager.LoadScene("Game");
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void LoadGameOver() {
        StartCoroutine(WaitAndLoad());
    }

    IEnumerator WaitAndLoad() {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("GameOver");
    }
    
    public void QuitGame() {
        FindObjectOfType<GameSession>().SaveGame();

        Application.Quit();
    }
}
