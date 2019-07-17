using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public GameObject UIManager;
    public GameObject TargetGenerator;

    public void OnClick(){
        UIManager.GetComponent<UIManager>().StartCountDown();//UIManager内のStartCoutDownを動かす
        TargetGenerator.SetActive(true);
    }
}
