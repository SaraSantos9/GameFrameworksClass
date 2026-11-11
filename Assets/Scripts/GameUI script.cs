using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;

public class GameUI : MonoBehaviour
{
    private Label cropsLabel;
    private Label scoreLabel;
    private int totalCropsPlaced = 0;
    private int totalScore = 0;

    private List<VisualElement> fullHearts;
    private List<VisualElement> emptyHearts;


    void Awake()
    {
        UIDocument uiDocument = GetComponent<UIDocument>();
        VisualElement root = uiDocument.rootVisualElement;

        cropsLabel = root.Q<Label>("crops-text-label");
        scoreLabel = root.Q<Label>("score-text-label");
        fullHearts = root.Query<VisualElement>(name: "heart-image").ToList();
        emptyHearts = root.Query<VisualElement>(name: "heart-empty").ToList();






        UpdateDisplay();

    }

    public void UpdateHearts(int health)
    {
        for (int i = 0; i < fullHearts.Count; i++)
        {
            if (health <= i)
            {
                fullHearts[i].style.opacity = 0;
                emptyHearts[i].style.visibility = Visibility.Visible;
                Debug.Log("Showing empty heart " + i);
            }
        }
    }



    public void UpdateCropsPlaced(int cropsPlaced)
    {
        totalCropsPlaced = cropsPlaced;
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        if (cropsLabel != null)
            cropsLabel.text = "Crops placed: " + totalCropsPlaced;

        if (scoreLabel != null)
            scoreLabel.text = "Score: " + totalScore;
    }
    public void AddScore(int points)
    {
        totalScore += points;
        UpdateDisplay();
    }
    public void RemoveScore(int points)
    {
        totalScore -= points;

        if (totalScore < 0)
        {
            totalScore = 0;
        }


        UpdateDisplay();




    }
}
