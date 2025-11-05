using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [Header("References")]
    //private Healthbar healthbar;
    //private Animator anim;
    //[HideInInspector] public Scene sceneToLoad;
    //[SerializeField] private GameObject executionPrompt;
    //public bool isTestDummy;
    //public bool beingExecuted;
    //[SerializeField] private GameObject slashVFX;
    //[SerializeField] private LayerMask knockableColliders;

    [Header("Stats")]
    [SerializeField] private float maxHealth;
    public float currentHealth;
    //[SerializeField] private float damageDealtWhileKnocked;

    //[Header("Stagger")]
    //[SerializeField] private float maxStaggerPoints;
    //public float currentStagger;
    //public bool backStabbed;
    //public bool knockedBack;

    //[Header("Souls")]
    //[SerializeField] private GameObject soul;
    //[SerializeField] private int amountOfSoulsDroppedEnemy;
    //[SerializeField] private float randomPosX;
    //[SerializeField] private float randomPosZ;




    private void Start()
    {
        //healthbar = GetComponent<Healthbar>();
        //anim = GetComponent<Animator>();

        currentHealth = maxHealth;
        //healthbar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        //CollisionCheck();
    }

    public void TakeDamage(float damage, Vector3 hitPos)
    {
        //anim.SetTrigger("Hit");
        //Camera_Shake.instance.StartShake(0.2f, 0.1f);
       // Instantiate(slashVFX, transform.position, Quaternion.identity);

        currentHealth -= damage;

        //if (backStabbed)
        //{
        //    StartCoroutine(GetComponent<ColourChanger>().HitEffectBackstab(0.15f));
        //}
        //else
        //{
        //    StartCoroutine(GetComponent<ColourChanger>().HitEffect(0.375f));
        //}


        if (currentHealth <= 0)
        {
            Death();
        }

        //backStabbed = false;
    }

    //public void StartKnockback(float knockDistance, float knockTime, Vector3 hitPos)
    //{
    //    IEnumerator knockbackCoroutine = Knockback(knockDistance, knockTime, hitPos);
    //    if (knockbackCoroutine != null)
    //    {
    //        StopCoroutine(knockbackCoroutine);
    //    }
    //    StartCoroutine(knockbackCoroutine);
    //    //StartCoroutine(knockbackCoroutine);
    //}

    //private void StopKnockBack()
    //{
    //    IEnumerator knockbackCoroutine = StartCoroutine(Knockback(0, 0, transform.position);
    //}

   // private IEnumerator Knockback(float knockDistance, float knockTime, Vector3 hitPos)
   // {
   //     if (gameObject.GetComponentInParent<EnemyStateMachine>()) GetComponentInParent<EnemyStateMachine>().IsLaunched = true;
   //     float timeElapsed = 0;
   //     Vector3 moveDirection = (transform.position - hitPos).normalized;
   //     Vector3 targetLocation = transform.position + moveDirection * knockDistance;
   //     while (timeElapsed < knockTime)
   //     {
   //         //GetComponentInParent<Rigidbody>().AddForce(-moveDirection * knockForce, ForceMode.Impulse);
   //         transform.position = Vector3.Lerp(transform.position, targetLocation, timeElapsed / knockTime);
   //         timeElapsed += Time.unscaledDeltaTime;
   //         knockedBack = true;
   //         yield return null;
   //     }
   //     knockedBack = false;
   //     timeElapsed = 0;
   //     if (gameObject.GetComponentInParent<EnemyStateMachine>()) GetComponentInParent<EnemyStateMachine>().IsLaunched = false;
   // }

   // public void Executed()
   // {
   //     if (!isTestDummy)
   //     {
   //         GetComponent<EnemyAI_Base>().canMove = false;
   //         GetComponent<EnemyAI_Base>().canLook = false;
   //         GetComponent<EnemyAI_Base>().navAgent.SetDestination(transform.position);
   //         GetComponent<EnemyAI_Base>().anim.SetTrigger("Executed");
   //     }
   // }

   // public void IncreaseCurrentStagger(float amount)
   // {
   //     currentStagger += amount;
   //
   //     if (currentStagger >= maxStaggerPoints)
   //     {
   //         currentStagger = maxStaggerPoints;
   //         GetComponent<EnemyStateMachine>().IsStaggered = true;
   //     }
   // }

    //public void IncreaseCurrentStagger()
    //{
    //    currentStagger += amount;
    //
    //    if (currentStagger >= maxStaggerPoints)
    //    {
    //        currentStagger = maxStaggerPoints;
    //        StartCoroutine(GetComponent<EnemyAI_Base>().Stunned());
    //    }
    //}

    //public void ResetStaggerPoints()
    //{
    //    currentStagger = 0;
    //}

    private void Death()
    {
        //if (!beingExecuted)
        //{
        //    //DropSouls();
            Destroy(gameObject);
        //}
        //else
        //{
        //    Destroy(gameObject, 0.75f);
        //    Invoke("DropSouls", 0.75f);
        //}
        //if (LockOnSystem.instance.isActive)
        //{
        //    LockOnSystem.instance.EnemyDeath();
        //}
    }

    //private void DropSouls()
    //{
    //    for (int i = 0; i < amountOfSoulsDroppedEnemy; i++)
    //    {
    //        Instantiate(soul, transform.position + new Vector3(Random.Range(0, 3), 0, Random.Range(0, 3)), Quaternion.identity);
    //    }
    //}



   // private IEnumerator ResetHealth()
   // {
   //     yield return new WaitForSeconds(1);
   //     currentHealth = maxHealth;
   // }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (!knockedBack) return;
    //
    //    //Enemy Layer
    //    if (other.gameObject.layer == 7)
    //    {
    //        //other.GetComponentInParent<EnemyAI_Base>().navAgent.enabled = false;
    //        other.GetComponentInParent<Damageable>().TakeDamage(damageDealtWhileKnocked, transform.position);
    //        other.GetComponentInParent<Damageable>().StartCoroutine(other.GetComponentInParent<Damageable>().Knockback(5F, 1f, transform.position));
    //    }
    //
    //    //Environment Layer
    //    if (other.gameObject.layer == 12)
    //    {
    //        GetComponentInParent<Damageable>().TakeDamage(500, transform.position);
    //        GetComponentInParent<EnemyStateMachine>().IsStunned = true;
    //    }
    //}
    // private void CollisionCheck()
    // {
    //     if (!knockedBack) return;
    //
    //     Collider[] collider = Physics.OverlapSphere(transform.position, 1.5f, knockableColliders);
    //     foreach (Collider c in collider)
    //     {
    //         //Enemy Layer
    //         if (c.gameObject.name != this.gameObject.name)
    //         {
    //                         if (c.GetComponent<Damageable>())
    //         {
    //             //other.GetComponentInParent<EnemyAI_Base>().navAgent.enabled = false;
    //             c.GetComponent<Damageable>().TakeDamage(damageDealtWhileKnocked, transform.position);
    //             StartCoroutine(c.GetComponentInParent<Damageable>().Knockback(10F, 0.35f, transform.position));
    //         }
    //         }
    //
    //
    //         //Environment Layer
    //         if (c.gameObject.layer == 12)
    //         {
    //             GetComponentInParent<Damageable>().TakeDamage(500, transform.position);
    //             GetComponentInParent<EnemyStateMachine>().IsStunned = true;
    //         }
    //         GetComponent<EnemyStateMachine>().IsStunned = true;
    //         TakeDamage(35, transform.position);
    //     }
    // }

}
