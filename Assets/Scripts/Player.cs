using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public int speed = 10;
    float horizontalInput;
    float verticalInput;    
    public Transform orientation;
    Vector3 moveDirection;
    float groundDrag = 5f;

    Rigidbody rb;

    public float jumpForce = 5f;
    public bool grounded = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Bloquer le curseur et le cacher
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // recuperer les inputs verticaux et horizontaux
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // tourner le joueur en fctn de l'orientation de la camera
        transform.rotation = orientation.rotation;

        // saut
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            rb.linearVelocity = Vector3.up * jumpForce;
            grounded = false;
        }

        // ralentit au sol (pour ne pas "glisser")
        if (grounded) {
            rb.linearDamping = groundDrag;
        }
        else
        {
            rb.linearDamping = 0;
        }

    }

    private void FixedUpdate()
    {
        // calcul de la direction du mouvement
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        //force pour deplacer le joueur dans la direction de la camera
        rb.AddForce(moveDirection.normalized * speed * 10f, ForceMode.Force);

        // limitation de la vitesse
        // vitesse actuelle
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        if(flatVel.magnitude > speed)
        {
            //vitesse max
            Vector3 limitedVel = flatVel.normalized * speed;
            //application
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
}
