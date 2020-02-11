using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballScript : MonoBehaviour
{

    public Rigidbody2D rb;
    public float ballSpeed;
    public bool inPlay;
    public Transform paddlePosition;
    public GameObject explosion;
    public GameManagerScript gm;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!inPlay)
        {
            transform.position = paddlePosition.position;
        }

        if (Input.GetButtonDown("Jump") && inPlay == false)
        {
            startGame();
        }

        // Return to paddle if stuck
        if (Input.GetKeyDown(KeyCode.P) && inPlay == true)
        {
            resetBall("redBall");
        }
        if (Input.GetKeyDown(KeyCode.R) && inPlay == true)
        {
            resetBall("greenBall");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(tag: "bottom")) {
            resetBall(transform.tag);
        };
    }
    
    private void startGame()
    {
        inPlay = true;
        rb.AddForce(Vector2.up * ballSpeed);
        rb.AddForce(Vector2.right * paddlePosition.GetComponentInParent<PaddleScript>().horizontal * ballSpeed);
    }

    // Hit a brick
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag(tag: "brick"))
        {
            GameObject newExplosion = Instantiate(explosion, other.transform.position, transform.rotation);

            Destroy(newExplosion.gameObject, 2);
            Destroy(other.gameObject);
            if (transform.tag == "redBall")
            {                
                gm.redScoreAdded = other.gameObject.GetComponent<BrickScript>().brickScore * gm.streakScore;
                gm.redScore += gm.redScoreAdded;
                gm.showScore(gm.redScoreAddedText, "red");

            }
            
            else if (transform.tag == "greenBall")
            {
                gm.greenScoreAdded = other.gameObject.GetComponent<BrickScript>().brickScore * gm.streakScore;
                gm.greenScore += gm.redScoreAdded;
                gm.showScore(gm.greenScoreAddedText, "green");
            }
            gm.currentNumBricks -= 1;
            gm.streakScore += 1;
        }

    }

    void resetBall(string tag)
    {
        if (transform.tag == tag)
        {
            gm.streakScore = 1;  // 1 is default as multiplier
            gm.streakText.color = Color.clear;
            inPlay = false;
            rb.velocity = Vector2.zero;
        }
      
    }
}
