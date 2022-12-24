using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllNotation : MonoBehaviour
{
    public static string AfterNotation;
    public static float BeforeNotation;
    private static double NotationProgress;

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void Convert(float BeforeNotation){
        // Step 1
        if (BeforeNotation >= 1000000000000000)
        {
            NotationProgress = BeforeNotation / 1000000000000000;
        }
        else if (BeforeNotation >= 1000000000000)
        {
            NotationProgress = BeforeNotation / 1000000000000;
        }
        else if(BeforeNotation >= 1000000000)
        {
            NotationProgress = BeforeNotation / 1000000000;
        }
        else if(BeforeNotation >= 1000000)
        {
            NotationProgress = BeforeNotation / 1000000;
        }
        else if(BeforeNotation >= 1000)
        {
            NotationProgress = BeforeNotation / 1000;
        }

        // Step 2
        if (BeforeNotation >= 1000000000000000)
        {
            AfterNotation = NotationProgress.ToString("F2") + "q";
        }
        else if (BeforeNotation >= 1000000000000)
        {
            AfterNotation = NotationProgress.ToString("F2") + "T";
        }
        else if (BeforeNotation >= 1000000000)
        {
            AfterNotation = NotationProgress.ToString("F2") + "B";
        }
        else if(BeforeNotation >= 1000000)
        {
            AfterNotation = NotationProgress.ToString("F2") + "M";
        }
        else if(BeforeNotation >= 1000)
        {
            AfterNotation = NotationProgress.ToString("F2") + "K";
        } 
        else if (BeforeNotation < 1000)
        {
            AfterNotation = "" + BeforeNotation;
        }
        
    }
}
