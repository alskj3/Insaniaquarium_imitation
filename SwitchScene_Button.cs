using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //씬전환

public class SwitchScene_Button : MonoBehaviour
{
    public string sceneName; //전환할 씬 이름

    public void ChangeScene() //클릭하면
    {
        SceneManager.LoadScene(sceneName); //씬 전환
    }
}
