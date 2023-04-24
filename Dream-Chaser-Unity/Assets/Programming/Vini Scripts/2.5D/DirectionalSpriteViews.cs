using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalSpriteViews : MonoBehaviour
{
    [Header("Sprite Look Controls")]
    [Tooltip("Angle needed before changing to back pixel")]
    [SerializeField] float backAngle = 65f;
    [Tooltip("Angle needed before changing to side pixel")]
    [SerializeField] float sideAngle = 155f;
    [Tooltip("Where we compare camera transform to")]
    [SerializeField] Transform mainTransform;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void LateUpdate()
    {
        SetPixelPerspective();
    }

    private void SetPixelPerspective()
    {


        Vector3 camForwardVect = new Vector3(Camera.main.transform.forward.x, 0f, Camera.main.transform.forward.z);
        Debug.DrawRay(Camera.main.transform.position, camForwardVect * 5f, Color.red);

        float signedAngle = Vector3.SignedAngle(mainTransform.forward, camForwardVect, Vector3.up);

        Vector2 animDir = new Vector2(0f, -1f);

        float angle = Mathf.Abs(signedAngle);

        if (angle < backAngle)
        {
            //back anim
            animDir = new Vector2(0f, -1f);
        }
        else if (angle < sideAngle)
        {
            if (signedAngle < 0)
            {
                // left anim
                animDir = new Vector2(-1f, 0f);
            }
            else
            {
                // right anim
                animDir = new Vector2(1f, 0);
            }
        }
        else
        {
            //Front Anim
            animDir = new Vector2(0f, 1f);
        }

        animator.SetFloat("movX", animDir.x);
        animator.SetFloat("movY", animDir.y);
    }
}
