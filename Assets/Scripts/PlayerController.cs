using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject[] Diversity;
    Vector3 initialPositionAdj = new Vector3(-1.2f, -1.2f, 0f);

    /// <summary>
    /// プレイヤー移動速度
    /// </summary>
    public float speed = 10;
    public float intial_pauseTime = 0.5f; 
    private float now_pauseTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        now_pauseTime = intial_pauseTime;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        DropDiversity();
        if (now_pauseTime > 0)
        {
            now_pauseTime -= Time.deltaTime;
        }
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
            if (now_pauseTime <= 0)
            {
            GameManager.Instance.DropDiversity(
                this.transform.position + initialPositionAdj);
            now_pauseTime = 0.5f;
            }
        }
    }
}
