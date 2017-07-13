// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
// MIT License
// Copyright (c) 2017 Stained Glass Guild
// See file "LICENSE.txt" at project root for complete license
// ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~   ~
// File: World.cs
// Creation: 2017-07
// Author: Jérémie Coulombe
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

using System.Collections.Generic;

using JetBrains.Annotations;

using SGG.RTS.Resource;

using UnityEngine;

namespace SGG.RTS
{
   public sealed class World : MonoBehaviour
   {
      #region Compile-time constants

      private const float TILE_BORDER_SIZE = 0.05f;

      private const float DARKEST_BORDER_INTENSITY = 0.9f;

      private const float ZOOM_LVL_WHERE_BORDERS_NOT_VISIBLE = 40;

      #endregion

      #region Private fields

      private Vector2UInt m_BoardSizeInTiles;

      #endregion

      #region Public fields

      public List<Unit> Units;

      #endregion

      #region Methods

      public bool Contains(Vector2 a_Pt)
      {
         return a_Pt.x > 0 && a_Pt.y > 0 &&
                a_Pt.x < m_BoardSizeInTiles.X &&
                a_Pt.y < m_BoardSizeInTiles.Y;
      }

      public void Initialize(Vector2UInt a_BoardSizeInTiles)
      {
         m_BoardSizeInTiles = a_BoardSizeInTiles;
         Units = new List<Unit>();

         CreateTiles();
         CreateBorders();
      }

      private void CreateBorders()
      {
         var bg = GameObject.CreatePrimitive(PrimitiveType.Plane);
         bg.name = "Background";
         bg.transform.parent = transform;

         var transf = bg.transform;
         var size2D = (m_BoardSizeInTiles + Vector2.one * TILE_BORDER_SIZE * 0.5f) * 0.1f;
         transf.localScale = new Vector3(size2D.x, 0, size2D.y);

         transf.LookAt(Vector3.up);

         var pos2D = m_BoardSizeInTiles / 2;
         transf.position = new Vector3(pos2D.x, pos2D.y, 1);

         bg.GetComponent<Renderer>().material = MaterialRepository.Instance.BackgroundMaterial;
      }

      private void CreateTiles()
      {
         // Create tiles
         Utils.ForEachElement(m_BoardSizeInTiles, a_TileCoord =>
         {
            // Create tile primitive
            var tile = GameObject.CreatePrimitive(PrimitiveType.Plane);
            tile.name = "Tile";
            tile.transform.parent = transform;

            // Set tile size
            var transf = tile.transform;
            transf.localScale = Vector3.one * 0.1f * (1 - 0.5f * TILE_BORDER_SIZE);

            // Set tile rotation
            transf.LookAt(Vector3.up);

            // Set tile position
            var pos2D = a_TileCoord + Vector2.one * 0.5f;
            transf.position = new Vector3(pos2D.x, pos2D.y);

            // Set tile color
            tile.GetComponent<Renderer>().material = MaterialRepository.Instance.TileMaterial;
         });
      }

      public void SpawnUnit(Vector2 a_Pos, Team a_Team)
      {
         if (!DebugUtils.Verify(Contains(a_Pos)))
         {
            return;
         }

         var obj = Instantiate(PrefabRepository.Instance.TestUnit);
         obj.transform.position = new Vector3(a_Pos.x, a_Pos.y, -1);

         var unit = obj.GetComponent<Unit>();
         unit.Color = a_Team.Color;
         unit.Team = a_Team;

         Units.Add(unit);
      }

      [UsedImplicitly]
      private void Update()
      {
         float borderDistFactor = (Mathf.Min(Camera.main.orthographicSize,
                                      ZOOM_LVL_WHERE_BORDERS_NOT_VISIBLE) -
                                   CameraController.MIN_ZOOM_LVL) /
                                  (ZOOM_LVL_WHERE_BORDERS_NOT_VISIBLE -
                                   CameraController.MIN_ZOOM_LVL);
         var bgColor = Color.white * Mathf.Lerp(DARKEST_BORDER_INTENSITY, 1, borderDistFactor);
         bgColor.a = 1;
         MaterialRepository.Instance.BackgroundMaterial.color = bgColor;
      }

      #endregion
   }
}
