using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class butukaru : MonoBehaviour
{
    public GameObject sinka;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == this.gameObject.name)
        {
            Destroy(this.gameObject);

            other.gameObject.GetComponent<butukaru>().sinka = null;

            if (sinka != null)
            {
                Instantiate(sinka, this.transform.position, this.transform.rotation);
            }

        }
    }
}
