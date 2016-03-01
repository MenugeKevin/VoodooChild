using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

    public float _speedCam; 
    public GameObject _roomManager;

    private int _actualRoom = 0;
    private GameObject[] _childObjects;
    private Camera _mainCam;
    private Vector3 vel = Vector3.zero;

	// Use this for initialization
	void Start () {
        _mainCam = Camera.main;
        _childObjects = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; ++i)
        {
            _childObjects[i] = transform.GetChild(i).gameObject;
        }
	}
	
	// Update is called once per frame
	void Update () {
		int actualRoom = _roomManager.GetComponent<RoomManager> ()._actualRoom;
		if (actualRoom == 18)
			actualRoom = 0;
        _mainCam.transform.position = Vector3.SmoothDamp(_mainCam.transform.position, _childObjects[actualRoom].transform.position, ref vel, Time.deltaTime * _speedCam);
        _mainCam.transform.rotation = Quaternion.Lerp(_mainCam.transform.rotation, _childObjects[actualRoom].transform.rotation, Time.deltaTime * _speedCam);
	}
}
