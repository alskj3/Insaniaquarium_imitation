using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Mouse : MonoBehaviour
{
    private void OnMouseDown()
    {
        //GameManager gm = ;
        //gm.money += 5;
        Destroy(this.gameObject);
    }
}
