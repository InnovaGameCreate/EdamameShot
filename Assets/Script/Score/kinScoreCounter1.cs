using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kinscorecounter : MonoBehaviour
{
    [SerializeField] private int kinscore;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void ScoreUp()
    {
        //金豆が籠に入ったときのメソッド
        kinscore = kinscore + 5;
    }
    // Start is called before the first frame update
    public int GetScore()
    {
        return kinscore;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
