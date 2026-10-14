class Program
{
    static ReaderWriterLockSlim readerWriterLockSlim = new ReaderWriterLockSlim();
    static Dictionary<int, string> persons = new Dictionary<int, string>(); 
    static Random random = new Random();
    static void Main()
    {
        var task1 = Task.Factory.StartNew(Read);
        var task2 = Task.Factory.StartNew(Write, "Custom");
        var task3 = Task.Factory.StartNew(Write, "Chander");
        var task4 = Task.Factory.StartNew(Read);

        Task.WaitAll(task1, task2, task3, task4);
    }
    static void Read()
    {
        for (int i = 0; i < 10; i++)
        {
            readerWriterLockSlim.EnterReadLock();
            Thread.Sleep(50);
            readerWriterLockSlim.ExitReadLock();
        }
    }
    static void Write(object user)
    {
        for (int i = 0; i < 10; i++)
        {
            //int id = random.Next(2000,5000);
            int id = GetRandom();
            readerWriterLockSlim.EnterReadLock();
            var person = $"Person {id}";
            persons.Add(id, person);
            readerWriterLockSlim.ExitReadLock();
            Console.WriteLine(user + " added "+person);
            Thread.Sleep(250);            
        }
    }
    static int GetRandom()
    {
        lock (random)
        {
            return random.Next(2000,5000);
        }
    }
}

/*
Bloqueo de lector/escritor
- [Instructor] Hay momentos en los que necesitamos trabajar con un recurso como un archivo que se actualizaría muy raramente, pero que podría leerse bastantes veces diferentes con diferentes hilos. Así que ahí es donde usamos bloqueos de lectura o escritura. Por lo tanto, podemos comenzar simulando una función de lectura y usar un bucle for que se ejecuta de cero a 10 y aquí es donde nos gustaría usar un bloqueo de lectura en un recurso en particular y luego dejarlo dormir durante algún tiempo y luego salir del bloqueo de lectura. Entonces, para eso necesitamos borrar el bloqueo de lectura, podemos decir bloqueo estático, de lector, de escritor y hay una versión delgada. Si está usando semi para delgado, eso significa que funciona mejor que semi para. Y si está utilizando el bloqueo de lector y escritor delgado, eso significa que funcionó mejor que el lector escritor real que viene con dot net. Podemos llamarlo lector escritor lock slim y crear una instancia aquí mismo, así que tenemos que hacer esto solo una vez. Ahora un recurso real, en lugar de usar un archivo o algo así, me gusta simplemente crear un diccionario estático que tenga int como ID y luego string como valor. De nuevo, simularemos un diccionario por ahora. Una vez que hayamos hecho eso, nos gustaría venir aquí y simular la funcionalidad de lectura. Podemos decir lector escritor lock slim dot entrar en read lock y luego usar thread dot sleep durante, digamos, 50 milisegundos y luego salir del bloqueo. Así que de esta manera salimos del bloqueo de lectura. Entonces, aunque podamos tener varios subprocesos diferentes adquiriendo el bloqueo de lectura, realmente no importa porque el bloqueo de lectura podría ser adquirido por varios subprocesos al mismo tiempo, que es exactamente como debería ser. Sin embargo, cuando alguien adquiere un bloqueo de escritura, no permitirá que nadie más adquiera un bloqueo y ahí es donde entra en juego la parte de escritura. Sin embargo, siempre seguimos usando el lector escritor lock slim. Así que vamos a usar exactamente el mismo objeto para la segunda parte de escritura. Entonces, para simular eso, podemos decir, escritura vacía estática y luego tenemos un bucle de cuatro; I es de uno a 10. De nuevo, yo plus plus y aquí podemos llegar a algún tipo de numeración aleatoria. Así que podríamos decir que un ID aleatorio podría estar en cualquier punto intermedio, nuevamente necesitaremos usar una función aleatoria, así que crearemos un objeto aquí estático, aleatorio, lo llamaré aleatorio igual a nuevo aleatorio y una vez que tenga aleatorio aquí, haremos el punto siguiente y luego haremos 2000 hasta 5000. Así que estamos diciendo que cree cualquier ID aleatorio y debe estar entre 2000 y 5000, puede hacer lo que quiera aquí. Ahora aquí es donde podemos usar enter write lock porque vamos a actualizar este diccionario en particular una vez que tengamos el bloqueo correcto, podemos llegar a esa lógica, puedo decir, usar la I del bucle for para darme unos 10 valores y ese será mi valor y podría usar el ID como I. Así que vamos a tener I o la identificación creada al azar es probablemente mejor, podemos usar eso y luego decir, persona como clave. Y una vez que se realiza la adición, he actualizado mi diccionario, puedo salir del bloqueo de escritura. Entonces, una lógica muy simple, ya que tenemos que actualizar el diccionario aquí mismo, eso sucede en la línea número 36, tenemos que crear un bloqueo de escritura y luego liberar ese bloqueo de escritura justo después de actualizarlo. Esto sucederá diez veces y cada vez, sin importar qué amenaza lo llame, tendrá que esperar hasta que se libere el bloqueo de escritura para acceder al diccionario. Y luego podemos simular algún tipo de lentitud aquí diciendo que espere al menos 250 milisegundos o algo así antes de que el siguiente intente actualizar el mismo diccionario nuevamente. Ahora, en este momento, estamos listos para comenzar y me gusta crear diferentes hilos y ver qué sucede. A continuación, cree una tarea mediante task dot factory dot start new. Esto inicia automáticamente una tarea y, a continuación, pasa el método de lectura. Y podemos copiar esto de nuevo varias veces porque estamos tratando de simular esto con diferentes hilos, podemos llamarlo tarea dos tres, luego queremos hacer un par de operaciones de escritura también. Tarea cuatro y tarea cinco, diría que hicimos una lectura aquí y luego podemos hacer una operación de escritura, cuando escribimos es posible que queramos pasar un valor. Así que aquí también quiero asegurarme de que puedo pasar la identificación. Y quiero poder saber qué hilo realmente llamó a esta función en particular. Podría decir que el usuario agregó esta entrada en particular. Hagamos otro escrito y llamémoslo Chander. Así que tenemos alrededor de tres lecturas diferentes y tenemos dos escrituras diferentes en curso y está sucediendo aquí mismo. Ahora, aunque estamos usando random aquí, no es una muy buena idea y lo solucionaremos en un segundo. Entonces, una cosa que debe asegurarse es que esperemos todas las tareas usando task dot wait all y luego podemos pasar todas estas tareas. Controle la palanca B y luego controle F5. Entonces, a veces, cuando ejecuta programas de subprocesos múltiples, desea asegurarse de que realmente ha realizado el cambio de control B antes del control F5 porque, de lo contrario, puede encontrarse con algunos problemas a veces con Visual Studio. Y si no obtiene el resultado que espera obtener, también le recomiendo reiniciar Visual Studio. Entonces, como puede ver aquí, tenemos a Chander y Caston agregando a estas personas y los números están ahí. Así que podemos agregar 10 personas cada una con dos objetos de escritura diferentes. Una cosa más a tener en cuenta es que tenemos un aleatorio aquí y se está usando dentro de un bloque sincronizado, pero se está usando sin sincronización. Entonces, una manera fácil de solucionar eso es tratar el método como static int y decir obtener un número o valor aleatorio. Y luego use un candado en la variable aleatoria y luego diga devolver el punto aleatorio a continuación y puede copiar esta línea de código. Así que ahora, en lugar de tener que hacer esto, simplemente puedes hacer esto. Y ahora tu código está sincronizado. Así que esta es una forma un poco mejor de escribir exactamente lo mismo.
*/