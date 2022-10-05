using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackGround : MonoBehaviour
{
    [SerializeField] private Vector2 parralax;
    [SerializeField] private bool infiteHoriz;
    [SerializeField] private bool infiteVeri;

    [Range(-1f,1f)]
    public float scrollSpeed = 0.5f;
    private float offset;
    private Material mat;

    private Transform cam;
    private Vector3 lastCamPos;
    private float textureUniteSizeX;
    private float textureUniteSizeY;
    
     void Start()
    {
        cam = Camera.main.transform;
        lastCamPos = cam.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUniteSizeX = texture.width / sprite.pixelsPerUnit;
        textureUniteSizeY = texture.height / sprite.pixelsPerUnit;
        mat = GetComponent<Renderer>().material;
    }

    
     void FixedUpdate()
    {
        Vector3 deltaMovement = cam.position - lastCamPos;
        transform.position += new Vector3(deltaMovement.x * parralax.x, deltaMovement.y * parralax.y);
        lastCamPos = cam.position;
        offset += (Time.deltaTime * scrollSpeed) / 10f;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));

        if (infiteHoriz) {
            if (Mathf.Abs(cam.position.x - transform.position.x) >= textureUniteSizeX)
            {
                float offsetPositionX = (cam.position.x - transform.position.x) % textureUniteSizeX;
                transform.position = new Vector3(cam.position.x + offsetPositionX, transform.position.y);
            }
        }
        

        if (infiteVeri) {
            if (Mathf.Abs(cam.position.y - transform.position.y) >= textureUniteSizeY)
            {
                float offsetPositionY = (cam.position.y - transform.position.y) % textureUniteSizeY;
                transform.position = new Vector3(transform.position.x, cam.position.y + offsetPositionY);
            }
        }
        
    }
}
