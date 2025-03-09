using UnityEngine;

public class Projectile : GameUnit
{
    //TODO: nen check theo khoang cach bay tung farme, ve tia raycat tu diem dau toi diem tiep de check xem trung khong
    [SerializeField] private float speedBullet;
    [SerializeField] private int damage;
    private Vector3 posTarget;
    Vector3 direction;
    float timer, timeLeft;
    //[Header("Raycat")]
    //[SerializeField] float distanceRaycat;
    //[SerializeField] LayerMask layerZombie;

    public void OnInit(Vector3 _posTarget, int _damage)
    {
        //StartCoroutine khong nen dung cho nhung thang Active deActive qua nhieu, bi sai lech thoi gian nhieu
        //khong an toan nen su dung update
        //Invoke(nameof(OnDesPawn), 5f); //chay ngam ngay ca khi gameObject ko active
        timeLeft = 5f;
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
        //Destroy(gameObject);
        timeLeft = 5f;
        SimplePool.Despawn(this);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer > timeLeft)
            OnDesPawn();

        transform.position += direction * speedBullet * Time.deltaTime;
    }

    void RotateTowardsDirection(Vector3 direction)
    {
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        transform.rotation = targetRotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.tag == TAG.ZOMBIE)
        //{
        //    other.GetComponent<Zombie>()?.OnHit(damage);
        //    OnDesPawn();
        //}

        if (other.CompareTag(TAG.ZOMBIE))
        {
            //cache getComponent
            //other.GetComponent<Zombie>()?.OnHit(damage);
            Cache.GenCollectZombie(other)?.OnHit(damage);
            OnDesPawn();
        }else
            OnDesPawn();
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
