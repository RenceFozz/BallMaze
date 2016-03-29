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
		redZ = GameObject.FindGameObjectsWithTag ("RedZone");
		greenZ = GameObject.FindGameObjectWithTag ("GreenZone");
		pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}

	void Update () {
		for (int i = 0; i < redZ.Length; i++){
			GOT = redZ[i].GetComponent<ZoneController> ().gameOverText;
			if(GOT != ""){
				GetComponent <TextMesh>().text = GOT;
				pc.setAllToZero();
			}
		}
		if(greenZ.GetComponent<ZoneController> ().gameOverText != ""){
			GOT = greenZ.GetComponent<ZoneController> ().gameOverText;
			t.position = new Vector3 (t.position.x + move, t.position.y, t.position.z);
			move = 0;
			GetComponent <TextMesh>().text = GOT;
			//pc.ballSpeed = 0.0f;
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
