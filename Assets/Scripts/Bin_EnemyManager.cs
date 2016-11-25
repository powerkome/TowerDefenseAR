using UnityEngine;
using System.Collections;

public class Bin_EnemyManager : MonoBehaviour
{
    public GameObject dronePrefab;

    public float respwanTimeMin = 1;
    public float respwanTimeMax = 3;

	void Start ()
    {
        StartCoroutine(ReSpwanDrone());
	}

    IEnumerator ReSpwanDrone()
    {
        while(true)
        {
            GameObject obj = Instantiate(dronePrefab) as GameObject;
            obj.transform.position = transform.position;
            obj.transform.SetParent(transform);

            yield return new WaitForSeconds(Random.Range(respwanTimeMin, respwanTimeMax));
        }
    }
}
