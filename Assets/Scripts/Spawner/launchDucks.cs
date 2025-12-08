using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class launchDucks : MonoBehaviour
{
    public List<GameObject> spawnersList;
    public float interval = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i=0;i < gameObject.transform.childCount; i++)
        {
            // Debug.Log(gameObject.transform.GetChild(i));
            spawnersList.Add(gameObject.transform.GetChild(i).gameObject);
            // Debug.Log(gameObject.transform.GetChild(i).gameObject);
        }

        StartCoroutine(launchRandom());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator launchRandom()
    {
        while (true)
        {
            int choosedIndex = Random.Range(0,spawnersList.Count);
            Spawner spawnerScript = spawnersList[choosedIndex].GetComponent<Spawner>();
            spawnerScript.launch();
            yield return new WaitForSeconds(interval);
        }
        
    }
}
