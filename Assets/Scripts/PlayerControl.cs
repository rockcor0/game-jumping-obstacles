using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody rbPlayer;

    Animator playerAnimation;

    public float jumpForce = 800f;
    public float gravitySetter = 3f;
    public bool isInTheFloor = true;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        Physics.gravity *= gravitySetter;
        playerAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isInTheFloor)
        {
            rbPlayer.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isInTheFloor = false;
            playerAnimation.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isInTheFloor = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            gameOver = true;
            playerAnimation.SetTrigger("Death_b");
        }
    }

}
