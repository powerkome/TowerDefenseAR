using UnityEngine;
using System.Collections;

public class Bin_Gun : MonoBehaviour
{
    public GameObject bulletEffect;

    Ray ray;
    RaycastHit hit;

    ParticleSystem bulEffectPS;
    AudioSource bulEffectAS;

    public GameObject explosionEffect;
    ParticleSystem expEffectPS;
    AudioSource expEffectAS;

    public Bin_ScoreManager scoreManager;
    
    void Start()
    {
        bulEffectPS = bulletEffect.GetComponent<ParticleSystem>();
        bulEffectAS = bulletEffect.GetComponent<AudioSource>();
        expEffectPS = explosionEffect.GetComponent<ParticleSystem>();
        expEffectAS = explosionEffect.GetComponent<AudioSource>();
    }

    void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            // 이렇게 하는 것과, 아래 레이캐스팅시 카메라의 위치와 포워드를 직접 넣어줘도 동일한 효과를 본다.
            //ray = new Ray(transform.position, transform.forward);
            //if(Physics.Raycast(transform.position, transform.forward, out hit, 1000))
            {
                //print(hit.transform.name);
                //GameObject obj = Instantiate(bulletEffect) as GameObject;
                //obj.transform.position = hit.point;
                if (hit.transform.name.Contains("Drone"))
                {
                    scoreManager.AddKillDrone();

                    Destroy(hit.transform.gameObject);
                    explosionEffect.transform.position = hit.point;
                    expEffectPS.Stop();
                    expEffectPS.Play();
                    expEffectAS.Stop();
                    expEffectAS.Play();
                }
                else
                {
                    bulletEffect.transform.position = hit.point;
                    bulEffectPS.Stop();
                    bulEffectPS.Play();
                    bulEffectAS.Stop();
                    bulEffectAS.Play();
                }
            }
        }
	}
}
