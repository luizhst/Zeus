<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Acesso.aspx.vb" Inherits="Project_Zeus.Acesso" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" />

    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Acesso</title>

    <%--<link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />--%>
    <link rel="stylesheet" type="text/css" href="~/Content/vendor/bootstrap/css/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="~/Content/fonts/font-awesome-4.7.0/css/font-awesome.min.css" />
    <link rel="stylesheet" type="text/css" href="~/Content/fonts/iconic/css/material-design-iconic-font.min.css" />
    <link rel="stylesheet" type="text/css" href="~/Content/vendor/animate/animate.css" />
    <link rel="stylesheet" type="text/css" href="~/Content/vendor/css-hamburgers/hamburgers.min.css" />
    <link rel="stylesheet" type="text/css" href="~/Content/vendor/animsition/css/animsition.min.css" />
    <link rel="stylesheet" type="text/css" href="~/Content/vendor/select2/select2.min.css" />
    <link rel="stylesheet" type="text/css" href="~/Content/vendor/daterangepicker/daterangepicker.css" />
    <link rel="stylesheet" type="text/css" href="~/Content/Css/util.css" />
    <link rel="stylesheet" type="text/css" href="~/Content/Css/main.css" />


</head>

<body>
    <form id="frmAcesso" runat="server">

        <div class="limiter">
            <div class="container-login100">
                <div class="wrap-login100">
                    <form class="login100-form validate-form">
                        <span class="login100-form-title p-b-26">Bem Vindo
                        </span>

                        <span class="login100-form-title p-b-48"></span>

                        <div class="wrap-input100 validate-input" data-validate="Informe uma conta válida!">
                            <label class="focus-input100">Conta</label>
                            <br />
                            <input class="input100" type="text" name="email" runat="server" id="txt_conta" required="required" />
                        </div>

                        <div class="wrap-input100 validate-input" data-validate="Insira uma senha válida!">
                            <label class="focus-input100">Senha</label>
                            <br />
                            <input class="input100" type="password" name="pass" runat="server" id="txt_senha" required="required" />
                        </div>

                        <div class="container-login100-form-btn">
                            <asp:Button CssClass="btn btn-primary" runat="server" ID="btn_logar" OnClick="btn_logar_Click" Text="Entrar no sistema" />
                        </div>

                        <br />

                        <h6 style="text-align: center; color: red">
                            <asp:Label runat="server" ID="lblMensagem"></asp:Label>
                        </h6>

                        <div class="text-center p-t-100">
                            <%--<span class="txt1">Ainda não possui uma conta?
                            </span>
                            <a class="txt2" href="#">Sign Up</a>--%>
                            <p>&copy; <%: DateTime.Now.Year %> - AdaptGestão | Controle</p>
                        </div>
                    </form>
                </div>
            </div>
        </div>

    </form>


    <script src="~/Content/vendor/jquery/jquery-3.2.1.min.js"></script>
    <script src="~/Content/vendor/animsition/js/animsition.min.js"></script>
    <script src="~/Content/vendor/bootstrap/js/popper.js"></script>
    <script src="~/Content/vendor/bootstrap/js/bootstrap.min.js"></script>
    <script src="~/Content/vendor/select2/select2.min.js"></script>
    <script src="~/Content/vendor/daterangepicker/moment.min.js"></script>
    <script src="~/Content/vendor/daterangepicker/daterangepicker.js"></script>
    <script src="~/Content/vendor/countdowntime/countdowntime.js"></script>
    <script src="~/Content/js/main.js"></script>

</body>
</html>
