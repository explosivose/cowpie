using UnityEngine;
using System.Collections;

public class BetsyController : MonoBehaviour {

	public float moveSpeed;
	public static float distanceTraveled;

	private bool onGround = true;
	private SpritePhysics physics;

	void Start () {
		physics = GetComponent<SpritePhysics>();
	}

	void Update () {

		physics.moveSpeed = moveSpeed;

		if (Input.GetAxis("Horizontal") != 0){
			physics.isMoving = true;
			physics.velocity.x += Input.GetAxis("Horizontal");
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

		
		