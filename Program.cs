string[] datosDocente = new string[5];
string[] camposDocente = new string[5] {"Nombres","Curso","Semestre","Aula","Nro. de Alumnos"};
const double criterioAprobacion=10.5;

Console.WriteLine("\n******************************************");
Console.WriteLine("*            BIENVENIDO DOCENTE          *");
Console.WriteLine("*       Ingrese sus datos por favor.     *");
Console.WriteLine("******************************************\n");
foreach(string campo in camposDocente){
    Console.Write($"{campo}: ");
    datosDocente[Array.IndexOf(camposDocente,campo)]=Console.ReadLine() ?? ""; 
    //Console.WriteLine($"{Array.IndexOf(camposDocente,campo)}: ");
}
Console.WriteLine("-------------------------------------------------");
Console.Write("Desea Registrar las notas de los alumnos (Y/N): ");
string opReg=Console.ReadLine() ?? "";
opReg=opReg.ToUpper();
Console.WriteLine("-------------------------------------------------");

if(opReg=="Y"){
    //datosAlumnos[]=pedirDatosAlumnos();
    int nroAlumnos = Convert.ToInt32(datosDocente[4]);//se convierte el campo Nro. Alumnos a Entero
    string[] camposAlumnos=new string[4] {"Nombres","Nota parcial 1","Nota parcial 2","Nota parcial 3"};    
    string[,] datosAlumnos=new string[nroAlumnos,7];
    Console.WriteLine("\n******************************************");
    Console.WriteLine("*       Ingreso de datos de Alumnos      *");
    Console.WriteLine("******************************************");
    
    for(int i=0;i<nroAlumnos;i++){
        Console.WriteLine($"\nAlumno {i+1}.");
        Console.WriteLine("---------\n");
        datosAlumnos[i,0] = "0" + Convert.ToString((i+1)); //Id de Alumno
        foreach(string campo in camposAlumnos){
            Console.Write($"{campo}: ");
            datosAlumnos[i,(Array.IndexOf(camposAlumnos,campo))+1] = Console.ReadLine() ?? "";
        }
        double promedio = Convert.ToInt32(datosAlumnos[i,2])*0.2 + Convert.ToInt32(datosAlumnos[i,3])*0.3 + Convert.ToInt32(datosAlumnos[i,4])*0.5;
        datosAlumnos[i,5]=Convert.ToString(promedio);
        
        if(promedio>=criterioAprobacion) {
            datosAlumnos[i,6]="PROMOVIDO";
        }
        else datosAlumnos[i,6]="REPITENTE";
        int promedioEntero=Convert.ToInt32(promedio);
        datosAlumnos[i,5]=Convert.ToString(promedioEntero);
        if(datosAlumnos[i,5].Length==1) datosAlumnos[i,5]="0" + datosAlumnos[i,5];

    }

    Console.Write("\nRegistro terminado / desea ver el resumen de notas y promedios (Y/N): ");
    string opProm = Console.ReadLine() ?? "";
    opProm=opProm.ToUpper();
    if(opProm=="Y"){
        Console.WriteLine("\n");
        ImprimirRegistro(datosDocente, datosAlumnos);
    }else{
        Console.WriteLine("El programa terminará...presione Enter.");
    }
    //foreach(string datos in datosAlumnos){
    //    Console.WriteLine(datos);
}

else{
    Console.WriteLine("El programa terminará...presione Enter.");
    //break;    
}
Console.ReadLine();

static void ImprimirRegistro(string[] datosDocente, string[,] datosAlumnos){
    //{"Nombres","Curso","Semestre","Aula","Nro. de Alumnos"};
    //{"id","Nombres","Nota parcial 1","Nota parcial 2","Nota parcial 3","promedio","estado"};    
    int nroAlumnos=Convert.ToInt32(datosDocente[4]);
    ColocarCaracter(72,"+");
    Console.Write($"\n+CURSO: {datosDocente[1].ToUpper()}");
    ColocarCaracter(71-(8+datosDocente[1].Length)," ");
    Console.WriteLine("+");
    Console.Write($"+DOCENTE: {datosDocente[0].ToUpper()}");
    ColocarCaracter(71-(10+datosDocente[0].Length)," ");
    Console.WriteLine("+");
    Console.Write($"+SEMESTRE: {datosDocente[2].ToUpper()}                        AULA: {datosDocente[3]}");
    ColocarCaracter(71-(41 + datosDocente[2].Length + datosDocente[3].Length)," ");
    Console.WriteLine("+");
    ColocarCaracter(72,"+");
    Console.WriteLine("\n+ID+ ALUMNO                                  + PF + CONDICION FINAL    +");
    ColocarCaracter(72,"+");
    Console.WriteLine();

    for(int i=0;i<nroAlumnos;i++){
        Console.Write($"+{datosAlumnos[i,0]}+ {datosAlumnos[i,1]}");
        ColocarCaracter(45-(3+datosAlumnos[i,0].Length + datosAlumnos[i,1].Length)," ");
        Console.Write($"+ {datosAlumnos[i,5]} + {datosAlumnos[i,6]}");
        ColocarCaracter(10," ");
        ColocarCaracter(1,"+");
        Console.WriteLine();
        //{datosAlumnos[i,5]} + {datosAlumnos[i,6]}");
    }
    ColocarCaracter(72,"+");
    Console.WriteLine("\nDesea Volver a Registrar todos los datos.(Y/N): ");
    Console.ReadLine();

}

//Funcion para escribir el caracter indicado cuantas veces se indica
static void ColocarCaracter(int cant,string caracter){ 
    for(int i=1;i<=cant;i++) Console.Write($"{caracter}");
}