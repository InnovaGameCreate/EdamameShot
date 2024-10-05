using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private float _radius;
    [SerializeField] private float _upwards;
    Vector3 _position;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(gameObject.transform.position, _radius);
        Debug.Log(_position);
        for (int i = 0; i < colliders.Length; i++)
        {
            Rigidbody rb = colliders[i].GetComponent<Rigidbody>();
            if (rb)
            {
                rb.AddExplosionForce(_force, _position, _radius, _upwards);
                //Debug.Log("Explosion!!");
            }
        }
    }
}
