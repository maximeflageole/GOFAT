using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Ingredients { Eggs, Seasonings, Meat, Veggies, Bread, Cheese, Milk, Sauce };

public class GameManagerScript : MonoBehaviour {

    //The input associated with every ingredient.
    public List<IngredientScript> GameIngredients;
    public List<CookButtonName> IngredientButtons;

    public Material selectedMat;
    public Material defaultMat;

    public RecipesBook RecipesRef;
    public RECIPE KING_WANT_THAT;
    RECIPE tempRecipe;

    int kingSatisfaction;
    public float kingAnimTime;
    public TextMesh kingTextRef;

    // Use this for initialization
    void Start () {
        MixupIngredients();

        tempRecipe = new RECIPE();
        tempRecipe.recipe_bonuses = new List<Ingredients>();
        tempRecipe.recipe_ingredients = new List<Ingredients>();

        ChangeWhatKingWants();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) MixupIngredients();
	}

    void MixupIngredients()
    {
        List<IngredientScript> tempList = new List<IngredientScript>();
        tempList.AddRange(GameIngredients);
        foreach (var button in IngredientButtons)
        {
            int ii = Random.Range(0, tempList.Count);
            tempList[ii].ChangeButton(button);
            Debug.Log(tempList[ii].ingredientName + "   " + tempList[ii].ingredientInput);
            tempList.RemoveAt(ii);
        }
    }

    //Code to execute when King change his idea. Change the recipe's ref. Need some other things for randomization and to deal with animations
    public void ChangeWhatKingWants()
    {
        KING_WANT_THAT = RecipesRef.RECIPES[Random.Range(0, RecipesRef.RECIPES.Count)];

        //Important mais fait chier
        tempRecipe.recipe_ingredients.Clear();
        tempRecipe.recipe_bonuses.Clear();
        tempRecipe.recipe_bonuses.AddRange(KING_WANT_THAT.recipe_bonuses);
        tempRecipe.recipe_ingredients.AddRange(KING_WANT_THAT.recipe_ingredients);
        tempRecipe.recipe_name = KING_WANT_THAT.recipe_name;

        kingTextRef.text = "I WANT " + KING_WANT_THAT.recipe_name;
    }

    public int EvaluateRecipe(List<Ingredients> i_dish)
    {
        kingSatisfaction = 0;
        foreach (var ingredient in i_dish)
        {
            if(tempRecipe.recipe_ingredients.Remove(ingredient))
            {
                kingSatisfaction += 20;
            }
            else if (tempRecipe.recipe_bonuses.Remove(ingredient))
            {
                kingSatisfaction += 5;
            }
            else
            {
                kingSatisfaction -= 5;
            }
        }
        kingSatisfaction -= tempRecipe.recipe_ingredients.Count * 10;

        Invoke("ChangeWhatKingWants", kingAnimTime);
        return kingSatisfaction;
    }
}
