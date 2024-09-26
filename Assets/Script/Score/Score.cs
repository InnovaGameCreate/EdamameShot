using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int _score;

    void Start()
    {
        // PlayerPrefs����X�R�A��ǂݍ��ށi���݂��Ȃ��ꍇ��0�j
        _score = PlayerPrefs.GetInt("Score", 0);
        _score = 0;
        ShowScore();
    }

    void Update()
    {
        ResultScore.score = _score;
    }

    private void ShowScore()
    {
        gameObject.GetComponent<Text>().text = _score.ToString();
    }

    public void AddScore(int score)
    {
        _score += score;
        ShowScore();
        // PlayerPrefs�ɃX�R�A��ۑ�
        PlayerPrefs.SetInt("Score", _score);
    }
}
