using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {

    public GameObject camera;
    public int speed = 1;
    public float waitTime = 20;
    public string level;

	// Update is called once per frame
	void Update () {
        camera.transform.Translate(Vector3.down * Time.deltaTime * speed);
        StartCoroutine(waitFor());
	}
    IEnumerator waitFor() {
        yield return new WaitForSeconds(waitTime);
        Application.LoadLevel(level);
    }
    void OnGUI() {
        if (GUI.Button(new Rect(15, 15, 100, 50), "Back")) {
            Application.LoadLevel(level);
        }
    }
}
 