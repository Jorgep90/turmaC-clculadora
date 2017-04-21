using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _20170317_calculadoraCompleta.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        public ActionResult Index()
        {

            // inicialização de variáveis
            ViewBag.Visor = "0";
            Session["operador"] = "";
            Session["limpaEcra"] = true;

            return View();
        }


        // POST: Home
        /// <summary>
        /// recebe os dados da View e processa-os
        /// com vista a calcular o resultado a apresentar
        /// ao utilizador
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(string bt, string visor)
        {

            // vars. auxiliares

            // qual o valor do botão que foi pressionado?
            switch (bt)
            {
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    if (visor.Equals("0") || (bool)Session["limpaEcra"])
                    {
                        visor = bt;
                        Session["limpaEcra"] = false;
                    }
                    else visor += bt; //visor = visor + bt;
                    break;
                //******************************************************
                case ",":
                    if (!visor.Contains(",")) visor += bt;
                    break;
                //******************************************************
                case "+/-":
                    if (!visor.StartsWith("-")) visor = "-" + visor;
                    else visor = visor.Replace("-", "");
                    break;
                //*************************
                case "+":
                case "-":
                case ":":
                case "x":
                    // já alguém carregou num operador?
                    string auxOperador = (string)Session["operador"];
                    // se já alguém carregou...
                    if (!auxOperador.Equals(""))
                    {
                        // já foi carregado um operador antes
                        // vamos fazer as contas...
                        double auxOperando1 = Convert.ToDouble(Session["operando"]);
                        double auxOPerando2 = Convert.ToDouble(visor);
                        switch (auxOperador)
                        {
                            case "+":
                                visor = auxOperando1 + auxOPerando2 + "";
                                break;
                            case "-":
                                visor = auxOperando1 - auxOPerando2 + "";
                                break;
                            case "x":
                                visor = auxOperando1 * auxOPerando2 + "";
                                break;
                            case ":":
                                visor = auxOperando1 / auxOPerando2 + "";
                                break;
                        }
                    }
                    // independentemente de ser a primeira vez que se carrega num operador,
                    // ou não, há que guardar estes valores para memória futura...
                    // preservar o valor do operador
                    Session["operador"] = bt;
                    // preservar o valor do visor, para memória futura
                    Session["operando"] = visor;
                    // marcar o visor para limpeza
                    Session["limpaEcra"] = true;

                    break;
                //******************************************************
                case "=":
                    // já alguém carregou num operador?
                    auxOperador = (string)Session["operador"];
                    // se já alguém carregou antes...
                    if (!auxOperador.Equals(""))
                    {
                        // já foi carregado um operador antes
                        // vamos fazer as contas...
                        double auxOperando1 = Convert.ToDouble(Session["operando"]);
                        double auxOPerando2 = Convert.ToDouble(visor);
                        switch (auxOperador)
                        {
                            case "+":
                                visor = auxOperando1 + auxOPerando2 + "";
                                break;
                            case "-":
                                visor = auxOperando1 - auxOPerando2 + "";
                                break;
                            case "x":
                                visor = auxOperando1 * auxOPerando2 + "";
                                break;
                            case ":":
                                visor = auxOperando1 / auxOPerando2 + "";
                                break;
                        }
                    }
                    // independentemente de ser a primeira vez que se carrega num operador,
                    // ou não, há que guardar estes valores para memória futura...

                    // fazer reset ao valor do operador
                    Session["operador"] = "";
                    // preservar o valor do visor, para memória futura
                    Session["operando"] = visor;
                    // marcar o visor para limpeza
                    Session["limpaEcra"] = true;

                    break;
                //******************************************************
                case "C":
                    // fazer reset ao valor do operador
                    Session["operador"] = "";
                    // fazer reset ao valor do visor
                    Session["operando"] = "";
                    // marcar o visor para limpeza
                    Session["limpaEcra"] = true;
                    // limpar o visor
                    visor = "0";
                    break;
            } // fim do switch() que faz a gestão dos botões


            // preparar os dados para serem enviados para a View
            ViewBag.Visor = visor;

            return View();
        } // fim do método INDEX (em ambiente Http.POST)


    }
}