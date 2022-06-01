using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public float spawnTime = 2.0f;
    public GameObject notePrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnNote());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator SpawnNote()
    {
        //wait for spawnTime seconds
        yield return new WaitForSeconds(spawnTime);
        //instantiate notePrefab
        GameObject noteSpawned = Instantiate(notePrefab, transform.position, transform.rotation);
        //Put noteSpawned as child of this gameObject
        noteSpawned.transform.parent = this.gameObject.transform;
        //Set noteSpawned transform values of notePrefab
        noteSpawned.transform.position = transform.position;
        noteSpawned.transform.rotation = transform.rotation;
        //set noteSpawned scale same as notePrefab
        noteSpawned.transform.localScale = notePrefab.transform.localScale;
        //call SpawnNote() again
        StartCoroutine(SpawnNote());
    }
}
