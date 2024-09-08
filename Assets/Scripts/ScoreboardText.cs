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
        this.gameObject.GetComponent<TMP_Text>().text = ScoreManager.Instance.Score.ToString() + EndText;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
