using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerPlatformer : MonoBehaviour
{
    [SerializeField] private GroundedCheck groundCheck;
    [SerializeField] private GameObject winUi;
    private float horizontalInput;
    private Rigidbody rigidBodyComponent;
    private bool isGrounded;
    public Transform SpawnPoint;
    Quaternion spawnQuaternion;

    void Start()
    {
        rigidBodyComponent = GetComponent<Rigidbody>();
    }


    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        isGrounded = groundCheck.isObjectGrounded;

        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rigidBodyComponent.AddForce((Vector3.up * 6) * (Pet.Instance.str / 2), ForceMode.VelocityChange);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            rigidBodyComponent.AddForce((Vector3.down * 5) * (Pet.Instance.str), ForceMode.VelocityChange);
        }


    }

    void FixedUpdate()
    {
        rigidBodyComponent.velocity = new Vector3(horizontalInput * Pet.Instance.dex, rigidBodyComponent.velocity.y, 0);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            gameObject.transform.SetPositionAndRotation(SpawnPoint.position, spawnQuaternion);
        }

        if (other.gameObject.layer == 8)
        {
            Pet.Instance.dexUp();
            winUi.SetActive(true);
        }
    }
}
