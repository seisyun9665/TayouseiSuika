using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Next : MonoBehaviour
{
    public Sprite[] gazo;

    public int bango;

    // Start is called before the first frame update
    void Start()
    {
        Change();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Change()
    {
        bango = Random.Range(0, 3);
        GetComponent<SpriteRenderer>().sprite = gazo[bango];
    }

    public void ChangeNext(Sprite diversity)
    {

    }
}
