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
    public AudioSource buttonClick; 


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collided");
        exited = false;

    }
    private void OnTriggerExit(Collider other)
    {
        exited = true;
    }
    public void isColliding()
    {

        if (exited == false)
        {
            buttonClick.Play();
            sphere.GetComponent<videoChange>().ButtonForward();
        }
    }
}