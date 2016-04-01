using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour {

	public float ballSpeed = 10.0f;

	private Rigidbody rb;

	public string gameOverText = "";
	public AudioClip impact;

	AudioSource audio1; 
	AudioSource audio2; 
	AudioSource audio3;

	void Start (){
		rb = GetComponent<Rigidbody>();
		AudioSource[] audios = GetComponents<AudioSource>(); 
		audio1 = audios[0]; 
		audio2 = audios[1]; 
		audio3 = audios[2];
	}

	void Update () {
		float moveX = Input.GetAxis("Horizontal");
		float moveZ = Input.GetAxis("Vertical");

		Vector3 move = new Vector3 (moveX,0f,moveZ);

		rb.AddForce (move * ballSpeed);
		//rb.velocity = move * ballSpeed;
	}

	public void setAllToZero(){
		ballSpeed = 0.0f;
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
	}

	void OnTriggerEnter(Collider other){
		//print (gameObject.tag);
		if(other.gameObject.tag == "RedZone" && gameObject.tag == "Player"){
			//print ("REDEAD");
			audio1.Stop ();
			audio3.loop = false;
			audio3.Play ();
			//GetComponent<AudioSource>().PlayOneShot(impact);
			gameOverText = "GAME OVER";
		} else {
			//print ("YOU LIVE!");
			audio1.Stop ();
			audio2.loop = false;
			audio2.Play ();
			//GetComponent<AudioSource>().PlayOneShot(impact);
			gameOverText = "YOU WIN!";
		}
	}
}
