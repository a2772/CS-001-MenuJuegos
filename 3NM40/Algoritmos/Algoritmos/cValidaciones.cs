using System.Windows.Forms;

namespace Algoritmos
{
    class cValidaciones
    {
        public void SoloLetrasSEspacios(KeyPressEventArgs pE)
        {
            if (char.IsLetter(pE.KeyChar))
            {
                pE.Handled = false;
            }
            if (char.IsControl(pE.KeyChar))
            {
                pE.Handled = false;
            }
            if (char.IsSeparator(pE.KeyChar))
            {
                pE.Handled = true;
            }
            if (char.IsNumber(pE.KeyChar))
            {
                pE.Handled = true;
            }
            if (char.IsSymbol(pE.KeyChar))
            {
                pE.Handled = true;
            }
            if (char.IsPunctuation(pE.KeyChar))
            {
                pE.Handled = true;
            }
        }
    }
}
