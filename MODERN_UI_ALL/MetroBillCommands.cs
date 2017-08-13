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
        /// Gets the client related commands.
        /// </summary>
        public DocumentCommands ClientCommands { get; set; } = new DocumentCommands();
        /// <summary>
        /// Gets document related commands.
        /// </summary>
        public DocumentCommands InvoiceCommands { get; set; } = new DocumentCommands();
        /// <summary>
        /// Toggles start control visibility.
        /// </summary>
        public Command ToggleStartControl { get; set; }
        /// <summary>
        /// Changes the Metro theme.
        /// </summary>
        public Command ChangeMetroTheme { get; set; }
        public Command GettingStartedCommand { get; set; }
        /// <summary>
        /// Not implemented command.
        /// </summary>
        public Command NotImplemented { get; set; }
        /// <summary>
        /// Open DotNetBar web-site.
        /// </summary>
        public Command DevComponents { get; set; }
    }

    public class DocumentCommands
    {
        public Command New { get; set; }
        public Command Save { get; set; }
        public Command Cancel { get; set; }
    }
}
