using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TukouninnMaker : MonoBehaviour
{
    [SerializeField] private GameObject TukouninnPrefab;
    [SerializeField] private float makeTime;�@//�����p�x�̎w��
    private float waitTime;
    [SerializeField] private float sponeX;
    [SerializeField] private float sponeZ;
    [SerializeField] private float Timerange; //makeTime-Timerange����makeTime+Timerange �b�Ń����_���ɐ��������
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
            Instantiate(TukouninnPrefab, new Vector3(sponeX, 0, sponeZ), TukouninnPrefab.transform.rotation);
            waitTime = Random.Range(-1*Timerange,Timerange);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
            Debug.Log("Hit");
            Destroy(this.gameObject);
    }
}
