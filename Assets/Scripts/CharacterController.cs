using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float speed = 15f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float rayDistance = 2.2f;
    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private float maxAngle = 40f;
    
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private Transform playerHead;
    [SerializeField] private Transform spawnBullet;
    [SerializeField] private GameObject prefabBullet;

    private Rigidbody m_Rigidbody;
    private float m_XRotation;
    
    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (OnGround() && Input.GetKeyDown(KeyCode.Space))
            m_Rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        if (Input.GetMouseButtonDown(0))
            Instantiate(prefabBullet, spawnBullet.position, Quaternion.identity);
    }
    
    private void FixedUpdate()
    {
        //Move
        var moveX = Input.GetAxis("Horizontal");
        var moveZ = Input.GetAxis("Vertical");
        if (moveX != 0 || moveZ != 0)
        {
            var dir = new Vector3(moveX, 0, moveZ);
            transform.Translate(dir * (speed * Time.fixedDeltaTime));
        }
        //Rotation
        var mouseX = Input.GetAxis("Mouse X");
        var mouseY = Input.GetAxis("Mouse Y");
        m_XRotation -= mouseY * (mouseSensitivity * Time.fixedDeltaTime);
        m_XRotation = Mathf.Clamp(m_XRotation, -maxAngle, maxAngle);
        playerHead.localRotation = Quaternion.Euler(m_XRotation, 0f, 0f);
        transform.Rotate(Vector3.up * (mouseX * (mouseSensitivity * Time.fixedDeltaTime)));
    }

    private bool OnGround()
    {
        var playerPosition = transform.position;
        Debug.DrawRay(playerPosition, Vector3.down * rayDistance, Color.red); //only for debug
        return Physics.Raycast(playerPosition, Vector3.down, rayDistance, playerMask);
    }
}
