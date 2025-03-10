using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenShots;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenShots)
            {
                canFire = true;
                timer = 0;
            }
        }

        if (canFire)
        {
            canFire = false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        }
    }
}
