using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    /// <summary>シングルトンインスタンス</summary>
    public static MainManager Instance { get; private set; }

    /// <summary>全種類のダイバーシティ</summary>
    public GameObject[] DiversityPrefabs;

    /// <summary>ネクスト表示用SpriteRenderer</summary>
    public SpriteRenderer NextSpriteRenderer;
    /// <summary>スコア表示用テキスト</summary>
    public TMP_Text ScoreText;
    /// <summary>ゲームオーバー画面</summary>
    public GameObject Canvas_Gameover;

    /// <summary>プレイ中状態</summary>
    private bool _IsPlaying;
    /// <summary>Nextに表示するダイバーシティ</summary>
    private int _NextDiversityIndex;
    /// <summary>スコア</summary>
    private int _Score;

    /// <summary>落下させられるダイバーシティの種類数</summary>
    public int DropDiversityRandomRange = 3;
    /// <summary>デバックモード</summary>
    public bool IsDebug = false;

    void Start()
    {
        Instance = this;
        _Score = 0;
        // DropDiversityRandomRangeの不正な値の場合の例外処理
        DropDiversityRandomRange = DropDiversityRandomRange > DiversityPrefabs.Length ? DiversityPrefabs.Length : DropDiversityRandomRange < 1 ? 1 : DropDiversityRandomRange;
        Canvas_Gameover.SetActive(false);
        _IsPlaying = true;
        Time.timeScale = 1.0f;
        ScoreText.text = "score : " + _Score.ToString();

        ChangeNext();
    }

    void Update()
    {
        OnQDown();
    }

    /// <summary>
    /// 多様性を落とす
    /// </summary>
    /// <param name="dropPosition">落下の場所</param>
    public void DropDiversity(Vector3 dropPosition)
    {
        if (!_IsPlaying) return;

        // 多様性をランダムに選択して落とす
        Instantiate(DiversityPrefabs[_NextDiversityIndex], dropPosition, Quaternion.identity);

        // Nextを決定する
        ChangeNext();
    }

    void ChangeNext()
    {
        _NextDiversityIndex = Random.Range(0, DropDiversityRandomRange);
        NextSpriteRenderer.sprite = DiversityPrefabs[_NextDiversityIndex].GetComponent<SpriteRenderer>().sprite;
    }

    /// <summary>
    /// Canvas_Gameoverを開いて、ゲームオーバー画面を表示する。
    /// </summary>
    public void GameOver()
    {
        // ゲーム停止処理
        _IsPlaying = false;
        Time.timeScale = 0f;

        // ゲームオーバーの処理
        Canvas_Gameover.SetActive(true);
    }


    /// <summary>
    /// スコアを加算する
    /// </summary>
    /// <param name="scoreRatio">2条分スコア加算</param>
    public void ScoreCountUp(int scoreRatio = 1)
    {
        if (!_IsPlaying) return;

        _Score += 10 * scoreRatio * scoreRatio;
        ScoreText.text = "score : " + _Score.ToString();
    }

    private void OnQDown()
    {
        if (!IsDebug) return;
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameOver();
        }
    }
}
