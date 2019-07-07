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
    public float shootSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        OnBoard();
        ShootFire();
        ShootIce();

    }

    void OnBoard(){
        if(OVRInput.GetDown(OVRInput.Button.One)){//Aボタンを押したときにboardの表示/非表示を切り替え
            if(Board.activeInHierarchy)Board.SetActive(false);
            else Board.SetActive(true);
        }
        
    }

    void ShootFire(){
        if(OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) > 0.999){
            GameObject FireInstance = Instantiate<GameObject>(Fire);
            FireInstance.transform.rotation = RShootPosition.transform.rotation;//オブジェクトと発射点の回転をあわせている
            FireInstance.transform.Rotate(0, -90f, 0);//オブジェクトの回転を先端が発射方向に向くように調整している
            FireInstance.transform.position = RShootPosition.transform.position;//オブジェクトと発射点の座標を合わせている
            FireInstance.GetComponent<Rigidbody> ().AddForce(RShootPosition.transform.forward * shootSpeed);
            Destroy(FireInstance, 1.0f);
        }
    }

    void ShootIce(){
        if(OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) > 0.999){
            GameObject IceInstance = Instantiate<GameObject>(Ice);
            IceInstance.transform.rotation = LShootPosition.transform.rotation;//オブジェクトと発射点の回転をあわせている
            IceInstance.transform.Rotate(0, -90f, 0);//オブジェクトの回転を先端が発射方向に向くように調整している
            IceInstance.transform.position = LShootPosition.transform.position;//オブジェクトと発射点の座標を合わせている
            IceInstance.GetComponent<Rigidbody> ().AddForce(LShootPosition.transform.forward * shootSpeed);
            Destroy(IceInstance, 1.0f);
        }
    }
}
