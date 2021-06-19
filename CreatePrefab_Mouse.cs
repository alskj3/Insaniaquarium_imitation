using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePrefab_Mouse : MonoBehaviour
{
    public GameObject newPrefeb; //만드는 프리팹

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //마우스 클릭
        {
            //터치한 위치를 카메라 안에서의 위치로 변환
            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition + Camera.main.transform.forward);
            pos.z = -5; //앞쪽에 표시
            GameObject newGameObject = Instantiate(newPrefeb) as GameObject; //프리팹 생성
            newGameObject.transform.position = pos; //그 위치로 이동
        }
    }
}
