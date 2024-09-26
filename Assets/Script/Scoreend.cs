using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreend : MonoBehaviour
{
    public Text scoreText; // �X�R�A��\������e�L�X�g

    void Start()
    {
        // PlayerPrefs����X�R�A��ǂݍ���
        int score = PlayerPrefs.GetInt("Score", 0);
        // �w�肳�ꂽ�e�L�X�g�ɃX�R�A��\��
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }

    void Update()
    {
        // Enter�L�[�܂��̓X�y�[�X�L�[�������ꂽ�Ƃ��ɃX�R�A�����Z�b�g
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            ResetScore();
        }
    }

    void ResetScore()
    {
        // �X�R�A��0�ɐݒ肵�APlayerPrefs�ɂ��ۑ�
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.Save();
        // �X�R�A�\�����X�V
        if (scoreText != null)
        {
            scoreText.text = "0";
        }
    }
}