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
        if (Input.GetKey(KeyCode.Space))    //�X�y�[�X�L�[�������ƃX�N���[���J��
        {
            SceneManager.LoadScene("GameScene");  //GameScene�����̑J�ڐ�
        }
        if (Input.GetKey(KeyCode.Return))    //enter�L�[�������ƃX�N���[���J��
        {
            SceneManager.LoadScene("ManualScene");  //ManualScene�����̑J�ڐ�
        }
    }
}
