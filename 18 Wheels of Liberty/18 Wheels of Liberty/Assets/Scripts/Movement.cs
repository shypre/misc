using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

	public Rigidbody rb;
	public float speed;
	private float moveX, moveY;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate ()
	{
		moveX = Input.GetAxis ("Horizontal");
		moveY = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveX, 0, moveY);
		rb.transform.Translate (movement*speed);
	}
}
