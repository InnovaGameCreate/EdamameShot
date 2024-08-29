using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredictionLine : MonoBehaviour
{
    // ’è”
    const float G = 9.8f * 0.1f; // d—Í

    // }“¤Prefab
    [SerializeField] private GameObject _edamamePrefab;

    // Œ»İ‚Ì}“¤
    Edamame _currentEdamame;

    // }“¤‚Ìƒpƒ‰ƒ[ƒ^
    [SerializeField] private float _speedX;
    [SerializeField] private float _speedY;
    [SerializeField] private float _speedZ;
    private float _angleX;
    private float _angleY;
    private float _mass;
    private float _forceX;
    private float _forceY;

    // ‚Ç‚Ì‚­‚ç‚¢Œo‚Á‚½‚©
    float _time;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = _edamamePrefab.GetComponent<Rigidbody>();
        _mass = rb.mass;
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;

        _currentEdamame = _edamamePrefab.GetComponent<Edamame>();
    }

    /// <summary>
    /// }“¤‚ÌŠp“x‚Ìİ’è
    /// </summary>
    /// <param name="angleX"> ‰¡‚ÌŠp“x </param>
    /// <param name="angleY"> c‚ÌŠp“x </param>
    public void SetAngle(float angleX, float angleY)
    {
        if (angleX < 0)
        {
            angleX *= -1;
        }
        if (angleX > 180)
        {
            angleX = 360 - angleX;
        }

        if (angleY < 0)
        {
            angleY *= -1;
        }
        if (angleY > 180)
        {
            angleY = 360 - angleY;
        }

        _angleX = angleX;
        _angleY = angleY;
    }

    float translateAngleToRad(float angle)
    {
        return Mathf.PI / (180 / angle);
    }
}
