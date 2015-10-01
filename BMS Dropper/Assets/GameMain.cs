using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public class GameMain : MonoBehaviour {

    private string assetName = "out";
    private double bpm = 150;
    private int inote = 0;
    private IList notes;

    public GameObject RedNote;
    public GameObject WhiteNote;
    public GameObject BlueNote;
    public AudioSource BGM;
    public Transform target;
    public float dropHeight = 20;
    private float accAngle=0;
    private Vector3 v;
    // Use this for initialization
    void Start () {
        BGM = gameObject.AddComponent<AudioSource>();
        BGM.playOnAwake = false;
        BGM.clip = (AudioClip)Resources.Load("DYNAMITE RAVE");

         v = GameObject.Find("Bar").transform.position;
        RedNote = (GameObject)Resources.Load("Rednote");
        WhiteNote = (GameObject)Resources.Load("WhiteNote");
        BlueNote = (GameObject)Resources.Load("BlueNote");
        Physics.gravity = new Vector3(0,-15,0);
        print("I'm attached to " + transform.name);
        TextAsset asset = (TextAsset)Resources.Load(assetName);
        string json = asset.text;
        notes = (IList)Json.Deserialize(json);
        StartCoroutine(load());
        
    }
	IEnumerator load()
    {
        yield return new WaitForSeconds(3.1f);
        BGM.Play();
    }
	// Update is called once per frame
	void Update () {
	    while(inote < notes.Count)
        {
            IDictionary note = (IDictionary)notes[inote];
            if(60 * 4 * (double)note["start"] > bpm * (Time.time))
            {
                break;
            }
            CreateNote((string)note["key"]);
            inote++;
        }


        
        transform.LookAt(new Vector3(v.x, v.y + 4, v.z));
        accAngle += 1;
        
        transform.Translate(((Mathf.RoundToInt(accAngle/4000f) % 2 == 1)? Vector3.right: Vector3.left) * Time.deltaTime);
    }

    private void CreateNote(string key)
    {
        switch (key)
        {
            case "0":
                Instantiate(RedNote, new Vector3(-6, dropHeight, 0), Quaternion.identity);
                break;
            case "1":
                Instantiate(WhiteNote, new Vector3(-4.5f, dropHeight, 0), Quaternion.identity);
                break;
            case "2":
                Instantiate(BlueNote, new Vector3(-3.0f, dropHeight, 0), Quaternion.identity);
                break;
            case "3":
                Instantiate(WhiteNote, new Vector3(-1.5f, dropHeight, 0), Quaternion.identity);
                break;
            case "4":
                Instantiate(BlueNote, new Vector3(0, dropHeight, 0), Quaternion.identity);
                break;
            case "5":
                Instantiate(WhiteNote, new Vector3(1.5f, dropHeight, 0), Quaternion.identity);
                break;
            case "6":
                Instantiate(BlueNote, new Vector3(3, dropHeight, 0), Quaternion.identity);
                break;
            case "7":
                Instantiate(WhiteNote, new Vector3(4.5f, dropHeight, 0), Quaternion.identity);
                break;

        }
    }
}
