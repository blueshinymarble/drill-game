using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockThree : MonoBehaviour
{
    private Player player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseOver()
    {// if cursor selection is enabled on the player then it will change the rocks to a color and set their rags to selected
        if (player.mousePressed == true)
        {
            gameObject.tag = "Selected";
            GetComponentInChildren<SpriteRenderer>().color = Color.red;
        }
        else
        {//changes the color of the rocks back to white when the mouse is released
            GameObject[] toChange = GameObject.FindGameObjectsWithTag("Selected");
            foreach (GameObject objToChange in toChange)
            {
                objToChange.GetComponentInChildren<SpriteRenderer>().color = Color.white;

                if (objToChange.GetComponent<Rock>())
                {
                    objToChange.tag = "Rock_1";
                }
                else if (objToChange.GetComponent<RockTwo>())
                {
                    objToChange.tag = "Rock_2";
                }
                else if (objToChange.GetComponent<RockThree>())
                {
                    objToChange.tag = "Rock_3";
                }
            }
        }
    }

   /* private void OnMouseDown()
    {
        player.clickedRock = gameObject;
    }*/
}
