using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    public GameObject UIManager;
    public GameObject TargetGenerator;

    public void OnClick(){
        UIManager.GetComponent<UIManager>().RestartGame();//UIManager内のRestartGameを動かす
        TargetGenerator.SetActive(true);
    }
}
