using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyScript : MonoBehaviour
{
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*private void OnCollisionEnter2D(Collision2D newParent)
    {
        if (newParent.collider.tag == "Head")
        {
            rb.transform.parent = newParent.transform.parent;
            rb.isKinematic = false;
        }
    }*/
}
