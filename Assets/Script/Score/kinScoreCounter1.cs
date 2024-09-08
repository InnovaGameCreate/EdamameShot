using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kinscorecounter : MonoBehaviour
{
    [SerializeField] private int kinscore;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void ScoreUp()
    {
        //‹à“¤‚ªâÄ‚É“ü‚Á‚½‚Æ‚«‚Ìƒƒ\ƒbƒh
        kinscore = kinscore + 5;
    }
    // Start is called before the first frame update
    public int GetScore()
    {
        return kinscore;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
