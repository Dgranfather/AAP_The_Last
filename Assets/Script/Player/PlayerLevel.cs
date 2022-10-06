using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevel : MonoBehaviour
{
    public int currentLevel;

    private LevelPlayer theLevelPlayer;

    // Start is called before the first frame update
    void Start()
    {
        theLevelPlayer.SetCurrentLevelText(currentLevel);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       // theLevelPlayer.SetCurrentLevelText(currentLevel);
    }
}
