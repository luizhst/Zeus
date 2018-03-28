<%@ Page Title="Cadastro Usuario" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="IncluirUsuario.aspx.vb" Inherits="Project_Zeus.IncluirUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <br />
        <br />
        <div class="col-md-12">
            <div class="panel" style="box-shadow: unset">

                <div class="panel-wrapper collapse in" aria-expanded="false">
                    <div class="panel-body">

                        <div class="form-body">
                            <h3 class="box-title">Cadastrar um novo usuário</h3>

                            <hr>

                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label ">Código</label>
                                        <asp:TextBox runat="server" ID="txt_cod_usuario" MaxLength="150" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label ">Nome do Usuario</label>
                                        <asp:TextBox runat="server" required="true" ID="txt_nome_usuario" MaxLength="150" CssClass="form-control"></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label ">Sobrenome do Usuario</label>
                                        <asp:TextBox runat="server" required="true" ID="txt_sobrenome_usuario" MaxLength="250" CssClass="form-control"></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label ">Login</label>
                                        <asp:TextBox runat="server" required="true" MaxLength="50" ClientIDMode="Static" ID="txt_login" CssClass="form-control"></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label ">Senha</label>
                                        <asp:TextBox runat="server" required="true" MaxLength="50" ClientIDMode="Static" ID="txt_senha" CssClass="form-control"  TextMode="Password"></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label ">Data de Nascimento</label>
                                        <asp:TextBox runat="server" required="true" MaxLength="50" ID="txt_nascimento" TextMode="DateTime" CssClass="form-control"></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label">Status</label>
                                        <asp:DropDownList AutoPostBack="false   " runat="server" AppendDataBoundItems="true" CssClass="dropdown form-control" SelectionMode="sigle" MaxLength="50" ID="drp_status">
                                            <asp:ListItem Value="true" Text="Ativo" />
                                            <asp:ListItem Value="false" Text="Inativo" />
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <br />
                            </div>

                            <br />

                            <div>
                                <asp:Button runat="server" CssClass="btn btn-success" ID="btn_registrar" Text="Cadastrar" OnClick="btn_registrar_Click" />
                                <a class="btn btn-default" href="Usuarios.aspx">Voltar</a>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>

    </div>

</asp:Content>
