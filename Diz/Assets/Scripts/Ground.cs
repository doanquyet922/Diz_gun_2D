using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public void Changelayer(int layerInt)
    {
        gameObject.layer = layerInt;
    }
}
