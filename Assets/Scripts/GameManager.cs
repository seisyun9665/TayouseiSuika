using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>シングルトンインスタンス</summary>
    public static GameManager Instance { get; private set; }
    /// <summary>全ダイバーシティ</summary>
    public GameObject[] DiversityPrefabs;
    /// <summary>ネクスト表示用SpriteRenderer</summary>
    public SpriteRenderer NextSpriteRenderer;
    /// <summary>Nextに表示するダイバーシティ</summary>
    private int _NextDiversityIndex;
    /// <summary>落下させられるダイバーシティの種類数</summary>
    public int DropDiversityRandomRange = 3;

    /// <summary>ゲームオーバー画面</summary>
    public Canvas Canvas_Gameover;

    //score関係の変数
    public TMP_Text _scoreText;
    public int score;

    void Start()
    {
        Instance = this;
        score = 0;
        // DropDiversityRandomRangeの不正な値の場合の例外処理
        DropDiversityRandomRange = DropDiversityRandomRange > DiversityPrefabs.Length ? DiversityPrefabs.Length : DropDiversityRandomRange < 1 ? 1 : DropDiversityRandomRange;
        _NextDiversityIndex = Random.Range(0, DropDiversityRandomRange);
    }

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
        // 多様性をランダムに選択して落とす
        Instantiate(DiversityPrefabs[_NextDiversityIndex], dropPosition, Quaternion.identity);

        // Nextを決定する
        _NextDiversityIndex = Random.Range(0, DropDiversityRandomRange);
        NextSpriteRenderer.sprite = DiversityPrefabs[_NextDiversityIndex].GetComponent<SpriteRenderer>().sprite;
    }

    /// <summary>
    /// Canvas_Gameoverを開いて、ゲームオーバー画面を表示する。
    /// </summary>
    public void GameOver()
    {
        Debug.Log("Game Over!");

        // ゲームオーバーの処理
        Canvas_Gameover.enabled = true;
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
