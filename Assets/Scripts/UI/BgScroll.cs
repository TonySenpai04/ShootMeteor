using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScroll : MonoBehaviour
{
   
   

    void Update()
    {

        transform.position += new Vector3(0, -5 * Time.deltaTime);
        if (transform.position.y < -32.4f)
        {
            transform.position = new Vector3(transform.position.x, 32.4f);
        }
    }
}
