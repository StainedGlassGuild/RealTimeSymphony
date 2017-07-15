// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
// MIT License
// Copyright (c) 2017 Stained Glass Guild
// See file "LICENSE.txt" at project root for complete license
// ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~
// File: SelectionPanel.cs
// Creation: 2017-07
// Author: Jérémie Coulombe
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

using SGG.RTS.Resource;

using UnityEngine;

namespace SGG.RTS.UI
{
   public sealed class SelectionPanel : MonoBehaviour
   {
      #region Methods

      public void UpdateContent()
      {
         var selectionUnits = GameDriver.Instance.Selection.Units;

         for (int i = selectionUnits.Count; i < transform.childCount; ++i)
         {
            Destroy(transform.GetChild(i).gameObject);
         }

         foreach (var unit in selectionUnits)
         {
            var selectElem = Instantiate(PrefabRepository.Instance.GameObjSelectionElem);
            selectElem.transform.SetParent(transform, false);
            selectElem.name += " [" + unit.name + "]";
         }
      }

      #endregion
   }
}
