using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
// most of the code is taken from; Breakout | Simple Game Tutorial Unity 2D for Beginners (https://www.youtube.com/watch?v=jyXZ3RVe5as&ab_channel=SilverlyBee)
{

    public Vector2Int size; // size of the pills x and y wise,  this is changed in the inspector, for the current game, this is set to 13 on the x axis and 4 on the y axis. 
    public Vector2 Offset; // the offset of the pillprefaps, this is changed in the inspector, for the current game, this is set to 1.43 on the x axis and 0.9 on the y axis. 
    public GameObject PillPrefap;
    public Gradient gradient;

    private float OffSetX = 1;  // making sure the pill prefaps are centered
    private float half = .5f;  // making sure the pill prefaps are centered
    private float GradientY = 1;

    // Start is called before the first frame update
    private void Awake()
    {
        for(int i = 0; i < size.x; i++)
        {
            for(int j = 0; j < size.y; j++)
            {
                GameObject NewPill = Instantiate(PillPrefap, transform); // here i create a new Pill prefap, which is then goes in a loop for both the size.x and size,y, which is controlled in the unity inspector. 
                NewPill.transform.position = transform.position + new Vector3((float)((size.x - OffSetX) * half - i) * Offset.x, j * Offset.y, 0); // here i move the position of all the pills generated, based on the offset.x and offset.y, this is also changed in the unity inspector 

                // the "(float)((size.x - OffSetX ) * half - i)" is there to make sure the pill prefaps are centered. 

                NewPill.GetComponent<SpriteRenderer>().color = gradient.Evaluate((float)j /(size.y-GradientY)); // here i can change all the colors of the new pill prefaps that were just made. the gradient is controlled in the unity inspector. 


            }
               

        }
    }
    //  it checks weather or not there are any GameObjects with the tag "Pill" if there arent any, it switches back to the main game scene. 
    public string tagName = "Pill";
    private void Update()
    {

        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(tagName); // this line finds all the gameObejcts that are tagged with pill
       
        if(taggedObjects.Length == 0) // if there are no more pill prefaps (they're all tagged with the "pill" tag) it then changes back to the previous scene, which the the waiting room for the game. 
        {
            SceneManager.LoadScene(3);
        }
    }
    public void restartGame() // this is used for the UI button in when the lives have reached 0, 
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // this reloads the scene, i could also have done, "sceneManager.LoadScene(2)" but since i already used that command ealier, i wanted to spicy it up a bit. to show there are more ways to change scene. 
    }
}
