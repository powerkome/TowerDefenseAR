using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {
    public Transform firePos;
    LineRenderer lr;
    public Transform bulletImpact;
    public Transform explosion;
    ParticleSystem bulletps;
    ParticleSystem explosionPs;

    public bool isVR = false;
    // Use this for initialization
    void Start () {
        lr = GetComponent<LineRenderer>();
        lr.enabled = false;
        if (bulletImpact)
            bulletps = bulletImpact.GetComponent<ParticleSystem>();
        if (explosion)
            explosionPs = explosion.GetComponent<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update () {
        Ray ray = isVR ? new Ray(Camera.main.transform.position, Camera.main.transform.forward) : 
            Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        lr.enabled = false;
        if (Physics.Raycast(ray, out hitInfo))
        {
            Vector3 dir = hitInfo.transform.position - firePos.position;
            Debug.DrawRay(transform.position, dir.normalized * 100);
            
            if (Input.GetButtonDown("Fire1"))
            {
                //GameObject bullet = Instantiate(bulletPrefab);
                //bullet.transform.position = firePos.position;
                //bullet.transform.forward = dir.normalized;
                if (bulletImpact)
                {
                    bulletImpact.up = hitInfo.normal;
                    bulletImpact.position = hitInfo.point + hitInfo.normal * 0.2f;
                    bulletps.Stop();
                    bulletps.Play();
                }
                if (hitInfo.transform.name.Contains("Drone"))
                {
                    if (explosion)
                    {
                        explosion.position = hitInfo.transform.position;
                        explosionPs.Stop();
                        explosionPs.Play();
                        explosion.GetComponent<AudioSource>().Stop();
                        explosion.GetComponent<AudioSource>().Play();

                    }
                    StartCoroutine(DestroyDrone(hitInfo.transform.gameObject));
                    //bullet.transform.forward = dir.normalized;
                }
                else
                {
                    if (bulletImpact)
                    {
                        bulletImpact.GetComponent<AudioSource>().Stop();
                        bulletImpact.GetComponent<AudioSource>().Play();
                    }
                }
            }
        }
	}

    IEnumerator DestroyDrone(GameObject hitInfo)
    {
        lr.enabled = true;
        lr.SetPosition(0, firePos.position);
        lr.SetPosition(1, hitInfo.transform.position);
        yield return new WaitForSeconds(0.2f);
        Destroy(hitInfo);
        lr.enabled = false;
    }
}
