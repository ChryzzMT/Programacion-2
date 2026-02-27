
public class NumeroNatural
{
    //caracteristicas
    private int valor;
    
    //constructor por defecto
    public NumeroNatural()
    {
        valor = 1;
    }
    public NumeroNatural(int num)
    {
        PonerValor(num);
    }

    public void PonerValor(int val)
    {
        if (val>=0)
        {
            this.valor = val;
        }
    }

    public int ObtenerValor()
    {
        return valor;
    }

    
    //Metodo que retorna la cantidad de digitos
    public int CantDig()
    {
        int n = valor;
        int cont = 0;
        if (n==0)
        {
            return 1;
        } 
        while (n > 0)
        {
            cont++;
            n = n / 10;
        }
        return  cont;
    }
    //Insertar un dígito X en la posición Y del valor
    public void InsertarDigito(int digito, int posicion)
    {

	    int valorCopia=0;
	    while (valor > 0)
	    {
		    int digExtraido=valor%10;
		    valorCopia=valorCopia*10+digExtraido;
		    valor = valor / 10;
	    }
	    int cont = 1;
	    while (valorCopia>0)
	    {
		    int digExtraido=valorCopia%10;
		    if (cont == posicion)
		    {
			    valor=valor*10+digito;
		    }
		    valor=valor*10+digExtraido;
		    valorCopia = valorCopia / 10;
		    cont++;

	    }
    }

    public void Cambiar(ref int num1, ref int num2)
    {
	    int temp = num1;
	    num1=num2;
	    num2=temp;
    }
    
    //Ordenar dígitos (2 métodos de ordenamiento), Ej.: 78291 --> 12789
    public void OrdenamientoInsercion()
    {
	    int[] valorArr = new int [CantDig()];
	    int cont = 0;
	    while (valor > 0)
	    {
			int digExtra=valor%10;
			valorArr[cont]=digExtra;
			cont++;
			valor = valor / 10;
	    }
	    
	    for (int i = 1; i < valorArr.Length; i++)
	    {
		    int j = i;
		    while (j > 0 && valorArr[j]<valorArr[j-1])
		    {
			    Cambiar(ref valorArr[j],ref valorArr[j-1]);
			    j = j - 1;
		    }

	    }

	    for (int i = 0; i < valorArr.Length; i++)
	    {
		    valor=valor*10+valorArr[i];
	    }
	    
    }

    public void OrdenamientoShell()
    {
	    int[] valorArr = new int [CantDig()];
	    int cont = 0;
	    while (valor > 0)
	    {
		    int digExtra=valor%10;
		    valorArr[cont]=digExtra;
		    cont++;
		    valor = valor / 10;
	    }

	    for (int gap = valorArr.Length / 2; gap > 0; gap = gap / 2)
	    {
		    for (int i = gap; i < valorArr.Length; i++)
		    {
			    int j = i;
			    while (j >= gap && valorArr[j] < valorArr[j - 1])
			    {
				    Cambiar(ref valorArr[j],ref valorArr[j-1]);
				    j = j - gap;
			    }
			    
		    }
	    }
	    
	    for (int i = 0; i < valorArr.Length; i++)
	    {
		    valor=valor*10+valorArr[i];
	    }
	    
    }
    
    
    //Convertir a Literal, Ej.: 125 --> ciento veinticinco
    public string ConvLiteral()
    {
	    string[,] matrizLiterales = {
		    {"cero", "uno", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve"},
		    {"", "diez", "veinte", "treinta", "cuarenta", "cincuenta", "sesenta", "setenta", "ochenta", "noventa"},
		    {"", "ciento", "doscientos", "trescientos", "cuatrocientos", "quinientos", "seiscientos", "setecientos", "ochocientos", "novecientos"},
		    {"", "mil", "dos mil", "tres mil", "cuatro mil", "cinco mil", "seis mil", "siete mil", "ocho mil", "nueve mil"}
	    };
	    string literal="";
	    int cont=0;
	    int n = valor;
	    if(n==0)
	    { 
		    return "cero";
	    }
	    while(n>0){
		    int dig=n%10;		
		    literal=matrizLiterales[cont,dig]+" "+literal;	
		    n=n/10;
		    cont=cont+1;
	    }
	    return literal;
    }
}
