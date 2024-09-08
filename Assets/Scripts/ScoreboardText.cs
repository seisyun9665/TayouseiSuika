using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreboardText : MonoBehaviour
{
    [SerializeField] string EndText = " Point";
    // Start is called before the first frame update
    void Start()
    {
        UpdateText(ScoreManager.Instance.Score.ToString() + EndText);
    }

    void UpdateText(string text)
    {
        this.gameObject.GetComponent<TMP_Text>().text = text;
    }
}
