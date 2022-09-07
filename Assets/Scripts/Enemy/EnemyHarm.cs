using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHarm : MonoBehaviour
{
    public GameObject player;
    PlayerHealth ph;

	void Start ()
    {
        ph = player.GetComponent<PlayerHealth>();
	}
	void Update () {	
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player) ph.IsHarming = true;
    }
    private void OnTriggerExit(Collider other)
    {
       if (other.gameObject == player) ph.IsHarming = false;
    }
}
