using UnityEngine;
using System.Collections.Generic;
using System.Collections;           // <- nécessaire pour IEnumerator et WaitForSeconds

public class RandomObject : MonoBehaviour
{
    [SerializeField] public List<GameObject> itemsList;
    public float interval = 0.1f;


    // public GameObject spawnRandom()
    // {
        

    //     Vector3 relativePosition = new Vector3(0f,0.85f,0.25f);
    //     Vector3 spawnPosition = transform.position + relativePosition;
    //     Quaternion rotation = Quaternion.identity;
    //     GameObject spawned = Instantiate(choosedItem,spawnPosition,rotation);
    //     spawned.SetActive(true);
    //     return spawned;
    // }

    public void ChooseRandomItem(){
        

        Debug.Log("Activé");
        
        int choosedIndex = Random.Range(0,itemsList.Count);
        // GameObject choosedItem = itemsList[choosedIndex];

        defilerItems(choosedIndex);

        
    }

    IEnumerator defilerItems(int choosedIndex)
    {
        // désactive tout
        foreach (var item in itemsList) item.SetActive(false);

        // affichage séquentiel simple
        for (int i = 0; i < itemsList.Count; i++)
        {
            itemsList[i].SetActive(true);
            yield return new WaitForSeconds(interval);
            itemsList[i].SetActive(false);
        }

        // affiche le gagnant
        itemsList[choosedIndex].SetActive(true);
        Debug.Log("Gagnant : " + choosedIndex);
    }

}



// public class SimpleLootMinimal : MonoBehaviour
// {
//     public GameObject[] items;    // Les items à faire défiler
//     public float interval = 0.1f; // Temps entre chaque apparition

//     public void Play(int winnerIndex)
//     {
//         StartCoroutine(Run(winnerIndex));
//     }

//     IEnumerator Run(int winner)
//     {
//         // désactive tout
//         foreach (var item in items) it.SetActive(false);

//         // affichage séquentiel simple
//         for (int i = 0; i < items.Length; i++)
//         {
//             items[i].SetActive(true);
//             yield return new WaitForSeconds(interval);
//             items[i].SetActive(false);
//         }

//         // affiche le gagnant
//         items[winner].SetActive(true);
//         Debug.Log("Gagnant : " + winner);
//     }
// }
