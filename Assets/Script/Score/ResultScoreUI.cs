using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScoreUI : MonoBehaviour
{
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Text>().text = ResultScore.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
