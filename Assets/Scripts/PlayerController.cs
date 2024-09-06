using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject[] kudamono;
    Vector3 initialPositionAdj = new Vector3(-1.2f, -1.2f, 0f);

    /// <summary>
    /// プレイヤー移動速度
    /// </summary>
    public float speed = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        DropDiversity();
    }

    /// <summary>
    /// プレイヤーの左右移動
    /// </summary>
    void Move()
    {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(1 * Time.deltaTime * speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-1 * Time.deltaTime * speed, 0, 0);
        }
    }

    /// <summary>
    /// 多様性を落とす
    /// </summary>
    void DropDiversity()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(kudamono[GameObject.Find("Next").GetComponent<Next>().bango],
            this.transform.position + initialPositionAdj, this.transform.rotation);

            GameObject.Find("Next").GetComponent<Next>().Change();
        }
    }
}
