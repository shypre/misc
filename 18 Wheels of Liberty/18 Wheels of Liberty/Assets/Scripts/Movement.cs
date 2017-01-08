using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	public Rigidbody rbCharacter;
	public float MoveSpeedMultiplier, RotateSpeedMultiplier;
	private float Velocity;
	private float HorizontalAxisValue, VerticalAxisValue;
    private Vector3 Rotation;

	void Start()
	{
		rbCharacter = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		HorizontalAxisValue = Input.GetAxis("Horizontal");
		VerticalAxisValue = Input.GetAxis("Vertical");
        if (Velocity >= 0)
        {
            if (VerticalAxisValue > 0)
            {
                Velocity += MoveSpeedMultiplier;
            }
            else if (VerticalAxisValue < 0)
            {
                Velocity -= MoveSpeedMultiplier;
            }
        }
        else if (Velocity < 0)
        {
            if (VerticalAxisValue >= 0)
            {
                Velocity = 0;
            }
            else
            {
                Velocity = Velocity * 1.05;
            }
        }
        Rotation = new Vector3(0, 0, HorizontalAxisValue);
        rbCharacter.transform.Rotate(Rotation);

	}
}
