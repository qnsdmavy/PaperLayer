using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falling : MonoBehaviour
{
    Rigidbody rigid; 

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.constraints = RigidbodyConstraints.FreezeAll;
    }

    public void fall()
    {
        rigid.constraints = RigidbodyConstraints.None;
    }
}
