using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kinscorecounter : MonoBehaviour
{
    [SerializeField] private int score;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void ScoreUp()
    {
        //金豆が籠に入ったときのメソッド
        score = score + 5;
    }
    // Start is called before the first frame update
    public int GetScore()
    {
        return score;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
