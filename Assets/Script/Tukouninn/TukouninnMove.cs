using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TukouninnMove : MonoBehaviour
{
    [SerializeField] private float TukouninnSpeedX;
    [SerializeField] private float TukouninnLifeTime;
    [SerializeField] private GameObject HitTukouninnPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        {
            transform.Translate(new Vector3(TukouninnSpeedX, 0, 0) * Time.deltaTime);

            TukouninnLifeTime = TukouninnLifeTime - Time.deltaTime;
            if (TukouninnLifeTime < 0)
            {
                Destroy(this.gameObject);
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(HitTukouninnPrefab, this.transform.position, HitTukouninnPrefab.transform.rotation);
        Destroy(this.gameObject);
    }
}
