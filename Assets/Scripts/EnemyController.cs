using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //Gizmos components
    public Transform positionTrigger=null;

    //Caracteristicas
    public int damageValue = 10;

    public float currentSpeed = 1f;

    protected Rigidbody2D rg2d;

    protected Animator animatorController;
    protected Collider2D collider;

    void Awake()
    {
        rg2d = GetComponent<Rigidbody2D>();
        animatorController = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public  virtual void FixedUpdate()
    {

    }

    void  OnCollisionEnter2D(Collision2D otherCollider)
    {
        /*if ( otherCollider.gameObject.tag == "Player")
        {
            //otherCollider.GetComponent<PlayerContoller>().GetDamage();
            Destroy(this.gameObject);
        }

        else if(otherCollider.gameObject.tag == "Vehicle")
        {
            otherCollider.transform.GetComponent<Vehicle>().GetDamage(damageValue);
            Destroy(this.gameObject);
        }*/
    }


    public void SetAwakeEnemy( bool value)
    {
        awakeEnemy = value;
        animatorController.SetTrigger("Awake");
    }

    public bool GetAwakeEnemy()
    {
        return awakeEnemy;
    }

    public bool GetIsAlive()
    {
        return isAlive;
    }

    public void DieEnemy()
    {
        isAlive = false;
    }

    public void SetTarget(Transform newTarget){
        target = newTarget;
    }

    /// //////////////////////////////////////////

    void OnDrawGizmosSelected()
    {
        if (positionTrigger != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(this.transform.position, positionTrigger.position);
            Gizmos.DrawSphere(positionTrigger.position, 0.15f);
        }
    }

    private bool awakeEnemy = false;
    private bool isAlive = true;
    protected Vector3 directionToWatch = Vector3.zero;
    protected Transform target = null;
}
