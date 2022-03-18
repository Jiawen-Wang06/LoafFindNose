using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMover : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject[] ladders;
    [SerializeField]
    private Transform leftpos;
    [SerializeField]
    private Transform rightpos;
    private float left_x;
    private float right_x;
    void Start()
    {
        left_x = leftpos.position.x;
        right_x = rightpos.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        MoveLadder();
    }

    void MoveLadder()
    {
      
        foreach (var ladder in ladders)
        {
            float ladder_x = ladder.transform.position.x;
            if(ladder_x <= left_x)
            {
                ladder.GetComponent<Ladder>().speed = Random.Range(3f,4f);
            }
            else if(ladder_x >= right_x)
            {
                ladder.GetComponent<Ladder>().speed = -(Random.Range(3f, 4f));
            }
        }
    }
}
