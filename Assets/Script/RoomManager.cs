using UnityEngine;
using System.Collections;

public class RoomManager : MonoBehaviour {

    public int _actualRoom = 0;

	// Use this for initialization
	void Start () {
    	for (int i = 0; i < transform.childCount; ++i)
        {
            if (transform.GetChild(i))
                transform.GetChild(i).gameObject.GetComponent<Room>().setRoomId(i+1);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void changeActualRoom(int id)
    {
        _actualRoom = id;
    }
}
