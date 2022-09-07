using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public GameObject BarelEnd;
    SphereCollider TouchDetection;
    CapsuleCollider HitDetection;
    Animator anim;
    NavMeshAgent navigation;

    public float HarmValue;
    public float Health = 100;
    public bool IsD = false;

    RaycastHit targetLocated;
    public float fadey;
    Vector3 fade;
    NavMeshAgent nav;
    public bool StopNav;
    public AudioSource Dead;
    bool AlreadyBeen=true;
    GameObject ScoreNumber;
    ScorePoints sp;
    Text Txt;

    void Start ()
    {
        ScoreNumber = GameObject.FindGameObjectWithTag("Score");
        if (ScoreNumber != null)
        {
            sp = ScoreNumber.GetComponent<ScorePoints>();
        }
        if (ScoreNumber == null) Debug.Log("NotFound");
        fade = new Vector3(0, fadey, 0);
        navigation = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        TouchDetection = GetComponent<SphereCollider>();
        HitDetection = GetComponent<CapsuleCollider>();
        nav = GetComponent<NavMeshAgent>();
	}
	void FixedUpdate ()
    {
        if(Physics.Raycast(BarelEnd.transform.position, BarelEnd.transform.forward*10 , out targetLocated))
        {
                HarmEnemy();
                Animate();
                IsDead();
                FadeAway();
        }
		
	}
    void HarmEnemy()
    {
        if (Input.GetButton("Fire1") && targetLocated.collider == HitDetection && AlreadyBeen)
        {
                Health = Health - HarmValue;
        }
    }
    void IsDead()
    {
        if(Health<=0 && AlreadyBeen)
        {
            sp.br++;
            sp.UpdateScore();
            Dead.Play();
            StopNav = true;
            nav.enabled = false;
            TouchDetection.isTrigger = false;
            AlreadyBeen = false;
        }  
    }
    void Animate()
    {
        if (Health <= 0 && !IsD)
        {
            anim.SetTrigger("Die");
            IsD = true;
        }
    }
    void FadeAway()
    {
        if (IsD && anim.GetCurrentAnimatorStateInfo(0).IsName("Death"))
        { 
            transform.position += fade;
            if (transform.position.y < -1) Destroy(gameObject);
        }
    }
}
