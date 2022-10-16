using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAwakeEnemy : MonoBehaviour
{
    private bool isAwakeEnemy = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        isAwakeEnemy = transform.parent.GetComponent<EnemyController>().GetAwakeEnemy();
        if (!isAwakeEnemy && 
            (other.gameObject.tag == "Vehicle" || other.gameObject.tag == "Player"))
        {
            this.transform.GetComponent<Collider2D>().enabled = false;
            transform.parent.GetComponent<EnemyController>().SetTarget(other.transform);
            transform.parent.GetComponent<EnemyController>().SetAwakeEnemy(true);
        }
    }
}
