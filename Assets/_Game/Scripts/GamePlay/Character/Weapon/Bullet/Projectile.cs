using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speedBullet;
    [SerializeField] private int damage;
    private Vector3 posTarget;
    Vector3 direction;

    //[Header("Raycat")]
    //[SerializeField] float distanceRaycat;
    //[SerializeField] LayerMask layerZombie;

    public void OnInit(Vector3 _posTarget, int _damage)
    {
        damage = _damage;

        posTarget = GetRandomPointAroundTarget(_posTarget, .4f);
        if (posTarget == null)
        {
            gameObject.SetActive(false);
            return;
        }
        direction = (posTarget - transform.position).normalized;
        RotateTowardsDirection(direction);
    }

    public void OnDesPawn()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        transform.position += direction * speedBullet * Time.deltaTime;
    }

    void RotateTowardsDirection(Vector3 direction)
    {
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        transform.rotation = targetRotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == TAG.ZOMBIE)
        {
            other.GetComponent<Zombie>()?.OnHit(damage);
            OnDesPawn();
        }
    }
    public Vector3 GetRandomPointAroundTarget(Vector3 posRandom, float _radius)
    {
        Vector3 randomOffset = Random.insideUnitSphere * _radius;

        Vector3 randomPoint = posRandom + randomOffset;

        return randomPoint;
    }
    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.red;
        //Gizmos.DrawLine(transform.position, transform.position + Vector3.forward * distanceRaycat);
    }
}
