using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoTo : MonoBehaviour
{
    NavMeshAgent follow;
    Transform player;
    PlayerHealth ph;
    Animator anim;
    EnemyHealth eh;

	void Start ()
    {
        follow = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        ph = player.GetComponent<PlayerHealth>();
        anim = GetComponent<Animator>();
        eh = GetComponent<EnemyHealth>();
	}
	void Update ()
    {
        if(!eh.StopNav && !ph.StopNav1) follow.SetDestination(player.position);
    }
    void FixedUpdate()
    {
        Animate();
    }
    void Animate()
    {
        if (ph.Isdeath) anim.SetTrigger("PlayerDead");
    }
}
