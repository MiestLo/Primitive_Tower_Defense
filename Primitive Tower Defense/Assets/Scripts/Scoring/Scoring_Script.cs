using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scoring_Script : MonoBehaviour
{
    public GameObject[] AllFoe = null;

    private int sumOfAllFoe =  0;
    private int currentSCore = 0;

    // Start is called before the first frame update
    void Start()
    {
        AllFoe = GameObject.FindGameObjectsWithTag("Foe");
        sumOfAllFoe = AllFoe.Length;
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject elem in AllFoe)
        {
            //To fix ... the elem won't be remvoe
            if (elem == null)
                AllFoe = DeleteWithArrayCopy(AllFoe, elem);
        }

        if(AllFoe.Length < sumOfAllFoe)
        {
            sumOfAllFoe = AllFoe.Length;
            currentSCore += 20;
            this.gameObject.GetComponent<TMP_Text>().text = "Score = " + currentSCore;
            //Not cool to doing like that, if other foes appear the counter of foe will be wrong
        }
    }


    public GameObject[] DeleteWithArrayCopy(GameObject[] inputArray, GameObject elementToRemove)
    {
        var indexToRemove = Array.IndexOf(inputArray, elementToRemove);
        if (indexToRemove < 0)
        {
            return inputArray;
        }
        var tempArray = new int[inputArray.Length - 1];
        Array.Copy(inputArray, 0, tempArray, 0, indexToRemove);
        Array.Copy(inputArray, indexToRemove + 1, tempArray, indexToRemove, inputArray.Length - indexToRemove - 1);
        return inputArray;
    }
}
