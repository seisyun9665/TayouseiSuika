using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class DiversityManager : MonoBehaviour
{
    public GameObject nextDiversity;
    public GameManager gm;

    public int scoreRatio;
    // Start is called before the first frame update
    void Start()
    {
        gm = MonoBehaviour.FindObjectOfType<GameManager>();
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

            other.gameObject.GetComponent<DiversityManager>().nextDiversity = null;

            if (nextDiversity != null)
            {
                Debug.Log(this.gameObject.name);
                gm.ScoreCountUp(scoreRatio);
                Instantiate(nextDiversity, this.transform.position, this.transform.rotation);
            }

        }

        // ゲームオーバーを判定する。
        if (other.gameObject.name == "Line")//衝突したオブジェクト名がLineかどうかを確認
        {
            Destroy(this.gameObject);
            GameManager.Instance.GameOver(); // ゲームオーバー処理
        }
    }
}
