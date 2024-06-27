using Blackberry.Robots.Facebook.Browsers;
using Blackberry.Robots.Facebook.Result;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Blackberry.Robots.Facebook.Process
{
    public class FacebookShare : BaseProcess
    {
        public string login { get; set; }
        public string senha { get; set; }
        public string nomePagina { get; set; }
        public string nomePerfil { get; set; }
        public string urlPublicacao { get; set; }

        public FacebookShare(string caminho)
        {
            LerConfig(caminho);
        }

        public FacebookShareResult SharePosts()
        {
            var result = new FacebookShareResult();
            BaseUrl = "https://facebook.com";

            Chrome = new GoogleChrome();
            Queue<string> fila = new Queue<string>();
            fila.Enqueue("Classificados Vila Carrão");
            fila.Enqueue("Classificados Vila Formosa / Tatuapé / Carrão / Antonieta e região");
            fila.Enqueue("Vila Guilhermina Zona Leste");
            fila.Enqueue("Penha, Ponte Rasa, Ermelino Matarazzo, V.Ré, Cisper etc.");
            fila.Enqueue("VILA FORMOSA");
            fila.Enqueue("Vila Matilde");
            fila.Enqueue("Zona Leste São Paulo, Compra, Venda e Troca");
            fila.Enqueue("TATUAPÉ Classificados e Serviços");
            fila.Enqueue("Desapego Zona Leste - SP");
            //fila.Enqueue("Desapega Vila Ré🛍🛒");
            fila.Enqueue("SAPOPEMBA CLASSIFICADOS");
            fila.Enqueue("ITAQUERA, SAVOY. CID LIDER. STA TEREZINHA.PATRIARCA,PENHA.");
            fila.Enqueue("Jardim Fernandes - Pesquisa sobre melhorias no bairro.");
            fila.Enqueue("Vila Nhocuné Arredores");
            fila.Enqueue("Mooca, Tatuapé e Penha  - Negócios");
            fila.Enqueue("Zona Leste/Vila Matilde / Vila Aricanduva/Tatuapé");
            fila.Enqueue("DESAPEGO Vila Carrão");
            fila.Enqueue("Tatuapé / Anália Franco - Anúncios e Informação");
            fila.Enqueue("ARTUR ALVIM e COHAB I");
            //fila.Enqueue("♥ MOOCA & TATUAPÉ ANÚNCIOS");
            fila.Enqueue("COHAB 2, Itaquera, Guaianases, Prestes MAIA, Jd São Paulo,  Compra /Venda");
            fila.Enqueue("GRUPO COHAB 2 - ITAQUERA");
            fila.Enqueue("Vendas e Trocas Penha Cangaiba Cisper e região . São Paulo Zona Leste");
            fila.Enqueue("Zona Leste Anuncie aqui");
            fila.Enqueue("GRUPO VILA MATILDE , MOÓCA, CARRÃO E CATRACAS");
            fila.Enqueue("Classificados de Arthur Alvim e Itaquera");
            fila.Enqueue("Desapegos - Penha, Cangaiba e região.");
            fila.Enqueue("Venda troca tudo Tatuapé ,Vila Formosa ,Vila Carrão ,Vila Ema e região");
            fila.Enqueue("Venda troca tudo Tatuapé ,Vila Formosa ,Vila Carrão ,Vila Ema e região");
            fila.Enqueue("OLX VILA MATILDE NEGÓCIOS: Belém, Penha, Pari, Brás, Tatuapé, Alvim, Mooca");
            fila.Enqueue("Classificados Penha, Vila Matilde e região");
            fila.Enqueue("OLX Cangaiba, Penha,Tiquatira, Danfer,Cisper,Vila Matilde, Ponte Rasa,ZL");
            fila.Enqueue("Vendas e Trocas SP Zona Leste");
            fila.Enqueue("VILA BUENOS AIRES / PENHA - Amigos vizinhos e moradores");
            fila.Enqueue("Desapego Arthur Alvim E região.");
            fila.Enqueue("Amigos da COHAB 1 ARTUR ALVIM");
            fila.Enqueue("Penha / SP vendas e serviços");
            fila.Enqueue("VENHA QUE EU SOU DA PENHA");
            fila.Enqueue("Cohab I Arthur Alvim");
            fila.Enqueue("Aricanduva Vl Formosa e Carrão");
            fila.Enqueue("Portal Da Vila Formosa ( ZL -SP)");
            fila.Enqueue("CLASSIFICADOS ANALIA FRANCO VILA FORMOSA CARRÃO TATUAPE AGUA RASA MOOCA");
            fila.Enqueue("Classificados vila Matilde,Patriarca,Aricanduva,Nova Savoia,Euthalia região");
            fila.Enqueue("Classificados Penha -SP");
            fila.Enqueue("Bairro Jardim Vila Formosa");
            fila.Enqueue("Classificados Vila Formosa");
            fila.Enqueue("VILA FORMOSA Classificados");
            fila.Enqueue("Feira Do rolo de Itaquera");
            fila.Enqueue("Desapego Zona Leste, Penha, Mooca, Itaquera, São Mateus, Cidade Tiradentes");
            fila.Enqueue("Penha de França, São Paulo -SP");
            fila.Enqueue("DESAPEGO ZONA LESTE");
            fila.Enqueue("Amigos do Jd Danfer/Cisper/ Vila Sílvia");
            fila.Enqueue("vendas,serviços vila alpina");
            fila.Enqueue("Ponte Rasa");
            fila.Enqueue("JARDIM NORDESTE SOMOS NÓS");
            fila.Enqueue("Grupo de Negócios na Penha - SP");
            fila.Enqueue("\"DESAPEGO\" Vila Formosa, Carrão, Tatuapé, Vila Santa Isabel e Redondezas.");
            fila.Enqueue("Vila Nova Manchester");

            try
            {
                string grupo = "";
                while (Step <= 10)
                {
                    try
                    {
                        switch (Step)
                        {
                            case 0:
                                LoginFacebook(login, senha);
                                break;
                            case 1:
                                AcessaTelaPagina(urlPublicacao);
                                break;
                            case 2:
                                SelecionaPerfil(nomePerfil);
                                break;
                            case 3:
                                IniciaCompartilhamento();
                                break;
                            case 4:
                                grupo = fila.Dequeue();
                                EscreveLog($"Iniciando publicação para o grupo {grupo}", true);
                                SelecionaGrupo(grupo);
                                break;
                            case 5:
                                Publicar();
                                EscreveLog($"Publicação realizada no grupo {grupo}", true);
                                break;
                            case 6:
                                FecharJanelaPopup();
                                if (fila.Any())
                                {
                                    Step = 3;
                                    goto case 3;
                                }
                                break;
                        }
                        Step++;
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine($"Falha ao realizar publicação no grupo {grupo}: {ex.Message}");
                        Step = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                result.ProcessOk = false;
                result.MsgCatch = ex.Message;
            }
            finally
            {
                Chrome.EncerraDriver();
                Chrome.EncerraNavegador();
            }
            return result;
        }

        private void LerConfig(string caminho)
        {
            using (StreamReader reader = new StreamReader(caminho))
            {
                login = reader.ReadLine();
                senha = reader.ReadLine();
                nomePagina = reader.ReadLine();
                nomePerfil = reader.ReadLine();
                urlPublicacao = reader.ReadLine();

                reader.Close();
            }
        }

        private void EscreveLog(string texto, bool escreveTxt = false)
        {
            var txt = $"{DateTime.Now.ToString("HH:mm:ss")} - {texto}";
            Console.WriteLine(txt);
            if (escreveTxt)
            {
                using (StreamWriter writer = new StreamWriter("log.txt", true))
                {
                    writer.WriteLine(txt);
                    writer.Flush();
                    writer.Close();
                }
            }
        }

        private void LoginFacebook(string login, string senha)
        {
            try
            {
                EscreveLog($"Acessando a tela de login");
                Chrome.Navegador.Navigate().GoToUrl(BaseUrl);
                Chrome.EscreveElemento("email", login, 10, 2, true);
                Chrome.EscreveElemento("pass", senha, 10, 2, true);

                var btnEntrar = Chrome.LocalizaElementoPropriedade("input", "value", "Entrar", 3, 2, false);
                if (btnEntrar == null) btnEntrar = Chrome.LocalizaElementoPropriedade("button", "tyoe", "submit", 3, 2, false);
                if (btnEntrar == null) throw new Exception("Não foi possível localizar o botão Entrar");
                btnEntrar.Click();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AcessaTelaPagina(string urlPublicacao)
        {
            try
            {
                EscreveLog("Acessando link da publicação");
                Thread.Sleep(5000);
                Chrome.Navegador.Navigate().GoToUrl($"{BaseUrl}/{urlPublicacao}");
                Chrome.LocalizaElementoPropriedade("a", "class", "_55pi _2agf _4o_4 _4jy0 _4jy3 _517h _51sy _59pe _42ft", 25, 2, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SelecionaPerfil(string nomePerfil)
        {
            try
            {
                EscreveLog("Selecionando o perfil pessoal para publicação");
                Thread.Sleep(5000);
                Chrome.ClicaElementoPropriedade("a", "class", "_55pi _2agf _4o_4 _4jy0 _4jy3 _517h _51sy _59pe _42ft", 10, 2, true);
                Chrome.ClicaElementoPropriedade("div", "data-tooltip-content", nomePerfil, 10, 2, true);
                Thread.Sleep(3000);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void IniciaCompartilhamento()
        {
            try
            {
                EscreveLog("Clicando em Compartilhar em um Grupo");
                Thread.Sleep(2000);
                Chrome.ClicaElementoTexto("a", "Compartilhar", 10, 2, true);
                Chrome.ClicaElementoTexto("span", "Compartilhar em um grupo", 10, 2, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SelecionaGrupo(string nomeGrupo)
        {
            try
            {
                EscreveLog($"Procurando o grupo {nomeGrupo}");
                Thread.Sleep(5000);
                for (int i = 0; i < 5; i++)
                {
                    try
                    {
                        Chrome.EscreveElementoProprieadade("input", "placeholder", "Nome do grupo", nomeGrupo, 10, 2, true);
                        Chrome.ClicaElementoTexto("span", nomeGrupo, 10, 2, true);
                        break;
                    }
                    catch (Exception ex)
                    {
                        if (i >= 4)
                        {
                            throw ex;
                        }
                        else
                        {
                            Thread.Sleep(2000);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Publicar()
        {
            try
            {
                EscreveLog($"Efetivando a publicação");
                Thread.Sleep(2000);
                Chrome.ClicaElementoTexto("button", "Publicar", 10, 2, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FecharJanelaPopup()
        {
            try
            {
                EscreveLog($"Verificando se será necessário fechar a mensagem popup");
                Thread.Sleep(2000);
                var elementoFechar = Chrome.LocalizaElementoTexto("span", "Fechar", 3, 2, false);
                if (elementoFechar != null)
                {
                    elementoFechar.Click();
                    Thread.Sleep(2000);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
