using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Diversity : MonoBehaviour
{
    public GameObject nextDiversity;

    public int scoreRatio;
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
        //衝突して、Diversityが次のDiversityに進化する処理
        if (other.gameObject.name == this.gameObject.name)
        {
            Destroy(this.gameObject);

            other.gameObject.GetComponent<Diversity>().nextDiversity = null;

            if (nextDiversity != null)
            {
                GameManager.Instance.ScoreCountUp(scoreRatio);
                Instantiate(nextDiversity, this.transform.position, this.transform.rotation);
            }
        }

        // ゲームオーバーを判定する。
        if (other.gameObject.name == "Line")//衝突したオブジェクト名がLineかどうかを確認
        {
            GameManager.Instance.GameOver(); // ゲームオーバー処理
        }
    }
}
