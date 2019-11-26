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
        anim1.Play("StartUserAnimation");
        anim2.Play("StartUserAnimation2");
        yield return new WaitForSeconds(0.25F);
        SceneManager.LoadScene("SplitScene");
    }
}
