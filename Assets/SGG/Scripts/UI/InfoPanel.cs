// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
// MIT License
// Copyright (c) 2017 Stained Glass Guild
// See file "LICENSE.txt" at project root for complete license
// ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~
// File: InfoPanel.cs
// Creation: 2017-07
// Author: Jérémie Coulombe
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

using JetBrains.Annotations;

using SGG.RTS;

using UnityEngine;
using UnityEngine.UI;

namespace SGG.FXG.UI
{
   public sealed class InfoPanel : MonoBehaviour
   {
      #region Private fields

      [SerializeField, UsedImplicitly]
      private Text m_ElementName;

      #endregion

      #region Methods

      public void UpdateContent()
      {
         var selectionUnits = GameDriver.Instance.Selection.Units;

         if (selectionUnits.Count != 1)
         {
            m_ElementName.text = string.Empty;
            return;
         }

         m_ElementName.text = selectionUnits[0].UnitTypeName;
      }

      #endregion
   }
}
