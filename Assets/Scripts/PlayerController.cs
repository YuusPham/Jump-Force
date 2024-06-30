using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce = 15;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameover;
    private Animator playerAni;
    public ParticleSystem explosionSmoke;
    public ParticleSystem dirParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAni = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && gameover != true)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAni.SetTrigger("Jump_trig");
            dirParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
             isOnGround = true;
             dirParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("GameOver");
            gameover = true ;
            playerAni.SetBool("Death_b", true);
            playerAni.SetInteger("DeathType_int", 1);
            explosionSmoke.Play();
            dirParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}
