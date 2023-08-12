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
    public ParticleSystem boom;
    public ParticleSystem dirty;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public AudioSource playerSounds;

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        Physics.gravity *= gravitySetter;
        playerAnimation = GetComponent<Animator>();
        playerSounds = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)) && isInTheFloor && !gameOver)
        {
            playerSounds.PlayOneShot(jumpSound, 1.0f);
            rbPlayer.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isInTheFloor = false;
            playerAnimation.SetTrigger("Jump_trig");
            dirty.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            dirty.Play();
            isInTheFloor = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            playerSounds.PlayOneShot(crashSound, 1.0f);
            gameOver = true;
            playerAnimation.SetTrigger("Death_b");
            boom.Play();
            dirty.Stop();
        }
    }

}
