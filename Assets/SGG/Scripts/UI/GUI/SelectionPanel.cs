﻿// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
// MIT License
// Copyright (c) 2017 Stained Glass Guild
// See file "LICENSE.txt" at project root for complete license
// ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~
// File: SelectionPanel.cs
// Creation: 2017-07
// Author: Jérémie Coulombe
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

using SGG.RTS.Resource;
using SGG.RTS.UI.Input;

using UnityEngine;

namespace SGG.RTS.UI.GUI
{
   public sealed class SelectionPanel : MonoBehaviour
   {
      #region Methods

      public void UpdateContent()
      {
         for (int i = 0; i < transform.childCount; ++i)
         {
            Destroy(transform.GetChild(i).gameObject);
         }

         foreach (var unit in Inputs.Instance.Selection.Entities)
         {
            var selectElem = Instantiate(Prefabs.Instance.GameObjSelectionElem);
            selectElem.transform.SetParent(transform, false);
            selectElem.name += " [" + unit.name + "]";
         }
      }

      #endregion
   }
}
