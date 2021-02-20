using UnityEngine;
using System.Collections.Generic;

public class PlayerMovementBehaviour : MonoBehaviour
{

	[Header("Component References")]
	public Rigidbody2D playerRigidbody;
	public Transform tip;
	public Animator animator;
	public ParticleSystem dust;
	public CapsuleCollider groundDetector;
	public PaddleSwing paddleSwing;

	[Header("Gravity Settings")]
	public Vector3 gravity = new Vector3(0, -40, 0);


	[Header("Jump Settings")]

	//public Vector3 jumpSpeed = new Vector3(0, 60, 0);
	public float jumpForce = 1.0f;
	[Range(0.1f, 1)] public float jumpTimeMax = 0.3f;

	[Header("Movement Settings")]
	public float horizontalSpeed = 1.0f;

	[Header("Paddle Settings")]
	public float explosiveForce = 10;
	[Range(0.05f, 1)] public float swingTime = 0.1f;
	

	
	float horizonalAxis;
	bool jump = false;
	bool jumpPrev = false;
	bool jumpChange = false;
	bool jumpAllow = false;
	bool isGrounded = true;

	// Jump state machine:
	enum Jump_State { grounded, jumping, falling, wait_for_ground};
	Jump_State jumpState;


	bool swingCCW = false;
	bool swingCCWPrev = false;
	bool swingCCWChange = true;


	bool swingCW = false;
	bool swingCWPrev = false;
	bool swingCWChange = true;

	List<GameObject> pinBallObjects = new List<GameObject>();

	float jumpStartTime;

	float swingStartTime;
	

	private Vector3 movementDirection;

	// Use this for initialization
	void Start()
	{
		
	}

	public void UpdateMovementData(Vector3 newMovementDirection)
    {
		movementDirection = newMovementDirection;
	}

	public void UpdateJumpData(bool newJump)
	{

		jumpPrev = jump;
		jump = newJump;
		if (jumpPrev != jump)
			jumpChange = true;
	}

	public void UpdateSwingCCWData(bool newSwing)
	{
		swingCCWPrev = swingCCW;
		swingCCW = newSwing;
		if (swingCCWPrev != swingCCW)
			swingCCWChange = true;
	}

	public void UpdateSwingCWData(bool newSwing)
	{
		swingCWPrev = swingCW;
		swingCW = newSwing;
		if (swingCWPrev != swingCW)
			swingCWChange = true;
	}


	// Update is called once per frame
	void FixedUpdate()
	{
		horizonalAxis = movementDirection.x;
		
		playerRigidbody.velocity = new Vector3(horizonalAxis * horizontalSpeed * Time.deltaTime, playerRigidbody.velocity.y, 0);
		

		switch(jumpState)
        {
			case Jump_State.grounded:
				if(jump)
					jumpState = Jump_State.jumping;
				jumpStartTime = Time.fixedTime;
				break;

			case Jump_State.jumping:
				isGrounded = false;
				if (jump == false)
					jumpState = Jump_State.falling;
				if ((Time.fixedTime - jumpStartTime) > jumpTimeMax)
					jumpState = Jump_State.falling;
				break;

			case Jump_State.falling:
				if (isGrounded)
					jumpState = Jump_State.wait_for_ground;
				break;

			case Jump_State.wait_for_ground:
				if (jump == false)
					if (isGrounded)
						jumpState = Jump_State.grounded;
					else
						jumpState = Jump_State.falling;
				break;

			default:
				if (isGrounded)
					jumpState = Jump_State.grounded;
				break;
        }


		Vector3 jumpVector = gravity.normalized * -1 * jumpForce;

		if (jumpState == Jump_State.jumping)
		{			
			playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpVector.y);
		}

		if (swingCCWChange)
		{
			if (swingCCWChange)
				swingStartTime = Time.fixedTime;
			swingCCWChange = false;
			

			animator.SetBool("SwingCCW", swingCCW);
		}
		if (swingCWChange)
		{
			if (swingCWChange)
				swingStartTime = Time.fixedTime;
			swingCWChange = false;


			animator.SetBool("SwingCW", swingCW);
		}

		if (Time.fixedTime - swingStartTime < swingTime)
		{
			paddleSwing.swinging = true;
		}
		else
        {
			paddleSwing.swinging = false;
		}

		playerRigidbody.AddForce(gravity);
	}

	void OnCollisionEnter2D(Collision2D other)
	{

		if (other.gameObject.CompareTag("Ground"))
		{
			jumpAllow = true;
			dust.Play();
			isGrounded = true;
			
		}
	}

    void OnCollisionExit2D(Collision2D other)
    {
		if (other.gameObject.CompareTag("Ground"))
		{
			//jumpAllow = false;
			//dust.Play();
			//isGrounded = false;

		}
	}
}
