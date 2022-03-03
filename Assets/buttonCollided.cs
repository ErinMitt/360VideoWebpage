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



    private void OnTriggerEnter(Collider other){
        Debug.Log("dollided");
        sphere.GetComponent<videoChange>().ButtonForward();
        exited = false;
        StartCoroutine(routine());
        exited = true;
    }
    IEnumerator routine()
    {
      
            yield return new WaitForSeconds(1f);
       
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
