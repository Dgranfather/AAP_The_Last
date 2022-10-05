using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CammeraFollow : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] float timeOfset;
    [SerializeField] Vector2 posOffset;
    
    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        Vector3 starPos = transform.position;

        Vector3 endPos = Player.transform.position;
        endPos.x += posOffset.x;
        endPos.y += posOffset.y;
        endPos.z = -10;
        transform.position = Vector3.Lerp(starPos, endPos, timeOfset * Time.deltaTime);
    }
}
