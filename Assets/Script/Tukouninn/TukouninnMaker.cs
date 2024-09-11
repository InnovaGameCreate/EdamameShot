using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TukouninnMaker : MonoBehaviour
{
    [SerializeField] private GameObject TukouninnPrefab;
    [SerializeField] private float makeTime;
    private float waitTime;
    [SerializeField] private float sponeX;
    [SerializeField] private float sponeranX;
    [SerializeField] private float sponeZ;
    private float ranX;
    private float ranZ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (waitTime < makeTime)
        {
            waitTime = waitTime + Time.deltaTime;
        }
        else
        {
            ranX = Random.Range(sponeranX * -1, sponeranX);
            Instantiate(TukouninnPrefab, new Vector3(ranX + sponeX, 0, sponeZ), TukouninnPrefab.transform.rotation);
            waitTime = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
            Debug.Log("Hit");
            Destroy(this.gameObject);
    }
}
