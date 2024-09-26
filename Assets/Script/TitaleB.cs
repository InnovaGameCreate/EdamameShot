using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitaleB : MonoBehaviour
{
    public Button myButton; // ボタン
    public Image myImage;   // 表示したいImage

    void Start()
    {
        // ボタンが押されたときにOnButtonClickメソッドが呼ばれるように設定
        myButton.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        StartCoroutine(ShowImageForDuration(10f));
    }

    IEnumerator ShowImageForDuration(float duration)
    {
        // Imageを表示
        myImage.enabled = true;

        // 指定された時間だけ待つ
        yield return new WaitForSeconds(duration);

        // Imageを非表示
        myImage.enabled = false;
    }
}
