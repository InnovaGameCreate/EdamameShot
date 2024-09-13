using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEdamame : MonoBehaviour
{
    // �J�S
    [SerializeField] private GameObject _basket;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == _basket.name)
        {
            other.GetComponent<Basket>().CatchEdamame(KindEdamame.NormalEdamame);
            gameObject.GetComponent<SphereCollider>().enabled = false;

            Destroy(gameObject);
        }
    }
}