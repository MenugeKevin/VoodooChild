using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	private float _timer = 0;
	Text score;
	
	// Use this for initialization
	void Start () {
		score = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		_timer += Time.deltaTime;
		score.text =  _timer.ToString("F2");
	}
	
}
