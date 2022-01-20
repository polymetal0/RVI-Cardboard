using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    public void Start()
    {
        _myRenderer = GetComponent<Renderer>();
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
            isMuted = !isMuted;
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
        txt.gameObject.SetActive(false);
    }

    private void SetMaterial(bool gazedAt)
    {
        if (InactiveMaterial != null && GazedAtMaterial != null)
        {
            _myRenderer.material = gazedAt ? GazedAtMaterial : InactiveMaterial;
        }
    }

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(2);
        Camera.main.transform.parent.position = gameObject.transform.position + new Vector3(0.0f, 1.25f);
        mask.fillAmount = 0;
        SetMaterial(false);
    }
}
