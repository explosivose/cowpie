using UnityEngine;
using System.Collections;

public class BetsyController : MonoBehaviour {

	public float moveSpeed;
	public static float distanceTraveled;
	public static bool onGround = true;

	private SpritePhysics physics;

	void Start () {
		physics = GetComponent<SpritePhysics>();
	}

	void Update () {

		physics.moveSpeed = moveSpeed;

		if (Input.GetAxis("Horizontal") != 0){
			physics.isMoving = true;
			physics.velocity.x += Input.GetAxis("Horizontal");

			if (Input.GetAxis("Horizontal") < 0)
				transform.localRotation = Quaternion.Euler(0,180, 0);
			
			if (Input.GetAxis("Horizontal") > 0)
				transform.localRotation = Quaternion.Euler(0, 0, 0);
		}
		else{
			physics.isMoving = false;
		}

		if(transform.position.y < 0.5){
			onGround = true;
		}

		if (Input.GetButtonDown("Jump") && onGround){
			physics.velocity.y += 10;
			physics.isJump = true;
			onGround = false;
		}

		distanceTraveled = transform.localPosition.x;
	}
}

		
		