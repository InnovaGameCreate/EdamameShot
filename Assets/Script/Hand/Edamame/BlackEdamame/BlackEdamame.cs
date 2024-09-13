using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackEdamame : MonoBehaviour
{
    [SerializeField] private GameObject _basket;

    private Rigidbody _rb;

    // AddExprosionForce
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _upwardsModifier;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == _basket.name)
        {
            _rb.AddExplosionForce(_explosionForce, new Vector3(3.823216e-08f, 0, -0.4233129f), _explosionRadius, _upwardsModifier, ForceMode.Impulse);

            other.GetComponent<Basket>().CatchEdamame(KindEdamame.BlackEdamame);
            Destroy(gameObject);
        }
    }
}
