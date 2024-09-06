using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>全ダイバーシティ</summary>
    public GameObject[] Diversities;
    /// <summary>シングルトンインスタンス</summary>
    public static GameManager Instance { get; private set; }
    
    //score関係の変数
    private TMP_Text _scoreText;
    public int score;


    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        
        score = 0;
        _scoreText = GetComponent<TMP_Text>();
        _scoreText.text = "score : 0";
    }

    // Update is called once per frame
    void Update()
    {
        _scoreText.text = "score : " + score.ToString();
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
    
    public void ScoreCountUp(int scoreRatio = 1)
    {
        score = score + 10 * scoreRatio * scoreRatio;
    }

    public int GetScore()
    {
        return score;
    }
}
