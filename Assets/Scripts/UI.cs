using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI : MonoBehaviour {
    public Text playerScoreText;
    public Text overText;
    // Use this for initialization
    void Start () {
        overText.text = "";
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void showPlayerScore(int score) {
        playerScoreText.text = "Score: " + score.ToString();
    }
}
