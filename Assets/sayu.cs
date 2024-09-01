using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class sayuu : MonoBehaviour
{
    public float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow)){
            transform.Translate(1 * Time.deltaTime * speed, 0, 0);
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            transform.Translate(-1*Time.deltaTime * speed, 0, 0);
        }
    }
}
