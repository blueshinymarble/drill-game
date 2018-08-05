using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Player : MonoBehaviour
{
    public Texture2D mouseTexture;
    public bool mousePressed;
    public GameObject clickedRock;

    private float speed = 10f;
    private Vector3 target;

	// Use this for initialization
	void Start ()
    {
        clickedRock = null;
        mousePressed = false;
        target = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        FaceMouse();
        //MovePlayerToMouseClick();
        RockSelector();
	}

    void FaceMouse() // makes sure the drill is always facing the mouse. need to switch this on if mouse control is on. will use it for the time being while we test the game
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);
        lookPos = lookPos - transform.position;
        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void MovePlayerToMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
        }
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.tag == "Rock_1")
        {
            collision.GetComponent<Animator>().Play("test_rock minimize animation");
        }
        else if(collision.tag == "Rock_2")
        {
            collision.GetComponent<Animator>().Play("test_rock2 minimize animation");
        }
        else if(collision.tag == "Rock_3")
        {
            collision.GetComponent<Animator>().Play("test_rock3 minimize animation");
        }*/
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //collision.GetComponent<Animator>().Play("Idle");
    }

    void RockSelector()
    {
        //while the mouse button is held down change the mouse cursor to a target
        if (Input.GetMouseButton(0))
        {
            mousePressed = true;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            mousePressed = false;
        }
    }

    //when the mouse button is clicked and held down selection mode begins
    //the rock that is clicked on is stored in a variable.
    //this rock must be adjacent to the drill.
    //with the mouse button held down the player can highlight any rock that is close enough to the rock before it
    //these rocks are stored in a list so that at the end of the chain these rocks will be destroyed
    //the player's drill is then moved through each rock clicked towards the end of the chain and rests at the location of the last rock in the chain

}
