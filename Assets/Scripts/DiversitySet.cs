using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiversitySet : MonoBehaviour
{
    /// <summary>ダイバーシティセット名</summary>
    public string DiversitySetName;
    /// <summary>セットに含まれるダイバーシティ</summary>
    public GameObject[] DiversityObjects;
    /// <summary>Select画面表示イメージ</summary>
    public Sprite SetImage;
    /// <summary>落下させるダイバーシティの大きさ(倍)</summary>
    public float DiversityScale = 1.0f;
}
