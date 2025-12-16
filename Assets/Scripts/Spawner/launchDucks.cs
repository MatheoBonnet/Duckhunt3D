using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class launchDucks : MonoBehaviour
{
    public static List<GameObject> spawnersList = new List<GameObject>();
    public static bool active = true;
    public static float interval = 1f;
    public static launchDucks instance;
    private Coroutine currentCoroutine;
    
    void Awake()
    {
        instance = this;
        spawnersList.Clear(); // Nettoyer la liste au cas où
    }
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

    static IEnumerator launchRandom()
    {
        while (active)
        {
            int choosedIndex = Random.Range(0,spawnersList.Count);
            Spawner spawnerScript = spawnersList[choosedIndex].GetComponent<Spawner>();
            spawnerScript.launch();
            yield return new WaitForSeconds(interval);
        }
        yield break;
    }
    public static void SetActive(bool state)
    {
        active = state;
        
        if (instance == null) return;
        
        // Toujours arrêter la coroutine en cours
        instance.StopAllCoroutines();
        
        // Relancer seulement si on active
        if (state)
        {
            instance.StartCoroutine(launchRandom());
        }
    }
}
