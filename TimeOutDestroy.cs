using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOutDestroy : MonoBehaviour
{
    public float limitSec = 3;
    
    void Start()
    {
        Destroy(this.gameObject, limitSec);
    }
}
