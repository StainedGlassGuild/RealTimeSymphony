// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
// MIT License
// Copyright (c) 2017 Stained Glass Guild
// See file "LICENSE.txt" at project root for complete license
// ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~
// File: Selection.cs
// Creation: 2017-07
// Author: Jérémie Coulombe
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

using System.Collections.Generic;

using JetBrains.Annotations;

using SGG.RTS.UI;
using SGG.RTS.Unit;

using UnityEngine;

namespace SGG.RTS
{
   public sealed class Selection : MonoBehaviour
   {
      #region Compile-time constants

      private const float BLINK_FREQUENCY = 2f;
      private const float BLINK_INTENSITY = 0.2f;
      private const float GLOW_FREQUENCY = Mathf.PI;
      private const float MIN_GLOW_INTENSITY = 0.7f;

      #endregion

      #region Private fields

      private float m_SelectionCreationTime;

      #endregion

      #region Properties

      public List<AUnit> Units { get; private set; }

      #endregion

      #region Methods

      [UsedImplicitly]
      private void Start()
      {
         Units = new List<AUnit>();
      }

      [UsedImplicitly]
      private void Update()
      {
         if (Units.Count == 0)
         {
            return;
         }

         // Update unit main sprite blinking color
         float blink = Mathf.Sin((Time.time - m_SelectionCreationTime) * BLINK_FREQUENCY);
         var blinkColor = Units[0].Team.Color;
         blinkColor = blink > 0
            ? Color.Lerp(blinkColor, Color.black, blink * BLINK_INTENSITY)
            : Color.Lerp(blinkColor, Color.white, -blink * BLINK_INTENSITY);
         SetUnitsColor(blinkColor);

         // Update glow color around units
         var glowColor = new Color(1, 1, 1) - Units[0].Team.Color;
         float glow = Mathf.Sin((Time.time - m_SelectionCreationTime) * GLOW_FREQUENCY) * 0.5f +
                      0.5f;
         glowColor.a = MIN_GLOW_INTENSITY + glow * (1 - MIN_GLOW_INTENSITY);
         SetUnitsGlowColor(glowColor);
      }

      public void Add(AUnit a_Unit)
      {
         Debug.Assert(!Contains(a_Unit));

         if (Units.Count == 0)
         {
            m_SelectionCreationTime = Time.time;
         }

         Units.Add(a_Unit);
      }

      public bool Contains(AUnit a_Unit)
      {
         return Units.Contains(a_Unit);
      }

      public void Remove(AUnit a_Unit)
      {
         Debug.Assert(Contains(a_Unit));
         a_Unit.Color = Units[0].Team.Color;
         a_Unit.GlowColor = Color.clear;
         Units.Remove(a_Unit);
      }

      public void Clear()
      {
         if (Units.Count == 0)
         {
            return;
         }

         SetUnitsColor(Units[0].Team.Color);
         SetUnitsGlowColor(Color.clear);
         Units.Clear();
      }

      private void SetUnitsColor(Color a_Color)
      {
         foreach (var unit in Units)
         {
            unit.Color = a_Color;
         }
      }

      private void SetUnitsGlowColor(Color a_Color)
      {
         foreach (var unit in Units)
         {
            unit.GlowColor = a_Color;
         }
      }

      #endregion
   }
}
