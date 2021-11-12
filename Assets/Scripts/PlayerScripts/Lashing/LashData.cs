using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LashData : MonoBehaviour
{
    //This array holds the maximum number of lashings that can be held at any given time.
    //In order: Front, Back, Right, Left, Up, Down
    public static int[] maxLashings = new int[6] {3, 3, 3, 3, 3, 3};
    public static int[] currentLashings = new int[6] {0, 0, 0, 0, 0, 0};
}
