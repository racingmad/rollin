using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {
    //Starts game on button click
	public void OnClickBtnPlay()
    {
        SceneManager.LoadScene("MainGame");
    }
}
