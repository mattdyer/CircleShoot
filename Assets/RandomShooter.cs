using UnityEngine;
using System.Collections;
using System;
using System.Diagnostics;
using UnityEngine.UI;

public class RandomShooter : MonoBehaviour {

	[SerializeField]
    private bool leftTrigger = true; 

	private RectTransform m_Transform;
	private Transform GameWorldTrasform;
	private Image m_Image;
	private Color color;
	private float speed;

	private float rateOfFire = 500;
	private float randomPositionMultiplier;

	private Stopwatch shootTimer;

	private GameObject canvas;

	// Use this for initialization
	void Start () {
		m_Transform = GetComponent<RectTransform>();
		GameWorldTrasform = GetComponent<Transform>();
		m_Image = GetComponent<Image>();
		canvas = GameObject.Find("Canvas");

		randomPositionMultiplier = (float) UnityEngine.Random.value;

		setTriggerPosition();

		setColor();

		shootTimer = new Stopwatch();

	}
	
	void setTriggerPosition(){

		float canvasHeight = canvas.GetComponent<RectTransform>().rect.height;

		float usableHeight = canvasHeight - (canvasHeight / 4);

		float newY = (usableHeight * randomPositionMultiplier) - (usableHeight / 2);
		UnityEngine.Debug.Log(newY);
		//UnityEngine.Debug.Log(Screen.height);
		//UnityEngine.Debug.Log(randomPositionMultiplier);
		m_Transform.anchoredPosition = new Vector3(m_Transform.anchoredPosition.x,newY,0f);
	}

	void setColor(){
		color = Color.blue;

		speed = (float) UnityEngine.Random.value;
		color.b = speed;


		m_Image.color = color;
	}

	// Update is called once per frame
	void Update () {
		//setTriggerPosition();
	}

	public void Shoot () {
		if(!shootTimer.IsRunning || shootTimer.ElapsedMilliseconds > rateOfFire){
			shootTimer.Reset();
			shootTimer.Start();
		
			GameObject laser = Instantiate(GameObject.FindWithTag("Laser"));
			laser.GetComponent<Laser>().setLaserPrototype(false);
			
			laser.GetComponent<Laser>().setSpeed(speed);
			laser.tag = "Untagged";
			laser.GetComponent<Laser>().leftLaser = leftTrigger;

			Transform laserTransform = laser.GetComponent<Transform>();

			laserTransform.position = GameWorldTrasform.position;
		}
	}
}
