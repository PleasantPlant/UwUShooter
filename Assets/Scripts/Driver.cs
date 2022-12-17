using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] private Transform muzzle;
    [SerializeField] private float coolDownTime = 0.625f;
    [SerializeField] private UwUmissile uwumissile;
    //[SerializeField] private AudioClip shooting;
    private float UwUshootTimer;


    
    internal void DestroySelf()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
        #if UNITY_STANDALONE
            Application.Quit();
        #endif
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveAmount = Input.GetAxisRaw("Vertical") * Time.deltaTime;

        UwUshootTimer += Time.deltaTime;

        transform.Translate(0,moveAmount * moveSpeed,0, Space.World);
        
        if (UwUshootTimer > coolDownTime && Input.GetKey(KeyCode.Space))
        {
            UwUshootTimer = 0f;
            GameObject.Instantiate(uwumissile, muzzle.position, Quaternion.identity);
        }
    } 

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "enemy")
        {
            DestroySelf();
        }
    }
}
