using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ZoneController : MonoBehaviour {

	public string gameOverText = "";

	void OnTriggerEnter(Collider other){
		//print (gameObject.tag);
		if(other.gameObject.tag == "Player" && gameObject.tag == "RedZone"){
			//SceneManager.LoadScene ("GameOverScene");
			gameOverText = "GAME OVER";
		} else {
			//SceneManager.LoadScene ("WinScene");
			gameOverText = "YOU WIN!";
		}
	}
}
