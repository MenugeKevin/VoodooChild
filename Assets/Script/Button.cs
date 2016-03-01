using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	public Material _newMat;
	public GameObject _Ia;
	public GameObject _doorToOpen;
	public float nbMax = 1;
	
	private bool _playerIn = false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (_playerIn) {
			if (Input.GetKeyDown(KeyCode.JoystickButton2))
			{
				if (_Ia)
				{
					_Ia.GetComponent<EnemyAI>().Activate(true);
				}
				GetComponent<MeshRenderer>().material = _newMat;
				GetComponent<BoxCollider>().enabled = false;
				_playerIn = false;
				GameManager.setNb(GameManager.getNb() + 1);
				if (GameManager.getNb() == nbMax)
				{
					GameManager.setNb(0);
					_doorToOpen.GetComponent<Door>()._state = true;
				}
			}
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		_playerIn = true;
	}
	
	void OnTriggerExit(Collider other)
	{
		_playerIn = false;
	}
	
}
