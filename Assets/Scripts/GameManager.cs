using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>全ダイバーシティ</summary>
    public GameObject[] Diversities;
    /// <summary>シングルトンインスタンス</summary>
    public static GameManager Instance { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// 多様性を落とす
    /// </summary>
    /// <param name="dropPosition">落下の場所</param>
    public void DropDiversity(Vector3 dropPosition)
    {
        Instantiate(Diversities[GameObject.Find("Next").GetComponent<Next>().bango],
        dropPosition, Quaternion.identity);

        GameObject.Find("Next").GetComponent<Next>().Change();
    }
}
