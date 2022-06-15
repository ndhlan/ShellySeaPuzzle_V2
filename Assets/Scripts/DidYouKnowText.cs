using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DidYouKnowText
{
    readonly string DYKText1 = "Six plastic bottles go into making one Shore Buddy.";
    readonly string DYKText2 = "It takes six recycled plastic bottles to make one Shore Buddies Stuffed Animal.";
    readonly string DYKText3 = "The recycled plastic bottles get sent to a recycling facility.";
    readonly string DYKText4 = "The recycled plastic bottles get shredded and turned into plastic pellets.";
    readonly string DYKText5 = "The pellets are melted and turned into yarn.";
    readonly string DYKText6 = "The upcycled plastic yarn is used to make the fluff inside stuffing and the soft outside of each Shore Buddy";
    readonly string DYKText7 = "By 2019 Shore Buddies saved over 300,000 plastic bottles from entering our oceans.";
    readonly string DYKText8 = "Single use plastic bags take 1,000 years to decompose.";
    readonly string DYKText9 = "When plastic is not recycled, it makes its way into the ocean, harming and endangering marine animals.";
    readonly string DYKText10 = "The sun and wave break plastic into pieces, which are then eaten by many fish species.";
    readonly string DYKText11 = "Each person uses around 300 toothbrushes during their lifetime, adding 175 feet of plastic to the environment.";
    readonly string DYKText12 = "200,000 tons of plastic straws flow into our oceans each year.";
    readonly string DYKText13 = "The life span of a sea turtle is 50-100 years.";
    readonly string DYKText14 = "More than 700 different species of marine animals have been found with ingested plastic.";
    readonly string DYKText15 = "31,000 balloons enter the oceans around the U.S. each year.";
    readonly string DYKText16 = "It takes 450 years to take a bottle of plastic to degrade into the ocean.";
    readonly string DYKText17 = "The Pacific Ocean has the most trash.";
    readonly string DYKText18 = "One million marine animals die each year in the world as a result of ingesting plastic.";
    //ADD NEW DYKTEXT STRING HERE


    public string GetDYKText(int index)
    {
        //ADD NEW DYKTEXT STRING TO THE ARRAY HERE

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
