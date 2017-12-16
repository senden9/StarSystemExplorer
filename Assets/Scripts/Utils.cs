﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils {
    public static float generateNormalRandom(float mu, float sigma)
    {
        // Inverse probability integral transform magic ✨
        float rand1 = Random.Range(0.0f, 1.0f);
        float rand2 = Random.Range(0.0f, 1.0f);

        float n = Mathf.Sqrt(-2.0f * Mathf.Log(rand1)) * Mathf.Cos((2.0f * Mathf.PI) * rand2);

        return (mu + sigma * n);
    }
}
