using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
namespace Giser_Lu
{
    class InsertCharacterAtCursorInTextBox
    {
       // int m_SelectionTextIndex;//光标所在位置
        //string m_StringToInsert;
        RichTextBox m_RichTextBox;

        public InsertCharacterAtCursorInTextBox(RichTextBox richtxtBx)
        {
            m_RichTextBox = richtxtBx;
        }
       public  void InsertCharacterAtCursor(ref int selectionIndex ,string StringToInsert)
        {


            m_RichTextBox.SelectedText = "";

            if (m_RichTextBox.Text == "")
            { selectionIndex = 0; }

            m_RichTextBox.Text = m_RichTextBox.Text.Insert(selectionIndex, StringToInsert);
            m_RichTextBox.Focus();
            m_RichTextBox.SelectionStart = selectionIndex + StringToInsert.Length;
            selectionIndex = m_RichTextBox.SelectionStart;
        }

        

    }
}
