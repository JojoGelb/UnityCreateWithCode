using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRb;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;
    private bool hasDoubleJump = true;

    public bool sprinting = false;

    public bool gameOver = false;

    private Animator playerAnim;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip jumpSound;
    public AudioClip crashSound;
    public float spawnSpeed = 0.1f;

    private AudioSource playerAudio;

    private int score = 0;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();

        playerAudio = GetComponent<AudioSource>();
        playerAnim.SetFloat("Speed_f", 0.3f);
    }

    // Update is called once per frame
    void Update()
    {

        if (gameOver)
        {
            return;
        }
        if (transform.position.x < 0)
        {
            if (transform.position.x < 0 && transform.position.x > -0.1 )
            {
                playerAnim.SetFloat("Speed_f",1f);
            }
            dirtParticle.Stop();
            transform.Translate(Vector3.forward * spawnSpeed * Time.deltaTime);

            return;
        }
        

        score += 1;
        if (sprinting)
        {
            score += 1;                                                                                                                                                                                     
        }

        Debug.Log("Score: " + score);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            sprinting = !sprinting;
        }

    }

    void Jump()
    {
        if (isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            dirtParticle.Stop();
            playerAnim.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
        else if (hasDoubleJump)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            hasDoubleJump = false;
            playerAnim.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            isOnGround = true;
            hasDoubleJump = true;
            dirtParticle.Play();
        }else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over");
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
        
    }
}
