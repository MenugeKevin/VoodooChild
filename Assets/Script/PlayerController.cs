    using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public enum LegForward
    {
        NOTHING = 0,
        LEFT,
        RIGHT,
        ATTACK
    }

	// Use this for initialization
	void Start () {
        _anim = GetComponent<Animator>();
        _rigid = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {
	if (trigger)
	{
		triggerdestroy += Time.deltaTime;
		if (triggerdestroy > 5f)
		{
				if (transform.GetChild(6))
					transform.GetChild(6).gameObject.SetActive(false);
		}
	}
        if (_state != LegForward.ATTACK)
        {
            _isGrounded = Physics.OverlapSphere(transform.position, _radiusOverlap, _whatIsGround);
            if (_isGrounded.Length > 0)
            {
                handleMovement();
            }
            if (_isJumping)
            {
                jump();
                _isJumping = false;
            }
        }
	}

    void FixedUpdate()
    {
        switch (_state)
        {
            case LegForward.LEFT:
                movePlayer(_state);
                break;
            case LegForward.RIGHT:
                movePlayer(_state);
                break;
            case LegForward.NOTHING:
                break;
            default:
                break;
        }
    }

    void    handleMovement()
    {
        if (Input.GetKeyDown(KeyCode.A) && _lastState != LegForward.LEFT)
        {
            _anim.SetBool("Walk", true);
            _state = LegForward.LEFT;
            _lastState = _state;
            _nextIdle = 0;
        }
        else if (Input.GetKeyDown(KeyCode.D) && _lastState != LegForward.RIGHT)
        {
            _anim.SetBool("Walk", true);
            _state = LegForward.RIGHT;
            _lastState = _state;
            _nextIdle = 0;
        }
        else
        {
            _nextIdle += Time.deltaTime;
            if (_nextIdle > _delay)
            {
                _anim.SetBool("Walk", false);
                _nextIdle = 0;
                _state = LegForward.NOTHING;
                _accel = 1f;
            }
        }
    }

    private void jump()
    {
        _rigid.AddForce(new Vector3(_rigid.velocity.x, _jumpForce, _rigid.velocity.z));
    }

    private void movePlayer(LegForward leg)
    {
        transform.Translate(Vector3.forward * Time.deltaTime * _speed * _accel);
        if (_accel < _maxAccel)
        	_accel += _incAccel;
    }

    public void setJumping(bool jump)
    {
        if (_isGrounded.Length > 0)
            _isJumping = jump;
    }

    public bool isGrounded()
    {
        if (_isGrounded != null)
            if (_isGrounded.Length > 0)
                return true;
        return false;
    }

    public void setAnim(string name, bool state)
    {
        _anim.SetBool(name, state);
    }

    public void setEnum(LegForward type)
    {
        _state = type;
    }
    
    public LegForward getEnum()
    {
    	return _state;
    }

    public void Attack()
    {
    	Debug.Log ("Launching Attack");
		Collider[] hit =  Physics.OverlapSphere(new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 1.5f), 1.5f, _enemy);
        foreach (Collider collide in hit)
        {
    	    	Debug.Log ("Damage Enemy " + collide.name);
	        	collide.GetComponent<EnemyAI>().TakeDamage(transform.position);
        }
        if (hit.Length == 0)
	        Debug.Log("Miss");
    }
    
    void OnTriggerEnter(Collider other)
    {
    if (other.tag == "Triggered")
    {
    	trigger = true;
    	transform.GetChild(6).gameObject.SetActive(true);
    	}
    }

    public float _speed = 10f;
    public float _delay = 0.2f;
    public float _maxAccel = 3f;
    public float _incAccel = 0.1f;
    public LayerMask _whatIsGround;
    public float _jumpForce;
    public float _radiusOverlap = 1f;
    public LayerMask _enemy;

	private float triggerdestroy = 0;
	private bool trigger = false;
    private Rigidbody _rigid;
    private Collider[] _isGrounded;
    private bool _isJumping = false;
    private float _accel = 1f;
    private float _nextIdle = 0;
    private LegForward _state;
    private LegForward _lastState;
    private Animator _anim;
}
