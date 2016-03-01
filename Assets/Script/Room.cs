using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Room : MonoBehaviour {

	public GameObject _door;
	public List<GameObject> _listIA;
	public List<GameObject> _deactivateRoom;
	public List<GameObject> _activateRoom;
    public bool _actAI = false;
    
    private bool _inRoom = false;
    private int _roomId = 0;
	private float _timer = 0;
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (_inRoom) {
			_timer += Time.deltaTime;
			if (_timer > 2f)
			{
				foreach (GameObject go in _deactivateRoom) {
					go.SetActive(false);
				}
			}
		}
	}

    void OnTriggerEnter(Collider other)
    {
		_inRoom = true;
		foreach (GameObject go in _activateRoom) {
			go.SetActive(true);
		}
        if (other.tag == "Player") {
			GetComponentInParent<RoomManager> ().changeActualRoom (_roomId);
			if (_door)
				_door.GetComponent<Door>()._state = false;
			for (int i = 0; i < _listIA.Count; ++i)
			{
				if (_listIA[i])
					_listIA[i].GetComponent<EnemyAI>().Activate(_actAI);
			}
		}

	}

    public void setRoomId(int id)
    {
        _roomId = id;
    }
}
