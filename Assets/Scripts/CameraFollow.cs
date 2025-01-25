using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] float boundary=5;
    public GameObject player;
    [SerializeField] float scrollspeed = 5;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 p = transform.position;
        if(player.gameObject.transform.position.y<=transform.position.y-boundary && transform.position.y>=-8.5)
        {
            p.y -= scrollspeed*Time.deltaTime;
            transform.position = p;
        }

        if (player.gameObject.transform.position.y >= transform.position.y + boundary && transform.position.y <= 0)
        {
            p.y += scrollspeed * Time.deltaTime;
            transform.position = p;
        }

        if (player.gameObject.transform.position.x <= transform.position.x - boundary && transform.position.x >= -14)
        {
            p.x -= scrollspeed * Time.deltaTime;
            transform.position = p;
        }

        if (player.gameObject.transform.position.x >= transform.position.x + boundary && transform.position.x <= 14)
        {
            p.x += scrollspeed * Time.deltaTime;
            transform.position = p;
        }
    }
}
