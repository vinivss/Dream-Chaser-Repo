using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] public int hp;
    public bool isAlive;

    public void underAttack()
    {
        hp -= 10;
    }

    public bool healthCheck()
    {

        return hp > 10 ? true : false;
    }
}
