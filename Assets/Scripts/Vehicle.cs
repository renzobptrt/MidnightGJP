using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void GetDamage(int value)
    {
        life = life - value <= 0? 0 : life - value;
    }

    private int life = 0;
}
