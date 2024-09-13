using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum KindEdamame { 
    NormalEdamame,
    RainbowEdamame,
    GoldenEdamame,
    RopeEdamame,
    BlackEdamame,
    ClockEdamame,
    ArrowEdamame
};

public class Edamame : MonoBehaviour
{
    // ‰½‚Ì}“¤‚©
    KindEdamame _kind;

    // Rigidbody
    private Rigidbody _rb;

    // }“¤‚Ìƒpƒ‰ƒ[ƒ^
    [SerializeField] private float _impulseX;
    [SerializeField] private float _impulseY;
    [SerializeField] private float _impulseZ;
    private float _angleX;
    private float _angleY;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();

        // “–‚½‚è”»’è–³Œø‰»
        gameObject.GetComponent<Collider>().enabled = false;

        // ƒfƒtƒHƒ‹ƒg‚Í•’Ê‚Ì}“¤
        _kind = KindEdamame.NormalEdamame;
    }

    // Update is called once per frame
    void Update()
    {
        // —‚¿‚Äs‚Á‚½‚çíœ
        if (transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// }“¤”­Ë
    /// </summary>
    /// <param name="angleX"> ‰¡‚ÌŠp“x </param>
    /// <param name="angleY"> c‚ÌŠp“x </param>
    public void ShootEdamame(float angleX, float angleY)
    {
        // Šp“xİ’è
        SetAngle(angleX, angleY);

        // Šp“x‚ğŒÊ“x–@‚É•ÏŠ·
        float radX = TranslateAngleToRad(_angleX);
        float radY = TranslateAngleToRad(_angleY);

        // ˆÚ“®—Ê‚ğŠp“x‚©‚çŒvZ
        float deltaX = Mathf.Cos(radX) * _impulseX;
        float deltaY = Mathf.Sin(radY) * _impulseY;
        float deltaZ = _impulseZ;

        // d—Í‚ğ“K—p
        _rb.useGravity = true;
        // ”­Ë
        _rb.AddForce(new Vector3(deltaX, deltaY, deltaZ), ForceMode.Impulse);

        gameObject.GetComponent<Collider>().enabled = true;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Basket")
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Šp“x–@‚ğŒÊ“x–@‚É•ÏŠ·
    /// </summary>
    /// <param name="angle"> Šp“x(Šp“x–@) </param>
    /// <returns> Šp“x(ŒÊ“x–@) </returns>
    private float TranslateAngleToRad(float angle)
    {
        return Mathf.PI / (180 / angle);
    }

    public void SetKind(KindEdamame kind)
    {
        _kind = kind;
    }
    public KindEdamame GetKind()
    {
        return _kind;
    }

    /// <summary>
    /// }“¤‚ğ”­Ë‚·‚éŠp“x(X)
    /// </summary>
    /// <returns> Šp“x(X) </returns>
    public float GetAngleX() { return _angleX; }
    /// <summary>
    /// }“¤‚ğ”­Ë‚·‚éŠp“x(Y)
    /// </summary>
    /// <returns> Šp“x(Y) </returns>
    public float GetAngleY() { return _angleY; }

    /// <summary>
    /// }“¤‚ğ”­Ë‚·‚é—Í(X)
    /// </summary>
    /// <returns> —Í(X) </returns>
    public float GetImpulseX() { return _impulseX; }
    /// <summary>
    /// }“¤‚ğ”­Ë‚·‚é—Í(Y)
    /// </summary>
    /// <returns> —Í(Y) </returns>
    public float GetImpulseY() { return _impulseY; }
    /// <summary>
    /// }“¤‚ğ”­Ë‚·‚é—Í(Z)
    /// </summary>
    /// <returns> —Í(Z) </returns>
    public float GetImpulseZ() { return _impulseZ; }
}
