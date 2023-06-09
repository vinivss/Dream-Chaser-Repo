using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] public int hp;


    public void underAttack()
    {
        Debug.Log("hit");
        hp -= 10;
        if (!healthCheck())
        {
            AudioManager.instance.PlayOneShot(FMODEvents.instance.ambience, this.transform.position);
            FindObjectOfType<DCMoveVin>().PlayerDeath();
            StartCoroutine(ResetScene());
        }
    }

    public bool healthCheck()
    {
        return hp > 0 ? true : false;
    }

    public int currentHealth()
    {
        return hp;
    }


    IEnumerator ResetScene()
    {
        yield return new WaitForSecondsRealtime(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
