using UnityEngine;
using System.Collections;

public class FirePlace : MonoBehaviour {

	public GameObject _doorToOpen;
	public GameObject _flame;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider other)
	{
	if (other.tag == "Buche")
		{
			_doorToOpen.GetComponent<Door>()._state = true;
			other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
			_flame.SetActive(true);
		}
	}
}
