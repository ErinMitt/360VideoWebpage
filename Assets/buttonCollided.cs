using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class buttonCollided : MonoBehaviour
{
    public Collider m_ObjectCollider;
    public GameObject sphere;
    bool exited = true;



    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("dollided");
        exited = false;

    }
    private void OnTriggerExit(Collider other)
    {
        exited = true;
    }
    public void isColliding()
    {
        Debug.Log("hi");
        if (exited == false)
        {
            Debug.Log("exited is false");
            sphere.GetComponent<videoChange>().ButtonForward();
        }
    }
}