using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiversityManager : MonoBehaviour
{
    public GameObject nextDiversity;
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

            other.gameObject.GetComponent<DiversityManager>().nextDiversity = null;

            if (nextDiversity != null)
            {
                Instantiate(nextDiversity, this.transform.position, this.transform.rotation);
            }

        }
    }
}
