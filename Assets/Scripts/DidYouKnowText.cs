using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DidYouKnowText
{
    readonly string DYKText1 = "That six plastic bottles go into making one Shore Buddy.";
    readonly string DYKText2 = "That the life span of a sea turtle is 50-100 years.";
    readonly string DYKText3 = "That the Pacific Ocean has the most trash.";
    readonly string DYKText4 = "That it takes 450 years to take a bottle of plastic to degrade into the ocean.";
    readonly string DYKText5 = "That 200,000 tons of plastic straws flow into our oceans each year.";
    readonly string DYKText6 = "That 31,000 balloons enter the oceans around the U.S. each year.";
    readonly string DYKText7 = "More than 700 different species of marine animals have been found with ingested plastic.";
    readonly string DYKText8 = "Single use plastic bags take 1,000 years to decompose.";
    readonly string DYKText9 = "When plastic is not recycled, it makes its way into the ocean, harming and endangering marine animals.";
    readonly string DYKText10 = "The sun and wave break plastic into pieces, which are then eaten by many fish species.";
    readonly string DYKText11 = "Each person uses around 300 toothbrushes during their lifetime, adding 175 feet of plastic to the environment.";
    readonly string DYKText12 = "";
    readonly string DYKText13 = "";
    readonly string DYKText14 = "";
    readonly string DYKText15 = "";
    readonly string DYKText16 = "";
    readonly string DYKText17 = "";
    readonly string DYKText18 = "";

    public string GetDYKText(int index)
    {
        string[] DYKList = new string[18] { DYKText1, 
                                            DYKText2, 
                                            DYKText3, 
                                            DYKText4, 
                                            DYKText5, 
                                            DYKText6, 
                                            DYKText7, 
                                            DYKText8, 
                                            DYKText9, 
                                            DYKText10, 
                                            DYKText11, 
                                            DYKText12, 
                                            DYKText13, 
                                            DYKText14, 
                                            DYKText15, 
                                            DYKText16, 
                                            DYKText17, 
                                            DYKText18 };

        return DYKList[index - 1];
    }



}
