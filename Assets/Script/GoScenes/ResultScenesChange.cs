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
        if (Input.GetKey(KeyCode.Return))    //enter�L�[�������ƃX�N���[���J��
        {
            SceneManager.LoadScene("TitleScene");  //TitlelScene�����̑J�ڐ�
        }
        if (Input.GetKey(KeyCode.Space))    //space�L�[�������ƃX�N���[���J��
        {
            SceneManager.LoadScene("SampleScene");  //GameScene�����̑J�ڐ�
        }
    }
}
