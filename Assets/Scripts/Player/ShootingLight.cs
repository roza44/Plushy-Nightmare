using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingLight : MonoBehaviour
{
    public ParticleSystem fire;
    public ParticleSystem HitParticle;
    public Light FireLight;
    public GameObject player;
    public AudioSource SoundOdShoot;

    PlayerHealth ph;
    float timer=0 ,timetowait = 0.3f;
    LineRenderer Bullets;
    float TimeofOperations = 0.2f;
    RaycastHit wallhit;
    Vector3[] positions = new Vector3[3];

    float offset;

	void Awake ()
    {
        ph = player.GetComponent<PlayerHealth>();
        Bullets = GetComponent<LineRenderer>();
    }
    void Update ()
    {
        positions[0] = transform.position;
        timer += Time.deltaTime;
        if (Input.GetButton("Fire1") && timer>=timetowait )
        {
            Shoot();
        }
        if(timer >= timetowait * TimeofOperations)
        {
            ResetValuesOfShoot();
        }
        Animation();
    }
    void Shoot()
    {

        FireLight.enabled = true;
        SoundOdShoot.Play();
        fire.Play();
        Bullets.enabled = true;
        if (Physics.Raycast(transform.position, transform.forward * 10, out wallhit))
        {
            HitParticle.transform.position = wallhit.point;
            HitParticle.Play();
            positions[1] = wallhit.point;
            Bullets.SetPositions(positions);
        }
        timer = 0;
    }
    void ResetValuesOfShoot()
    {
        FireLight.enabled = false;
        fire.Stop();
        Bullets.enabled = false;
    }
    void Animation()
    {
        if (ph.Isdeath)
        {
            enabled = false;
        }
    }
}
