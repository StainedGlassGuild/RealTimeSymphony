﻿// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
// MIT License
// Copyright (c) 2017 Stained Glass Guild
// See file "LICENSE.txt" at project root for complete license
// ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~
// File: MouseCursorHandler.cs
// Creation: 2017-07
// Author: Jérémie Coulombe
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

using JetBrains.Annotations;

using SGG.RTS.Entity.Unit;
using SGG.RTS.Resource;
using SGG.RTS.UI.GUI;
using SGG.RTS.World;

using UnityEngine;

namespace SGG.RTS.UI.Input
{
   public sealed class MouseCursorHandler : MonoBehaviour
   {
      #region Compile-time constants

      private const float UNIT_SELECTION_RADIUS = 0.3f;

      private const float CLICK_MAX_TIME_SEC = 0.3f;

      // Selection box
      private const float SELECTION_BOX_OPACITY = 0.5f;
      private const float MIN_SELECTION_BOX_SIZE = 0.3f;

      #endregion

      #region Private fields

      private float m_RightClickDownTime;

      // Selection box
      private GameObject m_SelectionBox;
      private Vector3 m_SelectionBoxStartPos;

      #endregion

      #region Static methods

      private static AUnit FindUnitClosestToCursorWithinRange(Vector2 a_ClickPosWorld)
      {
         float minDist = float.PositiveInfinity;
         AUnit closestUnit = null;

         foreach (var unit in GameWorld.Instance.Units)
         {
            float dist = Vector2.Distance(unit.Position, a_ClickPosWorld);
            if (dist < minDist)
            {
               minDist = dist;
               closestUnit = unit;
            }
         }

         if (closestUnit != null && minDist < UNIT_SELECTION_RADIUS)
         {
            return closestUnit;
         }

         return null;
      }

      #endregion

      #region Methods

      [UsedImplicitly]
      private void Start()
      {
         // Selection box
         m_SelectionBox = Instantiate(Prefabs.Instance.SelectionBox);
         m_SelectionBox.SetActive(false);
         var selectionBoxColor = new Color(1, 1, 1) - GameLogic.Instance.PlayerTeam.Color;
         selectionBoxColor.a = SELECTION_BOX_OPACITY;
         m_SelectionBox.GetComponent<Renderer>().material.color = selectionBoxColor;
      }

      [UsedImplicitly]
      private void Update()
      {
         bool isCursorInMainPanel = InGameGUI.Instance.MainPanel.ContainsCursor;

         // Get the point in the world where the mouse is
         var clickPosWorld = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);

         // Remember the location of left click down
         if (UnityEngine.Input.GetButtonDown(InputNames.LEFT_CLICK))
         {
            m_SelectionBoxStartPos = clickPosWorld;
         }

         // Remember the time of middle click down
         if (UnityEngine.Input.GetButtonDown(InputNames.MIDDLE_CLICK))
         {
            m_RightClickDownTime = Time.time;
         }

         // Use a selection box after a certain distance
         if (UnityEngine.Input.GetButton(InputNames.LEFT_CLICK) &&
             !InGameGUI.Instance.MainPanel.ContainsCursor &&
             Vector2.Distance(m_SelectionBoxStartPos, clickPosWorld) > MIN_SELECTION_BOX_SIZE)
         {
            m_SelectionBox.SetActive(true);
         }

         // Update selection box
         if (m_SelectionBox.activeInHierarchy)
         {
            UpdateSelectionBox(clickPosWorld);
         }

         // Create selection at left click up
         if (UnityEngine.Input.GetButtonUp(InputNames.LEFT_CLICK))
         {
            if (m_SelectionBox.activeInHierarchy)
            {
               m_SelectionBox.SetActive(false);
            }
            else if (!isCursorInMainPanel)
            {
               Inputs.Instance.Selection.Clear();
               var unit = FindUnitClosestToCursorWithinRange(clickPosWorld);
               if (unit != null)
               {
                  Inputs.Instance.Selection.Add(unit);
               }
               InGameGUI.Instance.MainPanel.UpdateSelectedContent();
            }
         }

         // Spawn a unit at middle click
         if (UnityEngine.Input.GetButtonUp(InputNames.MIDDLE_CLICK))
         {
            if (!UnityEngine.Input.GetButton(InputNames.LEFT_CLICK) &&
                !isCursorInMainPanel &&
                Time.time - m_RightClickDownTime < CLICK_MAX_TIME_SEC)
            {
               if (GameWorld.Instance.Contains(clickPosWorld))
               {
                  var unit = Instantiate(Prefabs.Instance.StaveUnit).GetComponent<StaveUnit>();
                  unit.Initialize(GameLogic.Instance.PlayerTeam,
                     UnitFunction.MILITARY, NoteValue.QUAVER);
                  GameWorld.Instance.SpawnUnit(unit, clickPosWorld);
               }
            }

            if (!isCursorInMainPanel)
            {
               Inputs.Instance.Selection.Clear();
               InGameGUI.Instance.MainPanel.UpdateSelectedContent();
            }
            m_SelectionBox.SetActive(false);
            m_SelectionBoxStartPos = clickPosWorld;
            m_RightClickDownTime = 0;
         }
      }

      private void UpdateSelectionBox(Vector2 a_ClickPosWorld)
      {
         // Compute selection box dimensions
         var boxCenter = new Vector3(
            (a_ClickPosWorld.x + m_SelectionBoxStartPos.x) * 0.5f,
            (a_ClickPosWorld.y + m_SelectionBoxStartPos.y) * 0.5f,
            -2);

         var boxMinCorner = new Vector3(
            Mathf.Min(a_ClickPosWorld.x, m_SelectionBoxStartPos.x),
            Mathf.Min(a_ClickPosWorld.y, m_SelectionBoxStartPos.y),
            -10);

         var boxMaxCorner = new Vector3(
            Mathf.Max(a_ClickPosWorld.x, m_SelectionBoxStartPos.x),
            Mathf.Max(a_ClickPosWorld.y, m_SelectionBoxStartPos.y),
            10);

         var boxSize = boxMaxCorner - boxMinCorner;

         var boxBounds = new Bounds(boxCenter, boxSize);

         // Update objects in selection
         foreach (var unit in GameWorld.Instance.Units)
         {
            if (boxBounds.Contains(unit.Position))
            {
               if (!Inputs.Instance.Selection.Contains(unit))
               {
                  Inputs.Instance.Selection.Add(unit);
               }
            }
            else
            {
               if (Inputs.Instance.Selection.Contains(unit))
               {
                  Inputs.Instance.Selection.Remove(unit);
               }
            }
         }
         InGameGUI.Instance.MainPanel.UpdateSelectedContent();

         // Update visual object
         var transf = m_SelectionBox.transform;
         transf.position = boxCenter;
         transf.localScale = new Vector3(boxSize.x * 0.1f, 1, boxSize.y * 0.1f);
      }

      #endregion
   }
}