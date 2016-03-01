using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAI : MonoBehaviour {

	public GameObject _deathParticule;
    private GameObject _target;
    public float _range = 1f;
    public LayerMask _TargetMask;
    public float _delay = 0.55f;
    public float violence = 300f;

    private AudioSource src;

    public enum IAState
    {
        INACTIVE = 0,
        WALKING,
        ATTACKING,
    }

    public IAState _state;
    public bool _isActivated = false;
    private NavMeshAgent _agent;
    private float _nextAnimation = 0;
    private float nextActive = 0;
    private Animator _anim;
    private float _nextAttack = 0;
   
    

    // Use this for initialization
	void Start () {
        _agent = GetComponent<NavMeshAgent>();
        src = GetComponent<AudioSource>();
        //_state = IAState.INACTIVE;
        _anim = GetComponent<Animator>();
        _target = GameObject.FindGameObjectWithTag("Player");
        GetComponent<Rigidbody>().isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {

	}

    void FixedUpdate()
    {
        if (_isActivated)
        {
             if (_state == IAState.WALKING)
             	walking();
            else if (_state == IAState.ATTACKING)
				attacking();
            else if (_state == IAState.INACTIVE && _isActivated)
				inactive();
        }
        else
        {
            _agent.Stop();
			_anim.SetBool("Attack", false);
			_anim.SetBool("isActive", false);
			transform.GetChild(2).GetChild(0).GetChild(7).GetChild(0).gameObject.SetActive(false);           
        }
    }

	private void inactive()
	{
		transform.GetChild(2).GetChild(0).GetChild(7).GetChild(0).gameObject.SetActive(false);           
		_nextAnimation += Time.deltaTime;
		if (_nextAnimation > 10f)
		{
			_state = IAState.WALKING;
			GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
			_agent.Resume();
			transform.GetChild(2).GetChild(0).GetChild(7).GetChild(0).gameObject.SetActive(true);
			_nextAnimation = 0f;
		}
	}
	
	private void walking()
	{
		_anim.SetBool("isActive", true);
		transform.GetChild(2).GetChild(0).GetChild(7).GetChild(0).gameObject.SetActive(true);
		_agent.destination = _target.transform.position;
		_nextAttack += Time.deltaTime;
		if (_nextAttack > 2f)
		{
			Collider[] entittiesAround = Physics.OverlapSphere(transform.position, _range, _TargetMask);
			foreach (Collider entity in entittiesAround)
			{
				_agent.Stop();
				_state = IAState.ATTACKING;
				_anim.SetBool("Attack", true);
				_anim.SetBool("isActive", false);
			}
			_nextAttack = 0;
		}
	}
	
	private void attacking()
	{
		transform.GetChild(2).GetChild(0).GetChild(7).GetChild(0).gameObject.SetActive(true);
		_nextAnimation += Time.deltaTime;
		if (_nextAnimation > _delay) // Delay of attack Animation
		{
			
			Collider[] entittiesAround = Physics.OverlapSphere(transform.position, _range, _TargetMask);
			foreach (Collider entity in entittiesAround)
			{
				_target.GetComponent<PlayerAttack>().isAttacked(transform.position);
			}
			_nextAnimation = 0;
			_anim.SetBool("Attack", false);
			_anim.SetBool("isActive", true);
			_state = IAState.WALKING;
			_agent.Resume();
		}
		else
			_agent.Stop();
	}
	
    public void Activate(bool state)
    {
    	
        _isActivated = state;
        if (state)
        {
			_agent.Resume();
            _state = IAState.WALKING;
        }
        else
            _state = IAState.INACTIVE;
    }
    
    public void TakeDamage(Vector3 enemypos)
    {
		/*float tmpX, tmpZ;

		Debug.Log ("IA " + gameObject.name + " is Taking damage");
		tmpX = transform.position.x - enemypos.x;
		tmpZ = transform.position.z - enemypos.z;
        GetComponent<Rigidbody>().isKinematic = false;		
		GetComponent<Rigidbody>().AddForce(new Vector3(tmpX * violence, 0, tmpZ * violence));
        GetComponent<Rigidbody>().isKinematic = true;
		System.Random rnd = new System.Random();
		int angle = rnd.Next(180, 360);
		transform.Rotate(new Vector3(0, angle, 0) * 30 * Time.deltaTime);
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        _nextAnimation = 0;
		_state = IAState.INACTIVE;
        _agent.Stop();
		_anim.SetBool("isActive", false);
        _anim.SetBool("Attack", false);
        if(!_isActivated)
        	return;*/
        if (_deathParticule)
	        Instantiate(_deathParticule, transform.position, Quaternion.identity);	
        Destroy(gameObject);
    }
}
