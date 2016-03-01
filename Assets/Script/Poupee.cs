using UnityEngine;
using System.Collections;

public class Poupee : MonoBehaviour {

	// Use this for initialization
	void Start () {
        time = 0;
        _anim = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
		if (player.GetComponent<PlayerController>().getEnum() == PlayerController.LegForward.LEFT ||
		    player.GetComponent<PlayerController>().getEnum() == PlayerController.LegForward.RIGHT)
			_anim.SetBool("Movement", true);
		else
			_anim.SetBool("Movement", false);
        if (player.GetComponent<Animator>().GetBool("Attack"))
             {
                 time += Time.deltaTime;
                 if (time > 0.5)
                 {
                     time = 0;
                player.GetComponent<PlayerController>().setAnim("Attack", false);
                player.GetComponent<PlayerController>().setEnum(PlayerController.LegForward.NOTHING);
            }
             }
    }

    void OnTouchDown()
    {
    	_anim.SetTrigger("Attack");
    	Debug.Log ("Ouos");
        player.GetComponent<PlayerController>().setAnim("Attack", true);
        player.GetComponent<PlayerController>().setEnum(PlayerController.LegForward.ATTACK);
        player.GetComponent<PlayerController>().Attack();
    }

    private float time;
    private Animator _anim;
    public GameObject player;
}
