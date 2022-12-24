using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDescription : MonoBehaviour
{   
    [SerializeField]
    public Image[] FoodImage;

    // Description Windows
    public GameObject descriptionWindow;
    public Image ItemImage;
    public Text ItemName;
    public Text ItemDesc;
    public Text HungerPlus;
    public Text FunPlus;
    public Text EnergyPlus;

    public void ItemDesc00()
    {   
        descriptionWindow.gameObject.SetActive(true);
        ItemImage.sprite = FoodImage[0].sprite;
        ItemName.text = "Apple Pie";
        ItemDesc.text = "Sweet food made from apples cooked under or inside pastry.";
        HungerPlus.text = "+5";
        FunPlus.text = "+5";
        EnergyPlus.text = "+3";
    }
    public void ItemDesc01()
    {
        descriptionWindow.gameObject.SetActive(true);
        ItemImage.sprite = FoodImage[1].sprite;
        ItemName.text = "Bread";
        ItemDesc.text = "Food made from flour, water, and usually yeast, mixed together and baked.";
        HungerPlus.text = "+5";
        FunPlus.text = "+5";
        EnergyPlus.text = "+3";
    }
    public void ItemDesc02()
    {
        descriptionWindow.gameObject.SetActive(true);
        ItemImage.sprite = FoodImage[2].sprite;
        ItemName.text = "Baguette";
        ItemDesc.text = "Long, thin loaf of French bread.";
        HungerPlus.text = "+10";
        FunPlus.text = "+5";
        EnergyPlus.text = "+3";
    }
    public void ItemDesc03()
    {
        descriptionWindow.gameObject.SetActive(true);
        ItemImage.sprite = FoodImage[3].sprite;
        ItemName.text = "Bun";
        ItemDesc.text = "Sweet or plain small bread.";
        HungerPlus.text = "+5";
        FunPlus.text = "+0";
        EnergyPlus.text = "+1";
    }
    public void ItemDesc04()
    {
        descriptionWindow.gameObject.SetActive(true);
        ItemImage.sprite = FoodImage[4].sprite;
        ItemName.text = "Bacon";
        ItemDesc.text = "Salted or smoked meat which comes from the back or sides of a pig.";
        HungerPlus.text = "+10";
        FunPlus.text = "+10";
        EnergyPlus.text = "+5";
    }
    public void ItemDesc05()
    {
        descriptionWindow.gameObject.SetActive(true);
        ItemImage.sprite = FoodImage[5].sprite;
        ItemName.text = "Burrito";
        ItemDesc.text = "Mexican dish consisting of a tortilla rolled around a filling, typically of beans or ground or shredded beef.";
        HungerPlus.text = "+15";
        FunPlus.text = "+10";
        EnergyPlus.text = "+0";
    }
    public void ItemDesc06()
    {
        descriptionWindow.gameObject.SetActive(true);
        ItemImage.sprite = FoodImage[6].sprite;
        ItemName.text = "Steak";
        ItemDesc.text = "Slice of meat, typically beef, usually cut thick and across the muscle grain and served broiled or fried.";
        HungerPlus.text = "+15";
        FunPlus.text = "+15";
        EnergyPlus.text = "+5";
    }
    public void ItemDesc07()
    {
        descriptionWindow.gameObject.SetActive(true);
        ItemImage.sprite = FoodImage[7].sprite;
        ItemName.text = "Bagel";
        ItemDesc.text = "Dense bread roll in the shape of a ring, made by boiling dough and then baking it.";
        HungerPlus.text = "+15";
        FunPlus.text = "+5";
        EnergyPlus.text = "+0";
    }
    public void ItemDesc08()
    {
        descriptionWindow.gameObject.SetActive(true);
        ItemImage.sprite = FoodImage[8].sprite;
        ItemName.text = "Cheese Cake";
        ItemDesc.text = "Dessert consisting of a creamy filling usually containing cheese baked in a pastry or pressed-crumb shell.";
        HungerPlus.text = "+20";
        FunPlus.text = "+10";
        EnergyPlus.text = "+0";
    }
    public void ItemDesc09()
    {
        descriptionWindow.gameObject.SetActive(true);
        ItemImage.sprite = FoodImage[9].sprite;
        ItemName.text = "Cheese Puff";
        ItemDesc.text = "Sensational snack eaten for pure snacking or can be thrown at other people to show affection.";
        HungerPlus.text = "+15";
        FunPlus.text = "+5";
        EnergyPlus.text = "+0";
    }
    public void ItemDesc10()
    {
        descriptionWindow.gameObject.SetActive(true);
        ItemImage.sprite = FoodImage[10].sprite;
        ItemName.text = "Chocolate";
        ItemDesc.text = "Made from roasted and ground cacao seed kernels, that is available as a liquid, solid or paste.";
        HungerPlus.text = "+15";
        FunPlus.text = "+10";
        EnergyPlus.text = "+5";
    }
    public void ItemDesc11()
    {
        descriptionWindow.gameObject.SetActive(true);
        ItemImage.sprite = FoodImage[11].sprite;
        ItemName.text = "Cookies";
        ItemDesc.text = "Small sweet cake, typically round and flat and having a crisp or chewy texture.";
        HungerPlus.text = "+10";
        FunPlus.text = "+5";
        EnergyPlus.text = "+0";
    }
    public void ItemDesc12()
    {
        descriptionWindow.gameObject.SetActive(true);
        ItemImage.sprite = FoodImage[12].sprite;
        ItemName.text = "Chocolate Cake";
        ItemDesc.text = "Cake flavored with melted chocolate, cocoa powder, or both.";
        HungerPlus.text = "+20";
        FunPlus.text = "+15";
        EnergyPlus.text = "+10";
    }
    public void ItemDesc13()
    {
        descriptionWindow.gameObject.SetActive(true);
        ItemImage.sprite = FoodImage[13].sprite;
        ItemName.text = "Curry";
        ItemDesc.text = "Dish of meat, vegetables, etc., cooked in an Indian-style sauce of hot-tasting spices.";
        HungerPlus.text = "+20";
        FunPlus.text = "+10";
        EnergyPlus.text = "+10";
    }
    public void ItemDesc14()
    {
        descriptionWindow.gameObject.SetActive(true);
        ItemImage.sprite = FoodImage[14].sprite;
        ItemName.text = "Donuts";
        ItemDesc.text = "Small fried cake of sweetened dough, typically in the shape of a ball or ring.";
        HungerPlus.text = "+15";
        FunPlus.text = "+10";
        EnergyPlus.text = "+3";
    }
    public void ItemDesc15()
    {
        descriptionWindow.gameObject.SetActive(true);
        ItemImage.sprite = FoodImage[15].sprite;
        ItemName.text = "Dumplings";
        ItemDesc.text = "Small savory ball of dough (usually made with suet) which may be boiled, fried, or baked in a casserole.";
        HungerPlus.text = "+15";
        FunPlus.text = "+10";
        EnergyPlus.text = "+5";
    }
    public void ItemDesc16()
    {
        descriptionWindow.gameObject.SetActive(true);
        ItemImage.sprite = FoodImage[16].sprite;
        ItemName.text = "Fried Egg";
        ItemDesc.text = "Egg cooked in oil or fat.";
        HungerPlus.text = "+15";
        FunPlus.text = "+5";
        EnergyPlus.text = "+0";
    }
    public void ItemDesc17()
    {
        descriptionWindow.gameObject.SetActive(true);
        ItemImage.sprite = FoodImage[17].sprite;
        ItemName.text = "Egg Salad";
        ItemDesc.text = "Dish made primarily of chopped hard-boiled or scrambled eggs, mustard, and mayonnaise.";
        HungerPlus.text = "+30";
        FunPlus.text = "+15";
        EnergyPlus.text = "+5";
    }
    public void ItemDesc18()
    {
        descriptionWindow.gameObject.SetActive(true);
        ItemImage.sprite = FoodImage[18].sprite;
        ItemName.text = "Egg Tart";
        ItemDesc.text = "Baked pastry commonly made in Hong Kong, Macau and other parts of Asia consisting of an outer pastry crust that is filled with egg custard.";
        HungerPlus.text = "+30";
        FunPlus.text = "+15";
        EnergyPlus.text = "+0";
    }
    public void ItemDesc19()
    {
        descriptionWindow.gameObject.SetActive(true);
        ItemImage.sprite = FoodImage[19].sprite;
        ItemName.text = "French Fries";
        ItemDesc.text = "Served hot, either soft or crispy, and are generally eaten as part of lunch or dinner or by themselves as a snack.";
        HungerPlus.text = "+20";
        FunPlus.text = "+20";
        EnergyPlus.text = "+0";
    }

}
