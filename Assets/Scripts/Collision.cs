using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    bool hasPackage = false;

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Ouch!");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "package" && !hasPackage)
        {
            Debug.Log("Picked up a package");
            hasPackage = true;
            Destroy(col.gameObject, 0.1f);
        }
        else if (col.gameObject.tag == "customer" && hasPackage)
        {
            Debug.Log("Delivered a package");
            hasPackage = false;
            Destroy(col.gameObject, 0.1f);
        }
    }

    void Awake()
    {
        
    }

    // Update is called once per frame
}
