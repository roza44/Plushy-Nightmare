using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePoints : MonoBehaviour
{

    public int br=0;
    public Text txt;
	public void UpdateScore ()
    {      
        txt.text = br.ToString();
	}
}
