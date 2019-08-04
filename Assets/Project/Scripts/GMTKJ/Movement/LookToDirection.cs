using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookToDirection : MonoBehaviour
{
    //https://answers.unity.com/questions/1023987/lookat-only-on-z-axis.html
    //https://answers.unity.com/questions/46845/face-forward-direction-of-movement.html

    float rotationSpeed = 10f;
    float lerp = 0;

    [SerializeField]
    private CharacterController charController;
    
    void Start()
    {

    }

    void Update()
    {
        //avoid very fast rotations, or errors if the object is standing still:
        Vector3 dirCharacter = charController.velocity.normalized;

        if(dirCharacter.magnitude > 0.1f)
        {
            float rotationY = Mathf.Atan2(dirCharacter.x, dirCharacter.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, rotationY + 180f, 0.0f);
        }
    }
}