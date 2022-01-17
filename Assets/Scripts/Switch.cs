using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public Material InactiveMaterial;
    public Material GazedAtMaterial;

    public AudioSource music;
    public SoloMusic solo;
    private Renderer _myRenderer;

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    public void Start()
    {
        _myRenderer = GetComponent<Renderer>();
        SetMaterial(false);
    }


    public void OnPointerEnter()
    {
        SetMaterial(true);
        solo.MuteAll(gameObject.name);

    }

    public void OnPointerExit()
    {
        SetMaterial(false);
        solo.UnMuteAll();
    }

    public void OnPointerClick()
    {

    }
    private void SetMaterial(bool gazedAt)
    {
        if (InactiveMaterial != null && GazedAtMaterial != null)
        {
            _myRenderer.material = gazedAt ? GazedAtMaterial : InactiveMaterial;
            music.mute = gazedAt;
        }
    }
}
