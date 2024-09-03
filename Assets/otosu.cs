using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otosu : MonoBehaviour
{

    public GameObject[] kudamono;
    Vector3 initialPositionAdj = new Vector3(-1.2f, -1.2f, 0f);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(kudamono[Random.Range(0, 3)], this.transform.position + initialPositionAdj, this.transform.rotation);
        }
    }
}
