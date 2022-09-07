using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Domino : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX;
        }
    }
}
