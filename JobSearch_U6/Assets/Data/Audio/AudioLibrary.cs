using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioLibrary", menuName = "AudioLibrary", order = 0)]

public class AudioLibrary : ScriptableObject
{
    public string libraryName;
    public AudioClip[] audioClips;
}
