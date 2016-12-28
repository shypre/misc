using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

	public Rigidbody rb;
	public float movespeed, rotatespeed;
	private float moveX, rotateX;
	private Vector3 movement, rotation;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate ()
	{
		moveX = Input.GetAxis ("Vertical");
		rotateX = Input.GetAxis ("Horizontal");

		movement = new Vector3 (0, 0, moveX);
		rotation = new Vector3 (0, rotateX, 0);
		rb.transform.Translate (movement*movespeed);
		rb.transform.Rotate (rotation*rotatespeed);
	}
}
