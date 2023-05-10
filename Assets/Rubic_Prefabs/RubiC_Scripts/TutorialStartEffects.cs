using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class TutorialStartEffects : MonoBehaviour
{
    PostProcessVolume m_Volume;
    Vignette m_Vignette;
    ChromaticAberration m_Aberration;
    LensDistortion m_Distortion;
    void OnEnable()
    {
        //MonoBehaviour soundScript = soundManager.GetComponent<AudioManager>();

        m_Vignette = ScriptableObject.CreateInstance<Vignette>();
        m_Vignette.enabled.Override(true);
        m_Vignette.smoothness.Override(0f);
        m_Vignette.intensity.Override(0f);

        m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_Vignette);


        m_Aberration = ScriptableObject.CreateInstance<ChromaticAberration>();
        m_Aberration.enabled.Override(true);
        m_Aberration.intensity.Override(0f);

        m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_Aberration);


        m_Distortion = ScriptableObject.CreateInstance<LensDistortion>();
        m_Distortion.enabled.Override(true);
        m_Distortion.intensity.Override(0f);

        m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_Distortion);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
