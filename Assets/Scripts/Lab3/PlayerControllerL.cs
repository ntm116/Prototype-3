using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerL : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;

    [SerializeField]
    private float zBound = 10f;

    private Rigidbody playerRb;

    private float horizontalInput;
    private float verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstrainPlayerPosition();
    }

    private void MovePlayer()
    {
        horizontalInput = Input.GetAxis("Horizontal");    
        verticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(verticalInput * speed * Vector3.forward);
        playerRb.AddForce(horizontalInput * speed * Vector3.right);
    }

    private void ConstrainPlayerPosition()
    {
        if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
            playerRb.velocity = Vector3.zero;
        } else if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
            playerRb.velocity = Vector3.zero;
        }
    }
}
