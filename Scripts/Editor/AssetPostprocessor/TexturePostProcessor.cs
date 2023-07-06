using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Tolian.Editor.AssetPostProcessSystem
{
    /// <summary>
    /// Handles importing textures as Sprite.
    /// </summary>
    public class TexturePostProcessor : AssetPostprocessor
    {
        private void OnPreprocessTexture()
        {
            var textureImporter = assetImporter as TextureImporter;
            textureImporter.textureType = TextureImporterType.Sprite;
            textureImporter.spriteImportMode = SpriteImportMode.Single;
            textureImporter.maxTextureSize = 512;
        }

    }
}

