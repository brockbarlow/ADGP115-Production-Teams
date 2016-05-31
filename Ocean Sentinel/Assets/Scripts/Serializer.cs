////////////////////////////////////////////////////////////////
//Austin Morrell//
//May 31 2016//
//ADGP-115 Production Teams//
///////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;

public class Serializer : MonoBehaviour {

    // This will be the Location of the Leaderboard's saved data.
    public string path;

    // This is a list of the scores the player has obtained.
    [XmlArray("Scores")]
    public List<float> Scores;

    // This is used for initialization.
	void Start ()
    {
        // I set the path equal to the location of the file SaveData.xml.
        path = System.Environment.CurrentDirectory + "\\SaveData.xml";
        // If the file SaveData.xml exists I will load it.
        if (File.Exists(path))
        {
            Load();
        }
	}
	
    // This serializes the information in the Scores list into the SaveData.xml.
    public void Save()
    {
        var serializer = new XmlSerializer(typeof(List<float>));
        var stream = new FileStream(path, FileMode.Create);
        serializer.Serialize(stream, Scores);
        stream.Close();
    }

    // This sets the list of scores equal to the list of scores in the SaveData.xml file.
    public void Load()
    {
        var serializer = new XmlSerializer(typeof(List<float>));
        var stream = new FileStream(path, FileMode.Open);
        Scores = serializer.Deserialize(stream) as List<float>;
        stream.Close();
    }
}
