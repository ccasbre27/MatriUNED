using System;

namespace App1
{
    public class UNED
    {
        // acá se debe incluir la lógica para matricular
        // en este caso únicamente se genera un número aleatorio y se verifica si es par o no
        // en caso que sea par se devuelve true que indica que "se realizo la matrícula"
        // en caso que sea impar se devuele false que indica que "hubo un problema para realizar la matrícula"
        public bool RealizarMatricula()
        {
            Random rnd = new Random();
            return rnd.Next() % 2 == 0;
        }
    }
}

