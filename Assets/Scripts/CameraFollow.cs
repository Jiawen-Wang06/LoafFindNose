using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform followTransform;
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {



        // Update is called once per frame

        this.transform.position = new Vector3(followTransform.position.x, followTransform.position.y, this.transform.position.z);



    }

}
