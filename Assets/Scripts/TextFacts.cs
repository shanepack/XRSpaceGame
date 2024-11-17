using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using TMPro;

public class FactGenerator : MonoBehaviour
{
     public TextMeshProUGUI factText;
    public string[] facts = {"The moon rotates on its own axis at the same rate as it orbits Earth. The Moon’s motion in space can be tracked through moon phases, eclipses, and supermoons.",
                            "The Sun is a hot glowing ball consisting of gases. The Sun plays a vital role in making life sustainable on Earth and is responsible for holding our entire solar system together.",
                            "The exosphere is the outermost layer of the Earth’s atmosphere. The large and cold exosphere does not contain air to breathe.",
                            "The troposphere is the innermost layer of the Earth’s atmosphere. The air in the troposphere consists of 78% nitrogen and 21% oxygen.",
                            "Mars is home to the tallest mountain in the solar system."
                            };
    // Start is called before the first frame update
    void Start()
    {
        System.Random random = new System.Random();
        int randomIndex = random.Next(facts.Length);
        factText.text = facts[randomIndex];
        Debug.Log(facts[randomIndex]);
    }
}