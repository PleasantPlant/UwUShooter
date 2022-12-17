using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwOshooter : MonoBehaviour
{

    [SerializeField] private Vector2 velocity = new Vector2(1.75f, 1.1f);
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private float explosionTime = 1f;
    [SerializeField] private float speed = 2f;
    private string last;

    internal void DestroySelf()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
    internal void CreateExplosion(Vector2 position)
    {
        var explosion = Instantiate(explosionPrefab, position, Quaternion.Euler(0f,0f,Random.Range(-180f,180f)));
        Destroy(explosion, explosionTime);
    }
    // Start is called before the first frame update
    void Awake()
    {

        transform.position = new Vector3(20.0f, 9.0f, 0.0f); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(velocity * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        //this is both destruction and movement logic.
        switch(col.gameObject.tag, last)
        {
            case ("missile", _):
                CreateExplosion(transform.position);
                DestroySelf();
                break;
            case ("bottomBorder", _):
                velocity.y = 0f;
                velocity.x = -speed;
                last = "bottom";
                speed += 1;
                break;
            case ("topBorder", _):
                velocity.y = 0f;
                velocity.x = -speed;
                last = "top";
                speed += 1;
                break;
            case ("frontBorder", "top"):
                velocity.x = 0f;
                velocity.y = -speed;
                speed += 1;
                break;
            case ("frontBorder", "bottom"):
                velocity.x = 0f;
                velocity.y = speed;
                speed += 1;
                break;
            

        }

    }
    private void onTriggerEnter2D(Collider2D col)
    {
        
    }
}
