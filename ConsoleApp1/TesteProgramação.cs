using System;
using System.Xml;
using System.Globalization;

class TesteGupy{

    static void Main(String[] args) {
        TesteGupy tg = new TesteGupy();

        Console.WriteLine("Pergunta 1");
        Console.WriteLine("A soma é igual a " + tg.Pergunta1());
        Console.WriteLine("");

        Console.WriteLine("Pergunta 2");
        tg.Pergunta2();
        Console.WriteLine("");

        Console.WriteLine("Pergunta 3");
        tg.Pergunta3();
        Console.WriteLine("");

        Console.WriteLine("Pergunta 4");
        tg.Pergunta4();
        Console.WriteLine("");

        Console.WriteLine("Pergunta 5");
        tg.Pergunta5();
    }

    int Pergunta1(){
        int soma = 0;

        for (int k = 0; k < 13; k++){
            soma = soma + k;
        }
        return soma;
    }

    void Pergunta2(){
        Console.WriteLine("Digite um valor para checar a existencia na sequencia Fibonachi");


        int numeroATestar = int.Parse(Console.ReadLine());

        int valor1 = 0;
        int valor2 = 1;

        while (valor1 < numeroATestar){
            var resultado = valor1 + valor2;
            valor1 = valor2;
            valor2 = resultado;
            if (resultado == numeroATestar){
                Console.WriteLine("O valor faz parte da sequencia Fibonachi");
                return;
            }
        }
        Console.WriteLine("O valor não faz parte da sequencia Fibonachi");
    }

    void Pergunta3(){
        XmlDocument dadosXml = new XmlDocument();
        dadosXml.Load("dados.xml");
        XmlNodeList rows = dadosXml.GetElementsByTagName("row");

        float[] valores = new float[rows.Count];
        foreach (XmlNode row in rows){
            valores[int.Parse(row["dia"].InnerText)-1] = float.Parse(row["valor"].InnerText, CultureInfo.InvariantCulture); //Meu pc usa um teclado POR PTB, então . não separa float
        }

        float menorValor = valores[0];
        float maiorValor = valores[0];
        float soma = 0;
        foreach(float valor in valores){
            soma += valor;
        }
        float mediaMensal = soma / valores.Length;
        int qtdDiasValorMaiorMedia = 0;
        for (int i = 0; i < valores.Length; i++){
            if ((valores[i] != 0) && (valores[i]<menorValor)) menorValor = valores[i];
            if ((valores[i]>maiorValor)) maiorValor = valores[i];
            if (valores[i]>mediaMensal) qtdDiasValorMaiorMedia++;
        }

        Console.WriteLine("O menor valor ocorrido foi de " + menorValor);
        Console.WriteLine("O maior valor ocorrido foi de " + maiorValor);
        Console.WriteLine(qtdDiasValorMaiorMedia + " dias o valor diario foi maior que o valor da media mensal");
    }

    void Pergunta4(){
        String[] estados = {"SP", "RJ", "MG", "ES", "Outros"};
        double[] faturamento = {6783643, 36678.66, 29229.88, 27165.48, 19849.53};
        double total = 0;
        foreach(double valor in faturamento){
            total += valor;
        }
        
        for (int i = 0; i < estados.Length; i++){
            double porcentagem = faturamento[i]/total*100;
            Console.WriteLine(estados[i] + " faturou " + porcentagem.ToString("F2") + "%");
        }
    }

    void Pergunta5(){
        Console.WriteLine("Digite um texto para ser invertido");

        String texto = Console.ReadLine();
        String otxet = "";

        for (int i = texto.Length-1; i >= 0; i--){
            otxet += texto[i];
        }

        Console.WriteLine(otxet);
    }
}

