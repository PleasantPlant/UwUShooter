using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UwUmissile : MonoBehaviour
{   

    [SerializeField] float speed = 200f;
    [SerializeField] float bulletlife = 5f;
    // Start is called before the first frame update

    internal void DestroySelf()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    private void Awake()
    {
        Invoke("DestroySelf", bulletlife);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed*Time.deltaTime * Vector2.right);   
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Collision detected!");
        if(col.gameObject.tag == "enemy")
        {
            DestroySelf();
        }
        else if(col.gameObject.tag == "obstacle")
        {
            DestroySelf();
        }   
    }
}
