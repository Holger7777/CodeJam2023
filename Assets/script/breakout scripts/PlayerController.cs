using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

// acceleration controll taken from "Unity Tutorial How Control And Move Gameobject With Accelerometer Or Gyroscope In Android Game." https://www.youtube.com/watch?v=wpSm2O2LIRM&ab_channel=AlexanderZotov
{
    public float speed; // speed which can be changed in the inspector in unity
    Rigidbody2D rb; // defining the RigidBody2D
    float dirX;
    // removed from the code as an improvement, private float leftX = -11f;
    // removed from the code as an improvement, private float rightX = 11F;

    // Start is called before the first frame update
    void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        dirX = Input.acceleration.x * speed; // this is where the magic happens, here the code gets the accelertometer data from the phone, it's then multiplied with the given speed and then we have the dirX, which is all the controls that is needed for this game
       
        
        /*removed, since i've already have edge colliders around the map so the ball cannot escape, it didnt make sense to have two of the same functions
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, leftX, rightX), transform.position.y);*/
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    rb.velocity = new Vector2(dirX, 0f);
    }
}
