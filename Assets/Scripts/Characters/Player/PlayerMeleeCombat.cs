using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeCombat : MonoBehaviour
{
    //public static PlayerMeleeCombat instance;

    //[Header("VFX")]
    //[SerializeField] GameObject slashRightVFX;
    //[SerializeField] GameObject slashLeftVFX;
    //[SerializeField] private Transform slashSpawnPoint;

    [Header("Weapon Stats")]
    public LayerMask damageableLayer;
    //public LayerMask enemyLayer;
    [SerializeField] private float baseDamage;
    [SerializeField] private float attackRadius;
    [SerializeField] private Transform damageCheckTransform;

    [Header("Combo Variables")]
    [SerializeField] private List<AttackSO> combo;
    public bool canAttack = true;
    private float lastClickedTimer;
    [SerializeField] private float lastClickedTime;
    private float lastComboEndTimer;
    private float lastComboEnd;
    [SerializeField] float endOfComboTimerReset;
    [SerializeField] float endComboTimer;
    private int comboCounter;
    public bool enemyDetected;
    private int maxCombo;

    [Header("Parry Stats")]
    public bool parriedLeft;
    public bool parriedRight;
    [SerializeField] private GameObject parryVFX;
    //[SerializeField] private GameObject parryVFX;
    public float parryStunIncrease;

    //[Header("Charged Attack")]
    //[SerializeField] private float chargedDamage;
    //[SerializeField] private float chargedAttackRadius;
    //private bool chargedAttck;
    //public bool chargedAttackUnlocked;

    //[Header("Dot")]
    //float dot;
    //Vector3 dirEnemyToPlayer;
    //public bool canApplyBackstabBonus;
    //public float backStabMultiplier;

    //[Header("Detection")]
    //public Transform detectedEnemyTransform;
    //public LayerMask obstructions;
    //public float attackDistance;
    //[Range(0, 360)]
    //public float angle;


    //private void Awake()
    //{
    //    if (instance != null)
    //    {
    //        Destroy(gameObject);
    //        return;
    //    }
    //    instance = this;
    //}

    private void Start()
    {
        maxCombo = combo.Count - 1;
    }

    private void Update()
    {
        ExitAttack();
        //DotDetection();
        PlayerRotationStability();
    }
    public void Attack()
    {
        if (!canAttack) return;
        if (Time.unscaledTime - lastComboEndTimer > lastComboEnd && comboCounter <= maxCombo)
        {
            CancelInvoke("EndCombo");

            if (Time.unscaledTime - lastClickedTimer >= lastClickedTime)
            {
                //Below not doing anything right now
                //if (enemyDetected)
                //{
                //    transform.LookAt(detectedEnemyTransform);
                //}
                baseDamage = combo[comboCounter].damage;
                StartCoroutine(SpawnDamageCollision(attackRadius, baseDamage));
                AnimatorManager.instance.anim.runtimeAnimatorController = combo[comboCounter].animatorOC;
                AnimatorManager.instance.anim.Play("Melee Attack", 0, 0);
                //AttackMovement(combo[comboCounter].attackMoveDistance);

                comboCounter++;
                lastClickedTimer = Time.unscaledTime;
            }
        }
    }

    private void AttackMovement(float distance)
    {
        //Ctx.Controller.Move(Ctx.transform.forward * distance);
    }

    //public void SpawnRightVFX()
    //{
    //    Instantiate(slashRightVFX, slashSpawnPoint.position, slashSpawnPoint.rotation);
    //}
    //public void SpawnLeftVFX()
    //{
    //    Instantiate(slashLeftVFX, slashSpawnPoint.position, slashSpawnPoint.rotation);
    //}

    public void ParryLeft()
    {
        if (parriedLeft) return;
        parriedLeft = true;
        AnimatorManager.instance.anim.SetLayerWeight(2, 1);
        AnimatorManager.instance.anim.SetTrigger("ParryLeft");
        //PlayerMovement.instance.PlayerIsFreeToMove(false);
    }

    public void ParryRight()
    {
        if (parriedRight) return;
        parriedRight = true;
        AnimatorManager.instance.anim.SetLayerWeight(1, 1);
        AnimatorManager.instance.anim.SetTrigger("ParryRight");
        //PlayerMovement.instance.PlayerIsFreeToMove(false);
    }

    public void DisableParryLeft()
    {
        parriedLeft = false;
        AnimatorManager.instance.anim.SetLayerWeight(2, 0);
        //PlayerMovement.instance.PlayerIsFreeToMove(true);
    }

    public void DisableParryRight()
    {
        parriedRight = false;
        AnimatorManager.instance.anim.SetLayerWeight(1, 0);
        //PlayerMovement.instance.PlayerIsFreeToMove(true);
    }

    public void ParryJuice()
    {
        PP_Vignette.instance.StartVignette(0.25f, 0.25f, 0.2f, PP_Vignette.instance.parryColour);
        TimeController.instance.StartHitstop(0.05f, 0.2f);
        CameraShake.instance.StartShake(0.05f, 0.1f);
        //Instantiate(parryVFX, slashSpawnPoint.position, Quaternion.identity);
    }

    public IEnumerator SpawnDamageCollision(float dmgRadius, float damage)
    {
        float distance = combo[comboCounter].attackMoveDistance;
        yield return new WaitForSecondsRealtime(0.02f);
        Collider[] collider = Physics.OverlapSphere(damageCheckTransform.position, dmgRadius, damageableLayer);
        foreach (Collider c in collider)
        {
            transform.LookAt(c.transform);
            if (c.GetComponentInParent<Damageable>())
            {
                //if (canApplyBackstabBonus)
                //{
                //    damage *= backStabMultiplier;
                //    //c.GetComponentInParent<Damageable>().backStabbed = true;
                //}
                c.GetComponentInParent<Damageable>().TakeDamage(damage, transform.position);
                //c.GetComponentInParent<Damageable>().StartKnockback(distance, 0.1f, transform.position);
            }
        }
    }
    //private void DotDetection()
    //{
    //    if (detectedEnemyTransform != null)
    //    {
    //        dirEnemyToPlayer = (transform.position - detectedEnemyTransform.position).normalized;
    //        dot = Vector3.Dot(detectedEnemyTransform.forward, dirEnemyToPlayer);
    //        if (dot < Player_ExecutionSystem.instance.executionAngle && Vector3.Distance(transform.position, detectedEnemyTransform.position) < attackDistance)
    //        {
    //            canApplyBackstabBonus = true;
    //            Player_ExecutionSystem.instance.canExecute = true;
    //            if (detectedEnemyTransform.GetComponent<Damageable>().isTestDummy == false)
    //            {
    //                if (detectedEnemyTransform.gameObject.GetComponent<EnemyAI_Base>().chase == false)
    //                {
    //                    Player_ExecutionSystem.instance.canExecute = true;
    //                    //detectedEnemyTransform.gameObject.GetComponent<Damageable>().executionPrompt.SetActive(true);
    //                }
    //                else
    //                {
    //                    Player_ExecutionSystem.instance.canExecute = false;
    //                }
    //            }
    //            
    //        }
    //        else
    //        {
    //            Player_ExecutionSystem.instance.canExecute = false;
    //            canApplyBackstabBonus = false;
    //            //detectedEnemyTransform.gameObject.GetComponent<EnemyStats>().executionPrompt.SetActive(false);
    //        }
    //    }
    //    else Player_ExecutionSystem.instance.canExecute = false;
    //}

    //private IEnumerator CallMethodDelay(string method, float duration)
    //{
    //    yield return new WaitForSecondsRealtime(duration);
    //    Invoke(method, 0);
    //}

    void ExitAttack()
    {
        if (AnimatorManager.instance.anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.25f && AnimatorManager.instance.anim.GetCurrentAnimatorStateInfo(0).IsTag("Melee Attack"))
        {
            Invoke("EndCombo", endComboTimer);
        }
    }
    void EndCombo()
    {
        comboCounter = 0;
        lastComboEndTimer = Time.unscaledTime;
    }

    //public void StartChargedAttack()
    //{
    //    if (!chargedAttackUnlocked) return;
    //    PlayerMovement.instance.anim.SetTrigger("StartCharge");
    //    PlayerMovement.instance.PlayerIsFreeToMove(false);
    //    chargedAttck = true;
    //}
   
    private void PlayerRotationStability()
    {
        //Keep Players rotation.x to 0
        Vector3 eulerRotation = transform.rotation.eulerAngles;
        eulerRotation.x = 0;
        transform.rotation = Quaternion.Euler(eulerRotation);
    }

    //public void ChargedAttackImpact()
    //{
    //    StartCoroutine(SpawnDamageCollision(chargedAttackRadius, chargedDamage));
    //    Camera_Shake.instance.StartShake(0.1f, 1.25f);
    //    PlayerMovement.instance.PlayerIsFreeToMove(true);
    //}


}
