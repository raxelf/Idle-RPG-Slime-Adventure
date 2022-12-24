using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFix : MonoBehaviour
{
    public Button Expand;
    public Button Shrink;

    public Button Home;
    public Button MobFight;
    public Button Shop;
    public Button Skin;

    public bool ClickedHome;
    public bool ClickedMobFight;
    public bool ClickedShop;
    public bool ClickedSkin;

    // RSS
    public Button rssExpand;
    public Button rssShrink;

    // Color Button
    public Button colorExpand;
    public Button colorShrink;

    // Start is called before the first frame update
    void Start()
    {
        ClickedHome = true;
        ClickedMobFight = false;
        ClickedShop = false;
        ClickedSkin = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickExpand()
    {
        StartCoroutine(ClickedExpand());
    }

    IEnumerator ClickedExpand()
    {
        Shrink.interactable = false;
        yield return new WaitForSeconds(1f);
        Shrink.interactable = true;
    }

    public void ClickShrink()
    {
        StartCoroutine(ClickedShrink());
    }

    IEnumerator ClickedShrink()
    {
        Expand.interactable = false;
        yield return new WaitForSeconds(1f);
        Expand.interactable = true;
    }

    public void ClickNavbar()
    {
        StartCoroutine(ClickedNavbar());
    }

    public void ClickHome()
    {
        ClickedHome = true;
        ClickedMobFight = false;
        ClickedShop = false;
        ClickedSkin = false;
    }

    public void ClickMobFight()
    {
        ClickedHome = false;
        ClickedMobFight = true;
        ClickedShop = false;
        ClickedSkin = false;
    }

    public void ClickShop()
    {
        ClickedHome = false;
        ClickedMobFight = false;
        ClickedShop = true;
        ClickedSkin = false;
    }

    public void ClickSkin()
    {
        ClickedHome = false;
        ClickedMobFight = false;
        ClickedShop = false;
        ClickedSkin = true;
    }

    IEnumerator ClickedNavbar()
    {
        Home.interactable = false;
        MobFight.interactable = false;
        Shop.interactable = false;
        Skin.interactable = false;
        yield return new WaitForSeconds(0.3f);
        if(!ClickedHome)
        {
            Home.interactable = true;
        }
        
        if(!ClickedMobFight)
        {
            MobFight.interactable = true;
        }

        if(!ClickedShop)
        {
            Shop.interactable = true;
        }

        if(!ClickedSkin)
        {
            Skin.interactable = true;
        }
    }


    // RSS Button
    public void ClickRssExpand()
    {
        StartCoroutine(ClickedRssExpand());
    }
    public void ClickRssShrink()
    {
        StartCoroutine(ClickedRssShrink());
    }

    IEnumerator ClickedRssExpand()
    {
        rssShrink.interactable = false;
        yield return new WaitForSeconds(1f);
        rssShrink.interactable = true;
    }
    IEnumerator ClickedRssShrink()
    {
        rssExpand.interactable = false;
        yield return new WaitForSeconds(1f);
        rssExpand.interactable = true;
    }


    // Color Button Change
    public void ClickColorExpand()
    {
        StartCoroutine(ClickedColorExpand());
    }
    public void ClickColorShrink()
    {
        StartCoroutine(ClickedColorShrink());
    }

    IEnumerator ClickedColorExpand()
    {
        colorShrink.interactable = false;
        yield return new WaitForSeconds(1f);
        colorShrink.interactable = true;
    }
    IEnumerator ClickedColorShrink()
    {
        colorExpand.interactable = false;
        yield return new WaitForSeconds(1f);
        colorExpand.interactable = true;
    }
}
