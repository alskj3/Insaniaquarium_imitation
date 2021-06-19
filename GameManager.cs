using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //씬전환

public class GameManager : MonoBehaviour
{
    //public GameObject Coin;
    //public int money = 0;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        GameObject target = GameObject.FindWithTag("fish"); //fish 태그를 찾아
        if(target == null) //물고기가 없으면
        {
            //게임오버 씬으로 전환
            SceneManager.LoadScene("GameOver"); //씬 전환
        }
    }

 
}
