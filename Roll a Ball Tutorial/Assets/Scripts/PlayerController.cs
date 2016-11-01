using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    void start()
    {
        rb=GetComponent<Rigidbody>();
    }

	void Update()
	{
		
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Verical");

       		Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        rb.AddForce(movement);
	}
}
