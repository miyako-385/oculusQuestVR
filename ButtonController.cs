using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject Board;
    public GameObject Fire;
    public GameObject Ice;
    public GameObject RShootPosition;
    public GameObject LShootPosition;

    GameObject[] tagObjectFire;
    GameObject[] tagObjectIce;

    public float shootSpeed = 1000f;
    public float shootInterval = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        OnBoard();
        ShootFire("Fire");
        ShootIce("Ice");

    }

    void OnBoard(){
        if(OVRInput.GetDown(OVRInput.Button.One)){//Aボタンを押したときにboardの表示/非表示を切り替え
            if(Board.activeInHierarchy)Board.SetActive(false);
            else Board.SetActive(true);
        }
        
    }

    void ShootFire(string tagname){
        tagObjectFire = GameObject.FindGameObjectsWithTag(tagname);//シーン上のtagnameタグがついたオブジェクトを数える
        if(OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) && tagObjectFire.Length == 0){
            GameObject FireInstance = Instantiate<GameObject>(Fire);
            FireInstance.transform.rotation = RShootPosition.transform.rotation;//オブジェクトと発射点の回転をあわせている
            FireInstance.transform.Rotate(0, -90f, 0);//オブジェクトの回転を先端が発射方向に向くように調整している
            FireInstance.transform.position = RShootPosition.transform.position;//オブジェクトと発射点の座標を合わせている
            FireInstance.GetComponent<Rigidbody> ().AddForce(RShootPosition.transform.forward * shootSpeed);
            Destroy(FireInstance, shootInterval);
        }
    }

    void ShootIce(string tagname){
        tagObjectIce = GameObject.FindGameObjectsWithTag(tagname);//シーン上のtagnameタグがついたオブジェクトを数える
        if(OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) && tagObjectIce.Length == 0){
            GameObject IceInstance = Instantiate<GameObject>(Ice);
            IceInstance.transform.rotation = LShootPosition.transform.rotation;//オブジェクトと発射点の回転をあわせている
            IceInstance.transform.Rotate(0, -90f, 0);//オブジェクトの回転を先端が発射方向に向くように調整している
            IceInstance.transform.position = LShootPosition.transform.position;//オブジェクトと発射点の座標を合わせている
            IceInstance.GetComponent<Rigidbody> ().AddForce(LShootPosition.transform.forward * shootSpeed);
            Destroy(IceInstance, shootInterval);
        }
    }
}
