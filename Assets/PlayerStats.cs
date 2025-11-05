using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float maxHealth;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage, string attackedSide)
    {
        //Is there a cleaner, less hackier way to do this
        if(GetComponent<PlayerMeleeCombat>().parriedLeft && attackedSide == "right" ||
                GetComponent<PlayerMeleeCombat>().parriedRight && attackedSide == "left")
        {
            //Create an instance for better refernce?
            GetComponent<PlayerMeleeCombat>().ParryJuice();
            Debug.Log("Parried the " + attackedSide);
            return;
        }
        Debug.Log("Got attacked on the " + attackedSide);
        currentHealth -= damage;
        if (currentHealth <= 0) Death();
    }

    private void Death()
    {
        GameManager.instance.RestartScene();
    }
}
