using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreUIPresenter : MonoBehaviour
{
    private GameObject scorecounterobject;
    private scorecounter scorecounterscript;
    private Text maytext;

    private int score;
    // Start is called before the first frame update
    void Start()
    {
        scorecounterobject = GameObject.Find("scorecounter");
        scorecounterscript = scorecounterobject.GetComponent<scorecounter>();
        maytext = GetComponent<Text>();
        score = scorecounterscript.GetScore();
        maytext.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
