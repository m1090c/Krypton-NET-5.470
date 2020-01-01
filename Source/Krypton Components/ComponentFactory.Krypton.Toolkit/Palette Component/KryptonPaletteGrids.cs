﻿// *****************************************************************************
// BSD 3-Clause License (https://github.com/ComponentFactory/Krypton/blob/master/LICENSE)
//  © Component Factory Pty Ltd, 2006 - 2020, All rights reserved.
// The software and associated documentation supplied hereunder are the 
//  proprietary information of Component Factory Pty Ltd, 13 Swallows Close, 
//  Mornington, Vic 3931, Australia and are supplied subject to license terms.
// 
//  Modifications by Peter Wagner(aka Wagnerp) & Simon Coghlan(aka Smurf-IV) 2017 - 2020. All rights reserved. (https://github.com/Wagnerp/Krypton-NET-5.470)
//  Version 5.470.0.0  www.ComponentFactory.com
// *****************************************************************************

using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit
{
    /// <summary>
    /// Storage for grids palette settings.
    /// </summary>
    public class KryptonPaletteGrids : Storage
    {
        #region Instance Fields

        #endregion

        #region Identity
        /// <summary>
        /// Initialize a new instance of the KryptonPaletteGrids class.
        /// </summary>
        /// <param name="redirector">Palette redirector for sourcing inherited values.</param>
        /// <param name="needPaint">Delegate for notifying paint requests.</param>
        internal KryptonPaletteGrids(PaletteRedirect redirector,
                                     NeedPaintHandler needPaint)
        {
            Debug.Assert(redirector != null);

            GridCommon = new KryptonPaletteGrid(redirector, GridStyle.List, needPaint);
            GridList = new KryptonPaletteGrid(redirector, GridStyle.List, needPaint);
            GridSheet = new KryptonPaletteGrid(redirector, GridStyle.Sheet, needPaint);
            GridCustom1 = new KryptonPaletteGrid(redirector, GridStyle.Custom1, needPaint);
            GridCustom2 = new KryptonPaletteGrid(redirector, GridStyle.Custom3, needPaint);
            GridCustom3 = new KryptonPaletteGrid(redirector, GridStyle.Custom3, needPaint);

            // Create redirectors for inheriting from style specific to style common
            PaletteRedirectGrids redirectCommon = new PaletteRedirectGrids(redirector, GridCommon);

            // Ensure the specific styles inherit to the common grid style
            GridList.SetRedirector(redirectCommon);
            GridSheet.SetRedirector(redirectCommon);
            GridCustom1.SetRedirector(redirectCommon);
            GridCustom2.SetRedirector(redirectCommon);
            GridCustom3.SetRedirector(redirectCommon);
        }
        #endregion

        #region IsDefault
        /// <summary>
        /// Gets a value indicating if all values are default.
        /// </summary>
        public override bool IsDefault => GridCommon.IsDefault &&
                                          GridList.IsDefault &&
                                          GridSheet.IsDefault 
                                          &&GridCustom1.IsDefault
                                          && GridCustom2.IsDefault 
                                          && GridCustom3.IsDefault;

        #endregion

        #region PopulateFromBase
        /// <summary>
        /// Populate values from the base palette.
        /// </summary>
        /// <param name="common">Reference to common settings.</param>
        public void PopulateFromBase(KryptonPaletteCommon common)
        {
            // Populate only the designated styles
            GridList.PopulateFromBase(common, GridStyle.List);
            GridSheet.PopulateFromBase(common, GridStyle.Sheet);
        }
        #endregion

        #region GridCommon
        /// <summary>
        /// Gets access to the common grid appearance entries.
        /// </summary>
        [KryptonPersist]
        [Category("Visuals")]
        [Description("Overrides for defining common grid appearance.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public KryptonPaletteGrid GridCommon { get; }

        private bool ShouldSerializeGridCommon()
        {
            return !GridCommon.IsDefault;
        }
        #endregion

        #region GridList
        /// <summary>
        /// Gets access to the list grid appearance entries.
        /// </summary>
        [KryptonPersist]
        [Category("Visuals")]
        [Description("Overrides for defining list grid appearance.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public KryptonPaletteGrid GridList { get; }

        private bool ShouldSerializeGridList()
        {
            return !GridList.IsDefault;
        }
        #endregion

        #region GridSheet
        /// <summary>
        /// Gets access to the sheet grid appearance entries.
        /// </summary>
        [KryptonPersist]
        [Category("Visuals")]
        [Description("Overrides for defining sheet grid appearance.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public KryptonPaletteGrid GridSheet { get; }

        private bool ShouldSerializeGridSheet()
        {
            return !GridSheet.IsDefault;
        }
        #endregion

        #region GridCustom1
        /// <summary>
        /// Gets access to the first custom grid appearance entries.
        /// </summary>
        [KryptonPersist]
        [Category("Visuals")]
        [Description("Overrides for defining the first custom grid appearance.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public KryptonPaletteGrid GridCustom1 { get; }

        private bool ShouldSerializeGridCustom1()
        {
            return !GridCustom1.IsDefault;
        }
        #endregion

        #region GridCustom2
        /// <summary>
        /// Gets access to the first custom grid appearance entries.
        /// </summary>
        [KryptonPersist]
        [Category("Visuals")]
        [Description("Overrides for defining the first custom grid appearance.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public KryptonPaletteGrid GridCustom2 { get; }

        private bool ShouldSerializeGridCustom2()
        {
            return !GridCustom2.IsDefault;
        }
        #endregion

        #region GridCustom3
        /// <summary>
        /// Gets access to the first custom grid appearance entries.
        /// </summary>
        [KryptonPersist]
        [Category("Visuals")]
        [Description("Overrides for defining the third custom grid appearance.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public KryptonPaletteGrid GridCustom3 { get; }

        private bool ShouldSerializeGridCustom3()
        {
            return !GridCustom3.IsDefault;
        }
        #endregion
    }
}
