// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using UnityEngine;

namespace HoloToolkit.Unity.InputModule.Tests
{
    /// <summary>
    /// This class implements IInputClickHandler to handle the tap gesture.
    /// It increases the scale of the object when tapped.
    /// </summary>
    public class ColorChange : MonoBehaviour, IInputClickHandler
    {
        private Material[] defaultMaterials;
        public void OnInputClicked(InputClickedEventData eventData)
        {
            // Increase the scale of the object just as a response.
            defaultMaterials[0].SetFloat("_Gloss", 10.0f);
            eventData.Use(); // Mark the event as used, so it doesn't fall through to other handlers.
        }
    }
}
