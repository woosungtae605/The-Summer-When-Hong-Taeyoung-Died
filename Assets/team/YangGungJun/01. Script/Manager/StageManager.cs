using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public List<Image> ImageList = new();
    private int ImageCount;
    private void Start()
    {
        ImageCount = ImageList.Count;
    }
}
