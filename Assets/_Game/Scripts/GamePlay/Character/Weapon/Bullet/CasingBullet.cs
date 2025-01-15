using UnityEngine;

public class CasingBullet : GameUnit
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
        Invoke(nameof(OnDesPawn), 2f);
    }

    private void AddForceCasing()
    {
        rb.AddForce(force);
    }

    public void OnDesPawn()
    {
        //Destroy(gameObject);
        SimplePool.Despawn(this);
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
