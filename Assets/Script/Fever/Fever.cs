using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Fever : MonoBehaviour
{
    [SerializeField] public static float FeverNeeds;
    [SerializeField] public static float FeverTime;
    [SerializeField] private float time; //フィーバー時間
    [SerializeField] private float needs;　//フィーバーに必要な数

    public static float FeverTimed=0; //Fever経過時間
    public static float FeverCount=3; //FeverTime中ならばFeverNeeds==FeverCount==needs

    // Start is called before the first frame update
    void Start()
    {
        FeverNeeds = needs;
        FeverTime = time;
    }

    // Update is called once per frame
    void Update()
    {
        if (FeverCount >= FeverNeeds)
        {
            if(FeverTimed < FeverTime)
            {
                FeverTimed += Time.deltaTime;
            }
            else
            {
                FeverTimed = 0;
                FeverCount = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RainbowBeans")) //豆側に識別用のTagが欲しい
        {
            if (FeverCount < FeverNeeds)
            {
                FeverCount++;
            }
        }
    }
}