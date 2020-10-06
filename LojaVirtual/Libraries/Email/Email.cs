using LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Email
{
    public class Email
    {
        /// <summary>
        /// Envia um email
        /// </summary>
        /// <returns></returns>
        public static bool EnviarEmail(Contato contato)
        {
            var enviado = false;

            MailMessage MailMessageToAgtecnica = new MailMessage(); ;
            MailMessage MailMessageToCliente = new MailMessage(); ;
            SmtpClient SmtpClient = new SmtpClient("smtp.gmail.com", 587);
            try
            {
                //email para AGTECNICA

                MailMessageToAgtecnica.To.Add("ag.tecnica@yahoo.com");
                MailMessageToAgtecnica.From = new MailAddress(contato.Email);
                MailMessageToAgtecnica.Subject = contato.Assunto;
                MailMessageToAgtecnica.Body = MontarEmailAgtecnica(contato);
                MailMessageToAgtecnica.IsBodyHtml = true;

                //Email para CLIENTE
                MailMessageToCliente.To.Add(contato.Email);
                MailMessageToCliente.From = new MailAddress(contato.Email);
                MailMessageToCliente.Subject = contato.Assunto;
                MailMessageToCliente.Body = MontarEmailCliente(contato);

                MailMessageToCliente.IsBodyHtml = true;

                //https://myaccount.google.com/lesssecureapps Permitir aplicativos menos seguros GMAIL
                SmtpClient.UseDefaultCredentials = false;
                SmtpClient.Credentials = new NetworkCredential("agtecnica.st@gmail.com", "ksagoncalves");
                SmtpClient.EnableSsl = true;
                SmtpClient.Send(MailMessageToAgtecnica);
                SmtpClient.Send(MailMessageToCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (MailMessageToAgtecnica != null)
                    MailMessageToAgtecnica.Dispose();

                if (MailMessageToCliente != null)
                    MailMessageToCliente.Dispose();

                if (SmtpClient != null)
                    SmtpClient.Dispose();
            }


            return enviado;
        }

        private static string MontarEmailCliente(Contato contato)
        {
            StringBuilder email = new StringBuilder();

            email.AppendLine("<!DOCTYPE html >");
            email.AppendLine(" <html lang = \"en\" >");
            email.AppendLine("  <head >");
            email.AppendLine("      <title > Bootstrap 4 Website Example</title >");
            email.AppendLine("         <meta charset = \"utf-8\" >");
            email.AppendLine("          <meta name = \"viewport\" content = \"width=device-width, initial-scale=1\" >");
            //email.AppendLine("             <link rel = \"stylesheet\" href = \"https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css\" >");
            email.AppendLine("                   <link href = \"https://fonts.googleapis.com/css2?family=Abril+Fatface&amp;family=Limelight&amp;display=swap\" rel=\"stylesheet\" > ");

            email.AppendLine("                      <style > ");
            email.AppendLine("                   ");

            email.AppendLine("            .containerPrincipal { ");
            email.AppendLine("                  border: 1px solid #cbc3c3; ");
            email.AppendLine("                  border-radius: 5px; ");
            email.AppendLine("                  margin: 20px auto; ");
            email.AppendLine("                  width: 60%; ");
            email.AppendLine("            } ");
            email.AppendLine(" ");
            email.AppendLine("        .fakeimg { ");
            email.AppendLine("            height: 200px; ");
            email.AppendLine("            background: #aaa; ");
            email.AppendLine("        } ");
            email.AppendLine(".jumbotron {");
            email.AppendLine("background - color: #e9ecef;");
            email.AppendLine(" } ");
            email.AppendLine(" ");
            email.AppendLine("        .textoH1 { ");
            email.AppendLine("                font-family: 'Limelight', cursive; margin: 19px 0px -5px 0 !important;");
            email.AppendLine("            } ");
            email.AppendLine(" ");
            email.AppendLine("        .cabecalho { ");
            email.AppendLine("            width: 100%; ");
            email.AppendLine("            padding: 15px 0; ");
            email.AppendLine("            margin: 0;  ");
            email.AppendLine("             float: left; ");
            email.AppendLine("              background-color: #e9ecef;");
            email.AppendLine("              border-radius: 5px 5px 0 0;");
            email.AppendLine("            } ");
            email.AppendLine(" ");
            email.AppendLine("            .cabecalho > div { ");
            email.AppendLine("            } ");
            email.AppendLine(" ");
            email.AppendLine("                .cabecalho > div.col-sm-7 > div { ");
            email.AppendLine("                float: left; ");
            email.AppendLine("            } ");
            email.AppendLine("            .cabecalho > div > div > h4 {");
            email.AppendLine("                  font-family: sans-serif;");
            email.AppendLine("            }");
            email.AppendLine(" ");
            email.AppendLine(" ");
            email.AppendLine("             .cabecalho > div > h1, .cabecalho > div > h4 { ");
            email.AppendLine("                  height: 40%; ");
            email.AppendLine("            } ");
            email.AppendLine(" ");
            email.AppendLine("                .cabecalho > div > img { ");
            email.AppendLine("                width: 60%; ");
            email.AppendLine("                float: right; ");
            email.AppendLine("            } ");
            email.AppendLine(" ");
            email.AppendLine("            .cabecalho > .col-sm-5 { ");
            email.AppendLine("                 display: inline-block; width: 40%; ");
            email.AppendLine("            } ");
            email.AppendLine(" ");
            email.AppendLine("            .cabecalho > .col-sm-5, .col-sm-7 { ");
            email.AppendLine("                 width: 40%; ");
            email.AppendLine("                text-align: center; ");
            email.AppendLine("            } ");
            email.AppendLine(" ");


            email.AppendLine("           .cabecalho > .col-sm-7 { ");
            email.AppendLine("              width: 59%; ");
            email.AppendLine("              display: inline-block; ");
            email.AppendLine("              float: right; ");
            email.AppendLine("           } ");

            email.AppendLine("          .conteudo { ");
            email.AppendLine("              text-align: center; ");
            email.AppendLine("              padding: 80px 0; ");
            email.AppendLine("              font-family: sans-serif; ");
            email.AppendLine("              margin-top: 90px; ");
            email.AppendLine("            } ");
            email.AppendLine(" ");
            email.AppendLine("          .footer { ");
            email.AppendLine("              margin-bottom: 0; ");
            email.AppendLine("              padding: 20px 20px 5px 20px; ");
            email.AppendLine("              text-align: center;");
            email.AppendLine("               font-family: sans-serif; background-color: #e9ecef;");
            email.AppendLine("            } ");
            email.AppendLine("    </style > ");
            email.AppendLine("</head > ");
            email.AppendLine("<body > ");
            email.AppendLine(" ");
            email.AppendLine("    <div class=\"containerPrincipal\"> ");
            email.AppendLine("        <div class=\"jumbotron text-center cabecalho row\" style=\"margin-bottom:0\"> ");
            email.AppendLine("            <!--   <div>--> ");
            email.AppendLine("            <div class=\"col-sm-5 col-md-5\"> ");
            email.AppendLine("                <img src = \"https://www.agtecnica.com.br/Images/icon.PNG\" alt=\"A.G. Técnica Segurança e controle\" /> ");
            email.AppendLine("            </div> ");
            email.AppendLine("            <div class=\"col-sm-7 col-md-7\"> ");
            email.AppendLine(" ");
            email.AppendLine("                <div> ");
            email.AppendLine("                    <h1 class=\"textoH1\">A.G TÉCNICA</h1> ");
            email.AppendLine(" ");
            email.AppendLine("");
            email.AppendLine("                    <h4>SEGURANÇA E CONTROLE</h4> ");
            email.AppendLine("                </div> ");
            email.AppendLine("            </div> ");
            email.AppendLine("            <!--   </div>--> ");
            email.AppendLine("        </div> ");
            email.AppendLine(" ");
            email.AppendLine("");
            email.AppendLine("        <div class=\"container conteudo\"> ");
            email.AppendLine(" ");
            email.AppendLine($"            <h2>Obrigado <span>{ contato.Nome },</span> por acessar nosso site!</h2> ");
            email.AppendLine(" ");
            email.AppendLine("            <br /> ");
            email.AppendLine($"            <h4>Email: { contato.Email }</h4> ");
            email.AppendLine($"            <h4>Mensagem: { contato.Mensagem }</h4> ");
            email.AppendLine(" ");
            email.AppendLine("            <br /> ");
            email.AppendLine("            <br /> ");
            email.AppendLine("            <h5>Em breve entraremos em contato.</h5> ");
            email.AppendLine("        </div> ");
            email.AppendLine(" ");
            email.AppendLine("        <div class=\"jumbotron text-center footer\"> ");
            email.AppendLine("            <p> ");
            email.AppendLine("                ©2020 - A.G.TÉCNICA Segurança e Controle ");
            email.AppendLine("           </p> ");
            email.AppendLine("        </div> ");
            email.AppendLine(" ");
            email.AppendLine("    </div> ");
            email.AppendLine(" ");
            email.AppendLine("</body> ");
            email.AppendLine("</html> ");


            return email.ToString();
        }

        private static string MontarEmailAgtecnica(Contato cliente)
        {
            StringBuilder email = new StringBuilder();

            email.AppendLine("<!DOCTYPE html >");
            email.AppendLine(" <html lang = \"en\" >");
            email.AppendLine("  <head >");
            email.AppendLine("      <title > Bootstrap 4 Website Example</title >");
            email.AppendLine("         <meta charset = \"utf-8\" >");
            email.AppendLine("          <meta name = \"viewport\" content = \"width=device-width, initial-scale=1\" >");
            email.AppendLine("                   <link href = \"https://fonts.googleapis.com/css2?family=Abril+Fatface&amp;family=Limelight&amp;display=swap\" rel=\"stylesheet\" > ");

            email.AppendLine("                      <style > ");
            email.AppendLine("                   ");

            email.AppendLine("            .containerPrincipal { ");
            email.AppendLine("                  border: 1px solid #cbc3c3; ");
            email.AppendLine("                  border-radius: 5px; ");
            email.AppendLine("                  margin: 20px auto; ");
            email.AppendLine("                  width: 60%; ");
            email.AppendLine("            } ");
            email.AppendLine(" ");
            email.AppendLine("        .fakeimg { ");
            email.AppendLine("            height: 200px; ");
            email.AppendLine("            background: #aaa; ");
            email.AppendLine("        } ");
            email.AppendLine(".jumbotron {");
            email.AppendLine("background - color: #e9ecef;");
            email.AppendLine(" } ");
            email.AppendLine(" ");
            email.AppendLine("        .textoH1 { ");
            email.AppendLine("                font-family: 'Limelight', cursive; margin: 19px 0px -5px 0 !important;");
            email.AppendLine("            } ");
            email.AppendLine(" ");
            email.AppendLine("        .cabecalho { ");
            email.AppendLine("            width: 100%; ");
            email.AppendLine("            padding: 15px 0; ");
            email.AppendLine("            margin: 0;  ");
            email.AppendLine("             float: left; ");
            email.AppendLine("              background-color: #e9ecef;");
            email.AppendLine("              border-radius: 5px 5px 0 0;");
            email.AppendLine("            } ");
            email.AppendLine(" ");
            email.AppendLine("            .cabecalho > div { ");
            email.AppendLine("            } ");
            email.AppendLine(" ");
            email.AppendLine("                .cabecalho > div.col-sm-7 > div { ");
            email.AppendLine("                float: left; ");
            email.AppendLine("            } ");
            email.AppendLine("            .cabecalho > div > div > h4 {");
            email.AppendLine("                  font-family: sans-serif;");
            email.AppendLine("            }");
            email.AppendLine(" ");
            email.AppendLine(" ");
            email.AppendLine("             .cabecalho > div > h1, .cabecalho > div > h4 { ");
            email.AppendLine("                  height: 40%; ");
            email.AppendLine("            } ");
            email.AppendLine(" ");
            email.AppendLine("                .cabecalho > div > img { ");
            email.AppendLine("                width: 60%; ");
            email.AppendLine("                float: right; ");
            email.AppendLine("            } ");
            email.AppendLine(" ");
            email.AppendLine("            .cabecalho > .col-sm-5 { ");
            email.AppendLine("                 display: inline-block; width:40%; ");
            email.AppendLine("            } ");
            email.AppendLine(" ");
            email.AppendLine("            .cabecalho > .col-sm-5, .col-sm-7 { ");
            email.AppendLine("                 height: 40%; ");
            email.AppendLine("                text-align: center; ");
            email.AppendLine("            } ");
            email.AppendLine(" ");


            email.AppendLine("           .cabecalho > .col-sm-7 { ");
            email.AppendLine("              width: 59%; ");
            email.AppendLine("              display: inline-block; ");
            email.AppendLine("              float: right; ");
            email.AppendLine("           } ");

            email.AppendLine("          .conteudo { ");
            email.AppendLine("              text-align: center; ");
            email.AppendLine("              padding: 80px 0; ");
            email.AppendLine("              font-family: sans-serif; ");
            email.AppendLine("              margin-top: 90px; ");
            email.AppendLine("            } ");
            email.AppendLine(" ");
            email.AppendLine("          .footer { ");
            email.AppendLine("              margin-bottom: 0; ");
            email.AppendLine("              padding: 20px 20px 5px 20px; ");
            email.AppendLine("              text-align: center;");
            email.AppendLine("               font-family: sans-serif; background-color: #e9ecef;");
            email.AppendLine("            } ");
            email.AppendLine("    </style > ");
            email.AppendLine("</head > ");
            email.AppendLine("<body > ");
            email.AppendLine(" ");
            email.AppendLine("    <div class=\"containerPrincipal\"> ");
            email.AppendLine("        <div class=\"jumbotron text-center cabecalho row\" style=\"margin-bottom:0\"> ");
            email.AppendLine("            <!--   <div>--> ");
            email.AppendLine("            <div class=\"col-sm-5 col-md-5\"> ");
            email.AppendLine("                <img src = \"https://www.agtecnica.com.br/Images/icon.PNG\" alt=\"A.G. Técnica Segurança e controle\" /> ");
            email.AppendLine("            </div> ");
            email.AppendLine("            <div class=\"col-sm-7 col-md-7\"> ");
            email.AppendLine(" ");
            email.AppendLine("                <div> ");
            email.AppendLine("                    <h1 class=\"textoH1\">A.G TÉCNICA</h1> ");
            email.AppendLine(" ");
            email.AppendLine("");
            email.AppendLine("                    <h4>SEGURANÇA E CONTROLE</h4> ");
            email.AppendLine("                </div> ");
            email.AppendLine("            </div> ");
            email.AppendLine("            <!--   </div>--> ");
            email.AppendLine("        </div> ");
            email.AppendLine(" ");
            email.AppendLine("");
            email.AppendLine("        <div class=\"container conteudo\"> ");
            email.AppendLine(" ");
            email.AppendLine($"            <h2>Contato: <span>{ cliente.Nome }.</h2> ");
            email.AppendLine($"            <h5>Acesso em: <span>{DateTime.Now.ToShortDateString() } as { DateTime.Now.ToShortTimeString() }.</h5> ");
            email.AppendLine(" ");
            email.AppendLine("            <br /> ");
            email.AppendLine($"            <h5>Email: { cliente.Email }</h5> ");
            email.AppendLine($"            <h5>Mensagem: { cliente.Mensagem }</h5> ");
            email.AppendLine(" ");
            email.AppendLine("            <br /> ");
            email.AppendLine("            <br /> ");
            email.AppendLine("            <h5 style=\"color: red;\">Necessário entrar em contato com o cliente.</h5> ");
            email.AppendLine("        </div> ");
            email.AppendLine(" ");
            email.AppendLine("        <div class=\"jumbotron text-center footer\"> ");
            email.AppendLine("            <p> ");
            email.AppendLine("                © 2020 - A.G.TÉCNICA Segurança e Controle ");
            email.AppendLine("           </p> ");
            email.AppendLine("        </div> ");
            email.AppendLine(" ");
            email.AppendLine("    </div> ");
            email.AppendLine(" ");
            email.AppendLine("</body> ");
            email.AppendLine("</html> ");


            return email.ToString();
        }
    }
}
