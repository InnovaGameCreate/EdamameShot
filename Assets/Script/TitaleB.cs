using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitaleB : MonoBehaviour
{
    public Button myButton; // �{�^��
    public Image myImage;   // �\��������Image

    void Start()
    {
        // �{�^���������ꂽ�Ƃ���OnButtonClick���\�b�h���Ă΂��悤�ɐݒ�
        myButton.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        StartCoroutine(ShowImageForDuration(10f));
    }

    IEnumerator ShowImageForDuration(float duration)
    {
        // Image��\��
        myImage.enabled = true;

        // �w�肳�ꂽ���Ԃ����҂�
        yield return new WaitForSeconds(duration);

        // Image���\��
        myImage.enabled = false;
    }
}
