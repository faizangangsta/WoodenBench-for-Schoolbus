using System;
using System.Collections.Generic;
using System.Text;
using DevComponents.DotNetBar;

namespace MetroBill
{
    /// <summary>
    /// Represents all application commands.
    /// </summary>
    public class MetroBillCommands
    {
        /// <summary>
        /// Toggles start control visibility.
        /// </summary>
        public Command ToggleStartControl { get; set; }
        /// <summary>
        /// Changes the Metro theme.
        /// </summary>
        public Command ChangeMetroTheme { get; set; }
    }
}
