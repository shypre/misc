using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    //TODO: Turn globals into local variables
	public Rigidbody rbCharacter;
	public float MoveSpeedMultiplier, RotateSpeedMultiplier, VelocityGainMultiplier;
	private float Velocity = 0.0005f;
    private float Sqrt2 = 1.5f; //Mathf.Sqrt(2.0f);
    private float HalfSqrt2 = 0.75f; //Sqrt2/2.0f;
	private bool isForward, isBack, isLeft, isRight;
    private Vector3 Rotation, Movement, Direction, Position, OffsetAngleTop, OffsetAngleBottom, temp1, temp2;
    Ray RaycastRay;
    RaycastHit HitInfo;
    public Text Speed;

	void Start()
    //standard Unity function
	{
		rbCharacter = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
    //standard Unity function
	{
        //TODO: Change random constants into variables and tidy up
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
                Velocity += (10.0f - Velocity)/(Velocity * MoveSpeedMultiplier + 10000.0f);
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
            Rotation = new Vector3(0.0f, RotateSpeedMultiplier * -1.0f, 0.0f);
            rbCharacter.transform.Rotate (Rotation);
        }
        else if (isRight)
        {
            Rotation = new Vector3(0.0f, RotateSpeedMultiplier, 0.0f);
            rbCharacter.transform.Rotate (Rotation);
        }

		/* Movement = new Vector3 (0, 0, Velocity);
		rbCharacter.transform.Translate (Movement); */
        Position = transform.position;
        if (Velocity != 0.0f)
        {
            temp1 = Position + new Vector3(0.0f, Velocity, 0.0f);
            temp2 = new Vector3(1.0f, -HalfSqrt2, 0.0f);
            Debug.Log("first: " + temp1.ToString("F5"));
            Debug.Log("second: " + temp2.ToString("F5"));
            RaycastRay = new Ray(temp1, temp2);
            Debug.DrawRay(temp1, temp2 * 100, Color.black, 10);
            if (Physics.Raycast(RaycastRay, out HitInfo, (Velocity * 1.5f) + 1.5f))
            {
                Debug.Log("HIT");
                Debug.Log(HitInfo.point.ToString("F5"));
                transform.position = HitInfo.point + new Vector3(0.0f, Velocity, 0.0f);
            }

        }
		/* RaycastHit hit = new RaycastHit();
		Ray ray = new Ray (transform.TransformPoint (transform.localPosition + offsetY), transform.TransformPoint (offsetX - offsetY));
		Physics.Raycast (ray, out hit, Velocity * 5.0f);
		transform.Translate (hit.point); */

        Speed.text = "Speed: " + Velocity.ToString();
	}
}
