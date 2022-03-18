using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryRock : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Rigidbody2D rockRg;
    private string PLAYER_TAG = "Player";
    void Start()
    {
        rockRg = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(PLAYER_TAG))
        {
            
            rockRg.velocity = new Vector2(rockRg.velocity.x, -0.5f);
        }
    }
    
    
}
