using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    public GameObject sight;
    PlayerMove pl;
    PlayerSight ps;
    public Vector3 offset;
    Vector3 upgrade;
    Vector3 lookat;

    void Start ()
    {
        ps = sight.GetComponent<PlayerSight>();
        pl = player.GetComponent<PlayerMove>();
        offset = transform.position - player.transform.position;
        upgrade = new Vector3((int) 2.5, 1, 0);
    }
    void Update ()
    {
        transform.position = player.transform.position + pl.rotation * offset;
        ps.offset1 = pl.rotation * ps.offset1;
        transform.position += ps.offset1;
        lookat = player.transform.position + pl.rotation * upgrade;
        transform.LookAt(lookat);
    }
}
