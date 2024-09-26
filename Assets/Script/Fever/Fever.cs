using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Fever : MonoBehaviour
{
    [SerializeField] private float _feverTime; //フィーバー時間
    [SerializeField] private int _feverNeeds;　//フィーバーに必要な数

    private float FeverTimed = 0; //Fever経過時間
    private int FeverCount = 0; //FeverTime中ならばFeverNeeds==FeverCount==needs

    public bool _isFever;

    // Start is called before the first frame update
    void Start()
    {
        _isFever = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (FeverCount >= _feverNeeds)
        {
            if(FeverTimed < _feverTime)
            {
                FeverTimed += Time.deltaTime;
                _isFever = true;
            }
            else
            {
                FeverTimed = 0;
                FeverCount = 0;
                _isFever = false;
            }
        }
    }

    public void AddFeverGauge()
    {
        if (FeverCount < _feverNeeds)
        {
            FeverCount++;
        }
    }

    public bool GetIsFever()
    {
        return _isFever;
    }

    public int GetFeverCount()
    {
        return FeverCount;
    }

    public int GetFeverNeeds()
    {
        return _feverNeeds;
    }
}