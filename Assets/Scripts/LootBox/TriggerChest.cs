using UnityEngine;
using UnityEngine.Playables;
using System.Collections.Generic;
using System.Collections; 

public class TriggerChest : MonoBehaviour
{
    [SerializeField] public PlayableDirector LootboxTimeline;

    public List<GameObject> itemsList;
    public GameObject items;
    public float interval = 0.3f;

    void Start()
    {
        for(int i=0; i < items.transform.childCount; i++)
        {
            GameObject item = items.transform.GetChild(i).gameObject;
            itemsList.Add(item);
            item.SetActive(false);
            item.GetComponent<CollectItem>().collectable = false;
        }
    }

    void OnTriggerStay(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
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

        int choosedIndex = Random.Range(0,itemsList.Count);
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
            Debug.Log(i%itemsList.Count);
            yield return new WaitForSeconds(interval);
            itemsList[i%itemsList.Count].SetActive(false);
        }

        // affiche le gagnant
        
        GameObject choosedItem = Instantiate(itemsList[choosedIndex], itemsList[choosedIndex].transform.position, itemsList[choosedIndex].transform.rotation);
        choosedItem.SetActive(true);
        choosedItem.GetComponent<CollectItem>().collectable = true;
        Debug.Log("Gagnant : " + choosedItem);
    }
}
