using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Feto;

public class MaterialsManager : SingletonPersistent<MaterialsManager>
{
    public Dictionary<string, Material> materials;

    protected override void Awake() {
        base.Awake();
        materials = new Dictionary<string, Material>();
    }

    public Material GetMaterial(string key) {
        if (materials == null) { materials = new Dictionary<string, Material>(); }
        Material material;

        if (!materials.TryGetValue(key, out material)) {
            material = Resources.Load<Material>(key);
        }

        return material;
    }

}
