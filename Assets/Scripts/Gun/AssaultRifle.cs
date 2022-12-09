using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : MonoBehaviour
{
    private InputHandler _input;
    private LineRenderer _laser;
    public Transform reticle;
    public Bullet bulletPrefab;
    public float bulletSpeed = 10f;
    public float reloadingTime = 2f;
    public int maxMagazine = 30;
    public int magazine = 0;
    public float pellets;
    public ParticleSystem muzzleFlash;
    [SerializeField] private Vector3 spread = new Vector3(0.1f, 0.1f, 0.1f);
    public bool AddSpread;
    public float fireRate;
    private float nextShot = 0.0f;
    private bool reloading;
    public AudioClip otherClip;
    AudioSource audioData;

    private void Awake() {
        audioData = GetComponent<AudioSource>();
        _input = transform.parent.GetComponent<InputHandler>();
        // _laser = reticle.GetComponent<LineRenderer>();
        // _laser.enabled = false;
    }
    
    private void Start() {
        // reload();
    }
    public void Shoot()
    {
        audioData.clip = otherClip;
        if ( magazine > 0  && !reloading){
            if (nextShot + fireRate < Time.time){
                for (float i = 0; i < pellets; i++){
                    audioData.Play();
                    muzzleFlash.Emit(1);
                    Vector3 direction = GetDirection();

                    var bullet = Instantiate(bulletPrefab, reticle.position, transform.rotation);
                    bullet.GetComponent<Rigidbody>().velocity = direction * bulletSpeed;

                    // TrailRenderer trail = Instantiate(BulletTrail, laserPos.position, Quaternion.identity);

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

    public void Look()
    {
        // if (!_laser.enabled){
            // Debug.Log(_laser.enabled);
            // _laser.SetPosition(0, reticle.position);
            // _laser.SetPosition(1, _input.MousePositionGround);
            // _laser.enabled = true;
        // }
    }
    public void UnLook()
    {
        // if (_laser.enabled)
        //     _laser.enabled = false;
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
