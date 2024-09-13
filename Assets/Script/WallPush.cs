using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPush : MonoBehaviour
{
    [SerializeField] private float WallPushSpeed;
    [SerializeField] private float WallPushSpan;
    private float WaitTime=0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(WallPushSpan > WaitTime )
        {
            WaitTime += Time.deltaTime;
            transform.Translate(new Vector3(0, 0, WallPushSpeed) * Time.deltaTime); 
        }
        else
        {
            WaitTime = 0;
            WallPushSpeed *= -1;
        }
    }
}
