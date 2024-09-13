using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeverGauge : MonoBehaviour
{
    public Slider slider;
    // Start is called before thue first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = Fever.FeverCount/Fever.FeverNeeds;
    }
}
