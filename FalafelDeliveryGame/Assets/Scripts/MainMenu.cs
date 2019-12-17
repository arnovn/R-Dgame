using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public Animator anim1;
    public Animator anim2;

    public void PlayGame() {

        StartCoroutine(PlayGameWaiter());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator PlayGameWaiter()
    {
        anim1.Play("user1");
        anim2.Play("user2");
        yield return new WaitForSeconds(0.50F);
        PlayerPrefs.SetInt("player1Sprite", 3);
        PlayerPrefs.SetInt("player2Sprite", 2);
        SceneManager.LoadScene("Splitscreen2");
    }
}
