using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {
	[SerializeField]
	private bool laserPrototype = true;

	private Transform trasform;
	private Rigidbody body;
	private GameObject target;
	private float speed;
	private float speedMultiplier = 5;

	public bool leftLaser;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody>();
		target = GameObject.FindWithTag("Target");
		if(!laserPrototype){
			Vector3 directionVector = target.GetComponent<Transform>().position - body.position;
			body.velocity = directionVector.normalized * ((speed + 0.5f) * speedMultiplier);

			Vector3 rotationVector = Quaternion.AngleAxis(-90, Vector3.forward	) * directionVector;

			body.rotation = Quaternion.LookRotation(rotationVector);

			GetComponent<Renderer>().material.color = Color.red;
		}

	}
	
	// Update is called once per frame
	void Update () {
		if(!laserPrototype){
			if((body.position - target.GetComponent<Transform>().position).magnitude < 0.5){
				Destroy(gameObject);
				
				target.GetComponent<Target>().Hit(leftLaser);
				
			}
		}
		
	}

	public void setLaserPrototype(bool setting){
		laserPrototype = setting;
	}

	public void setSpeed(float newSpeed){
		speed = newSpeed;
	}
}
