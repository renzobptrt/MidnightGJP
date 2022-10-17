using System;
using UnityEngine;

public class interactuable_items : MonoBehaviour
{

    private int actual_value = 0;
    private Animator animator;
    [SerializeField] private target_item target;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void change_value(int value)
    {
        actual_value = value;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<player_script>().allow_interact();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<player_script>().deny_interact();
        }
    }

    public void activar_objetivo()
    {
        animator.SetBool("Activar",true);
        
    }
    
}
