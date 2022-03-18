using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextCounter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Text[] texts;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        texts[0].text = player.GetComponent<Loaf>().carrotCount.ToString();
       
        texts[1].text = player.GetComponent<Loaf>().heartCount.ToString();
        
    }
}
