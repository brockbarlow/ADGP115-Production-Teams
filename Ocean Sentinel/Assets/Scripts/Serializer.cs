using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;

public class Serializer : MonoBehaviour {

    public string path;

    [XmlArray("Scores")]
    public List<float> Scores;

	void Start ()
    {
        path = System.Environment.CurrentDirectory + "\\SaveData.xml";
        if (File.Exists(path))
        {
            Load();
        }
	}
	
    public void Save()
    {
        var serializer = new XmlSerializer(typeof(List<float>));
        var stream = new FileStream(path, FileMode.Create);
        serializer.Serialize(stream, Scores);
        stream.Close();
    }

    public void Load()
    {
        var serializer = new XmlSerializer(typeof(List<float>));
        var stream = new FileStream(path, FileMode.Open);
        Scores = serializer.Deserialize(stream) as List<float>;
        stream.Close();
    }
}
