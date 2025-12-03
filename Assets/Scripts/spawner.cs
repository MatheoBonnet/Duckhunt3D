using UnityEngine;

public class spawner : MonoBehaviour
{
    [SerializeField] GameObject duck;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Quaternion rotation = Quaternion.identity;
            GameObject duckInstance = Instantiate(duck, transform.position + new Vector3(0,2,0), transform.rotation);
            duckInstance.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1000, 0));
        }
    }
}
