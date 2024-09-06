using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [FormerlySerializedAs("Diversity")] public GameObject[] diversity;
    Vector3 _initialPositionAdj = new Vector3(-1.2f, -1.2f, 0f);

    /// <summary>
    /// プレイヤー移動速度
    /// </summary>
    public float speed = 10;
    
    /// <summary>
    ///  プレイヤーの硬直時間
    /// </summary>
    public float initialPauseTime = 0.5f; 
    private float _nowPauseTime = 0.5f;
    
    /// <summary>
    /// プレイヤーの移動制限
    /// </summary>
    public float upperLimit = 6;
    public float lowerLimit = 4f;
    private Vector2 _playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        _nowPauseTime = initialPauseTime;
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
    /// 位置監視と制限
    /// </summary>

    void ClampPosition()
    {
        _playerPosition = transform.position;
        _playerPosition.x = Mathf.Clamp(_playerPosition.x, -1*lowerLimit, upperLimit);
        transform.position = new Vector2(_playerPosition.x, _playerPosition.y);
    }

    /// <summary>
    /// 多様性を落とす
    /// </summary>
    void DropDiversity()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_nowPauseTime <= 0)
            {
                GameManager.Instance.DropDiversity(
                    this.transform.position + _initialPositionAdj);
                _nowPauseTime = initialPauseTime;
            }
        }
    }
}
