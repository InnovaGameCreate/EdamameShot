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
        //�������Ăɓ������Ƃ��̃��\�b�h
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
