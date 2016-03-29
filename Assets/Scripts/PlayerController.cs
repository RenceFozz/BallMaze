using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float ballSpeed = 10.0f;

	private Rigidbody rb;

	void Start (){
		rb = GetComponent<Rigidbody>();
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
}
