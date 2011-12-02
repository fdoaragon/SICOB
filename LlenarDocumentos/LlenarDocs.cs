using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using System.IO;
//using System.Collections.Generic;

namespace LlenarDocumentos
{
    public static class LLenarDocumentos
    {
        private static void FindAndRepalce(Microsoft.Office.Interop.Word.Application WordApp,
           object findText, object replaceWithText)
        {
            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundsLike = false;
            object nmatchAllWordForms = false;
            object foward = true;
            object format = false;
            object matchKashida = false;
            object matchDiacritics = false;
            object matchAledHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;
            WordApp.Selection.Find.Execute(ref findText, ref matchCase, ref matchWholeWord,
                ref matchWildCards, ref matchSoundsLike, ref nmatchAllWordForms, ref foward,
                ref  wrap, ref format, ref replaceWithText, ref replace, ref matchKashida, ref matchDiacritics,
                ref matchAledHamza, ref matchControl);
        }

        public static bool LLenarDocumentoWord(object fileName, object saveAs, Dictionary<string,string> replace)
        {
            object missing = System.Reflection.Missing.Value;
            try
            {
                Microsoft.Office.Interop.Word.ApplicationClass wordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
                Microsoft.Office.Interop.Word.Document aDoc = null;
                object readOnly = false, isVisible = false;
                wordApp.Visible = false;
                if (!File.Exists((string)fileName))
                {
                    MessageBox.Show("No existe el archivo " + fileName.ToString());
                    return false;
                }
                aDoc = wordApp.Documents.Open(ref fileName, ref missing, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible, ref missing, ref missing, ref missing, ref missing);
                aDoc.Activate();
                Dictionary<string, string>.KeyCollection fields = replace.Keys;
                foreach (string field in fields)
                {
                    FindAndRepalce(wordApp, field, replace[field]);
                }
                //aDoc.Content.InsertBefore("Principio\r\n\r\n");
                aDoc.SaveAs(ref saveAs, ref missing, ref missing, ref missing, ref missing
                    , ref missing, ref missing, ref missing, ref missing, ref missing, ref missing
                    , ref missing, ref missing, ref missing, ref missing, ref missing);
                aDoc.Close(ref missing, ref missing, ref missing);
                return true;

            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show("Error al leer o crear el archivo. " + ex.Message);
                return false;
            }
        }
    }
}
