using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ResultTextController : MonoBehaviour {
	public Transform t;
	public Transform c;
	GameObject[] redZ;
	GameObject greenZ;
	PlayerController pc;
	string GOT = "";
	float move = 5.0f;

	void Start () {
		t = GetComponent <TextMesh>().transform;
		c = Camera.main.transform;
		t.parent = c.transform;
		t.Rotate (80,0,0);
		pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}

	void Update () {
		GOT = pc.GetComponent<PlayerController> ().gameOverText;
		if(GOT == "GAME OVER"){
			GetComponent <TextMesh>().text = GOT;
			pc.setAllToZero();
		}
		if(GOT == "YOU WIN!"){
			t.position = new Vector3 (t.position.x + move, t.position.y, t.position.z);
			move = 0;
			GetComponent <TextMesh>().text = GOT;
			pc.setAllToZero();
		}
		KeyPress ();
	}

	void KeyPress(){
		if(Input.GetKeyDown(KeyCode.R)){
			SceneManager.LoadScene ("MainScene");
		} else if(Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit();
		}
	}
}
