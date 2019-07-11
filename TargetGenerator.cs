using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGenerator : MonoBehaviour
{
    public GameObject targetFire;
    public GameObject targetIce;

    float span = 3.0f;
    float delta = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        float distance;
        if(this.delta > this.span){
            this.delta = 0;
            GameObject target;
            int randomize = Random.Range(0, 2);
            if(randomize == 0){
                target = Instantiate<GameObject>(targetFire);
            } else {
                target = Instantiate<GameObject>(targetIce);
            }
            float x,z;
            float y = Random.Range(0, 6.0f);
            do
            {
                x = Random.Range(-6.0f*Mathf.Sqrt(2.0f), 6.0f*Mathf.Sqrt(2.0f));
                z = Random.Range(-6.0f*Mathf.Sqrt(2.0f), 6.0f*Mathf.Sqrt(2.0f));
                distance = Mathf.Sqrt(x*x+z*z);
            } while (distance <= 6.0f || 6.0f*Mathf.Sqrt(2.0f) >= distance);
            target.transform.position = new Vector3(x, y, z);
        }
    }
}
