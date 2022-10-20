using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;

    [SerializeField]
    private float jumpForce = 10f;

    [SerializeField]
    private float gravityModifier = 1f;

    [SerializeField]
    private bool isOnGround = true;

    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;

    }

    // Update is called once per frame
    void Update()
    {
        // make jump
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        // if ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            print("Ground");
        } else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            print("over");
        }
    }
}
