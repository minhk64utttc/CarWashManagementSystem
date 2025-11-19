using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace CarWashManagement.UI
{
    public class BaseForm : Form
    {
        public BaseForm()
        {
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            BackColor = Color.WhiteSmoke;

            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
        }
    }
}
