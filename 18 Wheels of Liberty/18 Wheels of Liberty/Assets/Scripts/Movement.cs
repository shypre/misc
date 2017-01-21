using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
	public Rigidbody rbCharacter;
	public float MoveSpeedMultiplier, RotateSpeedMultiplier, VelocityGainMultiplier;
	private float Velocity;
	private bool isForward, isBack, isLeft, isRight;
    private Vector3 Rotation, Movement;
    public Text Speed;

	void Start()
	{
		rbCharacter = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
        isForward = Input.GetButton("Forward");
        isBack = Input.GetButton("Back");
        isLeft = Input.GetButton("Left");
        isRight = Input.GetButton("Right");
        if (Velocity == 0.0f)
        {
            if (isBack)
            {
                Velocity = -0.01f;
            }
            else if (isForward)
            {
                Velocity += MoveSpeedMultiplier;
            }
        }
		else if (Velocity > 0.0f)
        {
			if (isForward)
            {
                Velocity += (10 - Velocity)/(Velocity * MoveSpeedMultiplier + 10000);
			}
			else if (isBack)
            {
                Velocity -= (MoveSpeedMultiplier * 0.1f) + (Velocity * 0.01f) + 0.001f;
			}
            else
            {
                Velocity -= (Velocity * 0.01f) + 0.001f;
            }
		}
        else if (Velocity < 0.0f)
        {
            if (!(isBack))
            {
				Velocity = 0.0f;
			}
            else if (isBack)
            {
                Velocity = Velocity * VelocityGainMultiplier;
			}
		}
        if (isLeft)
        {
            Rotation = new Vector3(0, RotateSpeedMultiplier * -1, 0);
            rbCharacter.transform.Rotate (Rotation);
        }
        else if (isRight)
        {
            Rotation = new Vector3(0, RotateSpeedMultiplier, 0);
            rbCharacter.transform.Rotate (Rotation);
        }
		Movement = new Vector3 (0, 0, Velocity);
		rbCharacter.transform.Translate (Movement);

        Speed.text = "Speed: " + Velocity.ToString();
	}
}
