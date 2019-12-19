using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
  public Animator anim1;
  public Animator anim2;
  private Button[] buttons;
  public GameObject image1;
  public GameObject image2;
  public GameObject image3;
  public GameObject image4;

  public void PlayGame() {
    buttons = new Button[this.GetComponentsInChildren<Button>().Length];
    buttons = this.GetComponentsInChildren<Button>();
    StartCoroutine(PlayGameWaiter());
  }

  public void QuitGame()
  {
    Application.Quit();
  }

  IEnumerator PlayGameWaiter()
  {
    FindObjectOfType<AudioManager>().Play("NormalJump");
    anim1.Play("user1");
    anim2.Play("user2");
    foreach(Button b in buttons){
      b.gameObject.SetActive(false);
    }
    yield return new WaitForSeconds(0.50F);
    image1.SetActive(true);
    yield return new WaitForSeconds(5F);
    image2.SetActive(true);
    image1.SetActive(false);
    yield return new WaitForSeconds(5F);
    image3.SetActive(true);
    image2.SetActive(false);
    yield return new WaitForSeconds(5F);
    image4.SetActive(true);
    image3.SetActive(false);
    yield return new WaitForSeconds(5F);
    SceneManager.LoadScene("Splitscreen2");
  }
}
