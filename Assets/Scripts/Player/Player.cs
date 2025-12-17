// using UnityEngine;
// using UnityEngine.EventSystems;

// public class Player : MonoBehaviour
// {
//     public int speed = 10;
//     float horizontalInput;
//     float verticalInput;    
//     public Transform orientation;
//     Vector3 moveDirection;
//     float groundDrag = 5f;

//     Rigidbody rb;

//     public float jumpForce = 5f;
//     public bool grounded = false;


//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     void Start()
//     {
//         //Bloquer le curseur et le cacher
//         Cursor.lockState = CursorLockMode.Locked;
//         Cursor.visible = false;
//         rb = GetComponent<Rigidbody>();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         // recuperer les inputs verticaux et horizontaux
//         horizontalInput = Input.GetAxisRaw("Horizontal");
//         verticalInput = Input.GetAxisRaw("Vertical");

//         // tourner le joueur en fctn de l'orientation de la camera
//         transform.rotation = orientation.rotation;

//         // saut
//         if (Input.GetKey(KeyCode.Space) && grounded)
//         {
//             rb.linearVelocity = Vector3.up * jumpForce;
//             grounded = false;
//         }

//         // ralentit au sol (pour ne pas "glisser")
//         if (grounded) {
//             rb.linearDamping = groundDrag;
//         }
//         else
//         {
//             rb.linearDamping = 0;
//         }

//     }

//     private void FixedUpdate()
//     {
//         // calcul de la direction du mouvement
//         moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
//         //force pour deplacer le joueur dans la direction de la camera
//         rb.AddForce(moveDirection.normalized * speed * 10f, ForceMode.Force);

//         // limitation de la vitesse
//         // vitesse actuelle
//         Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
//         if(flatVel.magnitude > speed)
//         {
//             //vitesse max
//             Vector3 limitedVel = flatVel.normalized * speed;
//             //application
//             rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
//         }
//     }

//     void OnCollisionEnter(Collision collision)
//     {
//         if (collision.gameObject.tag == "Ground")
//         {
//             grounded = true;
//         }
//     }
// }

using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int speed = 10;
    public float sens;
    float yRotation;


    Rigidbody rb;
    public float jumpForce = 5f;
    public bool grounded = false;


    public InventorySO inventaire;
    public float baseDamage, bonusDamage, realDamage;
    public float baseShootDelay = 0.5f;
    public float bonusShootDelay, realShootDelay;

    public static float score, maxScore;
    public static float money = 1000f;
    public Canvas playerUI;
    private static Text scoreUI;
    private static Text maxScoreUI;
    private Text moneyUI;

    private tir shooter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Bloquer le curseur et le cacher
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();

        // try to auto-assign shooter if not set in Inspector
        if (shooter == null)
        {
            shooter = GetComponentInChildren<tir>();
            if (shooter == null)
                shooter = FindFirstObjectByType<tir>();
        }

        score = 0f;
        Debug.Log(gameObject);

        // Text scoreUI = playerUI.transform.GetChild(1).GameObject.GetComponent;
        Text[] texts = playerUI.GetComponentsInChildren<Text>();
        scoreUI = texts[0];
        maxScoreUI = texts[1];
        moneyUI = texts[2];
    }

    // Update is called once per frame
    void Update()
    {
        float realSpeed = speed + inventaire.GetBonusTotal(StatType.speed);


        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0,0,realSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A)) // tant que la touche est enfoncee
        {
            transform.Translate(-realSpeed * Time.deltaTime,0,0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0,0,-realSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(realSpeed * Time.deltaTime,0,0);
        }
        

        transform.Rotate(0,sens * Input.GetAxis("Mouse X"),0);


        // saut
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            rb.linearVelocity = Vector3.up * jumpForce;
            grounded = false;
        }

        // left click to shoot
        bonusDamage = inventaire.GetBonusTotal(StatType.damage);
        bonusShootDelay = inventaire.GetBonusTotal(StatType.shootDelay);
        realDamage = baseDamage + bonusDamage;
        realShootDelay = baseShootDelay + bonusShootDelay;
        if (Input.GetMouseButtonDown(0))
        {
            if (shooter != null)
            {
                shooter.Shoot(realDamage, realShootDelay);
            }
            else
            {
                Debug.LogWarning("Player: shooter (tir) is not assigned.");
            }
        }

         moneyUI.text = "Money : " + money.ToString();
    }

    void updateStats()
    {
        
    }

    public static void updateScore (float nb)
    {
        score += nb;
        if (score > maxScore)
        {
            maxScore = score;
        }
        scoreUI.text = "Score : " + score.ToString();
        maxScoreUI.text = "Max score : " + maxScore.ToString();
    }

    public static float getMoney()
    {
        return money;
    }

    public static void addMoney(float amount)
    {
        money += amount;
    }

    public static void removeMoney(float amount)
    {
        money -= amount;
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
}
