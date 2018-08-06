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
    private Game game;

	// Use this for initialization
	void Start ()
    {
        game = GameObject.Find("Game").GetComponent<Game>();
        clickedRock = null;
        mousePressed = false;
        target = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        FaceMouse();
        //MovePlayerToMouseClick();
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

    void TestMovePlayer()
    {

    }
}
