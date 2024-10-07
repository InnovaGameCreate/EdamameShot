using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManualScenesChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))    //enterキーを押すとスクリーン遷移
        {
            SceneManager.LoadScene("TitleScene");  //TitleSceneを仮の遷移先
        }
    }
}
