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
        if (Input.GetKey(KeyCode.Return))    //enter�L�[�������ƃX�N���[���J��
        {
            SceneManager.LoadScene("TitleScene");  //TitleScene�����̑J�ڐ�
        }
    }
}