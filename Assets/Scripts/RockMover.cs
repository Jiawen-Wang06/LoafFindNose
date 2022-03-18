using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMover : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform upperBar;
    [SerializeField]
    private Transform lowerBar;
    [SerializeField]
    private GameObject rock;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        MoveRock();
    }

    void MoveRock()
    {
        float rock_y = rock.transform.position.y;
        float upperBar_y = upperBar.position.y;
        float lowerBar_y = lowerBar.position.y;

        if(rock_y<= lowerBar_y)
        {
            rock.GetComponent<Rock>().speed = 1.5f;
        }
        else if (rock_y >= upperBar_y)
        {
            rock.GetComponent<Rock>().speed = -1.5f;
        }
    }
}
