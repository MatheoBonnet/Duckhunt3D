using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject duck;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Mouse0))
        // {
        //     Quaternion rotation = Quaternion.identity;
        //     GameObject duckInstance = Instantiate(duck, transform.position + new Vector3(0,2,0), transform.rotation);
        //     duckInstance.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1000, 0));
        // }
    }

    public void launch()
    {
        int xForce = Random.Range(100,300);
        int direction = Random.Range(0,2);
        Debug.Log(direction);
        if(direction == 0)
        {
            xForce = -xForce;
        }
        Quaternion rotation = Quaternion.Euler(-90,-90,0);
        // Quaternion rotation = transform.rotation;
        GameObject duckInstance = Instantiate(duck, transform.position + new Vector3(0,2,0), rotation);
        duckInstance.GetComponent<Rigidbody>().AddForce(new Vector3(xForce, 1000, 0));
    }
}