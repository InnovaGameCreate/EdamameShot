using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultScenesChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))    //enter�L�[�������ƃX�N���[���J��
        {
            SceneManager.LoadScene("TitleScene");  //TitlelScene�����̑J�ڐ�
        }
        if (Input.GetKeyDown(KeyCode.Space))    //space�L�[�������ƃX�N���[���J��
        {
            SceneManager.LoadScene("SampleScene");  //GameScene�����̑J�ڐ�
        }
    }
}
