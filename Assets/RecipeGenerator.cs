using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeGenerator : MonoBehaviour
{
    private enum Ingredient
    {
        Gear,
        Lettuce,
        Tomato,
        Bread
    }

    private void shuffle(int[] list)
    {
        for (int t = 0; t < list.Length; t++)
        {
            int tmp = list[t];
            int r = Random.Range(t, list.Length);
            list[t] = list[r];
            list[r] = tmp;
        }
    }

    private Texture2D makeOrder(List<Ingredient> ingredients)
    {
        int textureWidth = 20;
        int textureHeight = 20;

        Dictionary<Ingredient, Color> colors = new Dictionary<Ingredient, Color>();
        colors.Add(Ingredient.Gear, new Color(128, 128, 128));
        colors.Add(Ingredient.Lettuce, new Color(131, 197, 60));
        colors.Add(Ingredient.Tomato, new Color(255, 55, 55));
        colors.Add(Ingredient.Bread, new Color(255, 216, 161));

        Texture2D order = new Texture2D(textureWidth, textureHeight);

        Color currentColor;

        for (int j = 0; j < textureWidth; j++)
        {
            order.SetPixel()
        }

        return order;
    }

    // Start is called before the first frame update
    void Start()
    {
        int[] foodIndices = new int[] { 0, 1, 2, 3 };
        shuffle(foodIndices);
        int numIngredients = Random.Range(0, 4);

        List<Ingredient> ingredientList = new List<Ingredient>();
        for (int i = 0; i < numIngredients; i++)
        {
            ingredientList.Add((Ingredient)foodIndices[i]);
        }

        Texture2D order = makeOrder(ingredientList);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
