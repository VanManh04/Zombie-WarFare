using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasingBullet : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] Vector3 force;

    private void OnValidate()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnInit()
    {
        AddForceCasing();
    }

    private void AddForceCasing()
    {
        rb.AddForce(force);
    }

    public void OnDesPawn()
    {
        //Destroy(gameObject);
    }

    void Start()
    {
        rb.AddForce(force);
    }

    void Update()
    {
        
    }
}
