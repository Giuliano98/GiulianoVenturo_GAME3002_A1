using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_Target : MonoBehaviour
{
    Vector3 scaleObj;
    private float timeToDestroy = 6.0f;
    private float randomScale;

    private int targetPointsKill;

    private void Awake()
    {
        scaleObj = transform.localScale;
    }

    void Start()
    {
        randomScale = Random.Range(0, 3);
        targetPointsKill = 4 - (int)randomScale;
        transform.localScale = new Vector3(scaleObj.x + randomScale, scaleObj.y, scaleObj.z + randomScale);
        Destroy(gameObject, timeToDestroy);
    }
     
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreManager.instance.AddPoints(targetPointsKill);
            Destroy(gameObject);
        }
    }    
}
