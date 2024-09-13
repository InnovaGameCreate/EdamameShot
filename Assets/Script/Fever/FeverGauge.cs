using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeverGauge : MonoBehaviour
{
    Fever _fever;

    // Start is called before thue first frame update
    void Start()
    {
        _fever = GetComponent<Fever>();
    }

    // Update is called once per frame
    void Update()
    {
        int count = _fever.GetFeverCount();
        float need = _fever.GetFeverNeeds();
        gameObject.GetComponent<Slider>().value = (float)(count / need);
    }
}
