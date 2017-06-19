using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public bool autoPlay = false;
    public Transform projectile;
    public AudioClip projectileSound;
    int shots = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!autoPlay)
        {
            MoveWithMouse();
        }
        else
        {
            AutoPlay();
        }

        if (Input.GetMouseButtonDown(0))
        {
            if(shots > 0)
            {
                var paddleWidth = GetComponent<Renderer>().bounds.size.x;
                var paddleHeight = GetComponent<Renderer>().bounds.size.y;

                Vector3 position = new Vector3(transform.position.x + (paddleWidth/2), transform.position.y + paddleHeight, 0f);
                var p1 = Instantiate(projectile, position, Quaternion.identity);

                position.x -= paddleWidth;

                var p2 = Instantiate(projectile, position, Quaternion.identity);

                p1.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 10f);
                p2.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 10f);
                AudioSource.PlayClipAtPoint(projectileSound, transform.position);
                shots--;
            }

        }
        
	}

    void AutoPlay()
    {
        Ball ball = GameObject.FindObjectOfType<Ball>();
        Vector3 paddlePos = new Vector3(0, transform.position.y, transform.position.z);
        paddlePos.x = ball.transform.position.x;
        transform.position = paddlePos;
    }

    void MoveWithMouse()
    {
        var mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;

        Vector3 paddlePos = new Vector3(0, this.transform.position.y, this.transform.position.z);
        var paddleWidth = GetComponent<Renderer>().bounds.size.x;
        paddlePos.x = Mathf.Clamp(mousePosInBlocks, (paddleWidth/2f), (16 - (paddleWidth/2f)));
        this.transform.position = paddlePos;
    }

    public void addShots(int amount)
    {
        shots += amount;
    }

    public int getShots()
    {
        return shots;
    }
}
