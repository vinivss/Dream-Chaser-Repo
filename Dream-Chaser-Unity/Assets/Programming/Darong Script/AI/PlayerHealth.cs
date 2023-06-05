using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] public int hp;


    public void underAttack()
    {
        hp -= 10;
    }

    public bool healthCheck()
    {
        Debug.Log(hp);
        return hp > 10 ? true : false;
    }

    public int currentHealth()
    {
        return hp;
    }
}
