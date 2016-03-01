using UnityEngine;
using System.Collections;

public class SimpleEnemy : MonoBehaviour {

    public GameObject _target;
    public float _speed = 5.0f;
    private bool _isActivated = false;
    private Vector3 _spawn;
    // Use this for initialization
	void Start () {
        _spawn = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	}

    void FixedUpdate()
    {
        if (_isActivated)
        {
            if (_target)
                transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);
        }
        else
        {
            transform.position = _spawn;
        }
    }

    public void setActivate(bool state)
    {
        _isActivated = state;
    }
}
