using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerPlatformer : MonoBehaviour
{
    [SerializeField] private GroundedCheck groundCheck;
    [SerializeField] private Timer timer;
    [SerializeField] private GameObject winUi;
    [SerializeField] private GameObject mutationButton;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip jump;
    [SerializeField] private AudioClip stomp;
    [SerializeField] private AudioClip death;

    private float horizontalInput;
    private Rigidbody rigidBodyComponent;
    private bool isGrounded;
    public bool reachedEnd;
    public Transform SpawnPoint;
    Quaternion spawnQuaternion;

    void Start()
    {
        rigidBodyComponent = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (!reachedEnd)
        {
            horizontalInput = Input.GetAxis("Horizontal");
        }
        else
        {
            horizontalInput = Input.GetAxis("Horizontal") * 0;
        }
        isGrounded = groundCheck.isObjectGrounded;

        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rigidBodyComponent.AddForce((Vector3.up * 6) * (Pet.Instance.str / 2), ForceMode.VelocityChange);
            audioSource.PlayOneShot(jump);

        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            rigidBodyComponent.AddForce((Vector3.down * 5) * (Pet.Instance.str), ForceMode.VelocityChange);
            audioSource.PlayOneShot(stomp);
        }


    }

    void FixedUpdate()
    {
        rigidBodyComponent.velocity = new Vector3(horizontalInput * (Pet.Instance.dex / 2 + 2), rigidBodyComponent.velocity.y, 0);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            gameObject.transform.SetPositionAndRotation(SpawnPoint.position, spawnQuaternion);
            audioSource.PlayOneShot(death, 0.1f);
        }

        if (other.gameObject.layer == 8)
        {
            reachedEnd = true;
            int randomNumber = Random.Range(1, 100);
            if (Pet.Instance.motivated)
            {
                randomNumber -= 10;
            }
            if (randomNumber <= 20)
            {
                mutationButton.SetActive(true);
            }
            Pet.Instance.statGain = ((1 * Pet.Instance.petMotivatedBonus()) + Pet.Instance.petElementBonus(3, 4));
            if (timer.gotToEndOnTime())
            {
                Pet.Instance.statGain = 1 + Pet.Instance.petElementBonus(3, 4);
            }
            Pet.Instance.dexUp();
            winUi.SetActive(true);
        }
    }

}
