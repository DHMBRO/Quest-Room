using UnityEngine;

public class MovementForCamera : MonoBehaviour
{
    [SerializeField] float SensitivityX = 1.0f;
    [SerializeField] float SensitivityY = 1.0f; 
    
    [SerializeField] float DefaultSpeed = 1.0f;
    [SerializeField] float SpeedJump = 0.5f;
    [SerializeField] float SpeedBoost = 1.5f;

    [SerializeField] bool CameraIsWorking = false;
    
    float CurrentSpeed;

    float AxisHorizontal;
    float AxisVertical;
    float AxisJump;

    float MouseX;
    float MouseY;

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) CameraIsWorking = false;
        else if (Input.GetKey(KeyCode.Mouse1)) CameraIsWorking = true;

        if (!CameraIsWorking)
        {
            Cursor.lockState = CursorLockMode.None;
            return;
        }
        else Cursor.lockState = CursorLockMode.Locked;


        AxisHorizontal = Input.GetAxis("Horizontal");
        AxisVertical = Input.GetAxis("Vertical");
        AxisJump = Input.GetAxis("Jump");        

        MouseX = Input.GetAxis("Mouse X");
        MouseY = Input.GetAxis("Mouse Y");

        Vector3 Force = new Vector3(AxisHorizontal, 0.0f, -AxisVertical) * DefaultSpeed;

        if (Input.GetKey(KeyCode.LeftShift)) CurrentSpeed = (DefaultSpeed * SpeedBoost);
        else CurrentSpeed = DefaultSpeed;

        
        transform.localPosition += transform.forward * (AxisVertical * CurrentSpeed);
        transform.localPosition += transform.right * (AxisHorizontal * CurrentSpeed);
        transform.localPosition += transform.up * (AxisJump * SpeedJump);
        

        transform.localEulerAngles = new Vector3(
        transform.localEulerAngles.x + -MouseY * SensitivityY, 
        transform.localEulerAngles.y + MouseX * SensitivityX,
        0.0f);

        

    }
}
