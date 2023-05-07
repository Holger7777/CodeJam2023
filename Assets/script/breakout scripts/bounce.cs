using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class bounce : MonoBehaviour

// most of the code is taken from; Breakout | Simple Game Tutorial Unity 2D for Beginners (https://www.youtube.com/watch?v=jyXZ3RVe5as&ab_channel=SilverlyBee)
{
    public float minY = -5.5f; // defining the minimum threshold in which the ball can fall down in, this is used so i can get if the ball is out of the screen
    public GameObject Circle_; // circle prefap
    public float maxY = -1.3f; // the spawn position of the ball, when the game first starts and when the player loses a life
    public float Velocity = 3; // placeholder Velocity which can be changed in the inspector in unity, the max velocity in the inspector is set to 14.
    public Rigidbody2D rb;

    int Score = 0; // the start score
    int lives = 5; // the number of lives you have

    public TextMeshProUGUI ScoreTxt;
    public GameObject[] LivesImage; // an array of the 5 lives, they all have their own ui element. 

    public GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        
        if (transform.position.y < minY) //this function resets the ball/pill
        {
            if (lives <= 0) //first we check weather or not the lives have run out, if it has, it plays the GameOver function. 
            {
                GameOver();
            }
            else
            {
                transform.position = new Vector3(0, maxY, 0); //if there are more lives left, this moves the ball / pill up to the maxY value i defined ealier
                rb.velocity = Vector3.zero; //this resets the ball's velocity
                lives--; // if the ball comes under the minY value, one life is lost 
                LivesImage[lives].SetActive(false); //this toggles the ui element off, which is the hearts if a life is lost. 
            }

        }
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, Velocity);
        Debug.Log(rb.velocity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Pill")) // this code works by checking if there is a collision on the tag "pill" which all the pill prefaps are tagged with. 
        { 
            Destroy(collision.gameObject); // if hit, it destroys the gameObejct
            Score += 100; // if destoryed the score goes up with 100
            ScoreTxt.text = Score.ToString("00000"); // here i change the txt UI element to display the score getting higher, when the pill prefap is destroyed. 
        }
    }

    void GameOver()
    {
        gameOverPanel.SetActive(true); //in unity i sat the UI Panel to inactive, this way, when the GameOver scene is called, the panel gets set to active. 
        Time.timeScale = 0; // this is sat so nothing can move on the screen while the gameOverPanel is active. 
        Destroy(gameObject);

    }
}
