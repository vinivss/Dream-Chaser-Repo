using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineManagerVin : MonoBehaviour
{
    public List<GameObject> coffeeMakerList;
    [Min(0)]   int index = 0;
    GameObject currMach;

    private void Start()
    {
        currMach = Instantiate(coffeeMakerList[0], this.transform);
    }
    // Start is called before the first; frame update
    public void ChangeMachine(bool Left)
    {
        Destroy(currMach);
        if(Left == true)
        {
            if (index == 0)
            {
                index = coffeeMakerList.Count - 1;
            }
            else
            {
                index--;
                
            }
        }
        else
        {
            if(index == coffeeMakerList.Count -1 )
            {
                index = 0;
            }
            else
            {
                index++;
            }
        }
        currMach = Instantiate(coffeeMakerList[index], this.transform);
    }
}
