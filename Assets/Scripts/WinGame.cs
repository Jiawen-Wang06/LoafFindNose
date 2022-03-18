using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    // Start is called before the first frame update
    //private string PLAYER_TAG = "Player";
    [SerializeField]
    private GameObject wingame;
    [SerializeField]
    private Transform endline;
    [SerializeField]
    private GameObject player;
  
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        StartCoroutine(checkwin());
    }

    

    IEnumerator checkwin()
    {
        if (player.GetComponent<Rigidbody2D>().position.x >= (endline.position.x))
        {

            yield return new WaitForSeconds(0.2f);
            wingame.GetComponent<RectTransform>().position = new Vector3(1000, 500, 0);


        }

    }

    
}
