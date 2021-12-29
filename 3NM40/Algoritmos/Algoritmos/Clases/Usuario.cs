using System;

namespace Algoritmos.Clases
{
    class Usuario
    {
        private int idPassword;//Como es identity se usa como consulta y de nexo a las otras tablas
        private String usrName;
        private String passwd;
        private String nombres;//Éste no está en la BD pero se usa de auxiliar
        private DateTime fechaNac;
        private Byte[] foto;
        private int idSexo;
        private int idTipoUser;
        public int getIdPassword()
        {
            return idPassword;
        }
        public void setIdPassword(int idPassword)
        {
            this.idPassword = idPassword;
        }
        public String getUsrName()
        {
            return usrName;
        }
        public void setUsrName(String usrName)
        {
            this.usrName = usrName;
        }
        public String getPasswd()
        {
            return passwd;
        }
        public void setPasswd(String passwd)
        {
            this.passwd = passwd;
        }
        public String getNombres()
        {
            return nombres;
        }
        public void setNombres(String nombres)
        {
            this.nombres = nombres;
        }
        public DateTime getFechaNac()
        {
            return fechaNac;
        }
        public void setFechaNac(DateTime fechaNac)
        {
            this.fechaNac = fechaNac;
        }
        public int getIdSexo()
        {
            return idSexo;
        }
        public void setIdSexo(int idSexo)
        {
            this.idSexo = idSexo;
        }
        public int getIdTipoUser()
        {
            return idTipoUser;
        }
        public void setIdTipoUser(int idTipoUser)
        {
            this.idTipoUser = idTipoUser;
        }
        public Byte[] getFoto()
        {
            return this.foto;
        }
        public void setFoto(Byte[] foto)
        {
            this.foto = foto;
        }
        //Métodos de obtención de cadenas de la CURP
        public String valNomAps(String nombres)
        {
            bool valid = true;
            String message = "";//Mensaje de error, si termina así es que no hubo errores
            int i = 0, contador = 1;//Lleva la cuenta de los nombres
            char[] aux = nombres.ToCharArray();//Pasamos a arreglo de caracteres
            int length = aux.Length;
            for (i = 0; i < length; i++)
            {//Valida que los caracteres sean aceptados y que no haya espacios dobles además de que cuenta el numero de nombres
                if (!Char.IsLetter(aux[i]) && !Char.IsSeparator(aux[i]))
                {
                    //Aa-zZ; á-ú,ñÑ; é; Á-Ú (5 comparaciones); espacio
                    valid = false;//Marcamos que no fue válido por no ser una letra
                    message += "Xx Error: Ingresa solo letras xX" + Environment.NewLine;
                }
                if (i + 1 < length)
                {
                    if (aux[i] == (char)32 && aux[i + 1] == (char)32)
                    {//Si es espacio y el siguiente también, se invalida
                        valid = false;
                        message += "Xx Error: No ingreses espacios seguidos xX" + Environment.NewLine;
                    }
                    else if (aux[i] == (char)32)//De otro modo, cuenta la palabra, como al final es corte de linea, contará eso como palabra igual
                        contador++;//Contamos palabra
                }
            }
            if (aux[length - 1] == (char)32)//Si termina en espacio
            {
                valid = false;
                message += "Xx Error: No deje espacios al final xX" + Environment.NewLine;
            }
            if (valid)
            {//Usamos esto para saber si fue valido en el for y si no termina en espacio
             //Verificamos que el apellido paterno tenga una vocal mínimo después de la 1ra posición
             //Ubicando el ap paterno
                try
                {
                    bool flg = false;
                    int i1 = 0, i2 = 0;//Indices para ubicar los apellidos
                    char first = 'S';//Primera vocal del Ap paterno
                    for (i = 0; i < length; i++)
                    {//Extraemos el nombre inicial y marcamos el inicio de los apellidos
                        if (flg == false && aux[i] == (char)32)
                        {
                            flg = true;
                            i1 = i + 1;//Posible posición de i1, +1 porque es la primera letra del tentativo primer apellido
                        }
                        else
                        if (flg == true)
                        {//Si ya no está en el primer nombre
                            if (aux[i] == (char)32)
                            {//Si es espacio, se revisa i2, pues i1 siempre que flg sea true traerá un valor
                                if (i2 != 0)
                                {//Si ambos tienen algo, se cambia el valor de i2 a i1 e i2 toma el valor actual de i+1
                                    i1 = i2;
                                    i2 = i + 1;
                                }
                                else //De lo contrario, solo se asigna valor a i2
                                    i2 = i + 1;
                            }
                        }
                    }
                    for (i = i1 + 1; i < i2 - 1; i++)
                    {
                        if (Char.ToUpper(aux[i]) == (char)65 || Char.ToUpper(aux[i]) == (char)69 || Char.ToUpper(aux[i]) == (char)73 || Char.ToUpper(aux[i]) == (char)79 || Char.ToUpper(aux[i]) == (char)85)
                        {//Si es Vocal sencilla, se asigna y sale del ciclo
                            first = Char.ToUpper(aux[i]);
                            i = i2;
                        }
                        if (wthOutAcent(aux[i]) != (char)32)//Si es acentuada, la pasamos a normal
                            first = wthOutAcent(aux[i]);//Ya convierte a mayus
                    }
                    //Fin ubicación, sabemos que tiene vocal si first cambio de 'S' a cualquier vocal
                    if (first != 'S' && contador >= 3 && aux[0] != (char)32)
                    {//Por último, el contador debe estar en 3 o ser mayor (deben ser al menos dos apellidos y un nombre) y no debe comenzar con un espacio
                        char cN = (char)32, cP = (char)32, cM = (char)32;//Segundas consonantes de nombre y apellidos
                        for (i = 1; i < i1; i++)//Para nombre
                            if (aux[i] == 32)//Si llega al fin del nombre, sale
                                i = i1;
                            else if ((Char.ToLower(aux[i]) > (char)97 && Char.ToLower(aux[i]) <= (char)122 && Char.ToLower(aux[i]) != (char)101 && Char.ToLower(aux[i]) != 105 && Char.ToLower(aux[i]) != 111 && Char.ToLower(aux[i]) != 117) || aux[i] == 164 || aux[i] == 165)
                            {
                                //Si es consonante, se guarda y sale
                                cN = aux[i];
                                i = i1;
                            }
                        for (i = i1 + 1; i < i2 - 1; i++)//Para Apellido Paterno
                            if (aux[i] == 32)//Si llega al fin del ap, sale
                                i = i2;
                            else if ((Char.ToLower(aux[i]) > 97 && Char.ToLower(aux[i]) <= 122 && Char.ToLower(aux[i]) != 101 && Char.ToLower(aux[i]) != 105 && Char.ToLower(aux[i]) != 111 && Char.ToLower(aux[i]) != 117) || aux[i] == 164 || aux[i] == 165)
                            {
                                //Si es consonante, se guarda y sale
                                cP = aux[i];
                                i = i2;
                            }
                        for (i = i2 + 1; i < length; i++)//Para Apellido Materno
                            if (aux[i] == 32)//Si llega al fin del ap, sale
                                i = length;
                            else if ((Char.ToLower(aux[i]) > 97 && Char.ToLower(aux[i]) <= 122 && Char.ToLower(aux[i]) != 101 && Char.ToLower(aux[i]) != 105 && Char.ToLower(aux[i]) != 111 && Char.ToLower(aux[i]) != 117) || aux[i] == 164 || aux[i] == 165)
                            {
                                //Si es consonante, se guarda y sale
                                cM = aux[i];
                                i = length;
                            }
                        if (cN != (char)32 && cP != (char)32 && cM != (char)32)
                        {//Si todos tienen al menos una consonante
                            valid = true;//no se excede el límite 
                        }
                        else
                        {
                            valid = false;
                            message += "Xx Error: El primer nombre y los apellidos deben tener una consonante sin contar la inicial xX" + Environment.NewLine;
                        }
                    }
                    else
                        if (aux[0] == (char)32)
                        message += "Xx Error: No deje espacios al inicio xX" + Environment.NewLine;
                    else
                        message += "Xx Error: Debe ingresar al menos un nombre y dos apellidos válidos xX" + Environment.NewLine;
                    if (first == 'S')
                        message += "Xx Error: El primer apellido debe tener una vocal sin contar la inicial xX" + Environment.NewLine;
                }
                catch (Exception ex)
                {
                    message += ex;
                }
            }
            return message;
        }
        public static int getEdad(DateTime fechaDeNacimiento)
        {
            return DateTime.Today.AddTicks(-fechaDeNacimiento.Ticks).Year - 1;
        }
        char wthOutAcent(char let)
        {//Devuelve la vocal sin el acento y en mayuscula, si no es vocal, regresa un espacio
            char woVal = (char)32;
            if (let == 'á' || let == 'a')
                woVal = 'A';
            if (let == 'é' || let == 'e')
                woVal = 'E';
            if (let == 'í' || let == 'i')
                woVal = 'I';
            if (let == 'ó' || let == 'o')
                woVal = 'O';
            if (let == 'ú' || let == 'u')
                woVal = 'U';
            if (let == 'ñ' || let == 'Ñ')
                woVal = 'X';//las Ñ las cambia por X en la CURP
            return woVal;
        }
        public String subCurp(char sexo, String cveEntidad, String homoclave)//Devuelve el/los nombre(s) dada la cadena validada
        {
            //Datos que usa de este objeto
            char[] cadena = this.nombres.ToCharArray();
            //Fin datos que usa
            int i, i1 = 0, i2 = 0;//Indices para uicar los apellidos
            bool flg = false;
            char first = 'S';
            for (i = 0; i < cadena.Length; i++)
            {//Extraemos el nombre inicial y marcamos el inicio de los apellidos
                if (flg == false && cadena[i] == 32)
                {
                    flg = true;
                    i1 = i + 1;//Posible posición de i1, +1 porque es la primera letra del tentativo primer apellido
                }
                if (flg == true)
                {//Si ya no está en el primer nombre
                    if (cadena[i] == (char)32)
                    {//Si es espacio, se revisa i2, pues i1 siempre que flg sea true traerá un valor
                        if (i2 != 0)
                        {//Si ambos tienen algo, se cambia el valor de i2 a i1 e i2 toma el valor actual de i+1
                            i1 = i2;
                            i2 = i + 1;
                        }
                        else //De lo contrario, solo se asigna valor a i2
                            i2 = i + 1;
                    }
                }
            }
            //Buscamos la primera vocal del ap paterno
            for (i = i1 + 1; i < i2 - 1; i++)
            {//Como ya está validado que lleve vocal a partir de la segunda vocal del ap paterno
                if (Char.ToUpper(cadena[i]) == (char)65 || Char.ToUpper(cadena[i]) == (char)69 || Char.ToUpper(cadena[i]) == (char)73 || Char.ToUpper(cadena[i]) == (char)79 || Char.ToUpper(cadena[i]) == (char)85)
                {//Si es Vocal sencilla, se asigna y sale del ciclo
                    first = Char.ToUpper(cadena[i]);
                    i = i2;
                }
                else if (wthOutAcent(cadena[i]) != (char)32)
                {//Si es acentuada, la pasamos a normal
                    first = wthOutAcent(cadena[i]);//Ya convierte a mayus
                    i = i2;
                }
            }
            char[] curp = new char[19];
            //Una vez ubicamos los apellidos, vaciamos la primera parte al curp
            curp[0] = Char.ToUpper(cadena[i1]);
            curp[1] = first;
            curp[2] = Char.ToUpper(cadena[i2]);
            curp[3] = Char.ToUpper(cadena[0]);//1.-Inicial primer nombre
                                              //Obtenemos, dia, mes y año
                                              //Concatenando al final con la función año (últimos dos dígitos), mes y día
            char[] year = fechaNac.Year.ToString().ToCharArray();
            curp[4] = year[2];
            curp[5] = year[3];
            char[] month = fechaNac.Month.ToString().ToCharArray();
            if (fechaNac.Month < 10)
            {
                curp[6] = '0';
                curp[7] = month[0];
            }
            else
            {
                curp[6] = month[0];
                curp[7] = month[1];
            }
            char[] day = fechaNac.Day.ToString().ToCharArray();
            if (fechaNac.Day < 10)
            {
                curp[8] = '0';
                curp[9] = day[0];
            }
            else
            {
                curp[8] = day[0];
                curp[9] = day[1];
            }
            curp[10] = Char.ToUpper(sexo);
            char[] entFed = cveEntidad.ToCharArray();
            curp[11] = entFed[0];
            curp[12] = entFed[1];
            char cN = '1', cP = '1', cM = '1';
            for (i = 1; i < i1; i++)//Para nombre
                if (cadena[i] == 32)//Si llega al fin del nombre, sale
                    i = i1;
                else if ((Char.ToLower(cadena[i]) > 97 && Char.ToLower(cadena[i]) <= 122 && Char.ToLower(cadena[i]) != 101 && Char.ToLower(cadena[i]) != 105 && Char.ToLower(cadena[i]) != 111 && Char.ToLower(cadena[i]) != 117) || cadena[i] == 164 || cadena[i] == 165)
                {
                    //Si es consonante, se guarda y sale
                    cN = Char.ToUpper(cadena[i]);
                    i = i1;
                }
            for (i = i1 + 1; i < i2 - 1; i++)//Para Apellido Paterno
                if (cadena[i] == 32)//Si llega al fin del ap, sale
                    i = i2;
                else if ((Char.ToLower(cadena[i]) > 97 && Char.ToLower(cadena[i]) <= 122 && Char.ToLower(cadena[i]) != 101 && Char.ToLower(cadena[i]) != 105 && Char.ToLower(cadena[i]) != 111 && Char.ToLower(cadena[i]) != 117) || cadena[i] == 164 || cadena[i] == 165)
                {
                    //Si es consonante, se guarda y sale
                    cP = Char.ToUpper(cadena[i]);
                    i = i2;
                }
            for (i = i2 + 1; i < cadena.Length; i++)//Para Apellido Materno
                if (cadena[i] == 32)//Si llega al fin del ap, sale
                    i = cadena.Length;
                else if ((Char.ToLower(cadena[i]) > 97 && Char.ToLower(cadena[i]) <= 122 && Char.ToLower(cadena[i]) != 101 && Char.ToLower(cadena[i]) != 105 && Char.ToLower(cadena[i]) != 111 && Char.ToLower(cadena[i]) != 117) || cadena[i] == 164 || cadena[i] == 165)
                {
                    //Si es consonante, se guarda y sale
                    cM = Char.ToUpper(cadena[i]);
                    i = cadena.Length;
                }
            curp[13] = cP;
            curp[14] = cM;
            curp[15] = cN;
            char[] homoClave = homoclave.ToUpper().ToCharArray();
            curp[16] = homoClave[0];
            curp[17] = homoClave[1];
            String Curp = "";
            for (i = 0; i < 18; i++)
            {
                Curp += curp[i];
            }
            return Curp;
        }
        public static string getCveEntidad(int cve)
        {
            return InicioSesion.getCveEntidad(cve);
        }
    }
}
