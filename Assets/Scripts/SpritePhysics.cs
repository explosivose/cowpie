using UnityEngine;
using System.Collections;

public class SpritePhysics : MonoBehaviour {

	public float moveSpeed;

	public bool isJump = false;
	public bool isMoving = false;
	public Vector2 velocity = Vector2.zero;

	private float gravity = 0.1f;
	private Vector2 maxVelocity = new Vector2(1f, 2f);
	private Vector2 drag = new Vector2(0.2f, 0);

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		Vector2 currentPosition = transform.position;

		// Max Velocity
		velocity.x = Mathf.Clamp(velocity.x, -maxVelocity.x, maxVelocity.x);
		velocity.y = Mathf.Clamp(velocity.y, -maxVelocity.y, maxVelocity.y);

		if (isMoving == false)
		{
			if (velocity.x - (drag.x) > 0)
				velocity.x -= drag.x;
			else if (velocity.x + (drag.x) < 0)
				velocity.x += drag.x;
			else
				velocity.x = 0;
		}

		if (transform.position.y > 0.5 || isJump)
		{
			velocity.y -= gravity;
			isJump = false;
		}else{
			velocity.y = 0;
		}
		
		// Update position
		Vector2 target = currentPosition + velocity * moveSpeed;
		transform.position = Vector2.Lerp ( currentPosition, target, Time.deltaTime );
	
	}
}
