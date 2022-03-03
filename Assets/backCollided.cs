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
        Debug.Log("back collided");
        sphere.GetComponent<videoChange>().ButtonBackward();
        exited = false;
        StartCoroutine(routine());
        exited = true;
    }
    IEnumerator routine()
    {

        yield return new WaitForSeconds(1f);

    }   // Start is called before the first frame update
        void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

