using UnityEngine;
using UnityEngine.Playables;
using System.Collections.Generic;
using System.Collections; 

public class TriggerChest : MonoBehaviour
{
    [SerializeField] public PlayableDirector LootboxTimeline;

    [SerializeField] public List<GameObject> itemsList;
    public float interval = 0.3f;

    void Start()
    {
        foreach (var item in itemsList) item.SetActive(false);
    }

    void OnTriggerStay(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("Lancement Timeline");
                LootboxTimeline.Play();

                ChooseRandomItem();
                Debug.Log("choisi");

            }
            
        }
        
    }

    public void ChooseRandomItem(){
        
    Debug.Log("Activé");
        

    if (itemsList == null || itemsList.Count == 0)
    {
        Debug.LogWarning("itemsList est vide !");
        return;
    }

        int choosedIndex = Random.Range(0,itemsList.Count-1);
        // GameObject choosedItem = itemsList[choosedIndex];

        StartCoroutine(defilerItems(choosedIndex));

        
    }

    IEnumerator defilerItems(int choosedIndex)
    {
        Debug.Log("Test");
        
        

        // affichage séquentiel simple
        for (int i = 0; i < 20; i++)
        {
            itemsList[i%itemsList.Count].SetActive(true);
            yield return new WaitForSeconds(interval);
            itemsList[i%itemsList.Count].SetActive(false);
        }

        // affiche le gagnant
        itemsList[choosedIndex].SetActive(true);
        Debug.Log("Gagnant : " + choosedIndex);
    }
}
