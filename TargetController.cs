using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public float vanishingSpan = 5.0f;
    

    // Update is called once per frame
    void Update()
    {
        //TargetにFireかIceがぶつかったときの処理を書く
        
            Destroy(gameObject, vanishingSpan);
    }
}
