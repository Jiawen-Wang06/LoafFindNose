using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D ladderRd;
    public float speed;
    void Start()
    {
        ladderRd = GetComponent<Rigidbody2D>();
        speed = Random.Range(-3f,3f);
       
    }

    // Update is called once per frame
    void Update()
    {
        ladderRd.velocity = new Vector2(speed, ladderRd.velocity.y);
    }
}
