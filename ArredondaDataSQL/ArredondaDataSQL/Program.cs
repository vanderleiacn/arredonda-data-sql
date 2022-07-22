// See https://aka.ms/new-console-template for more information
static DateTime ArredondaMilisegundos(string strData, string valorArredondado)
{
    DateTime novaData;
    strData = $"{strData.Substring(0, strData.Length - 1)}{valorArredondado}";
    novaData = DateTime.ParseExact(strData, "yyyy-MM-dd HH:mm:ss fff", null);
    return novaData;
}

static DateTime ArredondaData(string strData)
{
    var data = DateTime.ParseExact(strData, "yyyy-MM-dd HH:mm:ss fff", null);
    var ultimoDigito = data.Millisecond % 10;

    DateTime novaData;

    if (ultimoDigito == 9)
        novaData = data.AddMilliseconds(1);
    else if (ultimoDigito >= 5 && ultimoDigito <= 8)
        novaData = ArredondaMilisegundos(strData, "7");
    else if (ultimoDigito >= 2 && ultimoDigito <= 4)
        novaData = ArredondaMilisegundos(strData, "3");
    else 
        novaData = ArredondaMilisegundos(strData, "0");

    return novaData;
}

//Array de data para serem arredondadas.
var datas = new string[]{
    "2022-07-22 23:59:59 990",
    "2022-07-22 23:59:59 991",
    "2022-07-22 23:59:59 992",
    "2022-07-22 23:59:59 993",
    "2022-07-22 23:59:59 994",
    "2022-07-22 23:59:59 995",
    "2022-07-22 23:59:59 996",
    "2022-07-22 23:59:59 997",
    "2022-07-22 23:59:59 998",
    "2022-07-22 23:59:59 999",
    "2022-07-22 23:59:59 099",
    "2022-07-22 23:59:59 095",
    "2022-07-22 23:59:59 108",
    "2022-07-22 23:59:59 009"
};

foreach (var strData in datas)
{
    DateTime novaData = ArredondaData(strData);

    Console.WriteLine(
        $"Data Original: {strData} -- Data Arredondada: {novaData.ToString("yyyy-MM-dd HH:mm:ss fff")}"
    );
}