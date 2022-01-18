using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//[ExecuteInEditMode()]
public class Switch : MonoBehaviour
{
    public Material InactiveMaterial;
    public Material GazedAtMaterial;

    public AudioSource music;
    public SoloMusic solo;
    private Renderer _myRenderer;

    public float max;
    public float current;
    public Image mask;
    public GameObject progressBar;
    public TextMeshProUGUI txt;

    private bool isMuted = false;
    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    public void Start()
    {
        _myRenderer = GetComponent<Renderer>();
        //isMuted = GetComponent<AudioSource>().mute;
        SetMaterial(false);
    }

    private void FixedUpdate()
    {
        if (progressBar.activeSelf)
        {
            mask.fillAmount += Time.deltaTime/20;
        }
    }


    public void OnPointerEnter()
    {
        SetMaterial(!isMuted);
        if (gameObject.CompareTag("Teleport"))
        {
            progressBar.SetActive(true);
            StartCoroutine(Teleport());
            txt.text = "Teleporting";
        }
        else
        {
            music.mute = !isMuted;
            /*if (!isMuted)
            {
                //solo.UnMuteAll();
                //solo.MuteAll(gameObject.name);
                music.mute = true;
            }
            else
            {
                //solo.UnMuteAll();
                //SetMaterial(false);
                music.mute = false;
            }*/

            isMuted = !isMuted;
            //music.mute = !music.mute;
            txt.text = gameObject.name;
        }
        txt.gameObject.SetActive(true);

    }

    public void OnPointerExit()
    {
        if (gameObject.CompareTag("Teleport"))
        {
            progressBar.SetActive(false);
            mask.fillAmount = 0;
            StopAllCoroutines();
            SetMaterial(false);

        }
        else
        {
            //solo.UnMuteAll();
            //SetMaterial(false);

        }
        txt.gameObject.SetActive(false);
    }

    public void OnPointerClick()
    {
        
    }
    private void SetMaterial(bool gazedAt)
    {
        if (InactiveMaterial != null && GazedAtMaterial != null)
        {
            _myRenderer.material = gazedAt ? GazedAtMaterial : InactiveMaterial;
            //music.mute = gazedAt;
        }
    }

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(2);
        Camera.main.transform.parent.position = gameObject.transform.position + new Vector3(0.0f, 1.25f);
        Debug.Log("puta");
        //txt.gameObject.SetActive(false);
        mask.fillAmount = 0;
        SetMaterial(false);
    }
}
