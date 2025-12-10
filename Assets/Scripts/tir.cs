using UnityEngine;
using System.Collections;

public class tir : MonoBehaviour
{
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private ParticleSystem ImpactParticule;
    [SerializeField]
    private ParticleSystem ShootingSystem;
    [SerializeField]
    private TrailRenderer BulletTrail;
    [SerializeField]
    private float shoodDelay = 0.5f;
    [SerializeField]
    private float bulletSpeed = 50f;
    [SerializeField]
    private LayerMask Mask;
    [SerializeField]
    private float maxDistance = 100f;
    [SerializeField]
    private Camera playerCamera;

    private float lastShootTime;
    private Animator animator;

    public InventorySO inventaire;



    private void Awake()
    {
        animator = GetComponent<Animator>();
        if (spawnPoint == null)
            spawnPoint = transform;
    }

    // Public method — call from Player or input handler
    public void Shoot(float damage, float shootDelay)
    {
        if (lastShootTime + shootDelay > Time.time) return;

        lastShootTime = Time.time;

        if (ShootingSystem != null)
            ShootingSystem.Play();

        Vector3 origin = spawnPoint != null ? spawnPoint.position : transform.position;

        // determine aim point from camera center (preferred) or from spawnPoint forward as fallback
        Camera cam = playerCamera != null ? playerCamera : Camera.main;
        Vector3 aimPoint;

        if (cam != null)
        {
            Ray camRay = cam.ScreenPointToRay(new Vector3(Screen.width * 0.5f, Screen.height * 0.5f));
            if (Physics.Raycast(camRay, out RaycastHit camHit, maxDistance, Mask))
            {
                aimPoint = camHit.point;
                GameObject hitObject = camHit.collider.gameObject;
                Debug.Log(hitObject.tag);
                if(hitObject.tag == "Duck")
                {
                    hitObject.GetComponent<DuckController>().takeDamage(damage);
                }
                
            }
            else
            {
                aimPoint = camRay.GetPoint(maxDistance);
                Debug.Log("pas touche");
            }
        }
        else
        {
            // no camera available — fallback to spawnPoint forward
            Vector3 fallbackDir = spawnPoint != null ? spawnPoint.forward : transform.forward;
            aimPoint = origin + fallbackDir.normalized * maxDistance;
        }

        // now cast from the spawn origin towards the aim point to get the actual hit (objects between spawn and aim)
        Vector3 dir = (aimPoint - origin).normalized;
        if (Physics.Raycast(origin, dir, out RaycastHit hit, maxDistance, Mask))
        {
            SpawnShot(origin, hit.point, true, hit.normal, hit.collider.gameObject);
        }
        else
        {
            Vector3 missPoint = origin + dir * maxDistance;
            SpawnShot(origin, missPoint, false, Vector3.up, null);
        }
    }


    // trail, particules, ... :

    private void SpawnShot(Vector3 origin, Vector3 targetPoint, bool didHit, Vector3 hitNormal, GameObject hitObject)
    {
        if (BulletTrail != null)
        {
            TrailRenderer trail = Instantiate(BulletTrail, origin, Quaternion.identity);
            StartCoroutine(SpawnTrail(trail, targetPoint, didHit, hitNormal, hitObject));
        }
        else
        {
            // if no trail, still spawn impact particle if hit
            if (didHit && ImpactParticule != null)
                Instantiate(ImpactParticule, targetPoint, Quaternion.LookRotation(hitNormal));
        }
    }

    private IEnumerator SpawnTrail(TrailRenderer trail, Vector3 targetPoint, bool didHit, Vector3 hitNormal, GameObject hitObject)
    {
        float time = 0f;
        Vector3 startPosition = trail.transform.position;

        while (time < 1f)
        {
            trail.transform.position = Vector3.Lerp(startPosition, targetPoint, time);
            time += Time.deltaTime / Mathf.Max(0.0001f, trail.time);
            yield return null;
        }

        trail.transform.position = targetPoint;

        if (didHit && ImpactParticule != null)
            Instantiate(ImpactParticule, targetPoint, Quaternion.LookRotation(hitNormal));

        Destroy(trail.gameObject, trail.time);
    }
}
