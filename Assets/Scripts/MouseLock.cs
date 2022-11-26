using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLock : MonoBehaviour
{
   [SerializeField]public GameObject cam;
    public float walkSpeed = 5f;
    public float hrotationSpeed = 100f;
    public float vRotationSpeed = 80f;
    public float maxVerticalAngle;
    public float minVerticalAngle;
    public float smoothTime = 0.05f;

    float vCamRotationAngles;
    float hPlayerRotation;
    float currentHVelocity;
    float currentVVelocity;
    float targetCamEulers;
    Vector3 targetCamRotation;



    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        GameObject.Find("Capsule").gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }


    //La rotacion ya no se utiliza en este script
    private void rotation()
    {
        float vCamRotation = Input.GetAxis("Mouse Y") * vRotationSpeed * Time.deltaTime;
        float hPlayerRotation = Input.GetAxis("Mouse X") * hrotationSpeed * Time.deltaTime;

        transform.Rotate(0f, hPlayerRotation, 0f);
        cam.transform.Rotate(-vCamRotation, 0f, 0f);
    }

    private void movement()
    {
        float hMovement = Input.GetAxisRaw("Horizontal");
        float vMovement = Input.GetAxisRaw("Vertical");

        //bool jumpInput = jumpInput.GetButtonDown("Jump");
        //bool jumpInput = jumpInput.GetButtonDown("Dash");

        Vector3 movementDirection = hMovement * Vector3.right + vMovement * Vector3.forward;
        transform.Translate(movementDirection * (walkSpeed * Time.deltaTime));
    }

    public void handleRotation(float hInput, float vInput){

        // Get rotation based on input

        float targetPlayerRotation = hInput * hrotationSpeed * Time.deltaTime;
        targetCamEulers += vInput * vRotationSpeed * Time.deltaTime;

        //Player Rotation

        hPlayerRotation = Mathf.SmoothDamp(hPlayerRotation, targetPlayerRotation, ref currentVVelocity, smoothTime);
        transform.Rotate(0f, hPlayerRotation, 0f);

        //Cam Rotation 

        targetCamEulers = Mathf.Clamp(targetCamEulers, minVerticalAngle, maxVerticalAngle);
        vCamRotationAngles = Mathf.SmoothDamp(vCamRotationAngles, targetCamEulers, ref currentVVelocity, smoothTime);
        targetCamRotation.Set(-vCamRotationAngles, 0f, 0f);
        // camerasParent.transform.localEulerAngles = targetCamRotation;
    }
}
