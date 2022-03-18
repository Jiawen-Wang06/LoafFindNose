using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loaf : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D rgbd2d;
    private SpriteRenderer sprite;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private AudioSource[] audioSouces;
    private AudioSource jump, bounce, hurt, carrot, gameover;
    


    [SerializeField]
    private float jumpForce = 25f;
    private bool isGround = true;
    private bool isIntheAir = false;
    private string GROUND_TAG = "Ground";
    private string CARROT_TAG = "Carrot";
    private string GHOST_TAG = "Ghost";
    private string CELLING_TAG = "Ceiling";
    private string RABBIT_TAG = "Rabbit";
    private string BOTTOM_TAG = "Bottom";
    public float timeSpan = 0.3f;
    private bool even;
    private float time;
    
    public int carrotCount = 0;
    public int heartCount = 3;
    private void Awake()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        rgbd2d.freezeRotation = true;
        sprite = GetComponent<SpriteRenderer>();
        
    }
    void Start()
    {
        jump = audioSouces[0].GetComponent<AudioSource>();
        bounce = audioSouces[1].GetComponent<AudioSource>();
        hurt = audioSouces[2].GetComponent<AudioSource>();
        carrot = audioSouces[3].GetComponent<AudioSource>();
        gameover = audioSouces[4].GetComponent<AudioSource>();

    }

    private void FixedUpdate()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        playerJump();
        if(heartCount == 0)
        {
            PlayerDead();
        }

    }

    void playerJump() {
      
        if (Input.GetButtonUp("Jump") && isGround)
        {
            time = 0;
            rgbd2d.AddForce(new Vector2(2f, jumpForce),ForceMode2D.Impulse);
            isIntheAir = true;
            isGround = false;
            bounce.Play();
            //Debug.Log("I'm short jump");
        }
        else if(Input.GetButtonUp("Jump") && (!isGround) && isIntheAir)
        {
            time = 0;
            rgbd2d.AddForce(new Vector2(0.5f, jumpForce*1.2f), ForceMode2D.Impulse);
            isIntheAir=false;
           bounce.Play();
            //Debug.Log("I'm air");
        }
        else if (Input.GetKey(KeyCode.Space) && isGround)
        {
            time += Time.deltaTime;
            
            if (time > timeSpan )
            {
                
                rgbd2d.AddForce(new Vector2(4f, jumpForce+time*20), ForceMode2D.Impulse);
                jump.Play();
                isGround = false;
                isIntheAir = false;
                time = 0;
                

            }
        }
       
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag(GROUND_TAG)) {
            isGround = true;
            isIntheAir = false;
        }

        if (collision.gameObject.CompareTag(CELLING_TAG)  ) {
            gameover.Play();
            PlayerDead();
            heartCount = 0;
        }

        if (collision.gameObject.CompareTag(RABBIT_TAG))
        {
            if (carrotCount > 0)
            {
                carrotCount--;
                hurt.Play();
            }
                
            
        }

        if (collision.gameObject.CompareTag(BOTTOM_TAG))
        {
            gameover.Play();
            rgbd2d.rotation = -90f;
            heartCount = 0;
           
        }



    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(GHOST_TAG))
        {
            Invoke("EnableBlink", 0.5f);
           
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(CARROT_TAG))
        {
            
            Destroy(collision.gameObject);
            this.carrotCount++;
            carrot.Play();
            
        }

        if (collision.gameObject.CompareTag(GHOST_TAG))
        {

            Invoke("DisableBlink", 0.5f);
            if(heartCount > 0)
            {
                heartCount--;
                hurt.Play();
            }
          
        }

    }

    void EnableBlink()
    {
        player.SetActive(true);
    }

    void DisableBlink()
    {
        player.SetActive(false);
    }

    void PlayerDead()
    {
        player.GetComponent<SpriteRenderer>().flipY = true;
        rgbd2d.velocity = new Vector2(rgbd2d.velocity.x, -5f);
    }
}
