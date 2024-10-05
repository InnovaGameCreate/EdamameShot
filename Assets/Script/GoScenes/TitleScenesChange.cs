using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScenesChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))    //スペースキーを押すとスクリーン遷移
        {
            SceneManager.LoadScene("SampleScene");  //GameSceneを仮の遷移先
        }
        if (Input.GetKeyDown(KeyCode.Return))    //enterキーを押すとスクリーン遷移
        {
            SceneManager.LoadScene("ManualScene");  //ManualSceneを仮の遷移先
        }
    }
}
