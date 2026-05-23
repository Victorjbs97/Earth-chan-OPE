using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class configScript : MonoBehaviour
{
    Resolution[] resolutions;
    public Dropdown resolutionsDropDown;
    public AudioMixer mixer;
    int faseACarregar;
    void Start()
    {
        faseACarregar = PlayerPrefs.GetInt("fase");
        resolutions = Screen.resolutions;
        resolutionsDropDown.ClearOptions();
        List<string> opitions = new List<string>();
        int resolucaoAtualX = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width+ " X " + resolutions[i].height;
            opitions.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height) 
            {
                resolucaoAtualX = i;
            }
        }
        resolutionsDropDown.AddOptions(opitions);
        resolutionsDropDown.value = resolucaoAtualX;
        resolutionsDropDown.RefreshShownValue();
    }

    public void SetResolucao(int resolutionIndex) 
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void setfullScream( bool isfullScreen) 
    {
        Screen.fullScreen = isfullScreen;
    }

    float Getvol(float vol)
    {
        float newvol = 0;
        newvol = 20 * Mathf.Log10(vol);
        if (vol <= 0)
        {
            newvol = -80;
        }
        return newvol;
    }
    public void setVolumeMaster(float vol) 
    {
        mixer.SetFloat("MasterVol", Getvol(vol));
    }
    public void SetVolumeMusic( float vol)
    {
        mixer.SetFloat("MusicVol", Getvol(vol));
    }

    public void SetVolumeSFX(float vol)
    {
        mixer.SetFloat("SfxVol", Getvol(vol));
    }
    public void carregarFaseMenu() 
    {
        if (faseACarregar == 1)
        {
            SceneManager.LoadScene("Fase 1");
        }
        if (faseACarregar == 2)
        {
            SceneManager.LoadScene("Fase 2");
        }
        if (faseACarregar == 3)
        {
            SceneManager.LoadScene("Fase 3");
        }
        if (faseACarregar == 4)
        {
            SceneManager.LoadScene("telaBoss");
        }
    }
    public void irCreditos() 
    {
        SceneManager.LoadScene("creditos");
    }


}
