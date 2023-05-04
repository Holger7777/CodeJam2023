using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{

    private void Update()
    
    {
        GameObject puzzle = GameObject.FindGameObjectWithTag("puzzle0");
       GameObject puzzle1 = GameObject.FindGameObjectWithTag("puzzle1");
        GameObject puzzle2 = GameObject.FindGameObjectWithTag("puzzle2");
        if (puzzle == null && puzzle1 == null && puzzle2 == null && SceneManager.GetActiveScene().name == "GameScene")
        {
            SceneManager.LoadScene(5);
        }
    }
}
