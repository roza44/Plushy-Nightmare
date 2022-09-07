using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject CharacterToSpawn;
    public GameObject SpawnPosition;
    EnemyHealth eh;
    public GameObject GunBarel;
    public GameObject player;
    EnemyHarm eharm;
    public float StartDelay;
    public float DelayBetwen;

    void Start ()
    {
        eh = CharacterToSpawn.GetComponent<EnemyHealth>();
        eharm = CharacterToSpawn.GetComponent<EnemyHarm>();
        eh.BarelEnd = GunBarel;
        eharm.player = player;
        InvokeRepeating("Spawn", StartDelay, DelayBetwen);
    }
	
	void Update ()
    {
        
	}
    void Spawn()
    {
        if (eh.Health <= 0) return;
        Instantiate(CharacterToSpawn,this.SpawnPosition.transform.position,this.SpawnPosition.transform.rotation);
    }
}
