using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public string selected;
    public Transform lastRockSelected; // this transform is used to make sure the player is selecting a rock that is close enough to them. it makes sure the player cant select a rock that is too far away
    public GameObject[] toScore;

    public float speed = 5f;

    private Text score;
    private GameObject player;

    private int playerScore;
    private RockInstantiator rockInstantiator;
    private Player playerScript;
    // Use this for initialization
    void Start()
    {
        rockInstantiator = GameObject.Find("Rock Instantiator").GetComponent<RockInstantiator>();
        score = GameObject.Find("Score").GetComponent<Text>();
        player = GameObject.Find("Player");
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        lastRockSelected = player.transform;
        playerScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && playerScript.gameObjectsToMoveTo.Count > 1)
        {
            playerScript.moving = true;
        }
        else if (Input.GetMouseButtonUp(0) && playerScript.gameObjectsToMoveTo.Count == 1)
        {
            if (lastRockSelected.GetComponent<Rock>())
            {
                lastRockSelected.GetComponent<Rock>().ResetMe();
            }
            lastRockSelected = player.transform;
        }

        if (Input.GetMouseButtonDown(1))
        {
            playerScript.DestoyRocksInRadius();
        }
        /*if (Input.GetMouseButtonDown(0))
        {
            playerScript.moving = true;
            playerScript.MoveToNextTransform();
        }
        /*if (Input.GetMouseButtonUp(0))
        {
            MovePlayer();
            //changes the color of the rocks back to white when the mouse is released
            /*GameObject[] toChange = GameObject.FindGameObjectsWithTag("Selected");
            foreach (GameObject objToChange in toChange)
            {
                objToChange.GetComponentInChildren<SpriteRenderer>().color = Color.white;
                objToChange.tag = objToChange.transform.GetChild(0).tag;
            }
            ScoreRocks();
            lastRockSelected = player.transform;
            playerScript.TestMovePlayer();
        }*/
    }

    void ScoreRocks()
    {
        toScore = GameObject.FindGameObjectsWithTag("Selected");
        playerScore += toScore.Length;
        score.text = playerScore.ToString();
        foreach(GameObject rock in toScore)
        {
            rockInstantiator.currentRockCount--;
            //Destroy(rock);
        }
        //score a number of points based on how many rocks you touched in your chain
        //move the player to each rock
        //count 0.5 seconds
        //destroy the rock sprite
        //make the rock sprite uncollidable with the player sprite?
        //move the player to the next rock in the chain
    }
}
