using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Globalization;

public class NoteSpawner : MonoBehaviour
{
    public float spawnTime = 2.0f;
    public GameObject notePrefab;
    public RuntimeText runtimeText;
    private List<string> noteTiming;
    private int noteIndex = 0;
    private bool hasSpawned = false;
    List<float> cleanNoteTiming = new List<float>();
    // Start is called before the first frame update
    void Start()
    {
        noteTiming = runtimeText.ReadString();
        //print the noteTiming
        //int bla = 0;
        for (int i = 0; i < noteTiming.Count; i++)
        {
            //if noteTiming[i] is not empty, add it to the cleanNoteTiming as float
            if (noteTiming[i] != "")
            {
                //parse as float
                float time = float.Parse(noteTiming[i], CultureInfo.InvariantCulture.NumberFormat);
                cleanNoteTiming.Add(time);
                //Debug.Log(cleanNoteTiming[bla]);
                //bla++;
            }
        }

        StartCoroutine(WaitForNote());
    }

    // Update is called once per frame
    void Update()
    {
    }
    

    public IEnumerator WaitForNote()
    {
        if (!hasSpawned)
        {
            hasSpawned = true;
            yield return new WaitForSeconds(spawnTime);
            StartCoroutine(SpawnNote());
        }
    }

    public IEnumerator SpawnNote()
    {
            //noteIndex is odd, spawn note
            if (noteIndex % 2 == 0 && noteIndex < cleanNoteTiming.Count - 1)
            {
                //wait for cleanNoteTiming seconds
                //float noteTimingSeconds = float.Parse(cleanNoteTiming[noteIndex]);
                //Debug.Log("Spawning note at " + cleanNoteTiming[noteIndex]);
                yield return new WaitForSeconds(cleanNoteTiming[noteIndex]);
                //instantiate notePrefab
                GameObject noteSpawned = Instantiate(notePrefab, transform.position, transform.rotation);
                //Put noteSpawned as child of this gameObject
                noteSpawned.transform.parent = this.gameObject.transform;
                //Set noteSpawned transform values of notePrefab
                noteSpawned.transform.position = transform.position;
                noteSpawned.transform.rotation = transform.rotation;
                //set noteSpawned scale same as notePrefab
                noteSpawned.transform.localScale = notePrefab.transform.localScale;
            }else if (noteIndex % 2 == 1 && noteIndex < cleanNoteTiming.Count - 1){
                yield return new WaitForSeconds(cleanNoteTiming[noteIndex]);
            }
            noteIndex++;
            if(noteIndex < cleanNoteTiming.Count){
                //call SpawnNote() again}
                StartCoroutine(SpawnNote());
            }
            
    }
}
