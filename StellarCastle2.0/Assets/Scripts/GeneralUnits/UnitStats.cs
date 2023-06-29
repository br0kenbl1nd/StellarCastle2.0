using UnityEngine;

public class UnitStats : MonoBehaviour
{
    [Header("Health")]
    [SerializeField]
    private float startHealth;
    public float StartHealth
    {
        get { return startHealth; }
    }
    private float health;
    public float Health
    {
        get { return health; }
        set { health = value; }
    }

    [Header("Attack Range")]
    [SerializeField]
    private float startAttackRange;
    public float StartAttackRange
    {
        get { return attackRange; }
    }
    private float attackRange;
    public float AttackRange
    {
        get { return attackRange; }
        private set { attackRange = value; }
    }

    [Header("Target seeking range")]
    [SerializeField]
    private float targetSeekingRange;
    public float TargetSeekingRange
    {
        get { return targetSeekingRange; }
        private set { targetSeekingRange = value; }
    }

    [Header("Movement Speed")]
    [SerializeField]
    private float startSpeed;
    public float StartSpeed
    {
        get { return startSpeed; }
    }
    private float speed;
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    [Header("Damage")]
    [SerializeField]
    private float startDamage;
    public float StartDamage
    {
        get { return startDamage; }
    }
    private float damage;
    public float Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    [Header("Attack speed")]
    [SerializeField]
    private float startAttackSpeed;
    public float StartAttackSpeed
    {
        get { return startAttackSpeed; }
    }
    private float attackSpeed;
    public float AttackSpeed
    {
        get { return attackSpeed; }
        set { attackSpeed = value; }
    }

    [Header("Bullet")]
    [SerializeField]
    private GameObject bullet;
    public GameObject Bullet
    {
        get { return bullet; }
        set { bullet = value; }
    }

    [Header("Evasion - enter percent as number")]
    [SerializeField]
    private float startEvasion;
    public float StartEvasion
    {
        get { return startEvasion; }
    }
    private float evasion;
    public float Evasion
    {
        get { return evasion; }
        set { evasion = value; }
    }

    private void Start()
    {
        health = startHealth;
        speed = startSpeed;
        attackSpeed = startAttackSpeed;
        attackRange = startAttackRange;
        damage = startDamage;
        evasion = startEvasion;
        
    } //start

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, targetSeekingRange);
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, startAttackRange);
        Gizmos.color = Color.green;
    }

} //class
