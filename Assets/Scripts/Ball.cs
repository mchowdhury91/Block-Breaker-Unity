using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Paddle paddle;
    private LevelManager levelManager;
    private Vector3 paddleToBallVector;
    bool launched;


	// Use this for initialization
	void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        launched = false;
        paddleToBallVector = this.transform.position - paddle.transform.position;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (launched)
        {
            GetComponent<AudioSource>().Play();
            if(collision.gameObject.tag == "Paddle"
                || collision.gameObject.tag == "Breakable")
            {
                paddle.addShots(1);
            }

            Vector2 tweak = new Vector2(Random.Range(0f, 0.3f), Random.Range(0f, 0.3f));
            GetComponent<Rigidbody2D>().velocity += tweak;
        }

        /**
        if(collision.collider.gameObject.name == paddle.gameObject.name)
        {
            Vector2 v = this.GetComponent<Rigidbody2D>().velocity;
            v.y = 10f;
            this.GetComponent<Rigidbody2D>().velocity = v;
            
        }**/

        /**
        Vector2 inDirection = this.GetComponent<Rigidbody2D>().velocity;
        Vector2 inNormal = collision.contacts[0].normal;
        inNormal.Normalize();
        Vector2 newVelocity = Vector2.Reflect(inDirection, inNormal);

        this.GetComponent<Rigidbody2D>().velocity = newVelocity;
        print(newVelocity);
        **/
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

    }

    // Update is called once per frame
    void Update () {
        if (!launched)
        {
            transform.position = paddle.transform.position + paddleToBallVector;
        }

        if (Input.GetMouseButton(0) && !launched)
        {
            launched = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(2f,5f);
        }
	}
}
