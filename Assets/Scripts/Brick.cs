using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public Sprite[] hitSprites;
    public static int breakableBricks = 0;
    public AudioClip audioClip;
    public GameObject smoke;


    private int timesHit;
    private LevelManager levelManager;
    private bool isBreakable;
    // Use this for initialization
    void Start () {
        isBreakable = (this.tag == "Breakable");
        if (isBreakable)
        {
            breakableBricks++;
        }
        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

    // Update is called once per frame
    void Update()
    {
        
        if (isBreakable)
        {
            HandleHits();
        }
    }

    void HandleHits()
    {
        int maxHits = hitSprites.Length;
        if (timesHit >= maxHits)
        {
            breakableBricks--;
            AudioSource.PlayClipAtPoint(audioClip, transform.position);
            levelManager.BrickDestroyed();
            Paddle paddle = GameObject.FindObjectOfType<Paddle>();

            paddle.addShots(1);
            GameObject.Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }    
    }

    void puffSmoke()
    {
        GameObject newSmoke = Instantiate(smoke, transform.position, Quaternion.identity);
        var main = newSmoke.GetComponent<ParticleSystem>().main;
        main.startColor = gameObject.GetComponent<SpriteRenderer>().color;
    }

    void LoadSprites()
    {
        int spriteIndex = timesHit;
        if (hitSprites[spriteIndex]) // check if sprite exists
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Brick sprite missing");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        timesHit++;
    }

}
