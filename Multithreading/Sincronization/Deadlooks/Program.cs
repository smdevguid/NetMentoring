using System.Diagnostics;

class Program
{
    static object customLock = new object();
    static object otherLock = new object();
    static void Main()
    {
        new Thread(() =>
        {
            lock (customLock)
            {
                Console.WriteLine("Custom lock obtained");
                Thread.Sleep(2000);
                lock (otherLock)
                {
                    Console.WriteLine("Anoter lock obtained");
                }
            }
        }).Start();

        lock (otherLock)
        {
            Console.WriteLine("Main thread Anoter lock obtained");
            Thread.Sleep(1000);
            lock (customLock)
            {
                Console.WriteLine("Main thread Custom lock obtained");
            }
        }
    }
}
/**
Bloqueo de punto muerto
- [Instructor] El bloqueo es engañosamente simple.
 A veces podemos entrar en puntos muertos mientras estamos haciendo bloqueos y esa no es una buena situación para estar. Solo mostraremos un interbloqueo simple que puede ocurrir con el uso simple de dos bloqueos. Así que borraremos dos cerraduras. Voy a llamar a esto Cazton Lock. Y otro candado con mi nombre, Chander. Entonces, de manera muy simple, podemos hacer que un hilo resuelva la referencia usando el sistema, no el subproceso, y luego, dentro de eso, podemos usar el primer bloqueo. Nuevamente, para que esto funcione aquí, tendrás que hacerlo estático. O puede moverlo dentro del método solo para simplificarlo. Entonces, una vez que tenga Cazton Lock aquí, quiero asegurarme de saber que acabamos de ingresar aquí para poder decir console dot write line, Cazton Lock obtenido o exitoso. Una vez que tengo este bloqueo que se ha obtenido lo que quiero hacer es tener el hilo principal, ahora este es un hilo completamente diferente, no es el hilo principal, lo que quiero hacer es que el hilo principal compita por este bloqueo en particular mientras este hilo ya tiene acceso a este bloqueo. Antes de eso, es posible que deseemos asegurarnos de que este bloqueo no se libere durante al menos un par de segundos y luego anidar este bloqueo aquí mismo dentro de él. Y podría decir Chander Lock, tenga en cuenta que este es un bloqueo completamente diferente, y luego podemos copiar la línea número 21. Cámbielo a Chander de Cazton. Entonces, si nota que tenemos Cazton Lock, una vez que este hilo adquiera Cazton Lock, liberará ese número de línea 27 y si ningún otro hilo está accediendo a Chander Lock en el número de línea 23, debería poder adquirirlo y liberarlo en el número de línea 26. Sin embargo, si algún otro subproceso puede adquirir el control de este bloqueo, tendrá que esperar a que ese subproceso ejecute estas líneas de código antes de que realmente pueda adquirir el bloqueo nuevamente. Así que hagámoslo, lo que podemos hacer es que el hilo principal realmente bloquee o adquiera el bloqueo en Chander Lock y podemos pegar esto aquí diciendo que el hilo principal obtuvo Chander Lock. Ahora esto suena como una situación fácil y va a funcionar, nada se va a bloquear, así que podemos hacer el control f5, hilo principal obtenido Chander Lock. Ahora también queremos asegurarnos de que comenzamos esto diciendo que iniciemos ese hilo en particular. Entonces, de esta manera, en realidad tenemos este inicio de hilo en particular y luego también tenemos el hilo principal tratando de bloquear Chander Lock. Entonces, si tuviera que hacer el control f5, como puede ver, el hilo principal obtuvo Chander Lock, luego el hilo trabajador obtuvo Cazton Lock y luego tomó unos dos segundos antes de que se obtuviera Chander Lock. Así que esta es una situación muy simple. Realmente no hay nada dañino aquí. No hay forma real de que pueda haber un punto muerto. Ahora, ¿qué podría crear un posible punto muerto? Y tratemos de imaginar eso. Como notamos, Chander Lock se otorgó al hilo principal antes de este hilo en particular. ¿Por qué? La razón es simple, porque en la línea número 19 el hilo de trabajo pudo adquirir Cazton Lock. Luego se duerme durante unos dos segundos. Durante ese tiempo, el hilo principal pudo adquirir Chander Lock, por eso obtenemos Chander Lock antes que el otro hilo. Ahora, cuando llegamos aquí, Chander Lock ya había sido lanzado por el hilo principal. Es por eso que pudimos obtener ese candado muy rápidamente. Entonces, para que podamos crear algún tipo de situación de interbloqueo, queremos asegurarnos de que este bloqueo, que es Chander Lock adquirido por el hilo principal, no se libere en un momento en que el hilo de trabajo quiera Chander Lock. Al mismo tiempo, también podemos crear una situación aquí en la que estamos haciendo que el hilo principal compita por Cazton Lock. Como notará, esta será una situación de punto muerto. Y ahora, para asegurarnos de que sea una situación de punto muerto, queremos darle al menos un segundo de tiempo de sueño. Y la razón es simple. Si te fijas, el hilo trabajador podrá adquirir Cazton Lock muy rápidamente y en fracciones de segundos tendrás el hilo principal adquirir Chander Lock. Una vez que ambos adquieren el bloqueo, ¿qué sucede después? El subproceso de trabajo se bloqueará en el número de línea 23 porque Chander Lock no habrá sido liberado por el subproceso principal y el subproceso principal se bloqueará en el número de línea 33 porque Cazton Lock no habría sido liberado por el subproceso de trabajo. Entonces, si nota, esta es una situación de punto muerto. Y solo está sucediendo por la forma en que está sucediendo esta ejecución. Muchas veces, cuando tenemos bloqueos anidados olvidamos el impacto que puede crear si algún otro hilo va a acceder a un bloqueo anidado. Por lo tanto, las cerraduras anidadas son extremadamente poderosas, pero al mismo tiempo, las cerraduras anidadas podrían ser mal utilizadas por otro desarrollador que puede no saber que las tiene como una de las cerraduras anidadas. Entonces, cada vez que agrega una cerradura anidada, debe tener mucho, mucho cuidado y asegurarse de proteger esa cerradura. Entonces, si tuviera que hacer el control f5, notará que el hilo está bloqueado allí mismo y realmente no veremos que suceda nada más.
*/