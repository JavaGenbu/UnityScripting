using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleRotation : MonoBehaviour
{
    [SerializeField]private Vector3 rotationAxis;
    [SerializeField]float rotationSpeed;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotationAxis = ClampVector3(rotationAxis);

        transform.Rotate(rotationAxis * (rotationSpeed * Time.deltaTime));


    }

    public static Vector3 ClampVector3(Vector3 target){
        float clampedX = Mathf.Clamp(target.x, -1f, 1f);
        float clampedY = Mathf.Clamp(target.y, -1f, 1f);
        float clampedZ = Mathf.Clamp(target.z, -1f, 1f);

        Vector3 result = new Vector3(clampedX, clampedY, clampedZ);
        return result;
    }
}

