using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotsText : MonoBehaviour {

    Paddle paddle;
    int shots;
    public Text text;

	// Use this for initialization
	void Start () {
        
        paddle = GameObject.FindObjectOfType<Paddle>();
	}
	
	// Update is called once per frame
	void Update () {
        shots = paddle.getShots();
        text.text = "Shots: " + shots;
	}
}
