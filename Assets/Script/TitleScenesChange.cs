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
        if (Input.GetKey(KeyCode.Space))    //スペースキーを押すとスクリーン遷移
        {
            SceneManager.LoadScene("GameScene");  //GameSceneを仮の遷移先
        }
        if (Input.GetKey(KeyCode.Return))    //enterキーを押すとスクリーン遷移
        {
            SceneManager.LoadScene("ManualScene");  //ManualSceneを仮の遷移先
        }
    }
}
