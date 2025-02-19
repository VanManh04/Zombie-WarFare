using System.Collections;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    [SerializeField] private Hero_GunCombat hero_GunCombat;
    [SerializeField] protected Animator animator;
    [SerializeField] private float speedAnim = 1;
    protected string currentAnimName;

    [Header("Shoot")]
    [SerializeField] protected Vector3 posTarget;
    [SerializeField] protected float speedShootOneBullet;
    [SerializeField] protected float timeInstanceCasingBulletPrefab;
    [SerializeField] protected int amount;
    [SerializeField] protected int damage;
    private int amountDefault;

    [Header("Bullet")]
    [SerializeField] private Transform projecttilepoint;
    [SerializeField] private Projectile projectilePrefab;

    [Header("Casing Bullet")]
    [SerializeField] private Transform casingBulletPoint;
    [SerializeField] private CasingBullet casingBulletPrefab;

    protected virtual void Start()
    {
        animator.speed = speedAnim;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public void SetUpAmountAnDamage(int _amount, int _damage)
    {
        amountDefault = _amount;
        amount = _amount;
        damage = _damage;
    }
    public void SetUpTarget(Vector3 _posTarget)
    {
        posTarget = _posTarget;
    }

    public virtual void Reload()
    {
        amount = amountDefault;
    }

    public virtual void Shoot(float _timeDelay)
    {
        StartCoroutine(IEInstanceProjcetile(_timeDelay));
    }

    protected void ChangeAnim(string _name)
    {
        if (currentAnimName != _name)
        {
            animator.ResetTrigger(currentAnimName);
            currentAnimName = _name;
            animator.SetTrigger(currentAnimName);
        }
    }

    private IEnumerator IEInstanceProjcetile(float _timeDelay)
    {
        yield return new WaitForSeconds(_timeDelay);
        for (int i = 0; i < amountDefault; i++)
        {
            amount--;
            if (hero_GunCombat.ZombieTarget != null)
            {
                //Projectile projectile = Instantiate(projectilePrefab, projecttilepoint.position, projecttilepoint.rotation);
                Projectile projectile = SimplePool.Spawn<Projectile>(PoolType.Projectile, projecttilepoint.position, projecttilepoint.rotation);
                if (projectile == null)
                {
                    Debug.LogError("⚠️ Spawn Projectile Fall.");
                    amount = -1;
                    yield break;
                }
                projectile.OnInit(posTarget, damage);

                yield return new WaitForSeconds(timeInstanceCasingBulletPrefab);

                // spawn catsing bullet
                //CasingBullet casingBullet = Instantiate(casingBulletPrefab, casingBulletPoint.position, Quaternion.identity);
                CasingBullet casingBullet = SimplePool.Spawn<CasingBullet>(PoolType.CasingBullet, casingBulletPoint.position, Quaternion.identity);
                casingBullet.OnInit();

                yield return new WaitForSeconds(speedShootOneBullet - timeInstanceCasingBulletPrefab);
            }
            else
            {
                amount = -1;
                yield break;
            }

        }
    }

    /// <summary>
    /// Het amount -> = true
    /// </summary>
    /// <returns></returns>
    public bool OutOfAmmo()
    {
        if (amount <= 0)
            return true;
        else
            return false;
    }
}
