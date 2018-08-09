using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public int currentScore;
    private Text playerScore;

	// Use this for initialization
	void Start ()
    {
        currentScore = 0;
        playerScore = gameObject.GetComponent<Text>();
        playerScore.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    public void AddScore(int score)
    {
        currentScore += score;
        playerScore.text = currentScore.ToString();
    }
}
