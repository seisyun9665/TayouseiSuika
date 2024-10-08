using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    /// <summary>プレイヤー初期位置</summary>
    Vector3 _initialPositionAdj = new Vector3(-1.2f, -1.2f, 0f);

    /// <summary>プレイヤー移動速度</summary>
    public float speed = 10;
    /// <summary>プレイヤーの移動制限</summary>
    public float upperLimit = 6;
    public float lowerLimit = 4f;
    private Vector2 _playerPosition;

    /// <summary>ダイバーシティ落下間隔/// </summary>
    public float DropInterval = 0.7f;
    private float _nowPauseTime;
    /// <summary>テトリスモードの時の落下間隔</summary>
    public float TetrisDropInterval = 1.5f;
    private float _tetorisNowPauseTime;

    /// <summary>マウス操作 OR　キーボード操作</summary>
    public bool UseMouse = true;
    private bool _MouseIsDownBeforeFrame = false;

    // Start is called before the first frame update
    void Start()
    {
        _nowPauseTime = DropInterval;
        _tetorisNowPauseTime = TetrisDropInterval;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        ClampPosition();
        DropDiversity();
        if (_nowPauseTime > 0)
        {
            _nowPauseTime -= Time.deltaTime;
        }
    }

    /// <summary>
    /// プレイヤーの左右移動
    /// </summary>
    void Move()
    {
        if (!UseMouse)
        {
            // キーボード操作
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(1 * Time.deltaTime * speed, 0, 0);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(-1 * Time.deltaTime * speed, 0, 0);
            }
        }

        else
        {
            // マウス操作
            if (Input.GetMouseButton(0))
            {
                // マウスを押している間、マウスの座標にプレイヤーを合わせる
                transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y, transform.position.z);
                _MouseIsDownBeforeFrame = true;
            }
        }

    }

    /// <summary>
    /// 位置監視と制限
    /// </summary>
    void ClampPosition()
    {
        _playerPosition = transform.position;
        _playerPosition.x = Mathf.Clamp(_playerPosition.x, -1 * lowerLimit, upperLimit);
        transform.position = new Vector2(_playerPosition.x, _playerPosition.y);
    }

    /// <summary>
    /// 多様性を落とす
    /// </summary>
    void DropDiversity()
    {
        if (DiversityManager.Instance.SelectedDiversitySet.Gamemode == Gamemode.Tetris)
        {
            // テトリスモード
            //　落下間隔を調整
            if (_tetorisNowPauseTime > 0)
            {
                _tetorisNowPauseTime -= Time.deltaTime;
            }

            if (_tetorisNowPauseTime <= 0)
            {
                // 一定時間が経過したら多様性を落とす
                MainManager.Instance.DropDiversity(
                    this.transform.position + _initialPositionAdj);

                // 落下までの時間を再設定
                _tetorisNowPauseTime = TetrisDropInterval;
            }
        }

        else if (!UseMouse)
        {
            // キーボード操作
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_nowPauseTime <= 0)
                {
                    MainManager.Instance.DropDiversity(
                        this.transform.position + _initialPositionAdj);
                    _nowPauseTime = DropInterval;
                }

            }
        }

        else
        {
            // マウス操作
            if (_MouseIsDownBeforeFrame)
            {
                if (!Input.GetMouseButton(0))
                {
                    _MouseIsDownBeforeFrame = false;
                    if (_nowPauseTime <= 0)
                    {
                        MainManager.Instance.DropDiversity(
                            this.transform.position + _initialPositionAdj);
                        _nowPauseTime = DropInterval;
                    }
                }
            }
        }
    }
}
