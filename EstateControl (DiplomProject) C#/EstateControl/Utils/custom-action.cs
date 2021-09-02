using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EstateControl.Utils
{
    class custom_action
    {
        public void mouseEnter(TextBox text_box, string text)
        {
            if (text_box.Text == text)
                text_box.Text = "";
        }

        public void mouseLeave(TextBox text_box, string text)
        {
            if (text_box.Text == "" && text_box.IsFocused == false)
                text_box.Text = text;
        }

        public void mouseEnter(TextBlock text_box, string text)
        {
            if (text_box.Text == text)
                text_box.Text = "";
        }

        public void mouseLeave(TextBlock text_box, string text)
        {
            if (text_box.Text == "" && text_box.IsFocused == false)
                text_box.Text = text;
        }

        public bool birthdayChecker(DateTime birthday)
        {
            return (birthday - DateTime.Now).TotalDays < -6574.37;
        }
    }
}
