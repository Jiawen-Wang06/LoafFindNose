using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winSound : MonoBehaviour
{
    // Start is called before the first frame update
    private string PLAYER_TAG = "Player";
    [SerializeField]
    private AudioSource winsound;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(PLAYER_TAG))
        {
            winsound.GetComponent<AudioSource>().Play();
        }
    }
}
