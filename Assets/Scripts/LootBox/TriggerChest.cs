using UnityEngine;
using UnityEngine.Playables;

public class TriggerChest : MonoBehaviour
{
    [SerializeField] public PlayableDirector LootboxTimeline;
    void OnTriggerStay(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("Lancement Timeline");
                LootboxTimeline.Play();
            }
            
        }
        
    }
}
