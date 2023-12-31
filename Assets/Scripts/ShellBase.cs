﻿using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShellBase : MonoBehaviour
{
    public const int SHELL_COUNT = 256;

    [Range(0.0f, 1.0f)]
    public float shellLength = 1f;

    [Range(0.01f, 3.0f)]
    public float distanceAttenuation = 0.67f;

    [Range(1.0f, 1000.0f)]
    public float density = 280.0f;

    [Range(0.0f, 1.0f)]
    public float noiseMin = 0.0f;

    [Range(0.0f, 1.0f)]
    public float noiseMax = 0.85f;

    [Range(0.0f, 10.0f)]
    public float thickness = 10f;

    [Range(0.0f, 10.0f)]
    public float curvature = 10f;

    [Range(0.0f, 1.0f)]
    public float displacementStrength = 0f;

    public Color shellColor;

    [Range(0.0f, 5.0f)]
    public float occlusionAttenuation = 1.3f;

    [Range(0.0f, 1.0f)]
    public float occlusionBias = 0.75f;
    public abstract IEnumerable<Material> materials { get; }

    protected virtual void OnValidate() => UpdateMaterials();
    public virtual void UpdateMaterials()
    { 
        Shader.SetGlobalFloat("_ShellLength", shellLength);
        Shader.SetGlobalFloat("_Density", density);
        Shader.SetGlobalFloat("_Thickness", thickness);
        Shader.SetGlobalFloat("_Attenuation", occlusionAttenuation);
        Shader.SetGlobalFloat("_ShellDistanceAttenuation", distanceAttenuation);
        Shader.SetGlobalFloat("_Curvature", curvature);
        Shader.SetGlobalFloat("_DisplacementStrength", displacementStrength);
        Shader.SetGlobalFloat("_OcclusionBias", occlusionBias);
        Shader.SetGlobalFloat("_NoiseMin", noiseMin);
        Shader.SetGlobalFloat("_NoiseMax", noiseMax); 
        Shader.SetGlobalColor("_ShellColor", shellColor);
    } 
}
