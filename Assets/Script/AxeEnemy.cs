using UnityEngine;
using System.Collections;

public class AxeEnemy : MonoBehaviour {

	public int idSpawn;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			//other.GetComponent<PlayerAttack>().isAttacked(transform.position);
			other.GetComponent<PlayerAttack>().spawn(idSpawn);
			
		}
	}
}
