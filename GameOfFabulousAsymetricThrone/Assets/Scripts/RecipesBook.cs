using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public struct RECIPE
{
    public string recipe_name;
    public List<Ingredients> recipe_ingredients;
    public List<Ingredients> recipe_bonuses;
}

public class RecipesBook : MonoBehaviour {

    public List<RECIPE> RECIPES;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
