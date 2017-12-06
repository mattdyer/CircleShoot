using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

	private Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
		updateScoreDisplay();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void increaseScore(){
		PlayerPrefs.SetInt("currentLevel",PlayerPrefs.GetInt("currentLevel",0) + 1);

		updateScoreDisplay();
	}

	private void updateScoreDisplay(){
		text.text = "Levels Completed: " + PlayerPrefs.GetInt("currentLevel",0);
	}

}
