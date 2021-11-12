using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxCount : MonoBehaviour
{
    public Text text;
    public int count;
    public int total;

    private void Update()
    {
        text.text = count + "/" + total;
    }

    public void CountIncrease()
    {
        count++;
    }
}
