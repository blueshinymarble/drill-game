using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{

    private Game game;
    private Player player;

	// Use this for initialization
	void Start ()
    {
        game = GameObject.Find("Game").GetComponent<Game>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    
    private void OnMouseOver()
    {// if cursor selection is enabled on the player then it will change the rocks to a color and set their tags to selected
        Vector3 magnitudeToCheck = transform.position - game.lastRockSelected.transform.position;
        if (Input.GetMouseButton(0) && gameObject.tag == game.selected && magnitudeToCheck.sqrMagnitude < 2f * 2f)//checks if the distance between this rock and the previously selected rock is close enough, if its too far then it wont be selected
        {
            gameObject.tag = "Selected";
            GetComponentInChildren<SpriteRenderer>().color = Color.red;
            game.lastRockSelected = gameObject.transform;
            player.transformsToMoveTo.Add(gameObject.transform.position);//TODO send my transform to a list in the player script or game script that will make the player move to each transform in the list
        }
    }

    private void OnMouseDown()
    {//changes the tag of "selected" in the game script to this objects tag so that only objects of this type will be selected
        game.selected = gameObject.tag;
    }

    public void DestroyMyself()
    {
        Destroy(gameObject);
    }
}
