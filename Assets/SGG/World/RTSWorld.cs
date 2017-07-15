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
using System.Diagnostics.CodeAnalysis;

using JetBrains.Annotations;

using SGG.RTS.Resource;
using SGG.RTS.Unit;

using UnityEngine;

namespace SGG.RTS.World
{
   // ReSharper disable once InconsistentNaming
   public sealed class RTSWorld : MonoBehaviour
   {
      #region Compile-time constants

      private const float TILE_BORDER_SIZE = 0.05f;
      private const float DARKEST_BORDER_INTENSITY = 0.9f;
      private const float ZOOM_LVL_WHERE_BORDERS_NOT_VISIBLE = 40;

      #endregion

      #region Static fields

      public static RTSWorld Instance;

      #endregion

      #region Private fields

      [SerializeField, UsedImplicitly]
      private GameObject m_Tiles;

      [SerializeField, UsedImplicitly]
      private GameObject m_BuildingsObj;

      [SerializeField, UsedImplicitly]
      private GameObject m_UnitsObj;

      #endregion

      #region Public fields

      public Vector2UInt BoardSizeInTiles;

      #endregion

      #region Properties

      public List<AUnit> Units { get; private set; }

      #endregion

      #region Methods

      [UsedImplicitly]
      private void Start()
      {
         Units = new List<AUnit>();

         CreateTiles();
         CreateBorders();

         Instance = this;
      }

      private void CreateTiles()
      {
         // Create tiles
         Utils.ForEachElement(BoardSizeInTiles, a_TileCoord =>
         {
            // Create tile primitive
            var tile = GameObject.CreatePrimitive(PrimitiveType.Plane);
            tile.name = "Tile";
            tile.transform.parent = m_Tiles.transform;

            // Set tile size
            var transf = tile.transform;
            transf.localScale = Vector3.one * 0.1f * (1 - 0.5f * TILE_BORDER_SIZE);

            // Set tile rotation
            transf.LookAt(Vector3.up);

            // Set tile position
            var pos2D = a_TileCoord + Vector2.one * 0.5f;
            transf.position = new Vector3(pos2D.x, pos2D.y);

            // Set tile color
            tile.GetComponent<Renderer>().material = Materials.Instance.TileMaterial;
         });
      }

      private void CreateBorders()
      {
         var bg = GameObject.CreatePrimitive(PrimitiveType.Plane);
         bg.name = "Background";
         bg.transform.parent = transform;

         var transf = bg.transform;
         var size2D = (BoardSizeInTiles + Vector2.one * TILE_BORDER_SIZE * 0.5f) * 0.1f;
         transf.localScale = new Vector3(size2D.x, 0, size2D.y);

         transf.LookAt(Vector3.up);

         var pos2D = BoardSizeInTiles / 2;
         transf.position = new Vector3(pos2D.x, pos2D.y, 1);

         bg.GetComponent<Renderer>().material = Materials.Instance.BackgroundMaterial;
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
         Materials.Instance.BackgroundMaterial.color = bgColor;
      }

      [SuppressMessage("ReSharper", "PossibleLossOfFraction")]
      public void SpawnUnit(AUnit a_Unit, Vector2 a_Pos)
      {
         Debug.Assert(Contains(a_Pos));
         a_Unit.transform.position = new Vector3(a_Pos.x, a_Pos.y, -1);
         a_Unit.transform.parent = m_UnitsObj.transform;
         Units.Add(a_Unit);
      }

      public bool Contains(Vector2 a_Pt)
      {
         return a_Pt.x > 0 && a_Pt.y > 0 &&
                a_Pt.x < BoardSizeInTiles.X &&
                a_Pt.y < BoardSizeInTiles.Y;
      }

      #endregion
   }
}
