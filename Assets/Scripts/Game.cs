using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public string selected;
    public Transform lastRockSelected;

    private Text score;
    private GameObject player;

    private int playerScore;
    // Use this for initialization
    void Start()
    {
        score = GameObject.Find("Score").GetComponent<Text>();
        player = GameObject.Find("Player");
        lastRockSelected = player.transform;
        playerScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            //changes the color of the rocks back to white when the mouse is released
            /*GameObject[] toChange = GameObject.FindGameObjectsWithTag("Selected");
            foreach (GameObject objToChange in toChange)
            {
                objToChange.GetComponentInChildren<SpriteRenderer>().color = Color.white;
                objToChange.tag = objToChange.transform.GetChild(0).tag;
            }*/
            ScoreRocks();
            lastRockSelected = player.transform;
        }
    }

    void ScoreRocks()
    {
        GameObject[] toScore = GameObject.FindGameObjectsWithTag("Selected");
        playerScore += toScore.Length;
        score.text = playerScore.ToString();
        foreach(GameObject rock in toScore)
        {
            Destroy(rock);
        }
        //score a number of points based on how many rocks you touched in your chain
        //move the player to each rock
        //count 0.5 seconds
        //destroy the rock sprite
        //make the rock sprite uncollidable with the player sprite?
        //move the player to the next rock in the chain
    }
}
