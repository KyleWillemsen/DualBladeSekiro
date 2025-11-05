using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackCollisionCheck : MonoBehaviour
{
    public bool left;
    public bool right;
    private string handType;

    private void Start()
    {
        if (left)
        {
            handType = "left";
        }
        else if(right)
        {
            handType = "right";
        }
        else
        {
            Debug.Log("No Hand Orientation selected on " + gameObject.name);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            other.GetComponent<PlayerStats>().TakeDamage(GetComponentInParent<TestDummy>().damage, handType);
        }
    }
}
