using UnityEngine;
using System.Collections;

public class PaintTrigger : MonoBehaviour {

	public GameObject _Button;
	public bool _end = false;

	Animator anim;
	bool _state = false;
	bool _playerIn = false;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (_playerIn) {
			if (Input.GetKeyDown(KeyCode.JoystickButton2))
			{
			if (_end)
			{
				Application.LoadLevel(0);
			}
				anim.SetBool("Open", true);
				GetComponent<BoxCollider>().enabled = false;
				_playerIn = false;
				if (_Button)
					_Button.GetComponent<BoxCollider>().enabled = true;
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
	if (other.tag == "Player")
		_playerIn = true;
	}

	void OnTriggerExit(Collider other)
	{
	if (other.tag == "Player")
		_playerIn = false;
	}

}
