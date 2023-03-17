using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDeathDissolve : MonoBehaviour
{
   [SerializeField] private Renderer[] dissolveRenderer = new Renderer[0];

    private float targetDissolveValue = 0.9f;
    private float currentDissolveValue = 0.0f;
    private float dissolveSpeed = 2f;

    bool dissolveEnabled = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dissolveEnabled)
        {
            Debug.Assert(dissolveEnabled);
            currentDissolveValue = Mathf.Lerp(currentDissolveValue, targetDissolveValue, dissolveSpeed * Time.deltaTime);
            foreach (Renderer renderer in dissolveRenderer)
            {

                renderer.material.SetFloat("_DissolveAmount", currentDissolveValue);
            }
        }
    }

    public void OnPlayerDeath()
    {
        dissolveEnabled = true;
    }
}
