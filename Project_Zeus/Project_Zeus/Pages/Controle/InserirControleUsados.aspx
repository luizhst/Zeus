<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="InserirControleUsados.aspx.vb" Inherits="Project_Zeus.InserirControleUsados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="row">
        <br />
        <br />
        <div class="col-md-12">
            <div class="panel" style="box-shadow: unset">

                <div class="panel-wrapper collapse in" aria-expanded="false">
                    <div class="panel-body">

                        <div class="form-body">
                            <h3 class="box-title">Lançamento de Nota Fiscal de Usados</h3>

                            <br />
                            <h4>Dados da nota</h4>

                            <hr>



                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label ">Código</label>
                                        <asp:TextBox runat="server" ID="txt_cod" MaxLength="150" CssClass="form-control" ReadOnly="true"></asp:TextBox>
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
                                        <label class="control-label ">Data Nota Fiscal</label>
                                        <asp:TextBox runat="server" MaxLength="50" ClientIDMode="Static" ID="txt_dta_notafiscal" CssClass="form-control"></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>

                            </div>

                            <div class="row">

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label">Tipo Nota Fiscal</label>
                                        <asp:DropDownList AutoPostBack="false   " runat="server" AppendDataBoundItems="true" CssClass="dropdown form-control" SelectionMode="sigle" MaxLength="50" ID="DropDownList2">
                                            <asp:ListItem Value="E" Text="Entrada" />
                                            <asp:ListItem Value="S" Text="Saída" />
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label ">CNPJ Origem</label>
                                        <asp:TextBox runat="server" MaxLength="50" ClientIDMode="Static" ID="txt_cnpj_nota" CssClass="form-control"></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label ">Origem / Destino</label>
                                        <asp:TextBox runat="server" required="true" MaxLength="50" ClientIDMode="Static" ID="txt_origem_destino" CssClass="form-control"></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>

                            </div>

                            <br />
                            <h4>Dados do produto</h4>
                            <hr />

                            <div class="row">

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label">Produto</label>
                                        <asp:DropDownList AutoPostBack="false" runat="server" AppendDataBoundItems="true" CssClass="dropdown form-control" SelectionMode="sigle" MaxLength="50" ID="DropDownList1">
                                            <asp:ListItem Value="PBR" Text="PBR Usado" />
                                            <asp:ListItem Value="ONEWAY" Text="OneWay Usado" />
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label ">Qtde Total</label>
                                        <asp:TextBox runat="server" required="true" MaxLength="50" ClientIDMode="Static" ID="txt_qtde_total" CssClass="form-control"></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>
                            </div>

                            <div class="row">

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label ">Qtde Fora Padrão</label>
                                        <asp:TextBox runat="server" required="true" MaxLength="50" ClientIDMode="Static" ID="txt_qtde_fpq" CssClass="form-control"></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label ">Percentual Sucata</label>
                                        <asp:TextBox runat="server" required="true" MaxLength="50" ClientIDMode="Static" ID="txt_perc_sucata" CssClass="form-control"></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label ">Qtde Sucata</label>
                                        <asp:TextBox runat="server" ReadOnly="true" required="true" MaxLength="50" ClientIDMode="Static" ID="txt_qtde_sucata" CssClass="form-control"></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>
                            </div>

                            <div class="row">

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label ">Qtde Total Liquido</label>
                                        <asp:TextBox runat="server" MaxLength="50" ReadOnly="true" ClientIDMode="Static" ID="txt_total_liquido" CssClass="form-control"></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label">Qtde Disponível</label><span> (Estoque da nota)</span>
                                        <asp:TextBox runat="server" ReadOnly="true" MaxLength="50" ClientIDMode="Static" ID="txt_total_disponivel" CssClass="form-control"></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>

                            </div>

                            <br />
                            <h4>Dados complementares</h4>
                            <hr />

                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label">Faturado Sucada</label>
                                        <asp:DropDownList AutoPostBack="false" runat="server" AppendDataBoundItems="true" CssClass="dropdown form-control" SelectionMode="sigle" MaxLength="50" ID="drp_faturado_sucata">
                                            <asp:ListItem Value="Não" Text="Não" />
                                            <asp:ListItem Value="Sim" Text="Sim" />
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label class="control-label">Faturado Fora do Padrão</label>
                                        <asp:DropDownList AutoPostBack="false   " runat="server" AppendDataBoundItems="true" CssClass="dropdown form-control" SelectionMode="sigle" MaxLength="50" ID="drp_faturado_fpq">
                                            <asp:ListItem Value="Não" Text="Não" />
                                            <asp:ListItem Value="Sim" Text="Sim" />
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

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
                                        <label class="control-label ">Usuario Registro</label>
                                        <asp:TextBox runat="server" ID="txt_usuario" MaxLength="250" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                        <span class="help-block"></span>
                                    </div>
                                </div>
                                <br />
                            </div>

                            <br />

                            <div>
                                <asp:Button runat="server" CssClass="btn btn-success" ID="btn_registrar" Text="Cadastrar" />
                                <a class="btn btn-default" href="../Default.aspx">Voltar</a>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>

    </div>

</asp:Content>
