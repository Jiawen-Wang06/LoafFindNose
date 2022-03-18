using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBox : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject ghost;
    private string PLYAER_TAG = "Player";
    [SerializeField]
    private AudioSource ghostsound;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(PLYAER_TAG))
        {
            ghostsound.GetComponent<AudioSource>().Play();
            ghost.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-5f, -2.5f), Random.Range(-5f, -2.5f)); 
        }
    }
}
