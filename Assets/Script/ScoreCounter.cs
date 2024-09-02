using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scorecounter : MonoBehaviour
{
    [SerializeField] private int score;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void ScoreUp()
    {
        score = score + 1;
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