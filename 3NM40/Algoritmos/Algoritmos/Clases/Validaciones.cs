using System.Windows.Forms;

namespace Algoritmos.Clases
{
    class Validaciones
    {
        public static void onlyLettersNubers(KeyPressEventArgs pE)
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
                pE.Handled = false;
            }
            if (char.IsPunctuation(pE.KeyChar))
            {
                pE.Handled = true;
            }
        }
        /*Otras validaciones que se podrían usar en futuras versiones
        public void SoloNumerosEnteros(KeyPressEventArgs pE)
        {
            if (char.IsLetter(pE.KeyChar))
            {
                pE.Handled = true;
            }
            if (char.IsControl(pE.KeyChar))
            {
                pE.Handled = false;
            }
            if (char.IsNumber(pE.KeyChar))
            {
                pE.Handled = false;
            }
            if (char.IsPunctuation(pE.KeyChar))
            {
                pE.Handled = true;
            }
            if (char.IsSeparator(pE.KeyChar))//Espacios
            {
                pE.Handled = true;
            }
        }
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
        }
        public void SinEspacios(KeyPressEventArgs pE)
        {
            if (char.IsLetter(pE.KeyChar))
            {
                pE.Handled = false;
            }
            if (char.IsControl(pE.KeyChar))
            {
                pE.Handled = false;
            }
            if (char.IsSeparator(pE.KeyChar))//Espacios
            {
                pE.Handled = true;
            }
            if (char.IsNumber(pE.KeyChar))
            {
                pE.Handled = false;
            }
        }
        public void SoloNumerosEnterosPositivos(KeyPressEventArgs pE)
        {
            if (char.IsLetter(pE.KeyChar))
            {
                pE.Handled = true;
            }
            if (char.IsControl(pE.KeyChar))
            {
                pE.Handled = true;
            }
            if (char.IsNumber(pE.KeyChar))
            {
                pE.Handled = false;
            }
            if (char.IsPunctuation(pE.KeyChar))
            {
                pE.Handled = true;
            }
            if (char.IsSeparator(pE.KeyChar))//Espacios
            {
                pE.Handled = true;
            }
            if (char.IsSymbol(pE.KeyChar))
            {
                pE.Handled = true;
            }
        }*/
    }
}
