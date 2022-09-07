using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider HealthValue;
    ShootingLight sl;
    float timer = 0;
    float AttacDelay = 0.5f;
    float HarmValue = 10;
    Animator anim;
    PlayerMove movement;
    public Animator EnemyAnimator;
    public bool Isdeath = false;
    public bool IsHarming;
    public AudioSource HurtClip;
    public AudioSource DeadClip;
    public bool StopNav1=false;
    public GameObject GameOver;

	void Start ()
    {
        anim = GetComponent<Animator>();
        movement = GetComponent<PlayerMove>();
	}
    void Update ()
    {
        Harm();
        IsDead();
	}
    void Harm()
    {
        timer += Time.deltaTime;
        if (IsHarming && timer >= AttacDelay && !Isdeath)
        {
            HurtClip.Play();
            timer = 0;
            HealthValue.value -= HarmValue;
            return;
        }
    }
    void IsDead()
    {
        if(HealthValue.value==0 &&  !Isdeath)
        {
            GameOver.SetActive(true);
            StopNav1 = true;
            HurtClip.enabled = false;
            DeadClip.Play();
            anim.SetTrigger("Die");
            movement.enabled = false;
            Isdeath = true;
            enabled = false;
        }
    }
}
