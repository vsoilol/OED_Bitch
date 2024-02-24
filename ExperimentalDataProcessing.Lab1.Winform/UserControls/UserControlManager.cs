﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExperimentalDataProcessing.Lab1.Winform.UserControls
{
    public class UserControlManager
    {
        private static Dictionary<Type, UserControl> _userControls = new Dictionary<Type, UserControl>();
        private static readonly object _lock = new object();

        public static TControl GetInstance<TControl>() where TControl : BaseInputsPanel, new()
        {
            var type = typeof(TControl);

            lock (_lock)
            {
                if (!_userControls.ContainsKey(type) || _userControls[type].IsDisposed)
                {
                    _userControls[type] = new TControl();
                }
            }

            lock (_lock)
            {
                return (TControl)_userControls[type];
            }
        }
    }
}