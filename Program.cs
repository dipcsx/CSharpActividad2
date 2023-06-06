string[] datosDocente = new string[5];
string[] camposDocente = new string[5] {"Nombres","Curso","Semestre","Aula","Nro. de Alumnos"};

const double criterioAprobacion=10.5;

Console.WriteLine("\n******************************************");
Console.WriteLine("*            BIENVENIDO DOCENTE          *");
Console.WriteLine("*       Ingrese sus datos por favor.     *");
Console.WriteLine("******************************************\n");
//PETICION Y VALIDACION DE DATOS DEL DOCENTE
foreach(string campo in camposDocente){
    string Error;
    do{
        //{"Nombres","Curso","Semestre","Aula","Nro. de Alumnos"};
        Console.Write($"{campo}: ");
        datosDocente[Array.IndexOf(camposDocente,campo)]=Console.ReadLine() ?? "";
        datosDocente[Array.IndexOf(camposDocente,campo)]=datosDocente[Array.IndexOf(camposDocente,campo)].ToUpper();
        Error=ValidarCampo(datosDocente[Array.IndexOf(camposDocente,campo)],campo);
        if(Error!=""){
            Console.WriteLine($"Se presento el error: {Error}");
            Console.WriteLine($"Reintente...");
        } 
    }while(Error!="");
}
//FIN PETICION Y VALIDACION DATOS DOCENTE
Console.WriteLine("-------------------------------------------------");
string ErrorOp,opReg;
//DoWhile para validar la opcion Y o N
do{
    Console.Write("Desea Registrar las notas de los alumnos (Y/N): ");
    opReg=Console.ReadLine() ?? "";
    opReg=opReg.ToUpper();
    ErrorOp=ValidarCampo(opReg,"YN");
    if(ErrorOp!=""){
        Console.WriteLine($"Se presento el error: {ErrorOp}");
        Console.WriteLine($"Reintente...");
    }
Console.WriteLine("-------------------------------------------------");
}while(ErrorOp!="");
//fin DoWhile
if(opReg=="Y"){
    
    int nroAlumnos = Convert.ToInt32(datosDocente[4]);//se convierte el campo Nro. Alumnos a Entero
    string[] camposAlumnos=new string[4] {"Nombres","Nota parcial 1","Nota parcial 2","Nota parcial 3"};    
    string[,] datosAlumnos=new string[nroAlumnos,7];
    Console.WriteLine("\n******************************************");
    Console.WriteLine("*       Ingreso de datos de Alumnos      *");
    Console.WriteLine("******************************************");
    
    for(int i=0;i<nroAlumnos;i++){
        Console.WriteLine($"\nAlumno {i+1}.");
        Console.WriteLine("---------\n");
        datosAlumnos[i,0] = "0" + Convert.ToString((i+1)); //Id de Alumno automatico
        foreach(string campo in camposAlumnos){
            string Error;
            do{
                //{"Nombres","Nota parcial 1","Nota parcial 2","Nota parcial 3"};    
                Console.Write($"{campo}: ");
                datosAlumnos[i,(Array.IndexOf(camposAlumnos,campo))+1] = Console.ReadLine() ?? "";
                datosAlumnos[i,(Array.IndexOf(camposAlumnos,campo))+1]=datosAlumnos[i,(Array.IndexOf(camposAlumnos,campo))+1].ToUpper();
                Error=ValidarCampo(datosAlumnos[i,(Array.IndexOf(camposAlumnos,campo))+1],campo);
                if(Error!=""){
                    Console.WriteLine($"Se presento el error: {Error}");
                    Console.WriteLine($"Reintente...");
                } 
            }while(Error!="");   
        }
        double promedio = Convert.ToInt32(datosAlumnos[i,2])*0.2 + Convert.ToInt32(datosAlumnos[i,3])*0.3 + Convert.ToInt32(datosAlumnos[i,4])*0.5;
        datosAlumnos[i,5]=Convert.ToString(promedio);
        
        if(promedio>=criterioAprobacion) datosAlumnos[i,6]="PROMOVIDO";
        else datosAlumnos[i,6]="REPITENTE";

        //datosAlumnos[i,6]=EvaluarPromedio(criterioAprobacion,promedio);

        int promedioEntero=Convert.ToInt32(promedio);//Convierto el Promedio decimal a Entero
        datosAlumnos[i,5]=Convert.ToString(promedioEntero);//luego almaceno el promedioEntero al array como string.
        //En caso promedio me sale menor a 10 (ejem. 2) le anexo un cero por delante: Ejem. 02
        if(datosAlumnos[i,5].Length==1) datosAlumnos[i,5]="0" + datosAlumnos[i,5]; 
    }

    
    Console.WriteLine("-------------------------------------------------");
    string opProm;
    do{
    Console.Write("Registro terminado / desea ver el resumen de notas y promedios (Y/N): ");
    opProm=Console.ReadLine() ?? "";
    opProm=opProm.ToUpper();
    ErrorOp=ValidarCampo(opProm,"YN");
    if(ErrorOp!=""){
        Console.WriteLine($"Se presento el error: {ErrorOp}");
        Console.WriteLine($"Reintente...");
    }
    Console.WriteLine("-------------------------------------------------");
    }while(ErrorOp!="");

    if(opProm=="Y"){
        Console.WriteLine("\n");
        ImprimirRegistro(datosDocente, datosAlumnos);
        Console.WriteLine("\n\nSe generó la libreta de promedios..Presione ENTER para salir...");
        Console.ReadLine();
    }else{
        Console.WriteLine("El programa terminará...presione Enter.");
    }
}

