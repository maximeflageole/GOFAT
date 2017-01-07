using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Les différents inputs du cook
public enum CookButtonName { A, B, X, Y, RA, RB, RX, RY };

public class CookScript : MonoBehaviour {

    //Different states in which the cook can be­. He is either cooking (free to do inputs), disabled (start and end of the game) or in animation
    public enum CookState { Cooking, InAnim, Disabled };

    CookButtonName lastInput;
    bool isRTOn;
    CookState myState = CookState.Disabled;
    public List<Ingredients> currentRecipe;
    float animTime = 0.5f;

    GameManagerScript GMRef;

    // Use this for initialization
    void Start () {
        GMRef = FindObjectOfType<GameManagerScript>();
        PutOnCooldown(2);
	}
	
	// Update is called once per frame
	void Update () {
	switch (myState)
        {
            case CookState.Disabled:
                break;
            case CookState.InAnim:
                break;
            case CookState.Cooking:
                UpdateInputs();
                break;
            default:
                break;
        }
	}

    void UpdateInputs()
    {
        if (Input.GetAxis("RightTrigger") > 0) isRTOn = true;
        else isRTOn = false;

        if (Input.GetButtonDown("Jump"))
        {
            if (isRTOn)
                FindIngredient(CookButtonName.RY);
            else
                FindIngredient(CookButtonName.Y);
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            if (isRTOn)
                FindIngredient(CookButtonName.RB);
            else
                FindIngredient(CookButtonName.B);
        }
        else if (Input.GetButtonDown("Fire3"))
        {
            if (isRTOn)
                FindIngredient(CookButtonName.RX);
            else
                FindIngredient(CookButtonName.X);
        }
        else if (Input.GetButtonDown("Fire1"))
        {
            if (isRTOn)
                FindIngredient(CookButtonName.RA);
            else
                FindIngredient(CookButtonName.A);
        }
        else if (Input.GetButtonDown("RightB"))
        {
            SendPlate();
        }
    }

    void PutOnCooldown(float i_time)
    {
        myState = CookState.Disabled;
        Invoke("PutOffCooldown", i_time);   
    }

    void PutOffCooldown()
    {
        myState = CookState.Cooking;
    }

    void FindIngredient(CookButtonName i_button)
    {
        foreach(var ingredient in GMRef.GameIngredients)
        {
            if(ingredient.ingredientInput == i_button)
            {
                currentRecipe.Add(ingredient.SelectIngredient(animTime));
                PutOnCooldown(animTime);
            }
        }
    }

    void SendPlate()
    {
        Debug.Log(GMRef.EvaluateRecipe(currentRecipe));
        PutOnCooldown(animTime);
        currentRecipe.Clear();
    }
}
