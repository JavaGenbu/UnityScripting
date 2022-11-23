using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankController : MonoBehaviour
{
    [SerializeField]private Vector3 direction;
    [SerializeField]float speed = 4f;
    [SerializeField]float angularSpeed = 30f;
    [SerializeField]Vector3 axes;
    [SerializeField]float scaleUnits;





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A)){
            transform.Rotate(Vector3.up * (-angularSpeed * Time.deltaTime));
        }
        else if(Input.GetKey(KeyCode.D)){
            transform.Rotate(Vector3.up * (angularSpeed * Time.deltaTime));
        }

        if(Input.GetKey(KeyCode.W)){
            transform.Rotate(Vector3.forward * (speed * Time.deltaTime));
        }
        else if(Input.GetKey(KeyCode.S)){
            transform.Rotate(Vector3.up * (speed * Time.deltaTime));
        }
        

    }

    public static Vector3 ClampVector3(Vector3 target){
        float clampedX = Mathf.Clamp(target.x, -1f, 1f);
        float clampedY = Mathf.Clamp(target.y, -1f, 1f);
        float clampedZ = Mathf.Clamp(target.z, -1f, 1f);

        Vector3 result = new Vector3(clampedX, clampedY, clampedZ);
        return result;
    }
}
