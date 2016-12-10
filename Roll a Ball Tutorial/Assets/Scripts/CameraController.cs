using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;
    private Vector3 offsetrotation;

	// Use this for initialization
	void Start ()
    {
        offset = transform.position - player.transform.position;
        offsetrotation = new Vector3(0, Input.GetAxis("Mouse X"), 0);
	}
	
	void LateUpdate ()
    {
        transform.position = player.transform.position + offset;

        Vector3 rotation = new Vector3(0, Input.GetAxis("Mouse X"), 0);
        transform.Rotate(rotation - offsetrotation, Space.World);
	}
}
