using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeverGauge : MonoBehaviour
{
    // Start is called before thue first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Slider>().value = Fever.FeverCount/Fever.FeverNeeds;
    }
}
