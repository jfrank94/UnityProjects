using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 3.5f;
    public float rotatingSpeed = 40f;
    public float jumpingForce = 10f;

    private bool canJump = false; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //change the position of the player in the x-axis
		if (Input.GetKey("right"))
            //multiply by Time.deltaTime to equalize frames across different processors
        {
            transform.RotateAround(transform.position, Vector3.up, rotatingSpeed * Time.deltaTime);
        }
        if (Input.GetKey("left"))
        {
            transform.RotateAround(transform.position, Vector3.up, -rotatingSpeed * Time.deltaTime);
            //transform.position += Vector3.left * speed * Time.deltaTime;
            /* OR 
             * transform.position -= Vector3.right * speed * Time.deltaTime;          
             */           
        }
        if (Input.GetKey("up"))
        {
            transform.position += transform.forward * speed * Time.deltaTime; 
        }
        if (Input.GetKeyDown("space") && canJump)
        {
            //set flag to false since when it jumps, it will not hit the floor therefore 
            //it will only jump once it hits the floor
            canJump = false;
            GetComponent<Rigidbody>().AddForce(0, jumpingForce, 0);
        }

        if (Input.GetKey("up"))
        {

        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Floor")
        {
            canJump = true;
        }
    }
}
