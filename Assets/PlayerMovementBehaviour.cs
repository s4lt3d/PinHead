using UnityEngine;
using System.Collections.Generic;

public class PlayerMovementBehaviour : MonoBehaviour
{

	[Header("Component References")]
	public Rigidbody playerRigidbody;
	public GameObject swingPivot;
	public Transform tip;

	[Header("Gravity Settings")]
	public Vector3 gravity = new Vector3(0, -30, 0);


	[Header("Movement Settings")]
	
	public float horizontalSpeed = 1.0f;
	public float jumpForce = 1.0f;
	
	public float swingDeltaTime = 0.2f;
	public ParticleSystem dust;

	public float pivotRest = 0;
	public float pivotSwing = -45;
	public float swingSpeed = 20;

	public float explosiveForce = 10;

	float nextSwingTime = 0;
	float horizonalAxis;
	int jump = 0;
	bool swing = false;
	bool swingPrev = false;
	bool swingChange = true;
	float direction = 180;
	List<GameObject> pinBallObjects = new List<GameObject>();
	

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
		
		if (newJump)
		{

			if(jump == 0)
				jump = 1;
		}
    }

	public void UpdateSwingData(bool newSwing)
	{
		swingPrev = swing;
		swing = newSwing;
		if (swingPrev != swing)
			swingChange = true;
	}


	// Update is called once per frame
	void FixedUpdate()
	{
		horizonalAxis = movementDirection.x;
		
		playerRigidbody.velocity = new Vector3(horizonalAxis * horizontalSpeed * Time.deltaTime, playerRigidbody.velocity.y, 0);
		

		if (jump == 1)
		{
			jump++;
			if (Mathf.Abs(playerRigidbody.velocity.y) < 30)
				playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
		}

		if (swingChange)
		{
			swingChange = false;

			if (swing)
			{
				transform.rotation = Quaternion.Euler(0, 0, pivotSwing);
				//playerRigidbody.MoveRotation(Quaternion.Euler(0, direction, pivotSwing));
			}

			else
			{
				transform.rotation = Quaternion.Euler(0, 0, pivotRest);
				//playerRigidbody.MoveRotation(Quaternion.Euler(0, direction, pivotRest));
			}

			foreach (GameObject o in pinBallObjects)
			{
				o.GetComponent<Rigidbody>().AddExplosionForce(explosiveForce, tip.position, 5.5f);
			}
		}

		playerRigidbody.AddForce(gravity, ForceMode.Acceleration);
	}

	void OnCollisionEnter(Collision other)
	{

		if (other.gameObject.CompareTag("Ground"))
		{
			jump = 0;
			dust.Play();
		}
		else if(other.gameObject.CompareTag("Pinball"))
		{
			pinBallObjects.Add(other.gameObject);
        }
	}

    void OnCollisionExit(Collision collision)
    {
		pinBallObjects.Remove(collision.gameObject);
    }
}
