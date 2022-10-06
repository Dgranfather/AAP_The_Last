using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelPlayer : MonoBehaviour
{
    public Text currentLevelValue;

    private PlayerStats thePlayerStats;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetCurrentLevelText(int value)
    {
        currentLevelValue.text = value.ToString();
    }
}
