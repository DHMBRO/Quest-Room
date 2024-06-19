using UnityEngine;

public class Move : MonoBehaviour
{
       
    [SerializeField] Transform PlayerTransform;
    [SerializeField] public Transform Camera;
    
    [SerializeField] Transform PointForRay;
    [SerializeField] Transform SlotHand;
    [SerializeField] Transform InHand;

    [SerializeField] private float SpeedForMove;
    [SerializeField] private float SpeedForRun;

    [SerializeField] private float DistanceForRay = 1.0f;
    [SerializeField] private float Sens = 0.5f;

    float MouseX;
    float MouseY;

    Rigidbody RigKeys;
    

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        PlayerTransform = gameObject.GetComponent<Transform>();
    }


    void Update()
    {
        Moving();
        Cam();
        Drop();
    }

    void Moving()
    {
        if (PlayerTransform)
        {
            if (Input.GetKey(KeyCode.W))
            {
                PlayerTransform.transform.localPosition += transform.forward * SpeedForMove;
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    PlayerTransform.transform.localPosition += transform.forward * SpeedForRun;
                }
            }
            else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
            {
                PlayerTransform.transform.localPosition += transform.forward * SpeedForMove;
                PlayerTransform.transform.localPosition += transform.right * SpeedForMove;
            }
            else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
            {
                PlayerTransform.transform.localPosition += transform.forward * SpeedForMove;
                PlayerTransform.transform.localPosition += -transform.right * SpeedForMove;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                PlayerTransform.transform.localPosition -= transform.forward * SpeedForMove;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                PlayerTransform.transform.localPosition += transform.right * SpeedForMove;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                PlayerTransform.transform.localPosition += -transform.right * SpeedForMove;
            }
        }
    }
        
    void Cam()
    {
        MouseX = Input.GetAxis("Mouse X");
        MouseY = Input.GetAxis("Mouse Y");

        Camera.transform.Rotate(-MouseY * new Vector3(Sens, 0.0f, 0.0f));
        transform.Rotate(MouseX * new Vector3(0.0f, Sens, 0.0f));

        Ray Rycast = new Ray(PointForRay.position, PointForRay.forward);
        if (!InHand && Input.GetKeyDown(KeyCode.F) && Physics.Raycast(Rycast, out RaycastHit HitResult, DistanceForRay))
        {
            if (HitResult.collider.gameObject.tag == "KeyBlue")
            {
                HitResult.collider.transform.position = SlotHand.position;
                HitResult.collider.transform.SetParent(SlotHand);

                RigKeys = HitResult.collider.gameObject.GetComponent<Rigidbody>();
                ChangeRigidbody(RigKeys);

                InHand = HitResult.collider.transform;   
            }
            else if (HitResult.collider.gameObject.tag == "KeyRed")
            {
                HitResult.collider.transform.position = SlotHand.position;
                HitResult.collider.transform.SetParent(SlotHand);

                RigKeys = HitResult.collider.gameObject.GetComponent<Rigidbody>();
                ChangeRigidbody(RigKeys);

                InHand = HitResult.collider.transform;
            }
                
        }
        Debug.DrawRay(PointForRay.position, PointForRay.forward * DistanceForRay, Color.red);

        void ChangeRigidbody(Rigidbody RigidbodyForChange)
        {
            RigidbodyForChange.isKinematic = true;
            RigidbodyForChange.useGravity = false;
        }

    }

    void Drop()
    {
        if (InHand && Input.GetKeyDown(KeyCode.Q))
        {
            RigKeys = InHand.gameObject.GetComponent<Rigidbody>();
            ChangeRigidbody(RigKeys);
            InHand.SetParent(null);
            InHand = null;
        }

        void ChangeRigidbody(Rigidbody RigidbodyForChange)
        {
            RigidbodyForChange.isKinematic = false;
            RigidbodyForChange.useGravity = true;
        }

    }

}

