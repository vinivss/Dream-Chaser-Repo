using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] public int hp;


    public void underAttack()
    {
        Debug.Log("hit");
        hp -= 10;
    }

    public bool healthCheck()
    {
        return hp > 0 ? true : false;
    }

    public int currentHealth()
    {
        return hp;
    }

}
