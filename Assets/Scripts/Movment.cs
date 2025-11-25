using UnityEngine;

public class Movment : MonoBehaviour
{
    public int speed = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0,0,speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A)) // tant que la touche est enfoncee
        {
            transform.Translate(-speed * Time.deltaTime,0,0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0,0,-speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed * Time.deltaTime,0,0);
        }
    }
}
