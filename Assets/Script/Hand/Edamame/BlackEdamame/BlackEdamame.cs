using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackEdamame : MonoBehaviour
{
    [SerializeField] private GameObject _basket;

    Rigidbody _rb;

    [SerializeField] private float _exprosionForce;
    [SerializeField] private float _exprosionX;
    [SerializeField] private float _exprosionY;
    [SerializeField] private float _exprosionZ;
    [SerializeField] private float _exporsionRadius;
    [SerializeField] private float _upWardsModifier;

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
        if (other == _basket)
        {
            _rb.AddExplosionForce(_exprosionForce, new Vector3(_exprosionX, _exprosionY, _exprosionZ), _exporsionRadius, _upWardsModifier);
        }
    }
}
