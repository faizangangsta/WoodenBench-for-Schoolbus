using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Metro;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro.ColorTables;

namespace RadialMenu
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Everything you need to know about RadialMenu control: http://www.devcomponents.com/kb2/?p=1363
        private void buttonX1_Click(object sender, EventArgs e)
        {
            DevComponents.DotNetBar.RadialMenu menu = new DevComponents.DotNetBar.RadialMenu();
            menu.Location = new Point(buttonX1.Left + (buttonX1.Width - menu.Width) / 2, buttonX1.Bounds.Bottom + 12);
            menu.Symbol = "\uf040";
            menu.SymbolSize = 14;
            menu.Diameter = 220; // Make menu diameter larger
            // Handle some events
            menu.ItemClick += new EventHandler(RadialMenuItemClick);
            menu.MenuOpened += new EventHandler(RadialMenuOpened);
            menu.MenuClosed += new EventHandler(RadialMenuClosed);

            RadialMenuItem item = new RadialMenuItem
            {
                Text = "Item 1",
                Symbol = "\uf011"
            };
            menu.Items.Add(item);

            item = new RadialMenuItem
            {
                Text = "Item 2",
                Symbol = "\uf00e"
            };
            menu.Items.Add(item);

            item = new RadialMenuItem
            {
                Text = "Item 3",
                Symbol = "\uf010"
            };
            menu.Items.Add(item);

            // Create spacer item
            item = new RadialMenuItem();
            menu.Items.Add(item);

            item = new RadialMenuItem
            {
                Text = "Item 4",
                Symbol = "\uf011"
            };
            menu.Items.Add(item);
            // Add sub items to last menu item
            RadialMenuItem childItem = new RadialMenuItem
            {
                Text = "Sub menu 1",
                Symbol = "\uf012"
            };
            item.SubItems.Add(childItem); // Add sub menu to its parent

            childItem = new RadialMenuItem
            {
                Text = "Sub\r\nmenu 2",
                Symbol = "\uf013"
            };
            item.SubItems.Add(childItem);

            this.Controls.Add(menu);

            buttonX1.Enabled = false;
        }

        void RadialMenuClosed(object sender, EventArgs e)
        {
            textBoxLog.AppendText(string.Format("{0} Radial Menu Closed\r\n", DateTime.Now));
        }

        void RadialMenuOpened(object sender, EventArgs e)
        {
            textBoxLog.AppendText(string.Format("{0} Radial Menu Opened\r\n", DateTime.Now));
        }

        private void RadialMenuItemClick(object sender, EventArgs e)
        {
            if (sender is RadialMenuItem item && !string.IsNullOrEmpty(item.Text))
            {
                textBoxLog.AppendText(string.Format("{0} Menu item clicked: {1}\r\n", DateTime.Now, item.Text));
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            // Customize colors of the RadialMenu
            Color c = ColorScheme.GetColor(0xE84C22); // We will use this as a "base" color for the menu

            // Background of the circular button seen on form and used to open the radial menu
            radialMenu1.Colors.RadialMenuButtonBackground = ColorScheme.GetColor(0xF8F8F8);

            // Border of the circular button seen on form and used to open the radial menu
            radialMenu1.Colors.RadialMenuButtonBorder = c;

            // Radial Menu Border
            radialMenu1.Colors.RadialMenuBorder = c;

            // Radial Menu Background, as seen in center of the radial menu
            radialMenu1.Colors.RadialMenuBackground = radialMenu1.Colors.RadialMenuButtonBackground;

            // Background of radial menu buttons
            radialMenu1.Colors.RadialMenuButtonBackground = Color.White;

            // Color of the thick sub-item border around the radial menu
            radialMenu1.Colors.RadialMenuInactiveBorder = Color.FromArgb(128, c);

            // Text and symbol colors of the radial menu item
            radialMenu1.Colors.RadialMenuItemForeground = c;

            // Color of the mouse over background of the radial menu item
            radialMenu1.Colors.RadialMenuItemMouseOverBackground = Color.FromArgb(92, c);

            // Text and symbol color of the mouse over radial menu item
            radialMenu1.Colors.RadialMenuItemMouseOverForeground = c;

            // Mouse over color of the radial menu thick sub-item border
            radialMenu1.Colors.RadialMenuMouseOverBorder = Color.FromArgb(192, c);


            // Invalidate Radial Menu to see color changes
            radialMenu1.Invalidate();
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            RadialMenuContainer menuContainer = null;
            if (buttonItem1.SubItems.Count == 0)
            {
                // RadialMenuContainer is used as host for RadialMenu when its being added to Bar
                menuContainer = new RadialMenuContainer() { Font = new Font(Font.FontFamily, 7F), Diameter = 200 };
                menuContainer.SubItems.Add(CreateItem("Camera", "\uf083"));
                menuContainer.SubItems.Add(CreateItem("", "")); // Spacer item does not have anything set
                menuContainer.SubItems.Add(CreateItem("Table", "\uf0ce"));
                menuContainer.SubItems.Add(CreateItem("List", "\uf0ca"));
                menuContainer.SubItems.Add(CreateItem("Paste", "\uf0ea"));
                menuContainer.SubItems.Add(CreateItem("Tag", "\uf046"));
                menuContainer.SubItems.Add(CreateItem("Undo", "\uf0e2"));
                menuContainer.SubItems.Add(CreateItem("", "")); // Spacer item does not have anything set
                buttonItem1.SubItems.Add(menuContainer); // Must add it to button to enable menu to be hidden when user clicks-out or app loses focus
            }
            else menuContainer = (RadialMenuContainer)buttonItem1.SubItems[0];

            // Menu will use custom location and it will be centered on mouse cursor
            menuContainer.MenuLocation = new Point(MousePosition.X - menuContainer.Diameter / 2, MousePosition.Y - menuContainer.Diameter / 2);

            // Open the menu
            menuContainer.Expanded = true;
        }
        private BaseItem CreateItem(string text, string symbol)
        {
            RadialMenuItem item = new RadialMenuItem
            {
                Text = text,
                Symbol = symbol
            };
            return item;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radialMenu2_ItemClick(object sender, EventArgs e)
        {

        }
    }
}