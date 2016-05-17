using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Leaderboard : MonoBehaviour {

    private List<float> Scores;
    [SerializeField]
    private Text text;
    [SerializeField]
    private Canvas Can;
    private float Distance;

    void Start ()
    {
        Distance = 1;
        Load();
        ShowLeaderboard();
	}

    void Update ()
    {
        if (Input.GetKeyDown("b"))
        {
            SceneManager.LoadScene("Main");
        }
    }

    void Load()
    {
        var serializer = new XmlSerializer(typeof(List<float>));
        var stream = new FileStream(System.Environment.CurrentDirectory + "\\SaveData.xml", FileMode.Open);
        Scores = serializer.Deserialize(stream) as List<float>;
        stream.Close();
    }

    void ShowLeaderboard()
    {
        for (int i = 0; i < Scores.Count; i++)
        {
            if (i == Scores.Count)
            {
                break;
            }

            Text UIElement = Instantiate(text, text.transform.position, text.transform.rotation) as Text;
            UIElement.transform.parent = Can.transform;
            UIElement.transform.position = new Vector3(UIElement.transform.position.x, UIElement.transform.position.y - 60 * Distance, UIElement.transform.position.z);
            UIElement.text = i + ".     " + Scores[i];
            Distance++;
        }
    }
}
