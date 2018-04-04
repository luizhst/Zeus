<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="IncluirHistCarga.aspx.vb" Inherits="Project_Zeus.IncluirHistCarga" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="row">
        <br />
        <br />
        <div class="col-md-12">
            <div class="panel" style="box-shadow: unset">

                <div class="panel-wrapper collapse in" aria-expanded="false">
                    <div class="panel-body">

                        <div class="form-body">
                            <h3 class="box-title">Registrar entrada de carregamento/descarregamento</h3>

                            <br />
                            <%--<h4>Dados</h4>--%>
                            <hr />

                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label ">Código</label>
                                        <asp:TextBox runat="server" ID="txt_cod_hist" MaxLength="150" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label ">Data da Nota</label>
                                        <asp:TextBox runat="server" ID="txt_data_nota" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label ">Nota Fiscal</label>
                                        <asp:TextBox runat="server" MaxLength="50" ClientIDMode="Static" ID="txt_notafiscal" CssClass="form-control"></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label ">Pedido de Compra</label>
                                        <asp:TextBox runat="server" MaxLength="50" ClientIDMode="Static" ID="txt_pedidocompra" CssClass="form-control"></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label ">Origem / Destino</label>
                                        <asp:TextBox runat="server" required="true" MaxLength="50" ClientIDMode="Static" ID="txt_origem_destino" CssClass="form-control"></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label ">Motorista</label>
                                        <asp:TextBox runat="server" required="true" MaxLength="50" ClientIDMode="Static" ID="txt_motorista" CssClass="form-control"></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label ">Transportadora</label>
                                        <asp:TextBox runat="server" required="true" MaxLength="50" ClientIDMode="Static" ID="txt_transportadora" CssClass="form-control"></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label ">Placa 1</label>
                                        <asp:TextBox runat="server" required="true" MaxLength="8" ClientIDMode="Static" ID="txt_placa1" CssClass="form-control"></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label ">Placa 2</label>
                                        <asp:TextBox runat="server" MaxLength="8" ClientIDMode="Static" ID="txt_placa2" CssClass="form-control"></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label">Placa 3</label>
                                        <asp:TextBox runat="server" MaxLength="8" ClientIDMode="Static" ID="txt_placa3" CssClass="form-control"></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label">Tipo</label>
                                        <asp:DropDownList AutoPostBack="false" runat="server" AppendDataBoundItems="true" CssClass="dropdown form-control" SelectionMode="sigle" MaxLength="50" ID="drp_tipo">
                                            <asp:ListItem Value="Carregar" Text="Carregar" />
                                            <asp:ListItem Value="Descarregar" Text="Descarregar" />
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label">Status</label>
                                        <asp:DropDownList AutoPostBack="false   " runat="server" AppendDataBoundItems="true" CssClass="dropdown form-control" SelectionMode="sigle" MaxLength="50" ID="drp_status">
                                            <asp:ListItem Value="False" Text="Aguardando" />
                                            <asp:ListItem Value="True" Text="Liberado" />
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <br />
                            <h4>Dados complementares</h4>
                            <hr />

                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label ">Data Registro</label>
                                        <asp:TextBox runat="server" ID="txt_registro" MaxLength="50" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label ">Última Atualização</label>
                                        <asp:TextBox runat="server" ID="txt_update" MaxLength="250" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>
                                <br />
                            </div>

                            <br />

                            <div>
                                <asp:Button runat="server" CssClass="btn btn-success" ID="btn_registrar" Text="Cadastrar" OnClick="btn_registrar_Click" />
                                <a class="btn btn-default" href="../Default.aspx">Voltar</a>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>

    </div>

</asp:Content>
