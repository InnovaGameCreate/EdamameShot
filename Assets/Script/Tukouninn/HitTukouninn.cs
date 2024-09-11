using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTukouninn : MonoBehaviour
{
    [SerializeField] private float HitTukouninnSpeed;
    [SerializeField] private float HitTukouninnLifeTime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        {
            transform.Translate(new Vector3(0, -2 * HitTukouninnSpeed, HitTukouninnSpeed) * Time.deltaTime);

            HitTukouninnLifeTime = HitTukouninnLifeTime - Time.deltaTime;
            if (HitTukouninnLifeTime < 0)
            {
                Destroy(this.gameObject);
            }

        }

    }
}
