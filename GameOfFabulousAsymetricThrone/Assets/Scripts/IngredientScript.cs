using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IngredientScript : MonoBehaviour {

    public Ingredients ingredientName;
    public CookButtonName ingredientInput;
    public TextMesh inputText;

    GameManagerScript GMRef;

	// Use this for initialization
	void Start () {
        GMRef = FindObjectOfType<GameManagerScript>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ChangeButton(CookButtonName i_button)
    {
        ingredientInput = i_button;
        inputText.text = ingredientInput.ToString();
    }

    public Ingredients SelectIngredient(float i_timer)
    {
        GetComponent < Renderer >().material = GMRef.selectedMat;
        Invoke("UnselectIngredient", i_timer);
        return ingredientName;
    }

    void UnselectIngredient()
    {
        GetComponent<Renderer>().material = GMRef.defaultMat;
    }
}
