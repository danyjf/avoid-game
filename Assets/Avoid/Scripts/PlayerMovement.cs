using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour {

	[SerializeField]
	float moveSpeed = 15f;

	[SerializeField]
	float angularSpeed = 45.0f;

	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
        Vector3 joystickInput = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical"), 0);

        float targetAngle = 90 - Mathf.Asin(joystickInput.y) * Mathf.Rad2Deg;

        if(joystickInput.x > 0)
        {
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, -targetAngle, angularSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, 0, angle);
        }
        else if(joystickInput.x < 0)
        {
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, targetAngle, angularSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, 0, angle);
        }
    }		

	void FixedUpdate () {
		rb.velocity = transform.up * moveSpeed;
    }
}
