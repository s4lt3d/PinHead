using UnityEngine;
using System.Collections;

public class PlayerMovementBehaviour : MonoBehaviour
{

	[Header("Component References")]
	public Rigidbody playerRigidbody;

	[Header("Movement Settings")]
	
	public float horizontalSpeed = 1.0f;
	public float jumpForce = 1.0f;
	
	public float swingDeltaTime = 0.2f;
	public ParticleSystem dust;

	float nextBulletTime = 0;
	float horizonalAxis;
	int jump = 0;


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
		jump = 1;
    }

	void Update()
	{
		horizonalAxis = movementDirection.x;
		if (horizonalAxis < 0)
			gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));

		if (horizonalAxis > 0)
			gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

		//if (Input.GetButton("Jump") && jump == 0)
		//	jump = 1;

		/*if (Input.GetButton("Fire1"))
		{

			if (Time.time >= nextBulletTime)
			{
				//nextBulletTime = Time.time + bulletDeltaTime;
				//Instantiate(bullet, bulletSpawnPoint.transform.position, transform.rotation);
				//playerRigidbody.AddRelativeForce(gunKickForce, ForceMode.Impulse);
			}
		}
		*/
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		playerRigidbody.AddForce(new Vector3(horizonalAxis * horizontalSpeed, 0, 0), ForceMode.Impulse);
		if (jump == 1)
		{
			jump++;
			playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Ground"))
		{
			jump = 0;
			dust.Play();
		}
	}
}
