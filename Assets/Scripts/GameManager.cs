using TMPro;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    /// <summary>シングルトンインスタンス</summary>
    public static MainManager Instance { get; private set; }
    /// <summary>使用するダイバーシティセット</summary>
    private DiversitySet _diversitySet;

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
    /// <summary>ダイバーシティの大きさ</summary>
    public float DiversityScale { get; private set; } = 1.0f;

    void Start()
    {
        Instance = this;
        _Score = 0;

        // 使用するダイバーシティを設定
        _diversitySet = DiversityManager.Instance.SelectedDiversitySet;

        // DropDiversityRandomRangeの不正な値の場合の例外処理
        DropDiversityRandomRange = DropDiversityRandomRange > _diversitySet.DiversityObjects.Length ? _diversitySet.DiversityObjects.Length : DropDiversityRandomRange < 1 ? 1 : DropDiversityRandomRange;

        // ゲームオーバー画面を隠す
        Canvas_Gameover.SetActive(false);
        // プレイ中状態設定
        _IsPlaying = true;
        // 時間を流す
        Time.timeScale = 1.0f;
        // スコアをゼロに設定
        ScoreText.text = "score : " + _Score.ToString();

        // ダイバーシティのサイズを決定
        DiversityScale = _diversitySet.DiversityScale;

        // 次に落とすダイバーシティを決定
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
        GameObject diversity = Instantiate(_diversitySet.DiversityObjects[_NextDiversityIndex], dropPosition, Quaternion.identity);
        diversity.transform.localScale = new Vector3(DiversityScale, DiversityScale, DiversityScale);

        // Nextを決定する
        ChangeNext();

        // 効果音
        AudioManager.Instance.PlaySFX("Drop");
    }


    void ChangeNext()
    {
        _NextDiversityIndex = Random.Range(0, DropDiversityRandomRange);
        NextSpriteRenderer.sprite = _diversitySet.DiversityObjects[_NextDiversityIndex].GetComponent<SpriteRenderer>().sprite;
    }

    /// <summary>
    /// Canvas_Gameoverを開いて、ゲームオーバー画面を表示する。
    /// </summary>
    public void GameOver()
    {
        // 効果音
        AudioManager.Instance.PlaySFX("GameOver");

        // ゲーム停止処理
        _IsPlaying = false;
        Time.timeScale = 0f;

        // スコア保存処理
        ScoreManager.Instance.Score = _Score;

        // ゲームオーバーの処理
        Canvas_Gameover.SetActive(true);
    }


    /// <summary>
    /// スコアを加算する
    /// </summary>
    /// <param name="scoreRatio">2条分スコア加算</param>
    public void ScoreCountUp(int scoreRatio = 1)
    {
        // 効果音
        AudioManager.Instance.PlaySFX("Collision");

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
