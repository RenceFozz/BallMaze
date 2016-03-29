using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float ballSpeed = 10f;

	private Rigidbody rb;

	void Start (){
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate () {
		float moveX = Input.GetAxis("Horizontal");
		float moveZ = Input.GetAxis("Vertical");

		Vector3 move = new Vector3 (moveX,0f,moveZ);
		rb.velocity = move * ballSpeed;
	}
}
