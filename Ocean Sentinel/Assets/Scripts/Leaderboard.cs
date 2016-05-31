using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
////////////////////////////////////////////////////////////////
//Austin Morrell//
//May 31 2016//
//ADGP-115 Production Teams//
///////////////////////////////////////////////////////////////

using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Leaderboard : MonoBehaviour {

    // This is the list of scores to be displayed.
    private List<float> Scores;
    // This is the UI element I will use for displaying.
    [SerializeField]
    private Text text;
    // This is the canvas I will display UI elements on.
    [SerializeField]
    private Canvas Can;
    // This is the distance I will separate the UI elements by.
    private float Distance;

    // This is used for initialization.
    void Start ()
    {
        // I set the distance to an interger of 1.
        Distance = 1;
        // I load from the SaveData.xml.
        Load();
        // And then display that information.
        ShowLeaderboard();
	}

    void Update ()
    {
        // Will return the user to the main menu after pressing B.
        if (Input.GetKeyDown("b") || Input.GetButtonDown("B"))
        {
            SceneManager.LoadScene("Main");
        }
    }

    // This sets the list of scores equal to the list of scores in the SaveData.xml file.
    void Load()
    {
        var serializer = new XmlSerializer(typeof(List<float>));
        var stream = new FileStream(System.Environment.CurrentDirectory + "\\SaveData.xml", FileMode.Open);
        Scores = serializer.Deserialize(stream) as List<float>;
        stream.Close();
    }

    void ShowLeaderboard()
    {
        // Continues for as long as the list Scores is OR until 8 have been displayed.
        for (int i = 0; i < Scores.Count && i < 8; i++)
        {
            // Makes sure it doesn't display any more than 8 scores.
            if (i == Scores.Count || i > 8)
            {
                break;
            }

            // Instantiates a Score's UI element.
            Text UIElement = Instantiate(text, text.transform.position, text.transform.rotation) as Text;
            // Parent the UI element to the canvas.
            UIElement.transform.parent = Can.transform;
            // Changes the position of the UI element on the canvas.
            UIElement.transform.position = new Vector3(UIElement.transform.position.x, UIElement.transform.position.y - 60 * Distance, UIElement.transform.position.z);
            // Changes what the UI element's text says to the score.
            UIElement.text = (i + 1) + ".     " + Scores[i];
            // Increases the distance between the UI element and the next one.
            Distance++;
        }
    }
}
