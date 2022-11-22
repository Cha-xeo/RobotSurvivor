using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaseGun : MonoBehaviour
{
    private InputHandler _input;
    public LineRenderer _sight;
    public Transform laserPos;
    public float reloadingTime = 2f;
    public ParticleSystem muzzleFlash;
    public int maxMagazine = 30;
    public int magazine = 0;
    public int damagePerPellets;
    public float impactForce;
    [SerializeField] private Vector3 spread = new Vector3(0.1f, 0.1f, 0.1f);
    [SerializeField] private TrailRenderer BulletTrail;
    [SerializeField] private LayerMask Mask;
    public float pellets;
    public float fireRate;
    private float nextShot = 0.0f;
    private bool reloading;
    public bool AddSpread;
    public AudioClip otherClip;
    AudioSource audioData;

    private void Awake() {
        _input = transform.parent.GetComponent<InputHandler>();
        audioData = GetComponent<AudioSource>();
        _sight.enabled = false;
    }

    public void Shoot()
    {
        audioData.clip = otherClip;
        if ( magazine > 0  && !reloading){
            if (nextShot + fireRate < Time.time){
                for (float i = 0; i < pellets; i++){
                    muzzleFlash.Play();
                    audioData.Play();
                    Vector3 direction = GetDirection();
                    if (Physics.Raycast(laserPos.position, direction, out  RaycastHit hit, float.MaxValue, Mask))
                    {
                        if (hit.transform.gameObject.tag == "Enemie"){
                            hit.transform.gameObject.GetComponent<EnemiesHealth>().healthUpdate(-damagePerPellets);
                            // Debug.Log("Enemie hit");
                        }
                         if (hit.rigidbody){
                            hit.rigidbody.AddForce(-hit.normal * impactForce);
                        }
                        TrailRenderer trail = Instantiate(BulletTrail, laserPos.position, Quaternion.identity);
                        StartCoroutine(SpawnTrail(trail, hit));
                    }else{
                        TrailRenderer trail = Instantiate(BulletTrail, laserPos.position, Quaternion.identity);
                        StartCoroutine(SpawnTrailNoHit(trail, direction));
                    }
                    nextShot = Time.time;
                    magazine--;
                }
            }
        }
    }

    private Vector3 GetDirection()
    {
        Vector3 direction = transform.forward;
        if (AddSpread){
            direction += new Vector3(
                (float)Random.Range(-spread.x, spread.x),
                0,// Random.Range(-spread.y, spread.y),
                (float)Random.Range(-spread.z, spread.z)
            );
            direction.Normalize();
        }
        return direction;
    }

    private IEnumerator SpawnTrail(TrailRenderer Trail, RaycastHit hit)
    {
        float time = 0;
        Vector3 startPosition = Trail.transform.position;
        while (time < 1)
        {
            Trail.transform.position = Vector3.Lerp(startPosition, hit.point, time);
            time += Time.deltaTime / Trail.time;
            yield return null;
        }
        Trail.transform.position = hit.point;
        if (hit.transform){
            var aled = Instantiate(hit.transform.gameObject.GetComponent<HitImpact>().Impact, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(aled, 0.5f);
        }
        Destroy(Trail.gameObject, Trail.time);
    }
    private IEnumerator SpawnTrailNoHit(TrailRenderer Trail, Vector3 direction)
    {
        float time = 0;
        Vector3 startPosition = Trail.transform.position;
        while (time < 1)
        {
            Trail.transform.position = Vector3.Lerp(startPosition, direction * 100, time);
            time += Time.deltaTime / Trail.time;
            yield return null;
        }
        Trail.transform.position = Vector3.forward * 100;
        Destroy(Trail.gameObject, Trail.time);
    }
    public void Look()
    {
        // _sight.SetPosition(0, laserPos.position*0.01f);
        // // Todo raycast to colide
        // _sight.SetPosition(1, (-Vector3.right+(laserPos.position*0.01f))*1000);
        // _sight.enabled = true;
    }
    public void UnLook()
    {
        // if (_sight.enabled)
        //     _sight.enabled = false;
    }

    public IEnumerator reload()
    {
        if (!reloading){
            reloading = true;
            yield return new WaitForSecondsRealtime(reloadingTime);
            magazine = maxMagazine;
            reloading = false;
        }
    }
}
