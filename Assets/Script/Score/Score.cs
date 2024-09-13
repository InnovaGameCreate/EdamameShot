using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // ÉXÉRÉA
    private int _score;

    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void ShowScore()
    {
        gameObject.GetComponent<Text>().text = _score.ToString();
    }

    public void AddScore(int score)
    {
        _score += score;
        ShowScore();
    }
}
