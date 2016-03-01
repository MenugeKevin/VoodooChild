using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerAttack : MonoBehaviour {

    public float violence;
    public List<GameObject> _gO;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void isAttacked(Vector3 enemypos)
    {
        //transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x - 2, transform.position.y, transform.position.z - 2), Time.deltaTime * 2);
        float tmpX, tmpZ;
        tmpX = transform.position.x - enemypos.x;
        tmpZ = transform.position.z - enemypos.z;
        GetComponent<Rigidbody>().AddForce(new Vector3(tmpX * violence, 0, tmpZ * violence));
        System.Random rnd = new System.Random();
        int angle = rnd.Next(180, 360);
        transform.Rotate(new Vector3(0, angle, 0) * 30 * Time.deltaTime);
        Debug.Log("Je suis attaque");
    }
    
    public void spawn(int id)
    {
    	transform.position = _gO[id].transform.position;
    }
}
