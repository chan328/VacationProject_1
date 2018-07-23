using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    public float MovePower = 1f;
    public float JumpPower = 1f;

    Rigidbody2D rigidbody;

    Vector3 movement;
    bool isJumping;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            isJumping = true;
        }
	}

    void FixedUpdate()
    {
        Move();
        Jump();
    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if(Input.GetAxis("Horizontal") < 0)
        {
            moveVelocity = Vector3.left;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            moveVelocity = Vector3.right;
        }

        transform.position += moveVelocity * MovePower * Time.deltaTime;
    }
    void Jump()
    {
        if (!isJumping)
            return;

        rigidbody.velocity = Vector2.zero;

        Vector2 jumpVelocity = new Vector2(0, JumpPower);
        rigidbody.AddForce(jumpVelocity, ForceMode2D.Impulse);

        isJumping = false;
    }
}
