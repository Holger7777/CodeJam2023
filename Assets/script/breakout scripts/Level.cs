using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
// most of the code is taken from; Breakout | Simple Game Tutorial Unity 2D for Beginners (https://www.youtube.com/watch?v=jyXZ3RVe5as&ab_channel=SilverlyBee)
{

    public Vector2Int size;
    public Vector2 Offset;
    public GameObject PillPrefap;
    public Gradient gradient;

    private float OffSetX = 1;
    private float half = .5f;
    private float GradientY = 1;

    // Start is called before the first frame update
    private void Awake()
    {
        for(int i = 0; i < size.x; i++)
        {
            for(int j = 0; j < size.y; j++)
            {
                GameObject NewPill = Instantiate(PillPrefap, transform);
                NewPill.transform.position = transform.position + new Vector3((float)((size.x - OffSetX ) * half - i) * Offset.x, j * Offset.y, 0);
                NewPill.GetComponent<SpriteRenderer>().color = gradient.Evaluate((float)j /(size.y-GradientY));


            }
               

        }
    }
    // wrote this code myself, it checks weather or not there are any GameObjects with the tag "Pill" if there arent any, it switches back to the main game scene. 
    public string tagName = "Pill";
    private void Update()
    {

        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(tagName);
       
        if(taggedObjects.Length == 0)
        {
            SceneManager.LoadScene(3);
        }
    }
    public void restartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
