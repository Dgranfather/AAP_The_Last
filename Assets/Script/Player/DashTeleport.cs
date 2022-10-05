using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
using TMPro;

public class DashTeleport : MonoBehaviour
{

    //dash (teleport)
    public float cdTime;
    private bool isCd = false;
    private float cdTimer = 0.0f;
    [SerializeField]
    private Image imageCd;
    [SerializeField]
    private TMP_Text textCd;
    private float nextDashTime = 0f;
    public float dashSpeed;
    public LayerMask outerLayer;
    public GameObject tpEffectPrefabs;
    //public GameObject fadeEffectPrefabs;
    //public GameObject fadeEffectLeftPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        textCd.gameObject.SetActive(false);
        imageCd.fillAmount = 0.0f;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (isCd)
        {
            ApplyCd();
        }
    }

    public void Dash()
    {
        if (GetComponent<MovementPlayer>().ButtonLeft)
        {
            //fungsi ngecek layer didepannya sesuai jarak dan layer yang ditentukan
            RaycastHit2D rayDash = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left), dashSpeed, outerLayer);
            if (rayDash)
            {
                //Debug.Log("hit something : " + rayDash.collider.name);
                //cantDashText(textCantDash);
            }
            else
            {
                if (Time.time >= nextDashTime)
                {
                    //fade animation 
                    /*GameObject instanceFadeLeft = (GameObject)Instantiate(fadeEffectLeftPrefabs, transform.position, Quaternion.identity);
                    Destroy(instanceFadeLeft, 2f);*/

                    //play particle effect
                    GameObject instanceDash = (GameObject)Instantiate(tpEffectPrefabs, transform.position, Quaternion.identity);
                    Destroy(instanceDash, 2f);

                    //camera shake
                    //cmShake.GenerateImpulse(0.7f);

                    transform.position = new Vector2(transform.position.x + (-dashSpeed), transform.position.y);
                    nextDashTime = Time.time + cdTime;
                    isCd = true;
                    textCd.gameObject.SetActive(true);
                    cdTimer = cdTime;
                }
            }
        }
        else if (GetComponent<MovementPlayer>().ButtonRight)
        {
            RaycastHit2D rayDash = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), dashSpeed, outerLayer);
            if (rayDash)
            {
                //Debug.Log("hit something : " + rayDash.collider.name);
                //cantDashText(textCantDash);
            }
            else
            {
                if (Time.time >= nextDashTime)
                {

                    //animation
                    /*GameObject instanceFade = (GameObject)Instantiate(fadeEffectPrefabs, transform.position, Quaternion.identity);
                    Destroy(instanceFade, 2f);*/

                    GameObject instanceDash = (GameObject)Instantiate(tpEffectPrefabs, transform.position, Quaternion.identity);
                    Destroy(instanceDash, 2f);

                    //cmShake.GenerateImpulse(0.7f);

                    transform.position = new Vector2(transform.position.x + dashSpeed, transform.position.y);
                    nextDashTime = Time.time + cdTime;
                    isCd = true;
                    textCd.gameObject.SetActive(true);
                    cdTimer = cdTime;
                }
            }
        }
    }

    public void ApplyCd()
    {
        cdTimer -= Time.deltaTime;

        if (cdTimer < 0.0f)
        {
            isCd = false;
            textCd.gameObject.SetActive(false);
            imageCd.fillAmount = 0.0f;
        }
        else
        {
            textCd.text = Mathf.RoundToInt(cdTimer).ToString();
            imageCd.fillAmount = cdTimer / cdTime;
        }
    }

}
