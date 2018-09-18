﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {


    [SerializeField]
    private float speed;
    bool started;
    bool gameOver;

    Rigidbody rb;

   


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

	// Use this for initialization
	void Start () {

        gameOver = false;
        started = false;
	}
	
	// Update is called once per frame
	void Update () {

        if(!started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(speed, 0, 0);
                started = true;

                GameManager.instance.StartGame();
            }

        }

        Debug.DrawRay(transform.position, Vector3.down, Color.red);

        if (!Physics.Raycast(transform.position, Vector3.down, 1f))
        {

            gameOver = true;
            rb.velocity = new Vector3(0, -25f, 0);


      
            Camera.main.GetComponent<CameraFollow>().gameOver = true;

            GameManager.instance.GameOver();


        }

        if (Input.GetMouseButtonDown(0) && !gameOver)
        {
            SwithDirections();
        }

    }

    private void SwithDirections()
    {
       
        if(rb.velocity.z >0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        else
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Diamond")
        {

           // GameObject part = Instantiate(particle, col.gameObject.transform.position, Quaternion.identity) as GameObject;

            Destroy(col.gameObject);
           // Destroy(part, 1f);


        }
    }
}