using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFPresentationLayer
{
    public class CustomTextBox : TextBox
    {
        public TextType TextType { get; set; }

        public CustomTextBox()
        {
            this.KeyPress += CustomTextBox_KeyPress;
            this.Font = new System.Drawing.Font("Segoe UI", 12);
            this.Width = 200;
        }

        public static implicit operator string(CustomTextBox txt)
        {
            return txt.Text;
        }

        public static implicit operator int(CustomTextBox txt)
        {
            return int.Parse(txt.Text);
        }

        void CustomTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(this.TextType == WFPresentationLayer.TextType.Number)
            {
                if(!char.IsNumber(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

    }
    public enum TextType
    {
        Money, Text, Number
    }
}
