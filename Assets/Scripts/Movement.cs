using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {


    [SerializeField] private float yForce;
    [SerializeField] private float maxVelocity;

    private bool isGrounded;
    private Vector3 mSpeed;
    private Vector3 mJump;
    private Rigidbody thisRB;

	// Use this for initialization
	void Start () {

        mJump = Vector3.up;
        mSpeed = Vector3.zero;
        thisRB = this.gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        mSpeed = (new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * maxVelocity);

        if(thisRB.velocity.magnitude < maxVelocity) thisRB.AddForce(mSpeed);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space)) thisRB.AddForce(mJump * yForce);
	}

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
