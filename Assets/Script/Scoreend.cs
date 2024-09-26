using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreend : MonoBehaviour
{
    public Text scoreText; // スコアを表示するテキスト

    void Start()
    {
        // PlayerPrefsからスコアを読み込む
        int score = PlayerPrefs.GetInt("Score", 0);
        // 指定されたテキストにスコアを表示
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }

    void Update()
    {
        // Enterキーまたはスペースキーが押されたときにスコアをリセット
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            ResetScore();
        }
    }

    void ResetScore()
    {
        // スコアを0に設定し、PlayerPrefsにも保存
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.Save();
        // スコア表示を更新
        if (scoreText != null)
        {
            scoreText.text = "0";
        }
    }
}