using UnityEngine;
using System.Collections;
using System.Diagnostics;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour {

	private Stopwatch shieldTimer;
	private GameObject shield;
	private Color shieldColor;
	private int shieldRepairTime = 100;
	public bool shieldDown;

	private bool shieldDownByLeftLaser = false;
	private bool shieldDownByRightLaser = false;

	// Use this for initialization
	void Start () {
		shieldTimer = new Stopwatch();
		shield = GameObject.Find("OuterSphere");
		shieldColor = shield.GetComponent<Renderer>().material.color;
		shieldColor.a = 0.4f;
		shield.GetComponent<Renderer>().material.color = shieldColor;

		shieldDown = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(shieldTimer.IsRunning && shieldTimer.ElapsedMilliseconds > shieldRepairTime){
			shieldColor.a = 0.4f;
			shield.GetComponent<Renderer>().material.color = shieldColor;
			shieldTimer.Stop();
			shieldTimer.Reset();
			shieldDown = false;
			shieldDownByLeftLaser = false;
			shieldDownByRightLaser = false;
		}
	}

	public void Hit(bool isLeftLaser){
		
		if(shieldDown && shieldDownByLeftLaser && !isLeftLaser){
			levelComplete();
		}

		if(shieldDown && shieldDownByRightLaser && isLeftLaser){
			levelComplete();
		}

		shieldTimer.Stop();
		shieldTimer.Reset();

		shieldTimer.Start();


		shieldColor.a = 0;
		shield.GetComponent<Renderer>().material.color = shieldColor;
		shieldDown = true;

		if(isLeftLaser){
			shieldDownByLeftLaser = true;
		}else{
			shieldDownByRightLaser = true;
		}
	}

	private void levelComplete(){

		var score = GameObject.FindWithTag("ScoreDisplay");
		
		score.GetComponent<ScoreDisplay>().increaseScore();

		SceneManager.LoadScene("gamescene");
	}

}
