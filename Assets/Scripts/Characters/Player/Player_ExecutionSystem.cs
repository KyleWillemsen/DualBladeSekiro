using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_ExecutionSystem : MonoBehaviour
{
    //public static Player_ExecutionSystem instance;
    //
    //[Header("Execution")]
    //[SerializeField] private float executeDamage;
    //public float executionAngle;
    //public bool canExecute;
    //public bool isExecuting;
    //
    //private void Awake()
    //{
    //    if (instance != null)
    //    {
    //        Destroy(gameObject);
    //        return;
    //    }
    //    instance = this;
    //    //DontDestroyOnLoad(instance);
    //}
    //private void Update()
    //{
    //    ExecutionDetection();
    //}
    //private void ExecutionDetection()
    //{
    //    Collider[] rangeChecks = Physics.OverlapSphere(transform.position, PlayerMeleeCombat.instance.attackDistance, PlayerMeleeCombat.instance.enemyLayer);
    //
    //    if (rangeChecks.Length != 0)
    //    {
    //        Transform target = rangeChecks[0].transform;
    //        Vector3 directionToTarget = (target.transform.position - transform.position).normalized;
    //
    //        if (Vector3.Angle(transform.forward, directionToTarget) < PlayerMeleeCombat.instance.angle / 2)
    //        {
    //            float distanceToTarget = Vector3.Distance(transform.position, target.position);
    //
    //            if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, PlayerMeleeCombat.instance.obstructions))
    //            {
    //                PlayerMeleeCombat.instance.enemyDetected = true;
    //                PlayerMeleeCombat.instance.detectedEnemyTransform = target;
    //            }
    //        }
    //        else
    //        {
    //            PlayerMeleeCombat.instance.detectedEnemyTransform = null;
    //            PlayerMeleeCombat.instance.enemyDetected = false;
    //        }
    //    }
    //}
    //
    //public void Execute()
    //{
    //    Camera_FOV.instance.ChangeFOV(4, 17f);
    //    transform.LookAt(PlayerMeleeCombat.instance.detectedEnemyTransform);
    //    
    //    isExecuting = true;
    //    canExecute = false;
    //    
    //    PlayerMovement.instance.anim.SetTrigger("Execute");
    //    PlayerMovement.instance.PlayerIsFreeToMove(false);
    //    PlayerMeleeCombat.instance.detectedEnemyTransform.gameObject.GetComponent<Damageable>().beingExecuted = true;
    //    PlayerMeleeCombat.instance.detectedEnemyTransform.gameObject.GetComponent<Damageable>().Executed();
    //    //TwinStickMovement.instance.ForceMovePosition();
    //}
    //
    //public void ExecuteStab()
    //{
    //    PlayerMeleeCombat.instance.detectedEnemyTransform.gameObject.GetComponent<Damageable>().TakeDamage(executeDamage, transform.position);
    //    Camera_Shake.instance.StartShake(0.225f, 2);
    //}
    //
    //public void ResetExecution()
    //{
    //    //PlayerMovement.instance.canm
    //    isExecuting = false;
    //    canExecute = true;
    //    PlayerMovement.instance.PlayerIsFreeToMove(true);
    //    Camera_FOV.instance.ChangeFOV(5, 17f);
    //}
}
