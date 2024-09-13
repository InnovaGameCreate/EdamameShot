using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // どれだけ経ったか
    private float _time;

    // タイマー
    [SerializeField] private GameObject _timeMinuteObj;
    [SerializeField] private GameObject _timeSecondObj;

    // 制限時間
    [SerializeField] private float _timeLimit;

    // Start is called before the first frame update
    void Start()
    {
        _time = _timeLimit;
    }

    // Update is called once per frame
    void Update()
    {
        if (_time <= 0)
        {
            gameObject.GetComponent<GameScene>().GoResultScene();
        }

        ShowTime();
        _time -= Time.deltaTime;
    }

    void ShowTime()
    {
        int minute = (int)(_time / 60f);
        int second = (int)(_time - 60 * minute);

        _timeMinuteObj.GetComponent<Text>().text = minute.ToString();
        _timeSecondObj.GetComponent<Text>().text = (second >= 10) ? second.ToString() : $"0{second.ToString()}";
    }
    
    public void AddTime(float time)
    {
        _time += time;

        ShowTime();
    }
}