else{
    Console.WriteLine("El programa terminará...presione Enter.");   
}
Console.ReadLine();

static void ImprimirRegistro(string[] datosDocente, string[,] datosAlumnos){
    //{"Nombres","Curso","Semestre","Aula","Nro. de Alumnos"};
    //{"id","Nombres","Nota parcial 1","Nota parcial 2","Nota parcial 3","promedio","estado"};    
    int nroAlumnos=Convert.ToInt32(datosDocente[4]);
    ColocarCaracter(72,"+");
    Console.Write($"\n+CURSO: {datosDocente[1]}");
    ColocarCaracter(71-(8+datosDocente[1].Length)," ");
    Console.WriteLine("+");
    Console.Write($"+DOCENTE: {datosDocente[0]}");
    ColocarCaracter(71-(10+datosDocente[0].Length)," ");
    Console.WriteLine("+");
    Console.Write($"+SEMESTRE: {datosDocente[2]}                        AULA: {datosDocente[3]}");
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

    }
    ColocarCaracter(72,"+");
}

//Funcion para escribir el caracter indicado cuantas veces se indica
static void ColocarCaracter(int cant,string caracter){ 
    for(int i=1;i<=cant;i++) Console.Write($"{caracter}");
}
static bool SonLetras(string cadena){
    bool validacion=true;
    int CA, CU;
    if(cadena.Trim()!=""){
        //A-Z = 65 al 90 // a-z = 97 al 122
        // no valido: á=160,é=130 ,í=161 ,ó=162 ,ú=163, ñ=164, Ñ=165 
        //no valido: Á=181 É=144 Í=214 Ó=224 Ú=233 
        //espacio=32
        
        //á=225 é=233 í=237 ó=243 ú=250
        //Á=193 É=201 Í=205 Ó=211 Ú=218
        //Ñ=209 ñ=241
        for(int i=0;i<cadena.Length;i++){
            CA=(int)cadena[i];
            CU=Convert.ToInt32(cadena[i]);
            if(CA>=65 && CA<=90 || CA>=97 && CA<=122) {
                validacion = true; 
            }
            else if(CU==161 || CU==225 || CU==233 || CU==237 || CU==243 || CU==250 || CU==193 || CU==201 || CU==205 || CU==211 || CU==218|| CU==209 || CU==241 || CA==32){
                validacion = true;
            }
            else{
                validacion = false;
                break;
            }
        }
    }else {
        return false;   
    }

    return validacion;   
}
static string ValidarCampo(string datos, string campo=""){
	string mensajeError="";
	datos=datos.Trim();
	if(datos==""){
		mensajeError="Campo vacío";
	} else if(!SonLetras(datos) && campo=="Nombres"){
		mensajeError="Nombre con numeros";		
	} else if(!EsNumero(datos) && campo=="Nro. de Alumnos"){
		mensajeError="Nro de alumnos con letras o con OverFlow";
	} else if((!EsNumero(datos) && campo=="Nota parcial 1") || 
        (!EsNumero(datos) && campo=="Nota parcial 2") || 
        (!EsNumero(datos) && campo=="Nota parcial 3")){
		mensajeError="Notas con letras";
	} else if((campo=="YN" && datos!="Y") && (campo=="YN" && datos!="N")){
        mensajeError="Debe ingresar solo Y o N.";
    }	
return mensajeError;
}
static bool EsNumero(string datos){
    if(int.TryParse(datos, out int numero)){
        return true;
    }else return false;
}