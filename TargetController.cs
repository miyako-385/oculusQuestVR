using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{

    public float vanishingSpan = 5.0f;
    public AudioClip HitFireSE;
    public AudioClip HitIceSE;
    public AudioClip HitMissSE;

    AudioSource aud;
    GameObject UIManager; 

    // Start is called before the first frame update
    void Start()
    {
        this.aud = GetComponent<AudioSource>();
        this.UIManager = GameObject.Find("UIManager");
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, vanishingSpan);
    }

    void OnCollisionEnter(Collision other){
        if(other.gameObject.tag == "Fire" && gameObject.tag == "FireTarget"){
            this.UIManager.GetComponent<UIManager>().GetScore();
            AudioSource.PlayClipAtPoint(this.HitFireSE, transform.position);//ぶつかったときのSE再生
            Destroy(gameObject);
            Destroy(other.gameObject);
        } else if(other.gameObject.tag == "Ice" && gameObject.tag == "IceTarget"){
            this.UIManager.GetComponent<UIManager>().GetScore();
            AudioSource.PlayClipAtPoint(this.HitIceSE, transform.position);//ぶつかったときのSE再生
            Destroy(gameObject);
            Destroy(other.gameObject);
        } else {
            this.UIManager.GetComponent<UIManager>().GetMiss();
            this.aud.PlayOneShot(this.HitMissSE);//対応していない的にあたったときのSE再生
            return;
        }
    }
}
