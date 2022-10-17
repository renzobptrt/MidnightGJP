using UnityEngine;

public class ladder_script : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<player_script>().allow_climb_lader();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<player_script>().deny_climb_ladder();
        }
    }

}
