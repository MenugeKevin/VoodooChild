using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	Animator anim;
	public bool _state = false;
	private bool _laststate;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		_laststate = _state;
	}
	
	// Update is called once per frame
	void Update () {
		if (_laststate != _state) {
			GetComponent<AudioSource> ().Play ();
			_laststate = _state;
		}
		anim.SetBool ("ouverture", _state);
	}
}
