using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backCollided : MonoBehaviour
{
    public Collider m_ObjectCollider;
    public GameObject sphere;
    bool exited = true;


    private void OnTriggerEnter(Collider other)
    {
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
            sphere.GetComponent<videoChange>().ButtonBackward();
        }
    }
}

