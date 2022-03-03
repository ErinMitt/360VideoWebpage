using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonCollided : MonoBehaviour
{
    public Collider m_ObjectCollider;
    public GameObject sphere;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("dollided");
        sphere.GetComponent<videoChange>().ButtonForward();
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
