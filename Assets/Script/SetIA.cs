using UnityEngine;
using System.Collections;

public class SetIA : MonoBehaviour {
	
	public GameObject IA;
	public bool _state;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other)
	{
	if (other.tag == "Player")
		if(IA)
			IA.GetComponent<EnemyAI>().Activate(_state);
	}
}
