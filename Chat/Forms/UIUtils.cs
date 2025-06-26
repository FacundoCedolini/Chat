using System;
using System.Drawing;
using System.Windows.Forms;

namespace Chat.Forms
{
    public static class UIUtils
    {
        public static void RedondearBoton(Button boton)
        {
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.BackColor = ColorTranslator.FromHtml("#5865f2");
            boton.ForeColor = Color.White;
            boton.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            boton.Region = System.Drawing.Region.FromHrgn(
                CreateRoundRectRgn(0, 0, boton.Width, boton.Height, 20, 20));
        }

        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
    }
}
