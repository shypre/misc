using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    //TODO: Turn globals into local variables
	public Rigidbody rbCharacter;
	public float MoveSpeedMultiplier, RotateSpeedMultiplier, VelocityGainMultiplier;
	private float Velocity = 5.0f;
    private float Sqrt2 = 1.5f; //Mathf.Sqrt(2.0f);
    private float HalfSqrt2 = 0.75f; //Sqrt2/2.0f;
	private bool isForward, isBack, isLeft, isRight;
    private Vector3 Rotation, Movement, Direction, Position, OffsetAngleTop, OffsetAngleBottom;
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
        Direction = transform.eulerAngles;
        OffsetAngleTop = new Vector3(Velocity * HalfSqrt2, Velocity * HalfSqrt2, 0.0f);
        OffsetAngleBottom = new Vector3(Velocity * HalfSqrt2, Velocity * HalfSqrt2 * -1.0f, 0.0f);
        if (Velocity != 0.0f)
        {
            RaycastRay = new Ray(Position, Direction + OffsetAngleBottom);
            if (Physics.Raycast(RaycastRay, out HitInfo, Velocity * HalfSqrt2))
            {
                transform.Translate(HitInfo.point);
            }
            else
            {
                RaycastRay = new Ray();
            }

        }
		/* RaycastHit hit = new RaycastHit();
		Ray ray = new Ray (transform.TransformPoint (transform.localPosition + offsetY), transform.TransformPoint (offsetX - offsetY));
		Physics.Raycast (ray, out hit, Velocity * 5.0f);
		transform.Translate (hit.point); */

        Speed.text = "Speed: " + Velocity.ToString();
	}
}
