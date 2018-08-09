using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Player : MonoBehaviour
{
    public Texture2D mouseTexture;
    public bool mousePressed;
    public GameObject clickedRock;
    public List<Vector3> transformsToMoveTo = new List<Vector3>();
    public bool moving;

    private float speed;
    private Vector3 target;
    private Game game;
    private Rigidbody2D myRigidBody2D;
    private Vector3 targetMouseClick;

	// Use this for initialization
	void Start ()
    {
        moving = false;
        myRigidBody2D = GetComponent<Rigidbody2D>();
        game = GameObject.Find("Game").GetComponent<Game>();
        clickedRock = null;
        mousePressed = false;
        target = transform.position;
        speed = 10f;
        targetMouseClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetMouseClick.z = transform.position.z;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //FaceMouse();
        //MovePlayerToMouseClick();
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 transformToAdd = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transformToAdd.z = transform.position.z;
            transformsToMoveTo.Add(transformToAdd);
        }
        MovePlayer();
        if (transformsToMoveTo.Count > 0 && transform.position == transformsToMoveTo[0])
        {
            transformsToMoveTo.RemoveAt(0);
        }
	}

    void FaceMouse() // makes sure the drill is always facing the mouse. need to switch this on if mouse control is on. will use it for the time being while we test the game
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);
        lookPos = lookPos - transform.position;
        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }


    public void TestMovePlayer()
    {
        //Transform nextTransform = transformsToMoveTo[0];
        float speedToMove = speed * Time.deltaTime;
        if (transformsToMoveTo.Count > 0)
        {
            transform.position = Vector3.Lerp(transform.position, Input.mousePosition, speed);
            transformsToMoveTo.RemoveAt(0);
        }
    }

    public void MoveToNextTransform()
    {
        if (transformsToMoveTo.Count > 0 && moving == true)
        {
            transform.position = Vector3.Lerp(transform.position, transformsToMoveTo[0], speed);
            transform.LookAt(transformsToMoveTo[0]);
            transformsToMoveTo.RemoveAt(0);
        }
    }

    void MovePlayer()
    {
        /*Vector3 targetMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetMousePos.z = transform.position.z;*/

        if (moving == true && transformsToMoveTo.Count > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, transformsToMoveTo[0], Time.deltaTime * speed);
            transform.LookAt(transformsToMoveTo[0]);
            
        }
        else if (transformsToMoveTo.Count == 0)
        {
            moving = false;
        }
    }
}

//move the player to the first transform in the list
//remove that transform from the list
//destroy the rock
//move to the next transform on the list
