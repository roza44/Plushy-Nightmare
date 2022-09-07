using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSight : MonoBehaviour
{
    PlayerMove playermovescript;

    public GameObject player;
    public GameObject sight;
    public GameObject cam;
    public RaycastHit wallhit;
    public GameObject GunBarel;
    public Vector3 offset,offset1,flooroffset;

    void Start ()
    {
       playermovescript = player.GetComponent <PlayerMove> ();
       offset.Set(0, 0, 0.5f);
       flooroffset.Set(0, 0.1f, 0);
    }
    void Update ()
    {
        cast();
    }
    void cast()
    {
        if (Physics.Raycast(GunBarel.transform.position, GunBarel.transform.forward * 10, out wallhit))
        {
            if (wallhit.collider.tag == "Floor")
            {
                sight.transform.position = wallhit.point + flooroffset;
                sight.transform.rotation = Quaternion.Euler(90, 0, 0);
                Vector3 scale = wallhit.point - player.transform.position;
                float magnitude = scale.magnitude;
                offset1 = new Vector3(0, 0, 0.5f / magnitude);
                
            }
            else
            {
               if(wallhit.point.z < 0) sight.transform.position = wallhit.point + offset;
                else sight.transform.position = wallhit.point - offset;
               sight.transform.rotation = playermovescript.rotation;
                Vector3 scale1 = wallhit.point - player.transform.position;
                float magnitude1 = scale1.magnitude;
                offset1 = new Vector3(0, 0, 0.5f / magnitude1);
            }
        }
    }
}
