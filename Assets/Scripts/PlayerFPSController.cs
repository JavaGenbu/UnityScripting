using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFPSController : MonoBehaviour
{

    [SerializeField]public GameObject cam;
    public float walkSpeed = 5f;
    public float hrotationSpeed = 100f;
    public float vRotationSpeed = 80f;


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

        //rotation

        rotation();
    }

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

        Vector3 movementDirection = hMovement * Vector3.right + vMovement * Vector3.forward;
        transform.Translate(movementDirection * (walkSpeed * Time.deltaTime));
    }
}
