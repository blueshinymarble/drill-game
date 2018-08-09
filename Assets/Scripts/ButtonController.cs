using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private Player playerScript;

	// Use this for initialization
	void Start ()
    {
        playerScript = GameObject.Find("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void ChangeMoveToTrue()
    {
        playerScript.moving = true;
    }
}
