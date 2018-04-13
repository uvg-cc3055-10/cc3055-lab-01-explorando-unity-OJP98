using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour {

    public float jumpForce = 350f;
    public float forwardSpeed = 2f;
    public Rigidbody2D rb;
    public GameObject cam;
    public bool dead = false;
    public bool start = false;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        if (!start)
        {
            rb.velocity = Vector2.zero;

            if (Input.GetButtonDown("Jump"))
            {                
                start = true;
            }
        }

        if (!dead && start)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.AddForce(new Vector2(0, 1) * jumpForce);                
            }

            rb.transform.Translate(new Vector3(1, 0, 0) * forwardSpeed * Time.deltaTime);
            cam.transform.Translate(new Vector3(1, 0, 0) * forwardSpeed * Time.deltaTime);
        }

        if (rb.transform.position.x > 36)
        {
            dead = true;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        dead = true;
    }

}
