// using UnityEngine;

// public class CameraMovment : MonoBehaviour
// {
//     //public Vector3 currentRotation;
//     //public float rotationSpeed = 5f;
//     //public float maxYangle = 45f;

//     public float sens;
//     public Transform orientation;
//     public Transform aimingDirection;
//     float xRotation;
//     float yRotation;

//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     void Start()
//     {
//         Cursor.lockState = CursorLockMode.Locked;  
//         Cursor.visible = false;
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sens;
//         float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sens;

//         yRotation += mouseX;
//         xRotation -= mouseY;
//         xRotation = Mathf.Clamp(xRotation, -90f, 90f);

//         transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);


//         orientation.rotation = Quaternion.Euler(0, yRotation, 0);
//         aimingDirection.rotation = Quaternion.Euler(xRotation, yRotation, 0);



//         // transform.Rotate(0,rotateSpeed * Input.GetAxis("Mouse X"),0);
//         // transform.Rotate(rotateSpeed * Input.GetAxis("Mouse Y"),0,0);
//         //currentRotation.x += rotationSpeed * Input.GetAxis("Mouse X");
//         //currentRotation.y -= rotationSpeed * Input.GetAxis("Mouse Y");
//         //currentRotation.x = Mathf.Repeat(currentRotation.x, 360);
//         //currentRotation.y = Mathf.Clamp(currentRotation.y, -maxYangle, maxYangle);
//         //transform.rotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0);
//     }
// }


using UnityEngine;

public class CameraMovment : MonoBehaviour
{


    public float sens;

    float xRotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;  
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sens;

        xRotation -= mouseX;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

    }
}
