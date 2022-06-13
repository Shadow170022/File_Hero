using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteKeyController : MonoBehaviour
{
    public bool noteVerifierPressed = false;
    public bool isEnabled = true;
    public ParticleSystem badNoteParticleSystem, goodNoteParticleSystem, perfectNoteParticleSystem, streakNoteParticleSystem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(noteVerifierPressed){
            //move this to local y = 0.5 with lerp
            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(transform.localPosition.x, 0.5f, transform.localPosition.z), Time.deltaTime * 10);
        }else{
            //move this to local y = 0.01 with lerp
            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(transform.localPosition.x, 0.01f, transform.localPosition.z), Time.deltaTime * 10);
        }
    }
}
