using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backCollided : MonoBehaviour
{
    public Collider m_ObjectCollider;
    public GameObject sphere;
    bool exited = true;
   public AudioSource buttonClick;

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
        if (exited == false)
        {
            buttonClick.Play();
            sphere.GetComponent<videoChange>().ButtonBackward();
        }
    }
}

