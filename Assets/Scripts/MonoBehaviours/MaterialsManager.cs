using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Feto;

public class MaterialsManager : Singleton<MaterialsManager>
{

    public Dictionary<string, Material> materials;

    void Start() {
        materials = new Dictionary<string, Material>();
    }

    public Material GetMaterial(string key) {
        Material material;

        if (!materials.TryGetValue(key, out material)) {
            material = Resources.Load<Material>(key);
        }

        return material;
    }

}
