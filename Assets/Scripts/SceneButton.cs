using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// シーン遷移用のボタンにAttackして使用する
public class SceneButton : MonoBehaviour
{

    /// <summary>遷移先シーン名</summary>
    public string SceneName;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            SceneManager.LoadScene(SceneName);
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
